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

namespace P2_AP1_PrandiFabiel_20190281.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cProyectos.xaml
    /// </summary>
    public partial class cProyectos : Window
    {
        public cProyectos()
        {
            InitializeComponent();
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            List<Proyectos> Listado = new List<Proyectos>();

            if(CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0:
                        try
                        {
                            if (DesdeDataPicker.SelectedDate != null)
                                Listado = ProyectosBLL.GetList(
                                    c => c.Fecha.Date >= DesdeDataPicker.SelectedDate &&
                                    c.Fecha.Date <= HastaDatePicker.SelectedDate &&
                                    c.ProyectoId == Utilidades.ToInt(CriterioTextBox.Text)
                                    );

                            else
                                Listado = ProyectosBLL.GetList(e => e.ProyectoId == Utilidades.ToInt(CriterioTextBox.Text));
                        }
                        catch (FormatException)
                        {

                            MessageBox.Show("Ingrese un criterio valido", "Error", MessageBoxButton.OK, MessageBoxImage.Warning); 
                        }
                        break;

                    case 1:
                        try
                        {
                            if (DesdeDataPicker.SelectedDate != null)
                                Listado = ProyectosBLL.GetList(
                                    c => c.Fecha.Date >= DesdeDataPicker.SelectedDate &&
                                    c.Fecha.Date <= HastaDatePicker.SelectedDate &&
                                    c.Descripcion.ToLower().Contains(CriterioTextBox.Text.ToLower())
                                    );

                            else
                                Listado = ProyectosBLL.GetList(e => e.Descripcion.ToLower().Contains(CriterioTextBox.Text.ToLower()));
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                        break; 
                }
            }
            else
            {
                Listado = ProyectosBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = Listado;

        }
    }
}
