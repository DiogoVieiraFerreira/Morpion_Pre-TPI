using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using saintify.Business;//Business Namespace to get easily access to business classes
using Newtonsoft.Json;//To manage JSON Content
using System.IO;//To manager files

namespace saintify.Data
{
    /// <summary>
    /// This class is designed to manage JSON File
    /// </summary>
    public class JsonConnector
    {
        #region private attributes
        private String _jsonFileName = "";
        private List<Artist> listOfArtists;
        #endregion private attributes

        #region constructors
        /// <summary>
        /// This constructor initializes a new instance of the artist class.
        /// </summary>
        /// <param name="jsonFileName">File Name containing the json string</param>
        public JsonConnector (String jsonFileName)
        {
            _jsonFileName = jsonFileName;

            ReadJsonFile();
        }
        #endregion constructors

        #region private methods
        /// <summary>
        /// This method is designed to extrat from file json content and convert it in artist object
        /// </summary>
        /// <returns>A list of artists extracted from Json File</returns>
        private List<Artist> ReadJsonFile()
        {
            //TODO -- Method ReadJsonFile()

            /* Help :
             * 
             * StreamReader to read a file
             * StreamReader has a method "ReadToEnd()"
             * Do not forget to close the file stream...
             * 
             * More info there : https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=netframework-4.7.2
             * 
             * To test if a file exists "File.Exists([pathToFile])"
             * 
             * More info there : https://docs.microsoft.com/en-us/dotnet/api/system.io.file.exists?view=netframework-4.7.2
             * 
             * The library Newtonsoft is already added in the class.
             * You can use the class "JsonConvert" with the method "DeserializeObject"
             * More info there : https://www.newtonsoft.com/json/help/html/DeserializeCollection.htm
             */

            //Verifie que le fichier exsiste
            if (File.Exists(this._jsonFileName))
            {
                //ouvre le fichier json
                using (StreamReader json = new StreamReader(this._jsonFileName))
                {
                    string jay = json.ReadToEnd();
                    try
                    {
                        listOfArtists = JsonConvert.DeserializeObject<List<Artist>>(jay);

                        foreach (Artist artist in listOfArtists)
                        {
                            int sameArtist = 0;
                            foreach (Artist artist2 in listOfArtists)
                            {
                                if (artist.Id() == artist2.Id())
                                {
                                    sameArtist++;

                                    if (sameArtist > 1)
                                    {
                                        foreach(Song song2 in artist2.ListOfSongs())
                                        {
                                            int sameSong = 0;
                                            foreach(Song song in artist.ListOfSongs())
                                            {
                                                if(song == song2)
                                                {
                                                    sameSong++;
                                                }
                                            }
                                            if(sameSong == 0)
                                            {
                                                artist.AddSong(song2);
                                            }
                                        }
                                        listOfArtists.Remove(artist2);
                                    }
                                }
                            }
                        }

                        return listOfArtists;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
            else
            {
                return this.listOfArtists;
            }
        }
        #endregion private methods

        #region public methods
        #region getters and setters
        /// <summary>
        /// This getter delivers the artist's list of songs" 
        /// </summary>
        /// <returns></returns>
        public List<Artist> ListOfArtists()
        {
            //TODO -- Getter ListOfArtists();

            return this.listOfArtists; 
        }
        #endregion getters and setters
        #endregion public methods
    }
}
