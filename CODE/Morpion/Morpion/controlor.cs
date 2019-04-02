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
    /// Controlor manage the application.
    /// To access data, controlor call model and ask specific data.
    /// when it has data, he send to view.
    /// </summary>
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
            _model.DbLimit = 10;
            _model.View = _view;
            _view.SuspendLayout();
            Show_interface();
            _view.ResumeLayout(false);
            _view.PerformLayout();
            End_program();
        }
        /// <summary>
        /// menu 0: welcome page,
        /// menu 1: game interface
        /// menu 2: informations interface
        /// </summary>
        /// <param name="menu">type of interface</param>
        private void Show_interface(int menu = 0)
        {
            _view.Controls.Clear();
            Size viewSize = new Size();
            TopMenu();
            switch (menu)
            {
                case 0:
                    viewSize = new Size(785, 560);
                    Main_menu();
                    break;
                case 1:
                    viewSize = new Size(804, 339);
                    Game_int();
                    break;
                case 2:
                    viewSize = new Size(350, 400);
                    Info_int();
                    break;
                default:
                    viewSize = new Size(785, 560);
                    Main_menu();
                    break;
            }
            _view.ClientSize = viewSize;
        }

        /// <summary>
        /// display the top menu
        /// </summary>
        private void TopMenu()
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
            mnuInfos.Click += Infos_click;

            //menu strip on the top of form and add it on the form
            _view.Controls.Add(mnu);
            _view.MainMenuStrip = mnu;
            mnu.ResumeLayout(false);
            mnu.PerformLayout();
        }

        /// <summary>
        /// display main interface, same menus of top menu
        /// </summary>
        private void Main_menu()
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
            cmdLocalMulti.Text = "Multijoueur";
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

        /// <summary>
        /// show game interface with user data and game data
        /// </summary>
        private void Game_int()
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
            lblPlayer01.Text = _model.NameP1;
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
            lblScoreP01.Text = _model.ScoreP1.ToString();
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
            lblPlayer02.Text = _model.NameP2;
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
            lblScoreP02.Text = _model.ScoreP2.ToString(); ;
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
        private void Info_int()
        {
            Button cmdClearDB = new Button();
            Button cmdHome = new Button();
            ListView lstView = new System.Windows.Forms.ListView();
            Label lblScores = new Label();
            Label lblDev = new Label();

                           
            // 
            // lblDev
            // 
            lblDev.AutoSize = true;
            lblDev.Location = new System.Drawing.Point(30, 25);
            lblDev.Name = "lblDev";
            lblDev.TabIndex = 0;
            lblDev.Text = "Dévelloppé par Diogo Vieira\nVersion "+ Application.ProductVersion;
            // 
            // lblScores
            // 
            lblScores.AutoSize = true;
            lblScores.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblScores.Location = new System.Drawing.Point(lblDev.Location.X, lblDev.Location.Y + lblDev.Height);
            lblScores.Name = "lblScores";
            lblScores.TabIndex = 0;
            lblScores.Text = "Scores";
            //
            //columns
            //
            lstView.View = System.Windows.Forms.View.Details;
            ColumnHeader clmPlayer01 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ColumnHeader clmPlayer02 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ColumnHeader clmScoreP1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ColumnHeader clmScoreP2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            // 
            // listView
            // 
            lstView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {  clmPlayer01,
                                                                                clmPlayer02,
                                                                                clmScoreP1,
                                                                                clmScoreP2});
            lstView.Location = new System.Drawing.Point(30, lblScores.Location.Y+lblScores.Height+10);
            lstView.Name = "lstView";
            lstView.Size = new System.Drawing.Size(296, 270);
            lstView.TabIndex = 0;
            lstView.UseCompatibleStateImageBehavior = false;
            lstView.View = System.Windows.Forms.View.Details;

            // 
            // clmPlayer01
            // 
            clmPlayer01.Text = "Nom J1";
            clmPlayer01.Name = "nameP01";
            clmPlayer01.Width = 90;
            // 
            // clmPlayer02
            // 
            clmPlayer02.Text = "Nom J2";
            clmPlayer02.Name = "nameP02";
            clmPlayer02.Width = 90;
            // 
            // clmScoreP1
            // 
            clmScoreP1.Text = "Score J1";
            clmScoreP1.Name = "scoreP01";
            clmScoreP1.Width = 55;
            // 
            // clmScoreP2
            // 
            clmScoreP2.Text = "Score J2";
            clmScoreP2.Name = "scoreP02";
            clmScoreP2.Width = 55;
            // 
            // cmdClearDB
            // 
            cmdClearDB.Location = new Point(lstView.Location.X, lstView.Location.Y + lstView.Height);
            cmdClearDB.Name = "cmdHome";
            cmdClearDB.AutoSize = true;
            cmdClearDB.TabIndex = 0;
            cmdClearDB.Text = "Effacer les scores";
            cmdClearDB.UseVisualStyleBackColor = true;
            cmdClearDB.Click += ClearDB;
            // 
            // cmdHome
            // 
            cmdHome.Name = "cmdClearDB";
            cmdHome.AutoSize = true;
            cmdHome.Location = new Point(lstView.Location.X+lstView.Width-cmdHome.Width-30, lstView.Location.Y + lstView.Height);
            cmdHome.TabIndex = 0;
            cmdHome.Text = "Revenir à l'accueil";
            cmdHome.UseVisualStyleBackColor = true;
            cmdHome.Click += CmdHome_Click;
            // 
            // View
            // 
            _view.Controls.Add(lstView);
            _view.Controls.Add(cmdClearDB);
            _view.Controls.Add(cmdHome);
            _view.Controls.Add(lblScores);
            _view.Controls.Add(lblDev);

            //show scores to user
            foreach (score scores in _model.GetScore)
            {               
                ListViewItem lvi = new ListViewItem();
                lvi.Text = scores.nameP01;
                lvi.SubItems.Add(scores.nameP02);
                lvi.SubItems.Add(scores.scoreP01);
                lvi.SubItems.Add(scores.scoreP02);
                lstView.Items.Add(lvi);
            }

        }
        
        private void CmdHome_Click(object sender, EventArgs e)
        {
            Show_interface();
        }
        
        private void ClearDB(object sender, EventArgs e)
        {
            _model.ClearDB();
        }

        /// <summary>
        /// messagebox ask user(s) name(s)
        /// </summary>
        /// <param name="oneOrTwoPlayers"></param>
        private void AskUserName(int oneOrTwoPlayers)
        {
            _model.Multi = false;
            _msgBox = new View("Infos");
            _msgBox.FormBorderStyle = FormBorderStyle.FixedSingle;
            _msgBox.StartPosition = FormStartPosition.CenterScreen;
            _msgBox.Size = new Size(200, 150);

            //
            // lblInfo01
            // label show "username:"
            //
            Label lblInfo01 = new Label();
            lblInfo01.Text = "votre nom:";
            lblInfo01.Name = "lblInfo";
            lblInfo01.Location = new Point(15, 5);
            _msgBox.Controls.Add(lblInfo01);

            //
            // _txtPlayer01
            // containt the name of first user
            //
            _txtPlayer01 = new TextBox();
            _txtPlayer01.Name = _model.NameP1;
            _txtPlayer01.Size = new Size(_msgBox.Size.Width - 40, 20);
            _txtPlayer01.Location = new Point(15, lblInfo01.Location.Y + lblInfo01.Size.Height);
            _txtPlayer01.KeyDown += MsgBoxAskUserName_KeyDown;
            _txtPlayer01.TabIndex = 1;
            _msgBox.Controls.Add(_txtPlayer01);

            //
            // cmdOk
            // send to cmdOl_click method
            //
            Button cmdOk = new Button();
            cmdOk.Name = "cmdOk";
            cmdOk.Text = "Ok";
            cmdOk.AutoSize = true;
            cmdOk.Location = new Point(_txtPlayer01.Location.X + _txtPlayer01.Size.Width - cmdOk.Size.Width, _txtPlayer01.Location.Y + _txtPlayer01.Size.Height + 5);
            cmdOk.Click += CmdOk_Click;
            cmdOk.TabIndex = 3;
            _msgBox.Controls.Add(cmdOk);

            //multiplayer?
            if (oneOrTwoPlayers == 2)
            {
                _model.Multi = true;
                _msgBox.Size = new Size(200, 170);
                //
                // lblInfo01
                // label show "username 02:"
                //
                Label lblInfo02 = new Label();
                lblInfo02.Text = "nom joueur 02:";
                lblInfo02.Name = "lblInfo02";
                lblInfo02.Location = new Point(15, _txtPlayer01.Location.Y + _txtPlayer01.Size.Height);
                _msgBox.Controls.Add(lblInfo02);

                //
                // _txtPlayer02
                // containt the name of second user
                //
                _txtPlayer02 = new TextBox();
                _txtPlayer02.Name = _model.NameP2;
                _txtPlayer02.Size = new Size(_msgBox.Size.Width - 40, 20);
                _txtPlayer02.Location = new Point(15, lblInfo02.Location.Y + lblInfo02.Size.Height);
                _txtPlayer02.KeyDown += MsgBoxAskUserName_KeyDown;
                _txtPlayer02.TabIndex = 2;
                _msgBox.Controls.Add(_txtPlayer02);

                //change the location of cmdOK
                cmdOk.Location = new Point(_txtPlayer02.Location.X + _txtPlayer02.Size.Width - cmdOk.Size.Width, _txtPlayer02.Location.Y + _txtPlayer02.Size.Height + 5);
            }
            //show the view, user have to close the view to access other views
            _msgBox.ShowDialog();

        }

        /// <summary>
        /// check data of messagebox and start game if game ok
        /// </summary>
        private void PopUpUserName()
        {
            if (_model.Multi)
            {
                if (string.IsNullOrWhiteSpace(_txtPlayer01.Text) || string.IsNullOrWhiteSpace(_txtPlayer02.Text) || _txtPlayer01.Text.Length > 11 || _txtPlayer02.Text.Length > 11)
                {
                    MessageBox.Show("Merci de rentrer un nom d'utilisateur ayant au maximum 11 lettres", "Nom utilisateur manquant", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    //set usernames in model
                    _model.NameP1 = _txtPlayer01.Text;
                    _model.NameP2 = _txtPlayer02.Text;
                    _msgBox.Close();
                    //show game
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
                    //set usernames in model
                    _model.NameP1 = _txtPlayer01.Text;
                    _model.NameP2 = "Ordinateur";
                    _msgBox.Close();
                    AskLvlAI();
                    _msgBox.ShowDialog();
                    //show game
                    Show_interface(1);
                }
            }
        }
        /// <summary>
        /// pop to ask level of AI
        /// </summary>
        private void AskLvlAI()
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
            // send 1 to CmdlvlAI_Click method
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
            // send 2 to CmdlvlAI_Click method
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
            // send 3 to CmdlvlAI_Click method
            // 
            hard.Location = new System.Drawing.Point(174, 40);
            hard.Name = "3";
            hard.Size = new System.Drawing.Size(75, 23);
            hard.TabIndex = 2;
            hard.Text = "Difficile";
            hard.Click += CmdlvlAI_Click;
            _msgBox.Controls.Add(hard);
        }
        /// <summary>
        /// set AI level
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdlvlAI_Click(object sender, EventArgs e)
        {
            int id= int.Parse(((Button)sender).Name);
            //set AI level
            _model.LvlAI=id;
            _msgBox.Close();
        }
        private void MsgBoxAskUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                PopUpUserName();
            }
        }
        /// <summary>
        /// send the pictureBox where user's click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserClick(object sender, EventArgs e)
        {
            ThinkingGame((PictureBox)sender);
        }
        /// <summary>
        /// function check the state of game and when finished game or equality, ask if user wants a revenge 
        /// </summary>
        /// <param name="pic">picturebox where user has click</param>
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
                    // check the end game and add score to winner
                    if (_model.CheckGame(id))
                    {
                        if (_model.WhatPlayer == 2)
                        {
                            _model.ScoreP1 += 1;
                        }
                        else
                        {
                            _model.ScoreP2 += 1;
                        }

                        throw new Exception("fin de partie, " + _model.ActualPlayer + " a gagné!");
                    }
                }
                //not multiplayer game
                if (!_model.Multi)
                {
                    if (_model.WhatPlayer == 2)
                    {
                        int AI_id = _model.AI(_model.LvlAI);
                        bool finish = _model.CheckGame(AI_id);
                        pic = (PictureBox)_view.Controls.Find(AI_id.ToString(), true)[0];
                        pic.Image = Morpion.Properties.Resources.circle;
                        if (finish)
                        {
                            _model.ScoreP2 += 1;
                            throw new Exception("L'ordinateur a gagné, dommage...");
                        }
                    }
                }
            }
            catch (Exception execption)
            {
                MessageBox.Show(execption.Message);
                Replay();
            }
        }
        /// <summary>
        /// view to ask rematch to user
        /// </summary>
        private void Replay()
        {
            try
            {
                //get result of player choose 
                var result = MessageBox.Show("Une autre partie?", "Revanche?", MessageBoxButtons.YesNo);
                if(result == DialogResult.Yes)
                {
                    Show_interface(1);
                }
                else
                {
                    //save and reset data to show home interface
                    _model.SaveGame();
                    _model.ScoreP1 = 0;
                    _model.ScoreP2 = 0;
                    Show_interface();
                }
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }
        private void CmdOk_Click(object sender, EventArgs e)
        {
            PopUpUserName();
        }

        private void LocalSolo_click(object sender, EventArgs e)
        {
            _model.ScoreP1 = 0;
            _model.ScoreP2 = 0;
            AskUserName(1);
        }

        private void LocalMulti_click(object sender, EventArgs e)
        {
            _model.ScoreP1 = 0;
            _model.ScoreP2 = 0;
            AskUserName(2);
        }
        private void Network_click(object sender, EventArgs e)
        {
            MessageBox.Show("Bientôt disponible.", "Partie en réseau");
        }
        private void Rules_click(object sender, EventArgs e)
        {
            //show pop-up with rules
            string rules = " Les joueurs cliquent à tour de rôle\n sur une case de la grille et le premier\n qui parvient à aligner trois de ses symboles\n horizontalement, verticalement ou en diagonale\n gagne un point. ";
            MessageBox.Show(rules, "Règles");
        }
        private void Infos_click(object sender, EventArgs e)
        {
            //show information interface
            Show_interface(2);
        }

        private void End_program()
        {
            //start application
            Application.Run(_view);
        }

    }

}
