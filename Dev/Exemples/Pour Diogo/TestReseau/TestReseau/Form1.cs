using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Apache.NMS;
using Apache.NMS.Util;

//Package ActiveMQ installé
//Aide sur 
//https://www.pmichaels.net/2016/09/29/a-c-programmers-guide-to-installing-running-and-messaging-with-activemq/
//Test du lancement de ActiveMQ avec le lien http://localhost:8161/admin/topics.jsp (admin / admin)
//L'install de ActiveMQ est sur C:\Data\Cours\2018-2019\ProjetCsharp\TestActiveMQ\ConsoleApp1 chez moi


namespace TestReseau
{
    public partial class frmTestReseau : Form
    {
        //On crée notre delegate.
        public delegate void GetResponse(string response);

        public frmTestReseau()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            SendNewMessageQueue(txtPosition.Text);
        }

        private void frmTestReseau_Load(object sender, EventArgs e)
        {
            Thread thRead = new Thread(ReadNextMessageQueue);

            //Un thread, ça ne part pas tout seul. Il faut lui indiquer de commencer l'exécution.
            thRead.Start();
        }

        private void ReadNextMessageQueue()
        {
            while (true)
            {
                //Attention, lit les messages dans la queue de l'autre joueur
                //queuename = "Q" + idOtherPlayer.
                string queueName = "Q1";
                Console.WriteLine(queueName);

                string brokerUri = $"activemq:tcp://localhost:61616";  // Default port
                NMSConnectionFactory factory = new NMSConnectionFactory(brokerUri);

                using (IConnection connection = factory.CreateConnection())
                {
                    connection.Start();
                    using (ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge))
                    using (IDestination dest = session.GetQueue(queueName))
                    using (IMessageConsumer consumer = session.CreateConsumer(dest))
                    {
                        IMessage msg = consumer.Receive();
                        if (msg is ITextMessage)
                        {
                            ITextMessage txtMsg = msg as ITextMessage;
                            string body = txtMsg.Text;

                            Console.WriteLine($"Received message: {txtMsg.Text}");

                            string value = "";
                            if (txtMsg.Text == "A2")
                            {
                                value = "touche";
                            } else
                            {
                                value = "raté";
                            }

                            try
                            {
                                //On invoque le delegate pour qu'il effectue la tâche sur le temps de l'autre thread.
                                Invoke((GetResponse)DisplayResponse, value);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Erreur invoke" + ex.Message);
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Unexpected message type: " + msg.GetType().Name);
                        }
                    }
                }
            }
        }

        private void SendNewMessageQueue(string text)
        {
            //Envoie les messages dans sa propre queue
            //queuename = "Q" + idPlayer.
            string queueName = "Q1";

            Console.WriteLine($"Adding message to queue topic: {queueName}");

            string brokerUri = $"activemq:tcp://localhost:61616";  // Default port
            NMSConnectionFactory factory = new NMSConnectionFactory(brokerUri);

            using (IConnection connection = factory.CreateConnection())
            {
                connection.Start();

                using (ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge))
                using (IDestination dest = session.GetQueue(queueName))
                using (IMessageProducer producer = session.CreateProducer(dest))
                {
                    producer.DeliveryMode = MsgDeliveryMode.NonPersistent;

                    producer.Send(session.CreateTextMessage(text));
                    Console.WriteLine($"Sent {text} messages");
                }
            }
        }

        private void DisplayResponse(string res)
        {
            lblReponse.Text = res;
        }

    }
}
