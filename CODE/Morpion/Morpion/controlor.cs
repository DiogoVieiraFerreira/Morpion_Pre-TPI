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
    class Controlor
    {
        private Model _model;
        private View _view;
        private View _msgBox;

        private TextBox _txtPlayer01;
        private TextBox _txtPlayer02;

        /// <summary>
        /// Constructor of control, he call model and ask all data before to execute program
        /// </summary>
        public Controlor()
        {
            _view = new View("Morpion");
            _view.FormBorderStyle = FormBorderStyle.FixedSingle;
            _view.StartPosition = FormStartPosition.CenterScreen;
            _model = new Model();
            _model.dbLimit = 10;
            _model.view = _view;
            _view.SuspendLayout();
            Show_interface();
            _view.ResumeLayout(false);
            _view.PerformLayout();
            End_program();
        }
        /// <summary>
        /// menu 0: welcome page,
        /// menu 1: game interface
        /// </summary>
        /// <param name="menu">type of interface</param>
        private void Show_interface(int menu = 0)
        {
            _view.Controls.Clear();
            Size viewSize = new Size();
            topMenu();
            switch (menu)
            {
                case 0: // main menu
                    viewSize = new Size(785, 560);
                    main_menu();
                    break;
                case 1:
                    viewSize = new Size(804, 339);
                    game_int();
                    break;
                default:
                    break;
            }
            _view.ClientSize = viewSize;
        }

        /// <summary>
        /// display the top menu
        /// </summary>
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
            cmdLocalSolo.Click += LocalSolo_click;
            // 
            // cmdLocalMulti
            // 
            cmdLocalMulti.Location = new Point(0, 132);
            cmdLocalMulti.Name = "cmdLocalMulti";
            cmdLocalMulti.Size = new Size(785, 107);
            cmdLocalMulti.TabIndex = 2;
            cmdLocalMulti.Text = "Multiojoueur";
            cmdLocalMulti.UseVisualStyleBackColor = true;
            cmdLocalMulti.Click += LocalMulti_click;
            // 
            // cmdNetwork
            // 
            cmdNetwork.Location = new Point(0, 239);
            cmdNetwork.Name = "cmdNetwork";
            cmdNetwork.Size = new Size(785, 107);
            cmdNetwork.TabIndex = 3;
            cmdNetwork.Text = "Partie sur le Réseau";
            cmdNetwork.UseVisualStyleBackColor = true;
            cmdNetwork.Click += Network_click;
            // 
            // cmdRules
            // 
            cmdRules.Location = new Point(0, 346);
            cmdRules.Name = "cmdRules";
            cmdRules.Size = new Size(785, 107);
            cmdRules.TabIndex = 4;
            cmdRules.Text = "Règles";
            cmdRules.UseVisualStyleBackColor = true;
            cmdRules.Click += Rules_click;
            // 
            // cmdInfos
            // 
            cmdInfos.Location = new Point(0, 453);
            cmdInfos.Name = "cmdInfos";
            cmdInfos.Size = new Size(785, 107);
            cmdInfos.TabIndex = 5;
            cmdInfos.Text = "Informations";
            cmdInfos.UseVisualStyleBackColor = true;
            cmdInfos.Click += Infos_click;

            _view.Controls.Add(cmdLocalSolo);
            _view.Controls.Add(cmdLocalMulti);
            _view.Controls.Add(cmdNetwork);
            _view.Controls.Add(cmdRules);
            _view.Controls.Add(cmdInfos);
        }

        private void game_int()
        {

            _model.GameArray = new int[] { 0,0,0,
                                         0,0,0,
                                         0,0,0 };
            _model.WhatPlayer = 1;

            Label lblPlayer01 = new Label();
            Label lblWinP01 = new Label();
            Label lblScoreP01 = new Label();
            // 
            // lblPlayer01
            // 
            lblPlayer01.AutoSize = false;
            lblPlayer01.Font = new Font("Microsoft Sans Serif", 20.25F, ((FontStyle)((FontStyle.Bold | FontStyle.Italic))), GraphicsUnit.Point, ((byte)(0)));
            lblPlayer01.Location = new Point(12, 105);
            lblPlayer01.Name = "lblPlayer01";
            lblPlayer01.Size = new Size(187, 31);
            lblPlayer01.TextAlign = ContentAlignment.MiddleCenter;
            lblPlayer01.Text = _model.nameP1;
            _view.Controls.Add(lblPlayer01);

            // 
            // lblWinP01
            // 
            lblWinP01.AutoSize = false;
            lblWinP01.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            lblWinP01.Location = new Point(55, 157);
            lblWinP01.Name = "lblWinP01";
            lblWinP01.Size = new Size(95, 25);
            lblWinP01.Text = "Victoires";
            _view.Controls.Add(lblWinP01);

            // 
            // lblScoreP01
            // 
            lblScoreP01.AutoSize = false;
            lblScoreP01.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            lblScoreP01.Location = new Point(76, 182);
            lblScoreP01.Name = "lblScoreP01";
            lblScoreP01.Size = new Size(47, 33);
            lblScoreP01.TextAlign = ContentAlignment.MiddleCenter;
            lblScoreP01.Text = _model.scoreP1.ToString();
            _view.Controls.Add(lblScoreP01);

            // 
            // lblPlayer02
            // 
            Label lblPlayer02 = new Label();
            lblPlayer02.AutoSize = false;
            lblPlayer02.Font = new Font("Microsoft Sans Serif", 20.25F, ((FontStyle)((FontStyle.Bold | FontStyle.Italic))), GraphicsUnit.Point, ((byte)(0)));
            lblPlayer02.Location = new Point(605, 105);
            lblPlayer02.Name = "lblPlayer02";
            lblPlayer02.Size = new Size(187, 31);
            lblPlayer02.TabIndex = 12;
            lblPlayer02.TextAlign = ContentAlignment.MiddleCenter;
            lblPlayer02.Text = _model.nameP2;
            _view.Controls.Add(lblPlayer02);


            // 
            // lblWinP02
            // 
            Label lblWinP02 = new Label();
            lblWinP02.AutoSize = false;
            lblWinP02.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            lblWinP02.Location = new Point(638, 157);
            lblWinP02.Name = "lblWinP02";
            lblWinP02.Size = new Size(95, 25);
            lblWinP02.TabIndex = 13;
            lblWinP02.Text = "Victoires";
            _view.Controls.Add(lblWinP02);

            // 
            // lblScoreP02
            // 
            Label lblScoreP02 = new Label();
            lblScoreP02.AutoSize = false;
            lblScoreP02.Font = new Font("Microsoft Sans Serif", 21.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            lblScoreP02.Location = new Point(659, 182);
            lblScoreP02.Name = "lblScoreP02";
            lblScoreP02.Size = new Size(47, 33);
            lblScoreP02.TabIndex = 14;
            lblScoreP02.TextAlign = ContentAlignment.MiddleCenter;
            lblScoreP02.Text = _model.scoreP2.ToString(); ;
            _view.Controls.Add(lblScoreP02);

            PictureBox[] picCases = new PictureBox[9];
            int y = 0;
            int x = 0;
            for (int i = 0; i < 9; i++)
            {
                picCases[i] = new PictureBox();
                picCases[i].Name = i.ToString();
                picCases[i].Size = new Size(90, 90);
                picCases[i].BackColor = Color.LightGray;
                picCases[i].SizeMode = PictureBoxSizeMode.StretchImage;
                picCases[i].Click += UserClick;
                if (i == 0 || i == 3 || i == 6)
                {
                    x = 264;
                }

                if (i < 3)
                {
                    y = 33;

                }
                else if (i < 6)
                {
                    y = 130;
                }
                else
                {
                    y = 229;
                }
                picCases[i].Location = new Point(x, y);
                _view.Controls.Add(picCases[i]);
                x += 97;
            }

            // 
            // picTop
            // 
            PictureBox picTop = new PictureBox();
            picTop.BackColor = Color.Black;
            picTop.Location = new Point(265, 124);
            picTop.Name = "picTop";
            picTop.Size = new Size(285, 5);
            picTop.TabIndex = 15;
            picTop.TabStop = false;
            _view.Controls.Add(picTop);
            // 
            // PicBottom
            // 
            PictureBox PicBottom = new PictureBox();
            PicBottom.BackColor = Color.Black;
            PicBottom.Location = new Point(265, 222);
            PicBottom.Name = "PicBottom";
            PicBottom.Size = new Size(285, 5);
            PicBottom.TabIndex = 18;
            PicBottom.TabStop = false;
            _view.Controls.Add(PicBottom);
            // 
            // picLeft
            // 
            PictureBox picLeft = new PictureBox();
            picLeft.BackColor = Color.Black;
            picLeft.Location = new Point(355, 33);
            picLeft.Name = "picLeft";
            picLeft.Size = new Size(5, 286);
            picLeft.TabIndex = 17;
            picLeft.TabStop = false;
            _view.Controls.Add(picLeft);
            // 
            // picRight
            // 
            PictureBox picRight = new PictureBox();
            picRight.BackColor = Color.Black;
            picRight.Location = new Point(452, 33);
            picRight.Name = "picRight";
            picRight.Size = new Size(5, 286);
            picRight.TabIndex = 16;
            picRight.TabStop = false;
            _view.Controls.Add(picRight);


            // 
            // separatorP1
            // 
            PictureBox separatorP1 = new PictureBox();
            separatorP1.BackColor = SystemColors.ActiveCaptionText;
            separatorP1.Location = new Point(229, 0);
            separatorP1.Name = "separatorP1";
            separatorP1.Size = new Size(1, 339);
            separatorP1.TabIndex = 19;
            separatorP1.TabStop = false;
            _view.Controls.Add(separatorP1);
            // 
            // separatorP2
            // 
            PictureBox separatorP2 = new PictureBox();
            separatorP2.BackColor = SystemColors.ActiveCaptionText;
            separatorP2.Location = new Point(583, 0);
            separatorP2.Name = "separatorP2";
            separatorP2.Size = new Size(1, 339);
            separatorP2.TabIndex = 20;
            separatorP2.TabStop = false;
            _view.Controls.Add(separatorP2);

        }
        private void askUserName(int oneOrTwoPlayers)
        {
            _model.multi = false;
            _msgBox = new View("Infos");
            _msgBox.FormBorderStyle = FormBorderStyle.FixedSingle;
            _msgBox.StartPosition = FormStartPosition.CenterScreen;
            _msgBox.Size = new Size(200, 150);


            Label lblInfo01 = new Label();
            lblInfo01.Text = "votre nom:";
            lblInfo01.Name = "lblInfo";
            lblInfo01.Location = new Point(15, 5);
            _msgBox.Controls.Add(lblInfo01);

            _txtPlayer01 = new TextBox();
            _txtPlayer01.Name = _model.nameP1;
            _txtPlayer01.Size = new Size(_msgBox.Size.Width - 40, 20);
            _txtPlayer01.Location = new Point(15, lblInfo01.Location.Y + lblInfo01.Size.Height);
            _txtPlayer01.KeyDown += MsgBoxAskUserName_KeyDown;
            _msgBox.Controls.Add(_txtPlayer01);

            Button cmdOk = new Button();
            cmdOk.Name = "cmdOk";
            cmdOk.Text = "Ok";
            cmdOk.AutoSize = true;
            cmdOk.Location = new Point(_txtPlayer01.Location.X + _txtPlayer01.Size.Width - cmdOk.Size.Width, _txtPlayer01.Location.Y + _txtPlayer01.Size.Height + 5);
            cmdOk.Click += CmdOk_Click;
            _msgBox.Controls.Add(cmdOk);


            if (oneOrTwoPlayers == 2)
            {
                _model.multi = true;
                _msgBox.Size = new Size(200, 170);

                Label lblInfo02 = new Label();
                lblInfo02.Text = "nom joueur 02:";
                lblInfo02.Name = "lblInfo02";
                lblInfo02.Location = new Point(15, _txtPlayer01.Location.Y + _txtPlayer01.Size.Height);
                _msgBox.Controls.Add(lblInfo02);

                _txtPlayer02 = new TextBox();
                _txtPlayer02.Name = _model.nameP2;
                _txtPlayer02.Size = new Size(_msgBox.Size.Width - 40, 20);
                _txtPlayer02.Location = new Point(15, lblInfo02.Location.Y + lblInfo02.Size.Height);
                _txtPlayer02.KeyDown += MsgBoxAskUserName_KeyDown;
                _msgBox.Controls.Add(_txtPlayer02);


                cmdOk.Location = new Point(_txtPlayer02.Location.X + _txtPlayer02.Size.Width - cmdOk.Size.Width, _txtPlayer02.Location.Y + _txtPlayer02.Size.Height + 5);
            }

            _msgBox.Show();

        }


        private void popUpUserName()
        {
            if (_model.multi)
            {
                if (string.IsNullOrWhiteSpace(_txtPlayer01.Text) || string.IsNullOrWhiteSpace(_txtPlayer02.Text) || _txtPlayer01.Text.Length > 11 || _txtPlayer02.Text.Length > 11)
                {
                    MessageBox.Show("Merci de rentrer un nom d'utilisateur ayant au maximum 11 lettres", "Nom utilisateur manquant", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _model.nameP1 = _txtPlayer01.Text;
                    _model.nameP2 = _txtPlayer02.Text;
                    _msgBox.Close();
                    Show_interface(1);
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(_txtPlayer01.Text) || _txtPlayer01.Text.Length > 11)
                {
                    MessageBox.Show("Merci de rentrer un nom d'utilisateur ayant au maximum 11 lettres", "Nom utilisateur manquant", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    _model.nameP1 = _txtPlayer01.Text;
                    _model.nameP2 = "Ordinateur";
                    _msgBox.Close();
                    askLvlAI();
                    _msgBox.ShowDialog();
                    Show_interface(1);
                }
            }
        }
        private void askLvlAI()
        {
            _msgBox = new View("Niveau de l'IA");
            _msgBox.Size = new Size(284, 130);
            _msgBox.FormBorderStyle = FormBorderStyle.None;
            _msgBox.StartPosition = FormStartPosition.CenterScreen;


            Label lblTitle = new Label();

            Button easy = new Button();
            Button medium = new Button(); 
            Button hard = new Button();
            //
            //lblTitle
            //
            lblTitle.Text = "Niveau de l'ordinateur:";
            lblTitle.Name = "lblTitle";
            lblTitle.Location = new Point(12, 12);
            lblTitle.AutoSize = true;
            _msgBox.Controls.Add(lblTitle);
            // 
            // easy
            // 
            easy.Location = new System.Drawing.Point(12, 40);
            easy.Name = "1";
            easy.Size = new System.Drawing.Size(75, 23);
            easy.TabIndex = 0;
            easy.Text = "Facile";
            easy.Click += CmdlvlAI_Click;
            _msgBox.Controls.Add(easy);
            // 
            // medium
            // 
            medium.Location = new System.Drawing.Point(93, 40);
            medium.Name = "2";
            medium.Size = new System.Drawing.Size(75, 23);
            medium.TabIndex = 1;
            medium.Text = "Moyen";
            medium.Click += CmdlvlAI_Click;
            _msgBox.Controls.Add(medium);
            // 
            // hard
            // 
            hard.Location = new System.Drawing.Point(174, 40);
            hard.Name = "3";
            hard.Size = new System.Drawing.Size(75, 23);
            hard.TabIndex = 2;
            hard.Text = "Difficile";
            hard.Click += CmdlvlAI_Click;
            _msgBox.Controls.Add(hard);
        }
        private void CmdlvlAI_Click(object sender, EventArgs e)
        {
            int id= int.Parse(((Button)sender).Name);
            _model.lvlAI=id;
            _msgBox.Close();
        }
        private void MsgBoxAskUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                popUpUserName();
            }
        }

        private void UserClick(object sender, EventArgs e)
        {
            ThinkingGame((PictureBox)sender);
        }
        private void ThinkingGame(PictureBox pic)
        {
            try
            {
                int id = int.Parse(pic.Name);
                if (_model.GameArray[id] == 0)
                {
                    if (_model.WhatPlayer == 1)
                        pic.Image = Morpion.Properties.Resources.cross;
                    else
                        pic.Image = Morpion.Properties.Resources.circle;

                    if (_model.CheckGame(id))
                    {
                        if (_model.WhatPlayer == 2)
                        {
                            _model.scoreP1 += 1;
                        }
                        else
                        {
                            _model.scoreP2 += 1;
                        }

                        throw new Exception("fin de partie, " + _model.ActualPlayer);
                    }
                }
                if (!_model.multi)
                {
                    if (_model.WhatPlayer == 2)
                    {
                        int AI_id = _model.AI(2);
                        bool finish = _model.CheckGame(AI_id);
                        pic = (PictureBox)_view.Controls.Find(AI_id.ToString(), true)[0];
                        pic.Image = Morpion.Properties.Resources.circle;
                        if (finish)
                        {
                            _model.scoreP2 += 1;
                            throw new Exception("L'ordinateur a gagné, dommage...");
                        }
                    }
                }
            }
            catch (Exception execption)
            {
                MessageBox.Show(execption.Message);
                replay();
            }
        }

        private void replay()
        {
            try
            {
                var result = MessageBox.Show("Une autre partie?", "Revanche?", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    Show_interface(1);
                }
                else
                {
                    _model.saveGame();
                    _model.scoreP1 = 0;
                    _model.scoreP2 = 0;
                    Show_interface(0);
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
        private void CmdOk_Click(object sender, EventArgs e)
        {
            popUpUserName();
        }

        private void LocalSolo_click(object sender, EventArgs e)
        {
            _model.scoreP1 = 0;
            _model.scoreP2 = 0;
            askUserName(1);
        }

        private void LocalMulti_click(object sender, EventArgs e)
        {
            _model.scoreP1 = 0;
            _model.scoreP2 = 0;
            askUserName(2);
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

        private void End_program()
        {
            Application.Run(_view);
        }

    }

}
