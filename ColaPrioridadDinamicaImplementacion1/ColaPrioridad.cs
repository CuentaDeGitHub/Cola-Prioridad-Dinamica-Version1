using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColaPrioridadDinamicaImplementacion1
{
    class ColaPrioridad
    {
        private Nodo head;
        private Nodo tail;

        public Nodo Head
        {
            get { return head; }
            set { head = value; }
        }

        public Nodo Tail
        {
            get { return tail; }
            set { tail = value; }
        }

        public ColaPrioridad()
        {
            head = null;
            tail = null;
        }
        public void Desencolar()
        {
            if(head == null)
            {
                return;
            }
            if(head == tail)
            {
                head = tail = null;
                return;
            }
            head = head.Siguiente;
        }
        public void Encolar(Nodo n)
        {
            if (head == null)
            {
                head = n;
                tail = n;
                return;
            }
            if (n.Prioridad > head.Prioridad)
            {
                n.Siguiente = head;
                head = n;
                return;
            }
            if(n.Prioridad <= tail.Prioridad)
            {
                tail.Siguiente = n;
                tail = n;
                return;
            }
            Nodo h = head;
            while (h != tail)
            {
                if (h.Siguiente.Prioridad < n.Prioridad)
                {
                    break;
                }
                h = h.Siguiente;
            }
                n.Siguiente = h.Siguiente;
                h.Siguiente = n;
                return;
        }
        public void IncrementarPrioridades()
        {
            Nodo h = head;
            if(h != null)
            {
                int MayorPrioridad = head.Prioridad;
                while (h != tail)
                {
                    if (h.Prioridad < MayorPrioridad)
                    {
                        h.Prioridad++;
                    }
                    h = h.Siguiente;
                }
                if (tail.Prioridad < MayorPrioridad)
                {
                    tail.Prioridad++;
                }
            } 
        }
        public  string ImprimirDatos()
        {
            string stringCola = "";
            Nodo h = head;
            if (h != null)
            {
                stringCola += h.ToString();
                h = h.Siguiente;
                if(h != null)
                {
                    while (h != tail)
                    {
                        stringCola += "," + h.ToString();
                        h = h.Siguiente;
                    }
                    stringCola += "," + tail.ToString();
                }
               
                return stringCola;
            }
            else
            {
                return "La lista esta vacia";
            }
        }

        public string ImprimirPrioridad()
        {
            string stringCola = "";
            Nodo h = head;
            if (h != null)
            {
                stringCola += h.Prioridad;
                h = h.Siguiente;
                if(h != null)
                {
                    while (h != tail)
                    {
                        stringCola += "," + h.Prioridad;
                        h = h.Siguiente;
                    }
                    stringCola += "," + tail.Prioridad;
                }
                return stringCola;
            }
            else
            {
                return "La lista esta vacia";
            }
        }
    }
}
