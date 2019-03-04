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
        private int _scoreP1;
        private int _scoreP2;
        private string _nameP1;
        private string _nameP2;
        private bool _multi;


        /// <summary>
        /// _multi's accessor
        /// </summary>
        public bool multi
        {
            get
            {
                return _multi;
            }
            set
            {
                _multi = value;
            }
        }
        /// <summary>
        /// _nameP1's accessor
        /// </summary>
        public string nameP1
        {
            get
            {
                return _nameP1;
            }
            set
            {
                _nameP1 = value;
            }
        }
        /// <summary>
        /// _scoreP1's accessor
        /// </summary>
        public int scoreP1
        {
            get
            {
                return _scoreP1;
            }
            set
            {
                _scoreP1 = value;
            }
        }
        /// <summary>
        /// _nameP2's accessor
        /// </summary>
        public string nameP2
        {
            get
            {
                return _nameP2;
            }
            set
            {
                _nameP2 = value;
            }
        }
        /// <summary>
        /// _scoreP2's accessor
        /// </summary>
        public int scoreP2
        {
            get
            {
                return _scoreP2;
            }
            set
            {
                _scoreP2 = value;
            }
        }
        /// <summary>
        /// _view's accessor
        /// </summary>
        public View view
        {
            set
            {
                _view = value;
            }
        }
    }
}
