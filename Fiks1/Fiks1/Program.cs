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
            for (int i = 0; i < inputCount; i++)
            {
                #region Howno
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
                #endregion
                #region Sorting
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
                Console.WriteLine("Segment: " + Convert.ToString(i));
                #endregion Sorting
                #region Processing
                //Todo: Implement main processing logic
                #endregion
            }
        }
    }
}
