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
        /// <summary>
        /// Constructor of control, he call model and ask all data before to execute program
        /// </summary>
        public Controlor()
        {
            _view = new View("Morpion");
            _model = new Model();
            _view.SuspendLayout();
            _model.Show_interface(_view);
            _view.ResumeLayout(false);
            _view.PerformLayout();
            End_program();
        }

        private void End_program()
        {
            Application.Run(_view);
        }

    }

}
