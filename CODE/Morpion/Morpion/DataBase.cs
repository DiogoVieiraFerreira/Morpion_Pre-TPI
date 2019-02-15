using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;

namespace Morpion
{
    /// <summary>
    /// The class give access to DB
    /// </summary>
    public class DataBase
    {
        #region private attributes
        private SQLiteConnection _dbConnection;
        private SQLiteDataReader _reader;
        private List<string> _ScoreList;
        private string _sql;
        private string _dbDirLocation = AppDomain.CurrentDomain.BaseDirectory + @"\DB\";
        #endregion private attributes

        #region Constructor
        public DataBase(string dbName)
        {
            dbName += ".sqlite";
            string dbLocation = _dbDirLocation + dbName;
            _dbConnection = new SQLiteConnection("Data Source=" + dbLocation + ";Version=3;");

            if (!Directory.Exists(_dbDirLocation)) Directory.CreateDirectory(_dbDirLocation);
            if (!File.Exists(dbLocation))
            {
                SQLiteConnection.CreateFile(dbLocation);                
                CreateTable(@"CREATE TABLE IF NOT EXISTS Scores (
                                  idScore INTEGER PRIMARY KEY,
                                  Player01 VARCHAR(45) NOT NULL,
                                  Player02 VARCHAR(45) NOT NULL,
                                  ScoreP01 INT NOT NULL,
                                  ScoreP02 INT NOT NULL
                                );");                
            }
        }
        #endregion Constructor

        #region private methods
        /// <summary>
        /// Open DB for use this
        /// </summary>
        private void OpenDB()
        {
            _dbConnection.Open();
        }
        /// <summary>
        /// close DB
        /// </summary>
        private void CloseDB()
        {
            try {
                _dbConnection.Close();
            }
            catch (Exception e)
            {
                e.ToString();
            }

        }
        /// <summary>
        /// create Table
        /// </summary>
        /// <param name="query"></param>
        private void CreateTable(string query)
        {
            OpenDB();
            SQLiteCommand command = new SQLiteCommand(query, _dbConnection);
            command.ExecuteNonQuery();
            command.Dispose();
            CloseDB();
        }

        #endregion private methods

        #region publics methods
        /// <summary>
        /// Add column in database with param values
        /// </summary>
        /// <param name="userName01">name of first user</param>
        /// <param name="userName02">name of second user</param>
        /// <param name="score01">score of first user</param>
        /// <param name="score02">score of second user</param>
        public void InsertScore(string userName01, string userName02, int score01, int score02)
        {
            OpenDB();
            SQLiteCommand query = new SQLiteCommand("INSERT INTO Scores(Player01, Player02, ScoreP01, ScoreP02) VALUES (@param1, @param2, @param3, @param4)", _dbConnection);
            query.Parameters.Add(new SQLiteParameter("@param1",userName01));
            query.Parameters.Add(new SQLiteParameter("@param2",userName02));
            query.Parameters.Add(new SQLiteParameter("@param3",score01));
            query.Parameters.Add(new SQLiteParameter("@param4",score02));
            query.ExecuteReader();
            CloseDB();
        }

        /// <summary>
        /// Select all scores in db and send a list with them
        /// </summary>
        /// <returns>list with all scores</returns>
        public List<string> ScoreList()
        {
            if (_ScoreList == null)
                _ScoreList = new List<string>();

            _sql = "SELECT * FROM Scores";
            SQLiteCommand command = new SQLiteCommand(_sql, _dbConnection);

            OpenDB();

            _reader = command.ExecuteReader();
            command.Dispose();

            while (_reader.Read())
            {
                _ScoreList.Add(_reader["Player01"] + " vs " + _reader["Player02"] + "\t" + _reader["ScoreP01"] + " : " + _reader["ScoreP02"]);
            }

            CloseDB();

            return _ScoreList;
        }
        #endregion publics methods

        #region accessor

        #endregion accessor
    }
}
