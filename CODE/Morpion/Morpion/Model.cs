using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Morpion
{
    /// <summary>
    /// 
    /// </summary>
    class Model
    {
        private DataBase db = new DataBase("Morpion");
        private View _view;
        private View _msgBox;
        private Size _viewSize;
        private string _player01;
        private string _player02;
        
        private void LocalSolo_click(object sender, EventArgs e)
        {
            _msgBox = new View("Infos");
            _msgBox.Size = new Size(200, 150);
            

            Label lblInfo = new Label();
            lblInfo.Text = "votre nom:";
            lblInfo.Name = "lblInfo";
            lblInfo.Location = new Point(15, 5);
            _msgBox.Controls.Add(lblInfo);

            TextBox txtUserName = new TextBox();
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(_msgBox.Size.Width - 40, 20);
            txtUserName.Location = new Point(15, lblInfo.Location.Y+lblInfo.Size.Height);
            _msgBox.Controls.Add(txtUserName);

            Button cmdOk = new Button();
            cmdOk.Name = "cmdOk";
            cmdOk.Text = "Ok";
            cmdOk.AutoSize = true;
            cmdOk.Location = new Point(txtUserName.Location.X+txtUserName.Size.Width-cmdOk.Size.Width, txtUserName.Location.Y+txtUserName.Size.Height+5);
            cmdOk.Click += CmdOk_Click;

            _msgBox.Controls.Add(cmdOk);

            _msgBox.Show();
            
        }


        private void CmdOk_Click(object sender, EventArgs e)
        {
            //je dois check si txtUserName.text est vide, mais j'arrive pas à récup son contenu :/ et je sais pas l'envoyer
            if (_msgBox.Controls.Find("txtUserName", true)[0].Text == "")
            {
                MessageBox.Show("Merci de rentrer un nom d'utilisateur", "Nom utilisateur manquant", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                _player01 = _msgBox.Controls.Find("txtUserName", true)[0].Text;
                _player02 = "Ordinateur";
                _msgBox.Close();
                _view.Text += ": Bienvenue " + _player01;
            }
        }

        private void LocalMulti_click(object sender, EventArgs e)
        {

        }
        private void Network_click(object sender, EventArgs e)
        {

        }
        private void Rules_click(object sender, EventArgs e)
        {

        }
        private void Infos_click(object sender, EventArgs e)
        {

        }
        private void topMenu()
        {

            System.Windows.Forms.MenuStrip mnu;
            System.Windows.Forms.ToolStripMenuItem mnuLocal;
            System.Windows.Forms.ToolStripMenuItem mnuLocalSolo;
            System.Windows.Forms.ToolStripMenuItem mnuLocalMulti;
            System.Windows.Forms.ToolStripMenuItem mnuNetwork;
            System.Windows.Forms.ToolStripMenuItem mnuRules;
            System.Windows.Forms.ToolStripMenuItem mnuInfos;

            mnu = new System.Windows.Forms.MenuStrip();
            mnuLocal = new System.Windows.Forms.ToolStripMenuItem();
            mnuLocalSolo = new System.Windows.Forms.ToolStripMenuItem();
            mnuLocalMulti = new System.Windows.Forms.ToolStripMenuItem();
            mnuNetwork = new System.Windows.Forms.ToolStripMenuItem();
            mnuRules = new System.Windows.Forms.ToolStripMenuItem();
            mnuInfos = new System.Windows.Forms.ToolStripMenuItem();
            
            mnu.SuspendLayout();

            //insert menus in menustrip
            mnu.Name = "mnu";
            mnu.Text = "mnu";
            mnu.BackColor = System.Drawing.Color.Silver;
            mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {   mnuLocal,
                                                                            mnuNetwork,
                                                                            mnuRules,
                                                                            mnuInfos});
            mnu.Location = new System.Drawing.Point(0, 0);
            mnu.Size = new System.Drawing.Size(600, 24);
            mnu.TabIndex = 0;

            // add local menu in mnu
            mnuLocal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            mnuLocal.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {  mnuLocalSolo,
                                                                                        mnuLocalMulti});
            mnuLocal.Name = "mnuLocal";
            mnuLocal.Size = new System.Drawing.Size(86, 20);
            mnuLocal.Text = "Partie Locale";

            //add solo button in local menu
            mnuLocalSolo.Name = "mnuLocalSolo";
            mnuLocalSolo.Size = new System.Drawing.Size(180, 22);
            mnuLocalSolo.Text = "En Solo";
            mnuLocalSolo.Click += LocalSolo_click;

            //add multijoueur button in local menu
            mnuLocalMulti.Name = "mnuLocalMulti";
            mnuLocalMulti.Size = new System.Drawing.Size(180, 22);
            mnuLocalMulti.Text = "En Multijoueur";
            mnuLocalMulti.Click += LocalMulti_click;

            //create mnuNetwork in mnu
            mnuNetwork.Name = "mnuNetwork";
            mnuNetwork.Size = new System.Drawing.Size(120, 20);
            mnuNetwork.Text = "Partie sur le Réseau";
            mnuNetwork.Click += Network_click;

            //create mnuRules in mnu
            mnuRules.Name = "mnuRules";
            mnuRules.Size = new System.Drawing.Size(53, 20);
            mnuRules.Text = "Règles";
            mnuRules.Click += Rules_click;

            //create mnuInfos in mnu
            mnuInfos.Name = "mnuInfos";
            mnuInfos.Size = new System.Drawing.Size(87, 20);
            mnuInfos.Text = "Informations";
            mnuNetwork.Click += Infos_click;

            //menu strip on the top of form and add it on the form
            _view.Controls.Add(mnu);
            _view.MainMenuStrip = mnu;
            mnu.ResumeLayout(false);
            mnu.PerformLayout();
        }

        private void main_menu()
        {
            System.Windows.Forms.Button cmdLocalSolo;
            System.Windows.Forms.Button cmdLocalMulti;
            System.Windows.Forms.Button cmdNetwork;
            System.Windows.Forms.Button cmdRules;
            System.Windows.Forms.Button cmdInfos;


            cmdLocalSolo = new System.Windows.Forms.Button();
            cmdLocalMulti = new System.Windows.Forms.Button();
            cmdNetwork = new System.Windows.Forms.Button();
            cmdRules = new System.Windows.Forms.Button();
            cmdInfos = new System.Windows.Forms.Button();
            // 
            // cmdLocalSolo
            // 
            cmdLocalSolo.Location = new System.Drawing.Point(0, 25);
            cmdLocalSolo.Name = "cmdLocalSolo";
            cmdLocalSolo.Size = new System.Drawing.Size(785, 107);
            cmdLocalSolo.TabIndex = 0;
            cmdLocalSolo.Text = "cmdLocalSolo";
            cmdLocalSolo.UseVisualStyleBackColor = true;
            cmdLocalSolo.Click += LocalSolo_click;
            // 
            // cmdLocalMulti
            // 
            cmdLocalMulti.Location = new System.Drawing.Point(0, 132);
            cmdLocalMulti.Name = "cmdLocalMulti";
            cmdLocalMulti.Size = new System.Drawing.Size(785, 107);
            cmdLocalMulti.TabIndex = 2;
            cmdLocalMulti.Text = "cmdLocalMulti";
            cmdLocalMulti.UseVisualStyleBackColor = true;
            cmdLocalMulti.Click += LocalMulti_click;
            // 
            // cmdNetwork
            // 
            cmdNetwork.Location = new System.Drawing.Point(0, 239);
            cmdNetwork.Name = "cmdNetwork";
            cmdNetwork.Size = new System.Drawing.Size(785, 107);
            cmdNetwork.TabIndex = 3;
            cmdNetwork.Text = "cmdNetwork";
            cmdNetwork.UseVisualStyleBackColor = true;
            cmdNetwork.Click += Network_click;
            // 
            // cmdRules
            // 
            cmdRules.Location = new System.Drawing.Point(0, 346);
            cmdRules.Name = "cmdRules";
            cmdRules.Size = new System.Drawing.Size(785, 107);
            cmdRules.TabIndex = 4;
            cmdRules.Text = "cmdRules";
            cmdRules.UseVisualStyleBackColor = true;
            cmdRules.Click += Rules_click;
            // 
            // cmdInfos
            // 
            cmdInfos.Location = new System.Drawing.Point(0, 453);
            cmdInfos.Name = "cmdInfos";
            cmdInfos.Size = new System.Drawing.Size(785, 107);
            cmdInfos.TabIndex = 5;
            cmdInfos.Text = "cmdInfos";
            cmdInfos.UseVisualStyleBackColor = true;
            cmdInfos.Click += Infos_click;

            _view.Controls.Add(cmdLocalSolo);
            _view.Controls.Add(cmdLocalMulti);
            _view.Controls.Add(cmdNetwork);
            _view.Controls.Add(cmdRules);
            _view.Controls.Add(cmdInfos);
        }
        public void Show_interface(View view, int menus=0)
        {
            _view = view;
            topMenu();
            switch(menus)
            {
                case 0: // main menu
                    _viewSize = new Size(785, 560);
                    main_menu();
                    break;
                default:
                    break;
            }
            _view.ClientSize = _viewSize;
        }
    }
}
