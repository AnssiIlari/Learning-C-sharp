﻿using System;
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

namespace PizzaApp
{
    /// <summary>
    /// Interaction logic for UpdatePizza.xaml
    /// </summary>
    public partial class UpdatePizza : Window
    {
        public UpdatePizza(Pizza pizza)
        {
            InitializeComponent();

            this.DataContext = pizza;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var pizza = (Pizza)this.DataContext;

            var repo = new PizzaRepository();
            repo.UpdatePizza(pizza);

            DialogResult = true;
        }
    }
}