using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicacionMatricesSecuencial
{
    class Program
    {
        static int[,] generateMatrix(int rows, int columns)
        {
            Random random = new Random();
            int[,] matrix = new int[rows, columns]; //Matriz de 3 filas x 2 columnas
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    matrix[r, c] = random.Next(1, 100); ;
                }
            }

            return matrix;
        }

        static void Main(string[] args)
        {
            int respuesta = 0;

            int r1 = 900;
            int c1 = 400;
            int[,] matrix1 = generateMatrix(r1, c1); //Matriz de 3 filas x 2 columnas

            int r2 = 400;
            int c2 = 900;
            int[,] matrix2 = generateMatrix(r2, c2); //Matriz de 2 filas x 3 columnas

            if (c1 == r2) //Si el numero de columnas de la 1 es igual al numero de filas de la 2
            {

                Stopwatch sw = new Stopwatch();
                sw.Start();

                int[,] matrixResponse = new int[r1, c2];
              
                Parallel.For(0, r1, i =>
               {
                   for (int j = 0; j < c2; j++)
                   {
                       for (int k = 0; k < c1; k++)
                       {
                           respuesta += matrix1[i, k] * matrix2[k, j];
                       }
                       matrixResponse[i, j] = respuesta;
                       respuesta = 0;
                   }
               });
                 

                sw.Stop();

                Console.WriteLine("LA RESPUESTA ES: ");
                string igual = "";
                for (int i = 0; i < r1; i++)
                {
                    for (int j = 0; j < c2; j++)
                    {
                        igual = igual + (matrixResponse[i, j].ToString()) + "  ";
                    }
                    Console.WriteLine("[  " + igual + "]");
                    igual = "";
                }

                Console.WriteLine("El programa demoró " + (sw.ElapsedMilliseconds / 1000) + "seg.");
                Console.ReadLine();

            }
            else
            {
                Console.WriteLine("No se puede multiplicar estas matrices");
                Console.Read();
            }

        }
    }
}
