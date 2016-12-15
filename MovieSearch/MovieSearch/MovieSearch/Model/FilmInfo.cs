using System;
using System.Collections.Generic;

namespace MovieSearch.Model
{
    public class FilmInfo
    {
        public string title { get; set; }
        public string year { get; set; }
        public string imageName { get; set; }
        public List<string> cast { get; set; }
        public string description { get; set; }
        public List<string> genres { get; set; }
        public string duration { get; set; }
        public string rating { get; set; }

        public string castToString
        {
            get { 
                var returnString = "";

                //Change this value to show more/less actors in the listView. 
                //Inconvenient but I don't know another way to implement this with binding.
                var numOfActors = 3; 
                var minNumOfActors = Math.Min(cast.Count, numOfActors);

                for(var i = 0; i < minNumOfActors; i++)
                {
                    returnString += cast[i];
                    returnString += (i == minNumOfActors - 1) ? "" : ", ";
                }

                return returnString;
            }
        }

        public string genresToString
        {
            get
            {
                var numOfGenres = genres.Count;
                var returnString = "";

                for (var i = 0; i < numOfGenres; i++)
                {
                    returnString += genres[i];
                    returnString += (i == numOfGenres - 1) ? "" : ", ";
                }

                return returnString;
            }
        }


    }
}