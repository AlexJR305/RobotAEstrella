using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotIA
{
    
    public class Nodo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int CostoActual { get; set; }
        public int Heuristica { get; set; }
        public Nodo Padre { get; set; }
    }
    
    public class AEstrella
    {
        private int[,] plano;
        private Nodo inicio;
        private Nodo objetivo;

        public AEstrella(int[,] plano, Nodo Inicio, Nodo Objetivo)
        {
            this.plano = plano;
            this.inicio = Inicio;
            this.objetivo= Objetivo;
        }
        List<Nodo> TodosLosNodos = new List<Nodo>();

        public List<Nodo> TodosLosVecinosEncontrados()
        {
            return TodosLosNodos;
        }
        
        public List<Nodo> EncontrarCamino(Nodo inicio, Nodo objetivo)
        {
            
            List<Nodo> listaAbierta = new List<Nodo> { inicio };
            List<Nodo> listaCerrada = new List<Nodo>();

            while (listaAbierta.Count > 0)
            {
                Nodo nodoActual = SeleccionarNodoMenorCosto(listaAbierta);

                if (EsObjetivo(nodoActual, objetivo))
                {
                    return ConstruirCamino(nodoActual);
                }

                MoverDeAbiertaACerrada(nodoActual, listaAbierta, listaCerrada);

                List<Nodo> vecinos = ObtenerVecinos(nodoActual);

                foreach (Nodo vecino in vecinos)
                {
                    if (listaCerrada.Contains(vecino))
                        continue;

                    int costoActual = nodoActual.CostoActual + CalcularCosto(nodoActual, vecino);

                    if (!listaAbierta.Contains(vecino) || costoActual < vecino.CostoActual)
                    {
                        ActualizarCostoYPadre(vecino, costoActual, nodoActual);
                        AgregarAListaAbiertaSiNoEsta(vecino, listaAbierta);
                    }
                }
            }

            return null;  // No se encontró un camino
        }

        private Nodo SeleccionarNodoMenorCosto(List<Nodo> lista)
        {
            // Implementar lógica para seleccionar el nodo con el menor costo
            // Puedes usar LINQ para simplificar esto, pero aquí se muestra un enfoque básico
            Nodo nodoMenorCosto = lista[0];
            foreach (Nodo nodo in lista)
            {
                if (nodo.CostoActual + nodo.Heuristica < nodoMenorCosto.CostoActual + nodoMenorCosto.Heuristica)
                {
                    nodoMenorCosto = nodo;
                }
            }
            return nodoMenorCosto;
        }

        private bool EsObjetivo(Nodo nodo, Nodo objetivo)
        {
            return nodo.X == objetivo.X && nodo.Y == objetivo.Y;
        }

        private void MoverDeAbiertaACerrada(Nodo nodo, List<Nodo> listaAbierta, List<Nodo> listaCerrada)
        {
            listaAbierta.Remove(nodo);
            listaCerrada.Add(nodo);
        }

        private List<Nodo> ObtenerVecinos(Nodo nodo)
        {
            // Implementar lógica para obtener los vecinos de un nodo en el plano
            // Puedes ajustar esto según la estructura específica de tu plano
            List<Nodo> vecinos = new List<Nodo>();

            //Horizontales
            AgregarVecino(nodo.X, nodo.Y - 1, vecinos);
            AgregarVecino(nodo.X, nodo.Y + 1, vecinos);
            AgregarVecino(nodo.X - 1, nodo.Y, vecinos);
            AgregarVecino(nodo.X + 1, nodo.Y, vecinos);
            //Diagonales
            
            AgregarVecino(nodo.X - 1, nodo.Y - 1, vecinos);
            AgregarVecino(nodo.X + 1, nodo.Y + 1, vecinos);
            AgregarVecino(nodo.X - 1, nodo.Y + 1, vecinos);
            AgregarVecino(nodo.X + 1, nodo.Y - 1, vecinos);
            
            return vecinos;
        }

        private void AgregarVecino(int x, int y, List<Nodo> vecinos)
        {
            // Verifica límites del plano y obstáculos
            if (x >= 0 && x < plano.GetLength(0) && y >= 0 && y < plano.GetLength(1) && plano[x, y] != 1)
            {
                Nodo vecino = new Nodo { X = x, Y = y };
                vecino.Heuristica = CalcularHeuristica(vecino);
                TodosLosNodos.Add(vecino);
                vecinos.Add(vecino);
            }
        }

        private int CalcularCosto(Nodo origen, Nodo destino)
        {
            // Puedes ajustar la lógica de cálculo de costo según tus necesidades
            return 1;
        }

        private void ActualizarCostoYPadre(Nodo nodo, int nuevoCosto, Nodo nuevoPadre)
        {
            nodo.CostoActual = nuevoCosto;
            nodo.Padre = nuevoPadre;
        }

        private void AgregarAListaAbiertaSiNoEsta(Nodo nodo, List<Nodo> listaAbierta)
        {
            if (!listaAbierta.Contains(nodo))
            {
                listaAbierta.Add(nodo);
            }
        }

        private List<Nodo> ConstruirCamino(Nodo nodoFinal)
        {
            List<Nodo> camino = new List<Nodo>();
            Nodo nodoActual = nodoFinal;

            while (nodoActual != null)
            {
                camino.Insert(0, nodoActual);  // Insertar al principio para obtener el camino en el orden correcto
                nodoActual = nodoActual.Padre;
            }

            return camino;
        }

        private int CalcularHeuristica(Nodo nodo)
        {
            // Puedes ajustar la función heurística según tus necesidades
            // En este ejemplo, se utiliza la distancia Euclidiana
            return (int)Math.Sqrt(Math.Pow(nodo.X - objetivo.X, 2) + Math.Pow(nodo.Y - objetivo.Y, 2));
        }
    }
}
