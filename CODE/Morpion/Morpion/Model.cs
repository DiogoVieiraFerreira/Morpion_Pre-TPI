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
    public class Model
    {
        private DataBase db = new DataBase("Morpion");
        private View _view;
        private int _scoreP1;
        private int _scoreP2;
        private string _nameP1;
        private string _nameP2;
        private string _actualPlayer;
        private bool _multi;
        private int[] _gameArray;
        private int _lastIdPlayed;
        private int _whatPlayer;


        /// <summary>
        /// Check state of game
        /// when user put the last our symbol, return true value
        /// when equality an exception are generate
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool CheckGame(int id)
        {
            int symbol;
            bool result = false;
            
            if(_whatPlayer==1)
            {
                _actualPlayer = _nameP1;
                _lastIdPlayed = id;
                symbol = 1;
            }
            else
            {
                _actualPlayer = _nameP1;
                symbol = 2;
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
                foreach(int value in _gameArray)
                {
                    if(value==0)
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
            Random rnd = new Random();
            switch (lvl)
            {
                case 1:
                    do
                    {
                        id = rnd.Next(0, 8);
                    } while (_gameArray[id] != 0);
                    break;
                case 2:
                    int count = 0;
                    foreach (int value in _gameArray)
                    {
                        if (value != 0)
                            count++;
                    }
                    if (count > 1)
                    {
                        int symbolCheck = 3 - _whatPlayer;
                        bool ok = false;
                        //if the player can win the next round, we prevent him from doing so
                        //else, we play or we can win
                        do
                        {
                            if (((_gameArray[0] == symbolCheck && _gameArray[1] == symbolCheck) ||
                                 (_gameArray[1] == symbolCheck && _gameArray[2] == symbolCheck) ||
                                 (_gameArray[0] == symbolCheck && _gameArray[2] == symbolCheck)) &&
                                 !(_gameArray[0] != 0 && _gameArray[1] != 0 && _gameArray[2] != 0))
                            {
                                if (_gameArray[0] == 0)
                                {
                                    id = 0;
                                }
                                else if (_gameArray[1] == 0)
                                {
                                    id = 1;
                                }
                                else if (_gameArray[2] == 0)
                                {
                                    id = 2;
                                }
                                ok = !ok;
                            }
                            //second line
                            else if (((_gameArray[3] == symbolCheck && _gameArray[4] == symbolCheck) ||
                                      (_gameArray[4] == symbolCheck && _gameArray[5] == symbolCheck) ||
                                      (_gameArray[3] == symbolCheck && _gameArray[5] == symbolCheck)) &&
                                      !(_gameArray[3] != 0 && _gameArray[4] != 0 && _gameArray[5] != 0))
                            {
                                if (_gameArray[3] == 0)
                                {
                                    id = 3;
                                }
                                else if (_gameArray[4] == 0)
                                {
                                    id = 4;
                                }
                                else if (_gameArray[5] == 0)
                                {
                                    id = 5;
                                }
                                ok = !ok;
                            }
                            //third line
                            else if (((_gameArray[6] == symbolCheck && _gameArray[7] == symbolCheck) ||
                                      (_gameArray[7] == symbolCheck && _gameArray[8] == symbolCheck) ||
                                      (_gameArray[6] == symbolCheck && _gameArray[8] == symbolCheck)) &&
                                      !(_gameArray[6] != 0 && _gameArray[7] != 0 && _gameArray[8] != 0))
                            {
                                if (_gameArray[6] == 0)
                                {
                                    id = 6;
                                }
                                else if (_gameArray[7] == 0)
                                {
                                    id = 7;
                                }
                                else if (_gameArray[8] == 0)
                                {
                                    id = 8;
                                }
                                ok = !ok;
                            }
                            //left diagonal
                            else if (((_gameArray[0] == symbolCheck && _gameArray[4] == symbolCheck) ||
                                      (_gameArray[4] == symbolCheck && _gameArray[8] == symbolCheck) ||
                                      (_gameArray[0] == symbolCheck && _gameArray[8] == symbolCheck)) &&
                                      !(_gameArray[0] != 0 && _gameArray[4] != 0 && _gameArray[8] != 0))
                            {
                                if (_gameArray[0] == 0 || _gameArray[4] == 0 || _gameArray[8] == 0)
                                {
                                    if (_gameArray[0] == 0)
                                    {
                                        id = 0;
                                    }
                                    else if (_gameArray[4] == 0)
                                    {
                                        id = 4;
                                    }
                                    else if (_gameArray[8] == 0)
                                    {
                                        id = 8;
                                    }
                                    ok = !ok;
                                }
                            }
                            //Right diagonal
                            else if (((_gameArray[2] == symbolCheck && _gameArray[4] == symbolCheck) ||
                                      (_gameArray[4] == symbolCheck && _gameArray[6] == symbolCheck) ||
                                      (_gameArray[2] == symbolCheck && _gameArray[6] == symbolCheck)) &&
                                      !(_gameArray[2] != 0 && _gameArray[4] != 0 && _gameArray[6] != 0))
                            {
                                if (_gameArray[2] == 0 || _gameArray[4] == 0 || _gameArray[6] == 0)
                                {
                                    if (_gameArray[2] == 0)
                                    {
                                        id = 2;
                                    }
                                    else if (_gameArray[4] == 0)
                                    {
                                        id = 4;
                                    }
                                    else if (_gameArray[6] == 0)
                                    {
                                        id = 6;
                                    }
                                    ok = !ok;
                                }
                            }
                            //first column
                            else if (((_gameArray[0] == symbolCheck && _gameArray[3] == symbolCheck) ||
                                      (_gameArray[3] == symbolCheck && _gameArray[6] == symbolCheck) ||
                                      (_gameArray[0] == symbolCheck && _gameArray[6] == symbolCheck)) &&
                                      !(_gameArray[0] != 0 && _gameArray[3] != 0 && _gameArray[6] != 0))
                            {
                                if (_gameArray[0] == 0 || _gameArray[3] == 0 || _gameArray[6] == 0)
                                {
                                    if (_gameArray[0] == 0)
                                    {
                                        id = 0;
                                    }
                                    else if (_gameArray[3] == 0)
                                    {
                                        id = 3;
                                    }
                                    else if (_gameArray[6] == 0)
                                    {
                                        id = 6;
                                    }
                                    ok = !ok;
                                }
                            }
                            //second column
                            else if (((_gameArray[1] == symbolCheck && _gameArray[4] == symbolCheck) ||
                                      (_gameArray[4] == symbolCheck && _gameArray[7] == symbolCheck) ||
                                      (_gameArray[1] == symbolCheck && _gameArray[7] == symbolCheck)) &&
                                      !(_gameArray[1] != 0 && _gameArray[4] != 0 && _gameArray[7] != 0))
                            {
                                if (_gameArray[1] == 0 )
                                {
                                    id = 1;
                                }
                                else if(_gameArray[4] == 0)
                                {
                                    id = 4;
                                }
                                else if(_gameArray[7] == 0)
                                {
                                    id = 7;
                                }
                                ok = !ok;
                            }
                            //third column
                            else if (((_gameArray[2] == symbolCheck && _gameArray[5] == symbolCheck) ||
                                      (_gameArray[5] == symbolCheck && _gameArray[8] == symbolCheck) ||
                                      (_gameArray[2] == symbolCheck && _gameArray[8] == symbolCheck)) &&
                                      !(_gameArray[2] != 0 && _gameArray[5] != 0 && _gameArray[8] != 0))
                            {
                                if (_gameArray[2] == 0 || _gameArray[5] == 0 || _gameArray[8] == 0)
                                {
                                    if (_gameArray[2] == 0)
                                    {
                                        id = 2;
                                    }
                                    else if (_gameArray[5] == 0)
                                    {
                                        id = 5;
                                    }
                                    else if (_gameArray[8] == 0)
                                    {
                                        id = 8;
                                    }
                                    ok = !ok;
                                }
                            }
                            if(symbolCheck==2 && !ok)
                            {
                                id = IA(1);
                                ok = !ok;
                            }
                            symbolCheck = 3 - symbolCheck;
                        } while (!ok);
                    }
                    else
                    {
                        id = IA(1);
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
        public int[] GameArray
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

