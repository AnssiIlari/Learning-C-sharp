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

namespace KloHarjoitusTyö
{
    /// <summary>
    /// Interaction logic for UpdateProduct.xaml
    /// </summary>
    public partial class UpdateProduct : Window
    {
        public UpdateProduct(Product product)
        {
            InitializeComponent();

            this.DataContext = product;
        }
        /// <summary>
        /// Päivittää tuotteen tiedot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateButton_click(object sender, RoutedEventArgs e)
        {
            var product = (Product)this.DataContext;

            var repo = new Repository();
            repo.UpdateProduct(product);

            DialogResult = true;


        }
    }
}
