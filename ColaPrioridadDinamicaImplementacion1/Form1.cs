using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ColaPrioridadDinamicaImplementacion1
{

    public partial class Form1 : Form
    {
        ColaPrioridad MiCola = new ColaPrioridad();
        Nodo n;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncolar_Click(object sender, EventArgs e)
        {
            try
            {

                int prioridad = int.Parse(txtPrioridad.Text);
                if (prioridad < 0)
                {

                    MessageBox.Show("Prioridad minimia : 0");
                    return;
                }
                string dato = txtDatos.Text;
                n = new Nodo();
                n.Dato = dato;
                n.Prioridad = prioridad;
                MiCola.Encolar(n);
                txtDatos.Clear();
                txtPrioridad.Clear();
                lblCola.Text = MiCola.ImprimirDatos();
                lblPrioridad.Text = MiCola.ImprimirPrioridad();
            }
            catch
            {
                MessageBox.Show("Error");
            }


        }

        private void btnIncrementar_Click(object sender, EventArgs e)
        {
            MiCola.IncrementarPrioridades();
            lblPrioridad.Text = MiCola.ImprimirPrioridad();

        }

        private void btnDesencolar_Click(object sender, EventArgs e)
        {
            MiCola.Desencolar();
            lblCola.Text = MiCola.ImprimirDatos();
            lblPrioridad.Text = MiCola.ImprimirPrioridad();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = true;
            groupBox2.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog Dialogo = new FolderBrowserDialog();
                if (Dialogo.ShowDialog() == DialogResult.OK)
                {
                    string datos = lblCola.Text;
                    string prioridades = lblPrioridad.Text;
                    string[] DatosYTamaño = { datos, prioridades, };
                    string nombreDelArchivo;
                    if (txtArchivo.Text == "")
                    {
                        nombreDelArchivo = "Cola";
                    }
                    else
                    {
                        nombreDelArchivo = txtArchivo.Text;
                    }
                    string ruta = Dialogo.SelectedPath + "\\" + nombreDelArchivo + ".txt";
                    using (var writer = new StreamWriter(ruta))
                    {
                        writer.Close();
                    }
                    File.WriteAllLines(ruta, DatosYTamaño);
                    MessageBox.Show("Datos guardados en la ruta : " + ruta);
                }
            }
            catch
            {
                MessageBox.Show("Error al cargar el archivo");
                this.Close();
            }
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            OpenFileDialog Seleccionar = new OpenFileDialog();
            if (Seleccionar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string ruta = Seleccionar.FileName;
                    string[] DatosYPrioridad = File.ReadAllLines(ruta);
                    string datos = DatosYPrioridad[0];
                    string prioridades = DatosYPrioridad[1];
                    string[] DatosArreglo = datos.Split(',');
                    string[] PrioridadesArreglo = prioridades.Split(',');
                    int contador = 0;
                    foreach(string i in DatosArreglo)
                    {
                        n = new Nodo();
                        n.Dato = DatosArreglo[contador];
                        n.Prioridad = int.Parse(PrioridadesArreglo[contador]);
                        MiCola.Encolar(n);
                        contador++;
                    }
                    groupBox1.Visible = true;
                    groupBox2.Visible = false;
                    lblCola.Text = MiCola.ImprimirDatos();
                    lblPrioridad.Text = MiCola.ImprimirPrioridad();

                }
                catch
                {

                }
            }
        }
    }
}
