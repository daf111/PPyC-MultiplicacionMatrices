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
            Matriz mat1 = new Matriz(2, 3);
            Matriz mat2 = new Matriz(3, 2);
            if (mat1.EsMultiplicablePor(mat2))
            {
                var m1 = Task.Factory.StartNew(() =>
                {
                    mat1.Cargar();
                    mat2.Cargar();
                    return new Matriz[] { mat1, mat2 };
                });
                var m2 = m1.ContinueWith((predecesora) =>
                {
                    Console.WriteLine("Matriz 1 : ");
                    predecesora.Result[0].Mostrar();
                    Console.WriteLine("Matriz 2 : ");
                    predecesora.Result[1].Mostrar();

                    return predecesora.Result;
                });
                var m3 = m2.ContinueWith((predecesora) =>
                {

                    var resultado = predecesora.Result[0].MultiplicarPor(predecesora.Result[1]);
                    return resultado;
                });
                var m4 = m3.ContinueWith((predecesora) =>
                {

                    Console.WriteLine("el resultado es : ");
                    predecesora.Result.Mostrar();

                });
                Task[] tasks = new Task[] { m1, m2, m3, m4 };
                Task.WaitAll(tasks);
            }
            else
            {
                throw new Exception("esas matrices no se pueden multiplicar");
            }


            Console.WriteLine("ejercicio terminado");
            Console.WriteLine("precione una tecla para salir");
            Console.ReadLine();

        }
    }
}
