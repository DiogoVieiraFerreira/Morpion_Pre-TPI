using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saintify.Business
{
    /// <summary>
    /// This class is designed to define an artist
    /// </summary>
    public class Artist
    {
        #region private attributes
        private int _id = 0;
        private String _pictureName = "";//artist's picture's file name (see application ressources.resx)
        private String _name = "";//artist's name
        private List<Song> _listOfSongs = null;//list of the artist's songs 
        #endregion private attributes

        #region constructors
        /// <summary>
        /// This constructor initializes a new instance of the artist class.
        /// </summary>
        /// <param name="pictureName">The artist's picture (see application ressources.resx</param>
        /// <param name="name">The artist's name</param>
        /// <param name="listOfSongs">The list of artist's songs</param>
        public Artist (int id, String pictureName, String name, List<Song> listOfSongs)
        {
            //TODO -- Constructor
            _id = id;
            _pictureName = pictureName;
            _name = name;
            _listOfSongs = listOfSongs;
        }
        #endregion constructors

        #region private
        /// <summary>
        /// This method prevents duplicate (when adding a song for the second time)
        /// </summary>
        /// <param name="songToCheck">The song to be added</param>
        /// <returns></returns>
        private bool SongExists(Song songToCheck)
        {
            return false;
        }

        /// <summary>
        /// This method prevents adding "null" song
        /// </summary>
        /// <param name="songToCheck">The song to be added</param>
        /// <returns></returns>
        private bool SongNotNull(Song songToCheck)
        {
            return false;
        }
        #endregion private

        #region public methods
        #region getters and setters
        /// <summary>
        /// This getter delivers the value of the private attribut "id" 
        /// </summary>
        /// <returns>The artist's picture's file name (see application ressources.resx)</returns>
        public int Id()
        {
            //TODO -- Getter PictureName();
            return _id;
        }

        /// <summary>
        /// This getter delivers the value of the private attribut "title" 
        /// </summary>
        /// <returns>The artist's picture's file name (see application ressources.resx)</returns>
        public String PictureName()
        {
            //TODO -- Getter PictureName();
            return _pictureName;
        }

        /// <summary>
        /// This getter delivers the value of the private attribut "name" 
        /// </summary>
        /// <returns>The artist's name</returns>
        public String Name()
        {
            //TODO -- Getter Name();
            return _name;
        }

        /// <summary>
        /// This getter delivers the list of Songs
        /// </summary>
        /// <returns>All songs performed by the artists</returns>
        public List<Song> ListOfSongs()
        {
            //TODO -- Getter ListOfSongs();
            return _listOfSongs;
        }
        #endregion getters and setters
        /// <summary>
        /// This method allows to add a song
        /// </summary>
        /// <param name="songToAdd">an object song to add to the list of existing song</param>
        public void AddSong(Song songToAdd)
        {
            if(songToAdd != null)
            {
                _listOfSongs.Add(songToAdd);
            }
        }

        /// <summary>
        /// This method allows to add a song
        /// </summary>
        /// <param name="songToAdd">The song to be added</param>
        public void AddSong(List<Song> listOfSongsToAdd)
        {
            bool error = false;

            if (listOfSongsToAdd != null)
            {

                //Pour chaque chanson présent dans la liste
                foreach (Song song in listOfSongsToAdd)
                {
                    //vérifie chaque chanson pour voir s'il y a un doublon ou si la valeur est nulle
                    foreach (Song _song in _listOfSongs)
                    {
                        if (song == _song || song == null)
                        {
                            error = true;
                        }
                    }
                    //Si la chanson n'existe pas déjà, on l'ajoute
                    if (error == false)
                    {
                        _listOfSongs.Add(song);
                    }
                }
            }
        }
        #endregion public methods


    }
}
