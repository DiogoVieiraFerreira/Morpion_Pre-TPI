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
        #endregion TestMethods

        #region CleanUp
        /// <summary>
        /// Clean values
        /// </summary>
        [TestCleanup]
        public void Cleanup()
        {
            if (Directory.Exists(this._expectedDbDirLocation))
            {
                Directory.Delete(this._expectedDbDirLocation);
            }
            this._expectedDbDirLocation = null;
            this._expectedDbLocation = null;
            this._db = null;
        }
        #endregion CleanUp
        
    }
}
