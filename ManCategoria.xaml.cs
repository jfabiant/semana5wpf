using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Semana5_.Net
{
    /// <summary>
    /// Lógica de interacción para ManCategoria.xaml
    /// </summary>
    public partial class ManCategoria : Window
    {
        public Categoria categoria = new Categoria();

        public ManCategoria(Categoria categoria)
        {
            InitializeComponent();

            this.categoria = categoria;

            if (this.categoria != null)
            {
                txtID.Text = this.categoria.IdCategoria.ToString();
                txtNombre.Text = this.categoria.NombreCategoria;
                txtDescripcion.Text = this.categoria.Descripcion;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Btn Grabar
            BCategoria bCategoria = null;
            try
            {
                bCategoria = new BCategoria();
                if (categoria != null)
                {
                    bCategoria.Update(new Categoria { IdCategoria = int.Parse(txtID.Text), NombreCategoria = txtNombre.Text, Descripcion = txtDescripcion.Text });
                }
                else
                {
                    bCategoria.Insert(new Categoria { NombreCategoria = txtNombre.Text, Descripcion = txtDescripcion.Text });
                }
                Close();
            }
            catch (Exception)
            {
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Btn Cerrar
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Btn Eliminar

            BCategoria bCategoria = new BCategoria();
            if (categoria != null)
            {
                bCategoria.Delete(categoria.IdCategoria);
            }
            Close();
        }
    }
}
