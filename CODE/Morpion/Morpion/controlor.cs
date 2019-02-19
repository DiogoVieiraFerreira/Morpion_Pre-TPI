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

        public Controlor()
        {
            _view = new View("Morpion");
            _model = new Model();
            _model.show_interface(_view);

            _view.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            _view.ClientSize = new System.Drawing.Size(800, 450);
            _view.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            End_program();
        }

        private void End_program()
        {
            Application.Run(_view);
        }

    }

}
