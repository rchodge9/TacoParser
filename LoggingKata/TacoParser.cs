using System;
using System.Linq;


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
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            // Log that and return null
            // Do not fail if one record parsing fails, return null
            if (cells.Length < 3)
            {
                
                logger.LogError(line);

                return null; // TODO Implement
            }

            var latitude = double.Parse(cells[0]);
            var longitude = double.Parse(cells[1]);
            var name = cells[2];




            var point = new Point()
            {
                Latitude = latitude,
                Longitude = longitude,
            };
            var tacoBell = new TacoBell()
            {
                Name = name,
                Location = point,
            };
            return tacoBell;

            /* grab the LATITUDEfrom your ARRAY at INDEX[0]
             grab the LONGITUDE from your ARRAY at INDEX[1]
             grab the NAME from your ARRAY at INDEX [2]
             Your going to need to PARSE your STRING as a `DOUBLE`
             which is similar to parsing a string as an `int`*/
            /*CELLS=Returns a Range object that represents the cells in the specified range*/
            /*AREA = Returns an Areas collection that represents all the ranges in a multiple-area selection.
             * Collection of the areas, or contiguous blocks of cells, within a selection.*/ //var name= double.Parse(cells[2]); var name = (cells[2]);'Input string was not in a correct format.'//


           

            // You'll need to create a TacoBell class
            // that conforms to ITrackable
            // Then, you'll need an NEW Instance (new object)of the TacoBell class
            // With the Name and Point (Lat & Long)set correctly
            // Then, Return the instance of your TacoBell class
            // Since it conforms to ITrackable (Name, Location)


            
            
           
   




        }
    }
}
