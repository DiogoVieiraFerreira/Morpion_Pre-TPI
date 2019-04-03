using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Data.SQLite;
using System.Collections.Generic;
using Morpion;

namespace TestMorpion
{
    [TestClass]
    public class TestModel
    {

        #region private attributes
        private Morpion.Model _model;
        private int[] _expectedArray;
        #endregion private attributes

        #region TestInitialize
        /// <summary>
        /// on instancie les variables
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this._model = new Morpion.Model();
        }
        #endregion TestInitialize

        #region TestMethods
        /// <summary>
        /// compare arrays of game
        /// </summary>
        [TestMethod]
        public void Model_GameArray_AfterInitialization_Created()
        {
            _model.GameArray = new int[] { 0,0,0,
                                           0,0,0,
                                           0,0,0 };
            _expectedArray = new int[] { 0,0,0,
                                         0,0,0,
                                         0,0,0 };

            //refere to Initialize()
            CollectionAssert.AreEqual(_expectedArray, _model.GameArray);
        }
        /// <summary>
        /// Game Finished, first column
        /// </summary>
        [TestMethod]
        public void Model_CheckGame_AfterInitialization_firstColumn_returnTrue()
        {
            //first possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 1,0,0,
                                           1,0,0,
                                           0,0,0 };
            
            Assert.IsTrue(_model.CheckGame(6));

            //second possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 1,0,0,
                                           0,0,0,
                                           1,0,0 };
            
            Assert.IsTrue(_model.CheckGame(3));

            //third possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 0,0,0,
                                           1,0,0,
                                           1,0,0 };
            
            Assert.IsTrue(_model.CheckGame(0));
        }
        /// <summary>
        /// Game Finished, second column
        /// </summary>
        [TestMethod]
        public void Model_CheckGame_AfterInitialization_secondColumn_returnTrue()
        {
            //first possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 0,1,0,
                                           0,1,0,
                                           0,0,0 };

            Assert.IsTrue(_model.CheckGame(7));

            //second possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 0,1,0,
                                           0,0,0,
                                           0,1,0 };

            Assert.IsTrue(_model.CheckGame(4));

            //third possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 0,0,0,
                                           0,1,0,
                                           0,1,0 };

            Assert.IsTrue(_model.CheckGame(1));
        }
        /// <summary>
        /// Game Finished, third column
        /// </summary>
        [TestMethod]
        public void Model_CheckGame_AfterInitialization_thirdColumn_returnTrue()
        {
            //first possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 0,0,1,
                                           0,0,1,
                                           0,0,0 };

            Assert.IsTrue(_model.CheckGame(8));

            //second possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 0,0,1,
                                           0,0,0,
                                           0,0,1 };

            Assert.IsTrue(_model.CheckGame(5));

            //third possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 0,0,0,
                                           0,0,1,
                                           0,0,1 };

            Assert.IsTrue(_model.CheckGame(2));
        }
        /// <summary>
        /// Game Finished, first line
        /// </summary>
        [TestMethod]
        public void Model_CheckGame_AfterInitialization_firstLine_returnTrue()
        {
            //first possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 0,1,1,
                                           0,0,0,
                                           0,0,0 };

            Assert.IsTrue(_model.CheckGame(0));

            //second possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 1,0,1,
                                           0,0,0,
                                           0,0,0 };

            Assert.IsTrue(_model.CheckGame(1));

            //third possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 1,1,0,
                                           0,0,0,
                                           0,0,0 };

            Assert.IsTrue(_model.CheckGame(2));
        }
        /// <summary>
        /// Game Finished, second line
        /// </summary>
        [TestMethod]
        public void Model_CheckGame_AfterInitialization_secondLine_returnTrue()
        {
            //first possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 0,0,0,
                                           0,1,1,
                                           0,0,0 };

            Assert.IsTrue(_model.CheckGame(3));

            //second possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 0,0,0,
                                           1,0,1,
                                           0,0,0, };

            Assert.IsTrue(_model.CheckGame(4));

            //third possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 0,0,0,
                                           1,1,0,
                                           0,0,0, };

            Assert.IsTrue(_model.CheckGame(5));
        }
        /// <summary>
        /// Game Finished, third line
        /// </summary>
        [TestMethod]
        public void Model_CheckGame_AfterInitialization_thirdLine_returnTrue()
        {
            //first possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 0,0,0,
                                           0,0,0 ,
                                           0,1,1};

            Assert.IsTrue(_model.CheckGame(6));

            //second possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 0,0,0,
                                           0,0,0,
                                           1,0,1 };

            Assert.IsTrue(_model.CheckGame(7));

            //third possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 0,0,0,
                                           0,0,0,
                                           1,1,0 };

            Assert.IsTrue(_model.CheckGame(8));
        }
        /// <summary>
        /// Game Finished, left diagonal
        /// </summary>
        [TestMethod]
        public void Model_CheckGame_AfterInitialization_leftDiagonal_returnTrue()
        {
            //first possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 1,0,0,
                                           0,1,0 ,
                                           0,0,0};

            Assert.IsTrue(_model.CheckGame(8));

            //second possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 1,0,0,
                                           0,0,0,
                                           0,0,1 };

            Assert.IsTrue(_model.CheckGame(4));

            //third possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 0,0,0,
                                           0,1,0,
                                           0,0,1 };

            Assert.IsTrue(_model.CheckGame(0));
        }
        /// <summary>
        /// Game Finished, right diagonal
        /// </summary>
        [TestMethod]
        public void Model_CheckGame_AfterInitialization_rightDiagonal_returnTrue()
        {
            //first possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 0,0,0,
                                           0,1,0 ,
                                           1,0,0};

            Assert.IsTrue(_model.CheckGame(2));

            //second possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 0,0,1,
                                           0,0,0,
                                           1,0,0 };

            Assert.IsTrue(_model.CheckGame(4));

            //third possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 0,0,1,
                                           0,1,0,
                                           0,0,0 };

            Assert.IsTrue(_model.CheckGame(6));
        }
        /// <summary>
        /// Game has equality, an exception is executed
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Model_CheckGame_AfterInitialization_Equality_GenerateException()
        {

            //third possibility
            _model.WhatPlayer = 1;
            _model.GameArray = new int[] { 1,2,1,
                                           0,1,2,
                                           2,1,2 };

            _model.CheckGame(3);
        }
        #endregion TestMethods
    }
}
