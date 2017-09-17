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


            int[] f_ship = new int[3];
            f_ship[0] = parameters[2]; // lenght
            f_ship[1] = 0;             // x
            f_ship[2] = 0;             // y

            int[] s_ship = new int[3];
            s_ship[0] = parameters[3]; //lenght
            s_ship[1] = 0;             // x
            s_ship[2] = 1;             // y

            #region Processing
            //TODO: List of conditions (Need add more and check)
            // ( parameters[0] > parameters[2] || parameters[3] ) || ( parameters[1] > parameters[2] || parameters[3] )
            // 0 < x0 - horizontal < parameters[0] || parameters[1]
            // 0 < x1 - horizontal < parameters[0] || parameters[1]
            // 0 < y0 - vertikal < parameters[0] || parameters[1]
            // 0 < y1 - vertikal < parameters[0] || parameters[1]
            // x0 > x1
            // y0 > y1

            for (int a = 0; a < parameters[0]; a++) //TODO: Move in columns
            {
                for (int b = a; b > parameters[1]; b--)
                {

                }
            }
            #endregion
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
