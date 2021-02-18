using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;


namespace LoggingKata
{
    //Finished 
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            // TODO:  Find the two Taco Bells that are the furthest from one another.
            // HINT:  You'll need two nested forloops ---------------------------

            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            // LOG and ERROR IF you get 0 LINE and a WARNING IF you get 1 LINE
            //Try block, and Catch the exception in a catch block.
            //(catch (ArgumentNullException e) or catch (Exception e) Console.WriteLine("{0} First exception caught.", e);
            var lines = File.ReadAllLines(csvPath);
            try
            {
                logger.LogInfo($"Lines: {lines[0]}");
            }
            catch(Exception x)
            {
                logger.LogError($" Error! The csv file has 0 lines in",x );

                Environment.Exit(0);

              
            }
            if (lines.Count()==1) //count returns the number of elements in a sequence 
            {
                logger.LogWarning($"Warning! The csv file contains only 1 line");
                Environment.Exit(0);
            }
            /*If Exit is called from a try or catch block, the code in any finally block does not execute. 
            *If the return statement is used, the code in the finally block does execute.*/  //The ExitCode property is a signed 32-bit integer. 
                                                                                             //Environment.ExitCode property to indicate error conditions. 
            /* Environment class Provides information about, and means to manipulate, 
            *the current environment and platform. This class cannot be inherited.*/


            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();

            // DON'T FORGET TO LOG YOUR STEPS

            // Now that your Parse method is completed, START BELOW ----------

            // TODO: Create TWO `ITrackable` variables with Initial Values of `Null`. These will be used to Store your TWO Taco Bells that are the farthest from each other.
            // Create a `DOUBLE` Variable to store the Distance

            //My Notes 
            // don't know distance so =0 but 0 is a error so we want to add to that.... 
            // want to know locations ...locations are in miles which is a distance so Length... length is greater than 0
            //locations want the location for locA


            ITrackable tacoA =null;
            ITrackable tacoB= null;
            var distance = 0.00;

            

            for (int a = 0; a < locations.Length; a++ )
            {
                var locA= locations[a].Location;
                
                    
                
                for (int b = 0; b < locations.Length; b++)
                {
                    var locB = locations[b].Location;
                    
                        var corB = new GeoCoordinate(locB.Latitude, locB.Longitude);
                        var corA = new GeoCoordinate(locA.Latitude, locA.Longitude);
                    
                    if (distance < corA.GetDistanceTo(corB))
                    {
                        distance = corA.GetDistanceTo(corB);

                        tacoA = locations[a];
                        tacoB = locations[b];
                    }

                    
                }
               

            }

            Console.WriteLine($"{tacoA.Name} and {tacoB.Name} equal the furthest apart");
            
            
            
            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`

            //HINT NESTED LOOPS SECTION---------------------
            // Do a loop for your locations to grab each location the origin (perhaps: `locA`)

            // Create a NEW corA Coordinate with your locA's Lat and Long (int)

            // Now, do another loop on the Locations within the scope of your first loop, so you can grab the "destination" Location (perhaps: `locB`)

            // Create a new Coordinate with your locB's lat and long

            // Now, compare the two using `.GetDistanceTo()`, which returns a Double
            // IF the DISTANCE is GREATER than the currently saved distance, update the distance and the two `ITrackable` variables you set above

            // Once you've looped through everything, you've found the two Taco Bells (Names)farthest away from each other.


            

        }
    }
}
