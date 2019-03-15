using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Data.SQLite;
using System.Collections.Generic;
using Morpion;
namespace TestMorpion
{
    [TestClass]
    public class TestDB
    {
        #region private attributes
        private DataBase _db;
        private string _expectedDbDirLocation;
        private string _expectedDbLocation;
        private string _dbName;
        private List<string> _exceptedScoreLst;
        #endregion private attributes

        #region TestInitialize
        /// <summary>
        /// on instancie les variables
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            this._dbName = "Morpion";
            this._db = new DataBase(_dbName);
            this._db.limit = 10;
            this._expectedDbDirLocation =  AppDomain.CurrentDomain.BaseDirectory + @"\DB\";
            this._expectedDbLocation = _expectedDbDirLocation + _dbName + ".sqlite";
            
        }
        #endregion TestInitialize

        #region TestMethods
        /// <summary>
        /// Check the database dir has been created
        /// </summary>
        [TestMethod]
        public void DataBase_Constructor_AfterInitialization_DatabaseDirExists()
        {
            //refere to Initialize()
            Assert.IsTrue(Directory.Exists(this._expectedDbDirLocation));
        }

        /// <summary>
        /// Check the database file has been created
        /// </summary>
        [TestMethod]
        public void DataBase_Constructor_AfterInitialization_DatabaseExists()
        {
            //refere to Initialize()
            Assert.IsTrue(File.Exists(this._expectedDbLocation));
        }

        /// <summary>
        /// Check the database file has been created
        /// </summary>
        [TestMethod]
        public void DataBase_ScoreList_AfterInitialization_ReturnList()
        {
            //refere to Initialize()
            _exceptedScoreLst = new List<string>();

            _exceptedScoreLst = _db.ScoreList();
            int expectedNbScores = _exceptedScoreLst.Count + 1;

            _db.InsertScore("Diogo", "Ordinateur", 0, 1);

            Assert.AreEqual(expectedNbScores, _db.ScoreList().Count);
        }

        /// <summary>
        /// Insert 11 scores, test if db delete 
        /// the oldes score after 10
        /// </summary>
        [TestMethod]
        public void DataBase_ScoreList_AfterInitialization_tenScores()
        {
            //refere to Initialize()
            _exceptedScoreLst = new List<string>();

            //insert eleven scores
            for(int i=0; i<11; i++)
                _db.InsertScore("Diogo", "Ordinateur", i, 11-i);

            _exceptedScoreLst = _db.ScoreList();
            Assert.AreEqual(10, _exceptedScoreLst.Count);
        }
        #endregion TestMethods

        #region CleanUp
        /// <summary>
        /// Clean values
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
             _db.ClearScores();
            this._db = null;
            this._expectedDbDirLocation = null;
            this._expectedDbLocation = null;
            this._exceptedScoreLst = null;
        }
        #endregion CleanUp
    }
}
