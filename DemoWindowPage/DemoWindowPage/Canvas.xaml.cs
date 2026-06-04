using System.Windows;

namespace DemoWindowPage
{
    public partial class Canvas : Window
    {
        public Canvas()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            string carInfo = $"Car Name:{txtCarName.Text}\n" +
                             $"Color:{txtColor.Text} \nBrand:{txtBrand.Text}";

            MessageBox.Show(carInfo, "Car Details");
        }
    }
}