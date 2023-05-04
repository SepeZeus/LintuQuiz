using Lintumies.Database;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;


namespace Lintumies
{
    internal class SpacedRepetition
    {
        public double priotityCalculator(int heardCnt, int wrongCnt)
        {
            double priority;
            if (heardCnt > 0)
            {
                priority = Math.Round(((double)wrongCnt / heardCnt), 2);
            }
            else
                priority = 0.90;

            //round priority value up or down depending on which side it is too much
            if (priority > 0.90)
                priority = 0.90;
            else if (priority < 0.1)
                priority = 0.1;
            return priority;
        }
        //return a list of birds
        public List<string> listOfBirds()
        {
            Random random = new Random();
            double rndChance = Math.Round(random.NextDouble(), 2);
            int rndBird = random.Next(0, 10);

            List<string> birdList = new List<string>();
            List<string> checkList = new List<string>(); //for checking if all birds have been tried to be added to the list already

            List<string> birds = new List<string>();
            birds.Add("Harakka");
            birds.Add("Hippiainen");
            birds.Add("Jarripeippo");
            birds.Add("Kaki");
            birds.Add("Pajulintu");
            birds.Add("Peippo");
            birds.Add("Punarinta");
            birds.Add("Rakattirastas");
            birds.Add("Selkalokki");
            birds.Add("Varis");

            while(birdList.Count != 5)
            {
                BirdDB.BirdDBMethods birdGet = BirdDB.BirdDBMethods.GetBirdDetails(birds[rndBird]);

                //higher priority birds get chosen easier, max 3 times in a row
                if (!birdList.Contains(birds[rndBird]) && birdGet.Priority > rndChance && birdList.Count < 4 && birdGet.rowCnt <= 2)
                    birdList.Add(birds[rndBird]);
                else if (!birdList.Contains(birds[rndBird]) && checkList.Count == 10 && birdList.Count < 4 && birdGet.rowCnt <= 2) //if bird is not already in list
                    birdList.Add(birds[rndBird]);

                if(birdList.Count >= 4)
                    break;

                if (!checkList.Contains(birds[rndBird])) //only add new birds to checklist
                    checkList.Add(birds[rndBird]);
                rndBird = random.Next(0, 10);
            }
            Debug.WriteLine(birdList.Count());
            //bird will not appear more than three times in a row (not affected if high priority) && will not appear for two times in a row after
            foreach (string bird in birds)
            {
                BirdDB.BirdDBMethods birdGet = BirdDB.BirdDBMethods.GetBirdDetails(bird);
                BirdDB.BirdDBMethods birdUpdate = new BirdDB.BirdDBMethods();
                int rowCnt = birdGet.rowCnt;
                if (!birdList.Contains(bird) || rowCnt > 3)
                    rowCnt = 0;
                else
                    rowCnt += 1;
                birdUpdate.UpdateBird(birdGet.birdName, birdGet.heardCnt, birdGet.correctCnt, birdGet.wrongCnt, rowCnt, birdGet.Priority);
                Debug.WriteLine(birdGet.birdName + rowCnt);

            }
            return birdList;
        }
    }
}
