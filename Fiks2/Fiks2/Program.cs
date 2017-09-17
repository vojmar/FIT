using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace Fiks2
{
    class Program
    {
        static void Main(string[] args)
        {
            #region File operation
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
            #region Parsing
            string[] inputCount = reader.ReadLine().Split(' ');
            int[] parameters = new int[inputCount.Length];
            for (int i = 0; i < inputCount.Length; i++)
            {
                parameters[i] = Convert.ToInt32(inputCount[i]);
            }
            #endregion

            int f_ship = parameters[2];
            int s_ship = parameters[3];

            #region Processing
            for (int a = 0; a < parameters[0]; a++) //TODO: Move in columns
            {
                for (int b = 0; b < parameters[1]; b++)
                {

                }
            }
            #endregion
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
