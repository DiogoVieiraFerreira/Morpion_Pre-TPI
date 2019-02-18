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
    public partial class View : Form
    {
        private Model _model;
        private System.Windows.Forms.MenuStrip mnu;
        private System.Windows.Forms.ToolStripMenuItem mnuLocal;
        private System.Windows.Forms.ToolStripMenuItem mnuLocalSolo;
        private System.Windows.Forms.ToolStripMenuItem mnuLocalMulti;
        private System.Windows.Forms.ToolStripMenuItem mnuNetwork;
        private System.Windows.Forms.ToolStripMenuItem mnuRules;
        private System.Windows.Forms.ToolStripMenuItem mnuInfos;
        /// <summary>
        /// The form Contain all views of game
        /// </summary>
        public View()
        {
            InitializeComponent();
            _model = new Model();
            principalMnu();
        }

        private void principalMnu()
        {


            this.mnu = new System.Windows.Forms.MenuStrip();
            this.mnuLocal = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLocalSolo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLocalMulti = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNetwork = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRules = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInfos = new System.Windows.Forms.ToolStripMenuItem();

            //insert menus in menustrip
            this.mnu.Name = "mnu";
            this.mnu.Text = "mnu";
            this.mnu.BackColor = System.Drawing.Color.Silver;
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {  this.mnuLocal,
                                                                                this.mnuNetwork,
                                                                                this.mnuRules,
                                                                                this.mnuInfos});
            this.mnu.Location = new System.Drawing.Point(0, 0);
            this.mnu.Size = new System.Drawing.Size(600, 24);
            this.mnu.TabIndex = 0;

            // add local menu in mnu
            this.mnuLocal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mnuLocal.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.mnuLocalSolo,
                                                                                            this.mnuLocalMulti});
            this.mnuLocal.Name = "mnuLocal";
            this.mnuLocal.Size = new System.Drawing.Size(86, 20);
            this.mnuLocal.Text = "Partie Locale";

            //add solo button in local menu
            this.mnuLocalSolo.Name = "mnuLocalSolo";
            this.mnuLocalSolo.Size = new System.Drawing.Size(180, 22);
            this.mnuLocalSolo.Text = "En Solo";
            this.mnuLocalSolo.Click += _model.localSolo_click;

            //add multijoueur button in local menu
            this.mnuLocalMulti.Name = "mnuLocalMulti";
            this.mnuLocalMulti.Size = new System.Drawing.Size(180, 22);
            this.mnuLocalMulti.Text = "En Multijoueur";

            //create mnuNetwork in mnu
            this.mnuNetwork.Name = "mnuNetwork";
            this.mnuNetwork.Size = new System.Drawing.Size(120, 20);
            this.mnuNetwork.Text = "Partie sur le Réseau";

            //create mnuRules in mnu
            this.mnuRules.Name = "mnuRules";
            this.mnuRules.Size = new System.Drawing.Size(53, 20);
            this.mnuRules.Text = "Règles";

            //create mnuInfos in mnu
            this.mnuInfos.Name = "mnuInfos";
            this.mnuInfos.Size = new System.Drawing.Size(87, 20);
            this.mnuInfos.Text = "Informations";

            //add menus on forms
            this.Name = "View";
            this.Text = "Form1";
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.mnu);
            this.MainMenuStrip = this.mnu;
            this.mnu.ResumeLayout(false);
            this.mnu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
            //menu strip on the top of form
            this.mnu.SuspendLayout();
            this.SuspendLayout();
        }
        
        
    }
}
