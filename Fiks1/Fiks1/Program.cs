using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace Fiks1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("./input.txt");
            int inputCount = Convert.ToInt32(reader.ReadLine());
            int[] results = new int[inputCount];
            //Main segment loop (calculates every input segment)
            for (int i = 0; i < inputCount; i++)
            {
                #region Input parsing
                int _buildingsCount = Convert.ToInt32(reader.ReadLine());
                List<int[]> buildings = new List<int[]>();
                for (int z = 0; z < _buildingsCount; z++) 
                {
                    string[] sBuilding = reader.ReadLine().Split(' ');
                    int[] tmp = new int[sBuilding.Length];
                    for (int n = 0; n < sBuilding.Length; n++)
                    {
                        tmp[n] = Convert.ToInt32(sBuilding[n]);
                    }
                    buildings.Add(tmp);
                }
                Console.WriteLine("Segment parsed: {0} Contains {1} buildings", i,buildings.Count);
                #endregion
                #region Sorting
                //TODO: Replace with faster sorting algo
                int[] temp;
                for (int write = 0; write < buildings.Count; write++)
                {
                    for (int sort = 0; sort < buildings.Count - 1; sort++)
                    {
                        if (buildings[sort][1] > buildings[sort + 1][1])
                        {
                            temp = buildings[sort + 1];
                            buildings[sort + 1] = buildings[sort];
                            buildings[sort] = temp;
                        }
                    }
                }
                Console.WriteLine("Segment sorted!");
                #endregion Sorting
                #region Processing
                for (int u = 0; u < buildings.Count; u++) //Loop throught every building
                {
                    int indexer = 1;
                    if(u + indexer < buildings.Count)
                    while (buildings[u][2] < buildings[u+indexer][1]) //Loop throught every coliding building
                    {
                        //Todo: Implement main processing logic (for conflict resolving)
                        if (buildings[u][0]>buildings[u + indexer][0]) //Is current building highter than following
                        {

                        }
                        else //TODO: Check if concept is correct with same heights
                        {

                        }
                            if (u + indexer + 1 < buildings.Count) //TODO: check logic (out of range prevention attemp)
                            { indexer++; }
                            else { break; }
                    }
                }
                Console.WriteLine("Segment colisions processed");
                #endregion
                #region Computing
                //TODO: Implement building's content computation (and result reporting)
                #endregion
            }

            Console.WriteLine("All segments done, Press any key to continue");
            Console.ReadKey();
        }
    }
}
