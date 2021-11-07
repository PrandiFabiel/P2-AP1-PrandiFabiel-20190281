﻿using P2_AP1_PrandiFabiel_20190281.UI.Consultas;
using P2_AP1_PrandiFabiel_20190281.UI.Registros;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace P2_AP1_PrandiFabiel_20190281
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Consultas_Click(object sender, RoutedEventArgs e)
        {
            cProyectos cp = new cProyectos();
            cp.Show();
        }

        private void Registro_Click(object sender, RoutedEventArgs e)
        {
            rProyectos rp = new rProyectos();
            rp.Show();
        }

        private void tiposDeTarea_Click(object sender, RoutedEventArgs e)
        {
            cTiposTareas tipoTareas = new cTiposTareas();
            tipoTareas.Show(); 
        }
    }
}
