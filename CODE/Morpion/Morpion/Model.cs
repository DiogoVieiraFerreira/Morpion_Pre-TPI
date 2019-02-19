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


        public void localSolo_click(object sender, EventArgs e)
        {

        }

        public void show_interface(View view)
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

            //insert menus in menustrip
            mnu.Name = "mnu";
            mnu.Text = "mnu";
            mnu.BackColor = System.Drawing.Color.Silver;
            mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {  mnuLocal,
                                                                                mnuNetwork,
                                                                                mnuRules,
                                                                                mnuInfos});
            mnu.Location = new System.Drawing.Point(0, 0);
            mnu.Size = new System.Drawing.Size(600, 24);
            mnu.TabIndex = 0;

            // add local menu in mnu
            mnuLocal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            mnuLocal.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mnuLocalSolo,
                                                                                            mnuLocalMulti});
            mnuLocal.Name = "mnuLocal";
            mnuLocal.Size = new System.Drawing.Size(86, 20);
            mnuLocal.Text = "Partie Locale";

            //add solo button in local menu
            mnuLocalSolo.Name = "mnuLocalSolo";
            mnuLocalSolo.Size = new System.Drawing.Size(180, 22);
            mnuLocalSolo.Text = "En Solo";
            mnuLocalSolo.Click += localSolo_click;

            //add multijoueur button in local menu
            mnuLocalMulti.Name = "mnuLocalMulti";
            mnuLocalMulti.Size = new System.Drawing.Size(180, 22);
            mnuLocalMulti.Text = "En Multijoueur";

            //create mnuNetwork in mnu
            mnuNetwork.Name = "mnuNetwork";
            mnuNetwork.Size = new System.Drawing.Size(120, 20);
            mnuNetwork.Text = "Partie sur le Réseau";

            //create mnuRules in mnu
            mnuRules.Name = "mnuRules";
            mnuRules.Size = new System.Drawing.Size(53, 20);
            mnuRules.Text = "Règles";

            //create mnuInfos in mnu
            mnuInfos.Name = "mnuInfos";
            mnuInfos.Size = new System.Drawing.Size(87, 20);
            mnuInfos.Text = "Informations";

            //menu strip on the top of form
            mnu.PerformLayout();
            mnu.ResumeLayout(false);
            view.ResumeLayout(false);
            view.PerformLayout();
            mnu.SuspendLayout();
            view.SuspendLayout();
            //add menus on forms
            view.MainMenuStrip = mnu;
            view.Controls.Add(mnu);


        }

    }
}
