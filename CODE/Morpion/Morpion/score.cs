using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morpion
{
    /// <summary>
    /// this class allows to create an object containing the score between 2 players
    /// </summary>
    public class score
    {
        /// <summary>
        /// accessor of first player's name
        /// </summary>
        public string nameP01 { get; set; }
        /// <summary>
        /// accessor of second player's name
        /// </summary>
        public string nameP02 { get; set; }
        /// <summary>
        /// accessor of first player's score
        /// </summary>
        public string scoreP01 { get; set; }
        /// <summary>
        /// accessor of second player's score
        /// </summary>
        public string scoreP02 { get; set; }
    }
}
