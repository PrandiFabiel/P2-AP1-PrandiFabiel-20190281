using P2_AP1_PrandiFabiel_20190281.BLL;
using P2_AP1_PrandiFabiel_20190281.Entidades;
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

namespace P2_AP1_PrandiFabiel_20190281.UI.Registros
{
    /// <summary>
    /// Interaction logic for rProyectos.xaml
    /// </summary>
    public partial class rProyectos : Window
    {

        private Proyectos proyectos = new Proyectos(); 
        public rProyectos()
        {
            InitializeComponent();
            this.DataContext = proyectos; 

            TipoTareaComboBox.ItemsSource = TareasBLL.GetList(T => true);
            TipoTareaComboBox.SelectedValuePath = "TareaId";
            TipoTareaComboBox.DisplayMemberPath = "TipoTarea";
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = proyectos; 
        }

        private void Limpiar()
        {
            this.proyectos = new Proyectos();
            this.DataContext = proyectos; 
        }

        private bool validar()
        {
            bool esValido = true;
            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Por favor completa el campo descripcion", "Error", MessageBoxButton.OK, MessageBoxImage.Warning); 
            }
            if (DetalleDataGrid.Items.Count == 0)
            {
                esValido = false;
                MessageBox.Show("Debe asignar la tarea", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            return esValido; 
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Proyectos econtrado = ProyectosBLL.Buscar(proyectos.ProyectoId);

            if (econtrado != null)
            {
                proyectos = econtrado;
                Cargar(); 
            }
            else
            {
                MessageBox.Show("Este proyecto no existe o no fue encontrado", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                Limpiar();
                //Revisa esto
            }
        }

        private void AgregarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            var detalle = new ProyectosDetalle
            {
                ProyectoId = this.proyectos.ProyectoId,
                Tipo = ((Tareas)TipoTareaComboBox.SelectedItem),
                Requerimiento = (RequerimientoTextBox.Text),
                Tiempo = Convert.ToSingle(TiempoTextBox.Text)
            };

            proyectos.TiempoTotal += Convert.ToDouble(TiempoTextBox.Text.ToString());

            this.proyectos.Detalle.Add(detalle);
            Cargar();

            TipoTareaComboBox.SelectedIndex = -1;
            RequerimientoTextBox.Clear();
            TiempoTextBox.Clear(); 
        }

        private void EliminarFilaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var detalle = (ProyectosDetalle)DetalleDataGrid.SelectedItem;
                double Total = Convert.ToDouble(TiempoTextBox.Text);
                if(DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
                {
                    proyectos.TiempoTotal -= detalle.Tiempo;
                    proyectos.Detalle.RemoveAt(DetalleDataGrid.SelectedIndex);

                    Cargar();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("No se ha seleccionado ninguna fila", "Error", MessageBoxButton.OK, MessageBoxImage.Warning); 
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar(); 
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!validar())
                return;

            var paso = ProyectosBLL.Guardar(this.proyectos);
            if (paso)
            {
                Limpiar();
                MessageBox.Show("Registro guardado con exito!!", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No se pudo guardar...", "Error", MessageBoxButton.OK, MessageBoxImage.Warning); 
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProyectosBLL.Eliminar(Utilidades.ToInt(ProyectoIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Eliminado correctamente", "Exito", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar", "Error", MessageBoxButton.OK, MessageBoxImage.Warning); 
        }
    }
}
