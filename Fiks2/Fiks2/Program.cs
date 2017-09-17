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
            // ship.lenght < parameters[0] -> (x) - horizontal
            // if not
            // ship.lenght > parameters[0] -> (x) - set on vertical -> parameters[1]
            // left site default ship1[0,0] ship2[0,1]
            // ship1.lenght > ship2.lenght -> ship2 = moveable first
            // right site < parameters[0] && parameters[1]

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
