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
        private int _menu;
        private int _score;
        private string _player01;
        private string _player02;
        private bool _multi;
        public void LocalSolo_click(object sender, EventArgs e)
        {
            askUserName(1);
        }

        public void LocalMulti_click(object sender, EventArgs e)
        {
            askUserName(2);
        }

        private void askUserName(int oneOrTwoPlayers)
        {
            _multi = false;
            _msgBox = new View("Infos");
            _msgBox.Size = new Size(200, 150);


            Label lblInfo01 = new Label();
            lblInfo01.Text = "votre nom:";
            lblInfo01.Name = "lblInfo";
            lblInfo01.Location = new Point(15, 5);
            _msgBox.Controls.Add(lblInfo01);

            TextBox txtPlayer01 = new TextBox();
            txtPlayer01.Name = "txtPlayer01";
            txtPlayer01.Size = new Size(_msgBox.Size.Width - 40, 20);
            txtPlayer01.Location = new Point(15, lblInfo01.Location.Y + lblInfo01.Size.Height);
            _msgBox.Controls.Add(txtPlayer01);
            
            Button cmdOk = new Button();
            cmdOk.Name = "cmdOk";
            cmdOk.Text = "Ok";
            cmdOk.AutoSize = true;
            cmdOk.Location = new Point(txtPlayer01.Location.X + txtPlayer01.Size.Width - cmdOk.Size.Width, txtPlayer01.Location.Y + txtPlayer01.Size.Height + 5);
            cmdOk.Click += CmdOk_Click;
            _msgBox.Controls.Add(cmdOk);

            
            if (oneOrTwoPlayers == 2)
            {
                _multi = true;
                _msgBox.Size = new Size(200, 170);

                Label lblInfo02 = new Label();
                lblInfo02.Text = "nom joueur 02:";
                lblInfo02.Name = "lblInfo02";
                lblInfo02.Location = new Point(15, txtPlayer01.Location.Y + txtPlayer01.Size.Height);
                _msgBox.Controls.Add(lblInfo02);

                TextBox txtPlayer02 = new TextBox();
                txtPlayer02.Name = "txtPlayer02";
                txtPlayer02.Size = new Size(_msgBox.Size.Width - 40, 20);
                txtPlayer02.Location = new Point(15, lblInfo02.Location.Y + lblInfo02.Size.Height);
                _msgBox.Controls.Add(txtPlayer02);


                cmdOk.Location = new Point(txtPlayer02.Location.X + txtPlayer02.Size.Width - cmdOk.Size.Width, txtPlayer02.Location.Y + txtPlayer02.Size.Height + 5);
            }

            _msgBox.Show();
            
        }


        private void CmdOk_Click(object sender, EventArgs e)
        {
            if(_multi)
            {
                if(_msgBox.Controls.Find("txtPlayer01", true)[0].Text == "" || _msgBox.Controls.Find("txtPlayer02", true)[0].Text == "" || _msgBox.Controls.Find("txtPlayer01", true)[0].Text.Length> 11 || _msgBox.Controls.Find("txtPlayer02", true)[0].Text.Length > 11)
                        MessageBox.Show("Merci de rentrer un nom d'utilisateur ayant au maximum 11 lettres", "Nom utilisateur manquant", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    _player01 = _msgBox.Controls.Find("txtPlayer01", true)[0].Text;
                    _player02 = _msgBox.Controls.Find("txtPlayer02", true)[0].Text;
                    _msgBox.Close();
                    _view.Text = "Morpion: Bienvenue " + _player01 + " et " + _player02;
                }
            }
            else
            {
                if (_msgBox.Controls.Find("txtPlayer01", true)[0].Text == "" || _msgBox.Controls.Find("txtPlayer01", true)[0].Text.Length > 11)
                {
                    MessageBox.Show("Merci de rentrer un nom d'utilisateur ayant au maximum 11 lettres", "Nom utilisateur manquant", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _player01 = _msgBox.Controls.Find("txtPlayer01", true)[0].Text;
                    _player02 = "Ordinateur";
                    _msgBox.Close();
                    _view.Text = "Morpion: Bienvenue " + _player01;
                }
            }
            
        }

        public void Network_click(object sender, EventArgs e)
        {

        }
        public void Rules_click(object sender, EventArgs e)
        {

        }
        public void Infos_click(object sender, EventArgs e)
        {

        }
        private void topMenu()
        {

            MenuStrip mnu;
            ToolStripMenuItem mnuLocal;
            ToolStripMenuItem mnuLocalSolo;
            ToolStripMenuItem mnuLocalMulti;
            ToolStripMenuItem mnuNetwork;
            ToolStripMenuItem mnuRules;
            ToolStripMenuItem mnuInfos;

            mnu = new MenuStrip();
            mnuLocal = new ToolStripMenuItem();
            mnuLocalSolo = new ToolStripMenuItem();
            mnuLocalMulti = new ToolStripMenuItem();
            mnuNetwork = new ToolStripMenuItem();
            mnuRules = new ToolStripMenuItem();
            mnuInfos = new ToolStripMenuItem();
            
            mnu.SuspendLayout();

            //insert menus in menustrip
            mnu.Name = "mnu";
            mnu.Text = "mnu";
            mnu.BackColor = Color.Silver;
            mnu.Items.AddRange(new ToolStripItem[] {   mnuLocal,
                                                                            mnuNetwork,
                                                                            mnuRules,
                                                                            mnuInfos});
            mnu.Location = new Point(0, 0);
            mnu.Size = new Size(600, 24);
            mnu.TabIndex = 0;

            // add local menu in mnu
            mnuLocal.BackgroundImageLayout = ImageLayout.None;
            mnuLocal.DropDownItems.AddRange(new ToolStripItem[] {  mnuLocalSolo,
                                                                                        mnuLocalMulti});
            mnuLocal.Name = "mnuLocal";
            mnuLocal.Size = new Size(86, 20);
            mnuLocal.Text = "Partie Locale";

            //add solo button in local menu
            mnuLocalSolo.Name = "mnuLocalSolo";
            mnuLocalSolo.Size = new Size(180, 22);
            mnuLocalSolo.Text = "En Solo";
            mnuLocalSolo.Click += LocalSolo_click;

            //add multijoueur button in local menu
            mnuLocalMulti.Name = "mnuLocalMulti";
            mnuLocalMulti.Size = new Size(180, 22);
            mnuLocalMulti.Text = "En Multijoueur";
            mnuLocalMulti.Click += LocalMulti_click;

            //create mnuNetwork in mnu
            mnuNetwork.Name = "mnuNetwork";
            mnuNetwork.Size = new Size(120, 20);
            mnuNetwork.Text = "Partie sur le Réseau";
            mnuNetwork.Click += Network_click;

            //create mnuRules in mnu
            mnuRules.Name = "mnuRules";
            mnuRules.Size = new Size(53, 20);
            mnuRules.Text = "Règles";
            mnuRules.Click += Rules_click;

            //create mnuInfos in mnu
            mnuInfos.Name = "mnuInfos";
            mnuInfos.Size = new Size(87, 20);
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
            Button cmdLocalSolo;
            Button cmdLocalMulti;
            Button cmdNetwork;
            Button cmdRules;
            Button cmdInfos;


            cmdLocalSolo = new Button();
            cmdLocalMulti = new Button();
            cmdNetwork = new Button();
            cmdRules = new Button();
            cmdInfos = new Button();
            // 
            // cmdLocalSolo
            // 
            cmdLocalSolo.Location = new Point(0, 25);
            cmdLocalSolo.Name = "cmdLocalSolo";
            cmdLocalSolo.Size = new Size(785, 107);
            cmdLocalSolo.TabIndex = 0;
            cmdLocalSolo.Text = "Solo";
            cmdLocalSolo.UseVisualStyleBackColor = true;
            // 
            // cmdLocalMulti
            // 
            cmdLocalMulti.Location = new Point(0, 132);
            cmdLocalMulti.Name = "cmdLocalMulti";
            cmdLocalMulti.Size = new Size(785, 107);
            cmdLocalMulti.TabIndex = 2;
            cmdLocalMulti.Text = "Multiojoueur";
            cmdLocalMulti.UseVisualStyleBackColor = true;
            // 
            // cmdNetwork
            // 
            cmdNetwork.Location = new Point(0, 239);
            cmdNetwork.Name = "cmdNetwork";
            cmdNetwork.Size = new Size(785, 107);
            cmdNetwork.TabIndex = 3;
            cmdNetwork.Text = "Partie sur le Réseau";
            cmdNetwork.UseVisualStyleBackColor = true;
            // 
            // cmdRules
            // 
            cmdRules.Location = new Point(0, 346);
            cmdRules.Name = "cmdRules";
            cmdRules.Size = new Size(785, 107);
            cmdRules.TabIndex = 4;
            cmdRules.Text = "Règles";
            cmdRules.UseVisualStyleBackColor = true;
            // 
            // cmdInfos
            // 
            cmdInfos.Location = new Point(0, 453);
            cmdInfos.Name = "cmdInfos";
            cmdInfos.Size = new Size(785, 107);
            cmdInfos.TabIndex = 5;
            cmdInfos.Text = "Informations";
            cmdInfos.UseVisualStyleBackColor = true;

            _view.Controls.Add(cmdLocalSolo);
            _view.Controls.Add(cmdLocalMulti);
            _view.Controls.Add(cmdNetwork);
            _view.Controls.Add(cmdRules);
            _view.Controls.Add(cmdInfos);
        }

        private void game_int()
        {
            _view.Controls.Clear();


            Label lblPlayer01 = new Label();
            Label lblWinP01 = new Label();
            Label lblScoreP01 = new Label();
            // 
            // lblPlayer01
            // 
            lblPlayer01.AutoSize = true;
            lblPlayer01.Font = new Font("Microsoft Sans Serif", 20.25F, ((FontStyle)((FontStyle.Bold | FontStyle.Italic))), GraphicsUnit.Point, ((byte)(0)));
            lblPlayer01.Location = new Point(12, 105);
            lblPlayer01.Name = "lblPlayer01";
            lblPlayer01.Size = new Size(187, 31);
            lblPlayer01.Text = "NoxCaedibux";
            _view.Controls.Add(lblPlayer01);

            // 
            // lblWinP01
            // 
            lblWinP01.AutoSize = true;
            lblWinP01.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            lblWinP01.Location = new Point(45, 157);
            lblWinP01.Name = "lblWinP01";
            lblWinP01.Size = new Size(95, 25);
            lblWinP01.Text = "Victoires";
            _view.Controls.Add(lblWinP01);

            // 
            // lblScoreP01
            // 
            lblScoreP01.AutoSize = true;
            lblScoreP01.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            lblScoreP01.Location = new Point(66, 182);
            lblScoreP01.Name = "lblScoreP01";
            lblScoreP01.Size = new Size(47, 33);
            lblScoreP01.Text = _score.ToString();
            _view.Controls.Add(lblScoreP01);

            Label lblPlayer02 = lblPlayer01;
            Label lblWinP02 = lblWinP01;
            Label lblScoreP02 = lblScoreP01;

            lblPlayer02.Location = new Point(659, 182);
            _view.Controls.Add(lblPlayer02);
            lblWinP02.Location = new Point(638, 157);
            _view.Controls.Add(lblWinP02);
            lblScoreP02.Location = new Point(605, 105);
            _view.Controls.Add(lblScoreP02);

            PictureBox[] picCases;
            picCases = new PictureBox[9];
            Point location;
            int y;
            int x;
            for(int i=0 ; i<10 ; i++)
            {
                picCases[i] = new PictureBox();
                picCases[i].Name = "pic"+i;
                picCases[i].Size = new System.Drawing.Size(90, 90);
                
                if(i == 0 || i == 2 || i == 5)
                {
                    x = 264;
                }

                if(i<3)
                {
                    y = 33;
                    
                }
                else if (i<6)
                {
                    y = 130;
                }
                else
                {
                    y = 229;
                }
                picCases[i].Location = new Point(x,y);
                x += 97;
                _view.Controls.Add(picCases[i]);
            }


    }
        public void Show_interface(View view, int menus=0)
        {
            _view = view;
            _menu = menu;
            topMenu();
            switch(_menu)
            {
                case 0: // main menu
                    _viewSize = new Size(785, 560);
                    main_menu();
                    break;
                case 1:
                    _viewSize = new Size(820, 371);
                    game_int();
                    break;
                default:
                    break;
            }
            _view.ClientSize = _viewSize;
        }


        public int menu
        {
            get
            {
                return _menu;
            }
        }
    }
}
