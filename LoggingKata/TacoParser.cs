using System.Data.Common;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split();


            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                // Log that and return null
                // Do not fail if one record parsing fails, return null
                return null; 
            }

        
            var lat = double.Parse(cells [0]);
    
            var lon = double.Parse(cells[1]);
       
            var name = cells[2];


            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly
           
            var Point = new Point();
            Point.Latitude = lat;
            Point.Longitude = lon;
            var tacobell = new TacoBell();
            tacobell.Name = name;
            tacobell.Point = Point;
         
 
            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable

            return tacobell;
        }
    }
}