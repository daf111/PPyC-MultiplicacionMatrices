using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplicacionMatricesSecuencial
{
    class Matriz
    {
        private int filas;
        private int columnas;
        private int[,] elementos;
        Random aleatorio = new Random();
        public Matriz(int filas, int columnas)
        {
            this.filas = filas;
            this.columnas = columnas;
            elementos = new int[this.filas, this.columnas];
        }

        public void Mostrar()
        {
            for (int f = 0; f < filas; f++)
            {
                for (int c = 0; c < columnas; c++)
                {
                    Console.Write(elementos[f, c] + " ");
                }
                Console.WriteLine("");
            }
        }

        public void Cargar()
        {
            for (int f = 0; f < filas; f++)
            {
                for (int c = 0; c < columnas; c++)
                {

                    elementos[f, c] = aleatorio.Next(0, 9);
                }
            }
        }

        private bool EsMultiplicablePor(Matriz otra)
        {
            return (this.columnas == otra.filas);
        }

        public Matriz Multiplicar(Matriz otra)
        {
            if (EsMultiplicablePor(otra))
            {
                return this.MultiplicarPor(otra);
            }
            else
            {
                throw new Exception("No se pudo realizar la multiplicacion: A.columnas != B.filas");
            }
        }

        private Matriz MultiplicarPor(Matriz otra)
        {
            Matriz resultado = new Matriz(this.filas, otra.columnas);
            int respuesta = 0;

            Parallel.For(0, this.filas, i => {
                for (int j = 0; j < otra.columnas; j++)
                {
                    for (int k = 0; k < this.columnas; k++)
                    {
                        respuesta += this.elementos[i, k] * otra.elementos[k, j];
                    }
                    resultado.elementos[i, j] = respuesta;
                    respuesta = 0;
                }
            });
            return resultado;
        }
    }
}
