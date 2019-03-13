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

        /// <summary>
        /// The form Contain all views of game
        /// </summary>
        public View(string text = "View", string name = "frmView")
        {
            InitializeComponent();
            this.Name = name;
            this.Text = text;
        }
        
    }
}
