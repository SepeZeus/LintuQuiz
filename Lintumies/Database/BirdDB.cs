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
        public class BirdDBMethods
        {
            public string birdName { get; set; }

            public string[] birdSounds { get; set; }

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

            public static BirdDBMethods GetBirdDetails(string birdName)
            {
                string filePath = "../../../Database/birdData.json";

                // Load existing data from file, if it exists
                List<BirdDBMethods> birds = new List<BirdDBMethods>();
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    birds = JsonConvert.DeserializeObject<List<BirdDBMethods>>(jsonData);
                }

                // Find the bird with the specified name and return its details
                var bird = birds.FirstOrDefault(b => b.birdName == birdName);
                if (bird != null)
                {
                    return bird;
                }
                else
                {
                    Console.WriteLine("Bird not found");
                    return null;
                }
            }



            public void AddBird(string birdName, int heardCnt, int correctCnt, int wrongCnt, int priority)
            {
                string filePath = "../../../Database/birdData.json";

                // Load existing data from file, if it exists
                List<BirdDB.BirdDBMethods> birds = new List<BirdDB.BirdDBMethods>();
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    birds = JsonConvert.DeserializeObject<List<BirdDB.BirdDBMethods>>(jsonData);
                }

                // Create new bird and add it to the list
                BirdDB.BirdDBMethods bird = new BirdDB.BirdDBMethods
                {
                    birdName = birdName,
                    heardCnt = heardCnt,
                    correctCnt = correctCnt,
                    wrongCnt = wrongCnt,
                    Priority = priority
                };
                birds.Add(bird);

                // Serialize the list back to JSON and save it to the file
                string json = JsonConvert.SerializeObject(birds, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }


            public void UpdateBird(string birdName, int heardCnt, int correctCnt, int wrongCnt, int priority)
            {
                string filePath = "../../../Database/birdData.json";

                // Load existing data from file, if it exists
                List<BirdDB.BirdDBMethods> birds = new List<BirdDB.BirdDBMethods>();
                if (File.Exists(filePath))
                {
                    string jsonData = File.ReadAllText(filePath);
                    birds = JsonConvert.DeserializeObject<List<BirdDB.BirdDBMethods>>(jsonData);
                }

                // Find the bird with the specified name and update its properties
                var bird = birds.FirstOrDefault(b => b.birdName == birdName);
                if (bird != null)
                {
                    bird.heardCnt = heardCnt;
                    bird.correctCnt = correctCnt;
                    bird.wrongCnt = wrongCnt;
                    bird.Priority = priority;
                }
                else
                {
                    // Bird not found, so add it as a new bird
                    bird = new BirdDB.BirdDBMethods
                    {
                        birdName = birdName,
                        heardCnt = heardCnt,
                        correctCnt = correctCnt,
                        wrongCnt = wrongCnt,
                        Priority = priority
                    };
                    birds.Add(bird);
                }

                // Serialize the list back to JSON and save it to the file
                string json = JsonConvert.SerializeObject(birds, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }


            // Method to load data from a .json file
            public static BirdDBMethods LoadFromJson(string fileName)
            {
                try
                {
                    string jsonData = File.ReadAllText(fileName);
                    BirdDBMethods bird = JsonConvert.DeserializeObject<BirdDBMethods>(jsonData);
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
