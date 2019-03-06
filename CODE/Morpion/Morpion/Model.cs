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
        private string _actualPlayer;
        private bool _multi;
        private string[] _gameArray;
        private int _lastIdPlayed;
        private string _symbolP1;
        private string _symbolP2;
        private int _whatPlayer;



        public bool CheckGame(int id)
        {
            string symbol;
            bool result = false;
            
            if(_whatPlayer==1)
            {
                _actualPlayer = _nameP1;
                _lastIdPlayed = id;
                symbol = "X";
            }
            else
            {
                _actualPlayer = _nameP1;
                symbol = "O";
            }
            _gameArray[id] = symbol;

            //first line
            if (_gameArray[0] == symbol && _gameArray[1] == symbol && _gameArray[2] == symbol)
                result = true;
            //second line
            else if (_gameArray[3] == symbol && _gameArray[4] == symbol && _gameArray[5] == symbol)
                result = true;
            //third line
            else if (_gameArray[6] == symbol && _gameArray[7] == symbol && _gameArray[8] == symbol)
                result = true;
            //first column
            else if (_gameArray[0] == symbol && _gameArray[3] == symbol && _gameArray[6] == symbol)
                result = true;
            //second column
            else if (_gameArray[1] == symbol && _gameArray[4] == symbol && _gameArray[7] == symbol)
                result = true;
            //third column
            else if (_gameArray[2] == symbol && _gameArray[5] == symbol && _gameArray[8] == symbol)
                result = true;
            //left diagonal
            else if (_gameArray[0] == symbol && _gameArray[4] == symbol && _gameArray[8] == symbol)
                result = true;
            //right diagonal
            else if (_gameArray[2] == symbol && _gameArray[4] == symbol && _gameArray[6] == symbol)
                result = true;
            else
            {
                bool finish=true;
                foreach(string value in _gameArray)
                {
                    if(value=="0")
                    {
                        finish=false;
                        break;
                    }
                }
                if (finish)
                    throw new Exception("Egalitée");
            }

            _whatPlayer = 3 - _whatPlayer;
            return result;
        }
        /// <summary>
        /// generate IA to play with user
        /// </summary>
        /// <param name="lvl">insert the difficult of IA. 1 easy, 2 medium, 3 hard</param>
        public int IA(int lvl)
        {
            int id=0;
            switch(lvl)
            {
                case 1:
                    do
                    {
                        Random rnd = new Random();
                        id = rnd.Next(0, 8);

                    } while (_gameArray[id] != "0");
                    break;
                case 2:
                    switch(_lastIdPlayed)
                    {
                        case 0:
                            if(_gameArray[1] == "0"|| _gameArray[3] == "0")
                            {
                                Random rnd = new Random();
                                int[] AllowedValues = new int[] { 1, 3 };
                                id = AllowedValues[rnd.Next(AllowedValues.Length)];
                            }
                            break;
                        case 1:
                            if (_gameArray[0] == "0" || _gameArray[2] == "0" || _gameArray[4] == "0")
                            {
                                Random rnd = new Random();
                                int[] AllowedValues = new int[] { 0, 2, 4 };
                                id = AllowedValues[rnd.Next(AllowedValues.Length)];
                            }
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;
                        case 8:
                            break;
                    }
                    break;
                case 3:
                    break;
            }
            return id;
        }

        /// <summary>
        /// _multi's accessor
        /// it's a multiplayer game?
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
        /// get or set name of player 02
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
        /// get or set score of player 01
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
        /// get or set name of player 02
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
        /// get name current player
        /// </summary>
        public string ActualPlayer
        {
            get
            {
                return _actualPlayer;
            }
        }
        /// <summary>
        /// _scoreP2's accessor
        /// get or set score of player 02
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

        /// <summary>
        /// _gameArray's accessor
        /// get or set the plateform's game
        /// </summary>
        public string[] GameArray
        {
            set
            {
                _gameArray = value;
            }
            get
            {
                return _gameArray;
            }
        }
        /// <summary>
        /// _wahtPlayer's accessor
        /// return number of player, 1 or 2
        /// </summary>
        public int WhatPlayer
        {
            get
            {
                return _whatPlayer;
            }
            set
            {
                _whatPlayer = value;
            }
        }
    }
}

