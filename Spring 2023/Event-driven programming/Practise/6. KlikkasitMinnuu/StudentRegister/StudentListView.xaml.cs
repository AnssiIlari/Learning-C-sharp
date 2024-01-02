using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace StudentRegister
{
    /// <summary>
    /// Interaction logic for StudentListView.xaml
    /// </summary>
    public partial class StudentListView : Window
    {
        public StudentListView()
        {
            InitializeComponent();

        }

        public StudentListView(ObservableCollection<Student> students) : this()
        {
            grid.ItemsSource = students;
        }

    }
}
