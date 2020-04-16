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
    

        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
            {
                Matriz m1 = new Matriz(2, 3);
                Matriz m2 = new Matriz(3, 2);

                Task t1 = new Task(() =>
                {
                    m1.Cargar();

                });
                Task t2 = new Task(() =>
                {
                    m2.Cargar();

                });
                Task t3 = new Task(() =>
                {
                    Console.WriteLine("Matriz A");
                    m1.Mostrar();
                    Console.WriteLine("\nMatriz B");
                    m2.Mostrar();

                });

                Task t4 = new Task(() =>
                {
                    Console.WriteLine("\nResultado");
                    m1.Multiplicar(m2).Mostrar();
                });


                t1.Start();
                t2.Start();
                Task.WaitAll(t1, t2);

                t3.Start();
                t3.Wait();

                t4.Start();
                t4.Wait();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            sw.Stop();
            Console.WriteLine("El programa demoró " + (sw.ElapsedMilliseconds / 1000) + " seg.");
            Console.WriteLine("Presione enter para finalizar");
            Console.ReadLine();

        }
    }
}
