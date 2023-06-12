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

namespace CalculadoraWPF
{
    public partial class MainWindow : Window
    {
        private double numeroAnterior;
        private string operacionActual;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Numero_Click(object sender, RoutedEventArgs e)
        {
            Button boton = (Button)sender;
            txtResultado.Text += boton.Tag.ToString();
        }

        private void Operacion_Click(object sender, RoutedEventArgs e)
        {
            Button boton = (Button)sender;
            operacionActual = boton.Tag.ToString();
            numeroAnterior = double.Parse(txtResultado.Text);
            txtResultado.Text = string.Empty;
        }
        private void Limpiar_Click(object sender, RoutedEventArgs e)
        {
            txtResultado.Text = string.Empty;
        }

        private void Igual_Click(object sender, RoutedEventArgs e)
        {
            double numeroActual = double.Parse(txtResultado.Text);
            double resultado = 0;

            switch (operacionActual)
            {
                case "+":
                    resultado = numeroAnterior + numeroActual;
                    break;
                case "-":
                    resultado = numeroAnterior - numeroActual;
                    break;
                case "*":
                    resultado = numeroAnterior * numeroActual;
                    break;
                case "/":
                    if (numeroActual != 0)
                    {
                        resultado = numeroAnterior / numeroActual;
                    }
                    else
                    {
                        MessageBox.Show("No se puede dividir entre cero.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    break;
            }

            txtResultado.Text = resultado.ToString();
        }
    }
}