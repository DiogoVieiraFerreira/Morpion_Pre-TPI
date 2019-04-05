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
    /// The form Contain all views of game
    /// </summary>
    public partial class View : Form
    {

        /// <summary>
        /// Define the name and the texte of form and disable the
        /// maximize box.
        /// </summary>
        public View(string text = "View", string name = "frmView")
        {
            InitializeComponent();
            this.Name = name;
            this.Text = text;
            this.MaximizeBox = false;
            this.Icon = Morpion.Properties.Resources.morpion;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        
    }
}
