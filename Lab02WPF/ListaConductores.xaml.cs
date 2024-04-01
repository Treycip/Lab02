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

namespace Lab02WPF
{
    /// <summary>
    /// Lógica de interacción para ListaConductores.xaml
    /// </summary>
    public partial class ListaConductores : Window
    {
        public ListaConductores()
        {
            InitializeComponent(); 
            CargarDatosPorDefecto();
        }
        public class Persona
        {
            public string Nombre { get; set; }
            public string Licencia { get; set; }
            public string Transporte { get; set; }
        }
        private void CargarDatosPorDefecto()
        {
            List<Persona> personas = new List<Persona>
            {
                new Persona { Nombre = "Treyci", Licencia = "A2B", Transporte = "Trailer" },
                new Persona { Nombre = "Gabriel", Licencia = "A2B", Transporte = "Camión" },
                new Persona { Nombre = "Hugo", Licencia = "A2B", Transporte = "Trailer" }
            };

            dataGridPersonas.ItemsSource = personas;
        }
    }
}