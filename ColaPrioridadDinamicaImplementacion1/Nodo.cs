using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaPrioridadDinamicaImplementacion1
{
    class Nodo
    {
        private string dato;
        private Nodo siguiente;
        private int prioridad;
        public string Dato
        {
            get { return dato; }
            set { dato = value; }
        }
        public Nodo Siguiente
        {
            get { return siguiente; }
            set { siguiente = value; }
        }
        public int Prioridad
        {
            get { return prioridad; }
            set { prioridad = value; }
        }
        public Nodo()
        {
            dato = "A";
            prioridad = 1;
            siguiente = null;
        }

        public Nodo(string dato, Nodo siguiente,int prioridad)
        {
            this.dato = dato;
            this.siguiente = siguiente;
            this.prioridad = prioridad;
        }
        public override string ToString()
        {
            return Dato + "";
        }
    }
}
