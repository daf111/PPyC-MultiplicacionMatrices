using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicacionMatricesParalela
{
    class Program
    {
        static void Main(string[] args)
        {
            Matriz matriz1 = new Matriz(900, 400);
            matriz1.cargarMatriz();
            Matriz matriz2 = new Matriz(400, 900);
            matriz2.cargarMatriz();

            if (matriz1.esMultiplicable(matriz2))
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Matriz resultado = matriz1.Multiplicar(matriz2);
                sw.Stop();
                Console.WriteLine ("LA RESPUESTA ES: ");
                resultado.mostrar();
                Console.WriteLine("El programa demoró " + (sw.ElapsedMilliseconds / 1000) + " seg.");
                Console.Read();
            }
            else
            {
                Console.WriteLine("No se puede multiplicar estas matrices");
                Console.Read();
            }
        }
    }

    public class Matriz
    {
        private int[,] matriz;
        private int fila;
        private int columna;


        public Matriz(int fila, int columna)
        {
            this.matriz = new int[fila, columna];
            this.fila = fila;
            this.columna = columna;
        }

        public void cargarMatriz()
        {
            Random random = new Random();
            for (int r = 0; r < this.fila; r++)
            {
                for (int c = 0; c < this.columna; c++)
                {
                    this.matriz[r, c] = random.Next(1, 100); ;
                }
            }
        }

        public bool esMultiplicable(Matriz otra)
        {
            return this.columna == otra.fila;
        }

        public void mostrar()
        {
            string resultado = "";
            for (int i = 0; i < this.fila; i++)
            {
                for (int j = 0; j < this.columna; j++)
                {
                    resultado = resultado + (this.matriz[i, j].ToString()) + " ";
                }
                Console.WriteLine("[ " + resultado + "]");
                resultado = "";
            }
        }
        public Matriz Multiplicar(Matriz otra)
        {
            Matriz matrixResponse = new Matriz(this.fila, otra.columna);
            int aux = 0;
            Parallel.For(0, this.fila, i =>
            {
                for (int j = 0; j < otra.columna; j++)
                {
                    for (int k = 0; k < this.columna; k++)
                    {
                        aux += this.matriz[i, k] * otra.matriz[k, j];
                    }
                    matrixResponse.matriz[i, j] = aux;
                    aux = 0;
                }
            });
            return matrixResponse;
        }
    } 
}