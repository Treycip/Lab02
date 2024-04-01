using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using static Lab02WPF.ListaIngresos;

namespace Lab02WPF
{
    /// <summary>
    /// Lógica de interacción para ListaIngresos.xaml
    /// </summary>
    public partial class ListaIngresos : Window
    {
        public ListaIngresos()
        {
            InitializeComponent();
            CargarDatosPorDefecto();
        }
        public class Ingreso
        {
            public string Fecha { get; set; }
            public string Placa { get; set; }
            public string Turno { get; set; }
            public string Conductor { get; set; }
            public string Producto { get; set; }
            public string Peso { get; set; }
            public string Transporte { get; set; }
        }

        private bool IngresosFilter(object item)
        {
            Ingreso ingreso = item as Ingreso;
            if (ingreso != null)
            {
                bool nombreConductorOK = string.IsNullOrEmpty(txtNombreConductor.Text) || ingreso.Conductor.ToLower().Contains(txtNombreConductor.Text.ToLower());
                bool placaOK = string.IsNullOrEmpty(txtPlaca.Text) || ingreso.Placa.ToLower().Contains(txtPlaca.Text.ToLower());
                bool productoOK = string.IsNullOrEmpty(txtProducto.Text) || ingreso.Producto.ToLower().Contains(txtProducto.Text.ToLower());

                return nombreConductorOK && placaOK && productoOK;
            }
            return false;
        }
        private void CargarDatosPorDefecto()
        {
            List<Ingreso> ingresos = new List<Ingreso>
            {
                new Ingreso { Fecha = "2024-03-01", Placa = "GHJ890", Turno = "Tarde", Conductor = "Treyci", Producto = "Fideos", Peso = "700 kg", Transporte = "Trailer" },
                new Ingreso { Fecha = "2024-03-02", Placa = "SDF456", Turno = "Mañana", Conductor = "Gabriel", Producto = "Menestras", Peso = "550 kg", Transporte = "Camión" },
                new Ingreso { Fecha = "2024-03-03", Placa = "TRE123", Turno = "Noche", Conductor = "Hugo", Producto = "Legumbres", Peso = "850 kg", Transporte = "Trailer" }
            };


            dataGridIngresos.ItemsSource = ingresos;
        }

        


        private void BtnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            // Tu lógica de filtrado aquí
            // Por ejemplo:
            ICollectionView view = CollectionViewSource.GetDefaultView(dataGridIngresos.ItemsSource);
            view.Filter = IngresosFilter;
        }


        private void dataGridIngresos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}