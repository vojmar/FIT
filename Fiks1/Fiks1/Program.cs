using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace Fiks1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region File operations and declaration
            string inputFile = "./input.txt";
            string outputFile = "./output.txt";
            if (args.Length > 0)
                inputFile = args[0];
            StreamReader reader = new StreamReader(inputFile);
            Stopwatch sw = new Stopwatch();
            TimeSpan span = new TimeSpan(0);
            if (File.Exists(outputFile))
                File.Delete(outputFile); 
            #endregion
            int inputCount = Convert.ToInt32(reader.ReadLine());
            //Main segment loop (calculates every input segment)
            for (int i = 0; i < inputCount; i++)
            {
                sw.Start();
                Console.ForegroundColor = ConsoleColor.Red;
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
                Console.WriteLine("{2}\t Segment parsed: {0} \t Contains {1} buildings", i,buildings.Count,sw.Elapsed);
                #endregion
                #region Sorting
                //TODO: Replace with faster sorting algo
                //int[] temp;
                //for (int write = 0; write < buildings.Count; write++)
                //{
                //    for (int sort = 0; sort < buildings.Count - 1; sort++)
                //    {
                //        if (buildings[sort][1] > buildings[sort + 1][1])
                //        {
                //            temp = buildings[sort + 1];
                //            buildings[sort + 1] = buildings[sort];
                //            buildings[sort] = temp;
                //        }
                //    }
                //}
                Quicksort(buildings,0,buildings.Count);
                buildings.Reverse();
                Console.WriteLine("{0}\t Segment sorted!",sw.Elapsed);
                #endregion Sorting
                #region Processing
                for (int u = 0; u < buildings.Count; u++) //Loop throught every building  //TODO: 113 segment je vynechaný z výpočtu, program se ukončí po spočtení 112
                { 
                    int indexer = 1;
                    if(u + indexer < buildings.Count)
                    while (buildings[u][2] > buildings[u+indexer][1]) //Loop throught every coliding building
                    {
                            bool doNext = true; //Do not change indexer if List changed (when building is deleted)
                             //Todo: Implement main processing logic (for conflict resolving)
                            if (buildings[u][0]>buildings[u + indexer][0]) //Is current building taller than following
                        {
                                if (buildings[u+indexer][2] <= buildings[u][2]) //building size underrun check
                                {
                                    buildings.RemoveAt(u + indexer);
                                    doNext = false;
                                }
                                else
                                {
                                    buildings[u + indexer][1] = buildings[u][2];
                                }
                        }
                        else //TODO: Check if concept is correct with same heights
                        {
                                if (buildings[u][2] <= buildings[u + indexer][2])
                                {
                                    buildings[u][2] = buildings[u+indexer][1];
                                }
                                else
                                {
                                    buildings.Insert(u + indexer+1,new int[] { buildings[u][0], buildings[u + indexer][1] ,buildings[u][2] });
                                    buildings[u][2] = buildings[u + indexer][1];
                                }
                        }
                            if (u + indexer + 1 < buildings.Count) //TODO: check logic (out of range prevention attemp)
                            {
                                if(doNext)
                                    indexer++;
                            }
                            else { break; }
                    }
                }
                Console.WriteLine("{0}\t Segment colisions processed", sw.Elapsed);
                #endregion
                #region Computing
                //TODO: Implement building's content computation (and result reporting)
                ulong result = 0;
                foreach (var building in buildings)
                {
                    result = result + (ulong)(building[2]-building[1])*(ulong)building[0];
                }

                using (StreamWriter writer = new StreamWriter(outputFile, true)) //Saving results to file
                {
                    writer.WriteLine(result);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{4}\t Segment {2}/{3} content done. Total size is {0} \nSegment took: {5} \t Progress saved to {1}\n\n", result,outputFile,i,inputCount,sw.Elapsed,sw.Elapsed-span);
                span = sw.Elapsed;
                Console.ResetColor();
                #endregion
            }

            Console.WriteLine("All segments done, Press any key to continue");
            Console.ReadKey();
        }
        public static void Quicksort(List<int[]> array, int left, int right)
        {
            if (left < right)
            {
                int boundary = left;
                for (int i = left + 1; i < right; i++)
                {
                    if (array[i][1] > array[left][1])
                    {
                        Swap(array, i, ++boundary);
                    }
                }
                Swap(array, left, boundary);
                Quicksort(array, left, boundary);
                Quicksort(array, boundary + 1, right);
            }
        }
        private static void Swap(List<int[]> array, int left, int right)
        {
            int[] tmp = array[right];
            array[right] = array[left];
            array[left] = tmp;
        }
    }
}
