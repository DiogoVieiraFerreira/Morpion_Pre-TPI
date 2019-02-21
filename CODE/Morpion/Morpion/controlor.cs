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

            switch(_model.menu)
            {
                case 0:
                    _view.Controls.Find("cmdLocalSolo", true)[0].Click += _model.LocalSolo_click;
                    _view.Controls.Find("cmdLocalMulti", true)[0].Click += _model.LocalMulti_click;
                    _view.Controls.Find("cmdNetwork", true)[0].Click += _model.Network_click;
                    _view.Controls.Find("cmdRules", true)[0].Click += _model.Rules_click;
                    _view.Controls.Find("cmdInfos", true)[0].Click += _model.Infos_click;
                    break;
                default:
                    break;
            }

            End_program();
        }

        private void Controlor_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ici");
        }

        private void End_program()
        {
            Application.Run(_view);
        }

    }

}
