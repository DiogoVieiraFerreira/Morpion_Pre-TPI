using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Morpion
{
    /// <summary>
    /// The class give access to DB
    /// </summary>
    class DataBase
    {

        private SQLiteConnection _dbConnection;

        #region private methods
        /// <summary>
        /// Connection with your DB
        /// </summary>
        private void DB_Connection()
        {
            _dbConnection = new SQLiteConnection("Data Source=Morpion.sqlite;Version=3;");
        }
        
        #endregion private methods

        #region publics methods
        public void InsertScore(string userName01, string userName02, int score01, int score02)
        {
            SQLiteCommand insertSQL = new SQLiteCommand("INSERT INTO Score(Player01, Player02, ScoreP01, ScoreP02) VALUES (?,?,?,?)");
            insertSQL.Parameters.Add(userName01);
            insertSQL.Parameters.Add(userName02);
            insertSQL.Parameters.Add(score01);
            insertSQL.Parameters.Add(score02);
        }
        #endregion publics methods

        #region accessor
        
        #endregion accessor
    }
}
