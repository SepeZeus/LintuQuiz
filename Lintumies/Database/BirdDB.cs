using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lintumies.Database
{
    internal class BirdDB
    {
        public class BirdBD
        {
            public string birdName { get; set; }
            public int heardCnt { get; set; }
            public int correctCnt { get; set; }
            public int wrongCnt { get; set; }
            public int Priority { get; set; }

            // Method to save data to a .json file
            public void SaveToJson(string fileName)
            {
                try
                {
                    string jsonData = JsonConvert.SerializeObject(this);
                    File.WriteAllText(fileName, jsonData);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error saving data to file: " + ex.Message);
                }
            }

            // Method to load data from a .json file
            public static BirdBD LoadFromJson(string fileName)
            {
                try
                {
                    string jsonData = File.ReadAllText(fileName);
                    BirdBD bird = JsonConvert.DeserializeObject<BirdBD>(jsonData);
                    return bird;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error loading data from file: " + ex.Message);
                    return null;
                }
            }
        }
    }
}
