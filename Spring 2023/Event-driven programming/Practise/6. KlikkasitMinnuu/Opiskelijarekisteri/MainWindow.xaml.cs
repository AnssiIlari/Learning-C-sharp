using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Media;
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

namespace Opiskelijarekisteri
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Student student;
        private ObservableCollection<Student> students;
        private int index;

        public MainWindow()
        {
            InitializeComponent();

            students = Studentlist.GetAllStudents();

            // comboboxin sisältö for-loopissa
            for (int i = 2015; i <= 2023; i++)
            {
                comYears.Items.Add(i);
            }

            //var student = new Student() { Number = 1, Name = "Anssi" }; JNE...

            // comboboxin sisältö tehdystä listasta
            comGenders.ItemsSource = Gender.Genders;


            //student = new Student();
            //student.Number = 1;
            //student.Name = "Anssi";
            //student.StartYear = 2022;
            //student.Credits = 61;
            //student.Gender= 1;

            // tässä lisätään ilmentymä näytön tietoon
            this.DataContext = students[index];
        }

        private void VersionClick(object sender, RoutedEventArgs e)
        {
            //SystemSounds.Beep.Play();
            MessageBox.Show("Opiskelijarekisteri v1.0 (c) Anssi Laitinen", "Tiedot");
        }

        private void CloseClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            students[index].Credits += 1;
            student.Credits += 1;
        }

        private void FirstClick(object sender, RoutedEventArgs e)
        {
            index = 0;
            this.DataContext = students[index];
        }

        private void PrevClick(object sender, RoutedEventArgs e)
        {
            index--;

            if (index < 0)
            {
                index = 0;
            }

            this.DataContext = students[index];

        }

        private void NextClick(object sender, RoutedEventArgs e)
        {
            index++;

            if (index > students.Count -1)
            {
                index = students.Count - 1;
                // >= students.count
                // index = students.Count
            }

            this.DataContext = students[index];
        }

        private void LastClick(object sender, RoutedEventArgs e)
        {
            index = students.Count - 1;
            this.DataContext = students[index];
        }

        private void ShowListView(object sender, RoutedEventArgs e)
        {
            var listView = new StudentListView(students);
            listView.ShowDialog();
            // .Show mahdollinen

            FirstClick(null, null);
        }
    }


    public class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public int Number { get; set; }
        public string Name { get; set; }
        public int StartYear { get; set; }

        public int Gender { get; set; }

        private int credits = 0;
        public int Credits
        {
            get
            {
                return credits;
            }
            set
            {
                credits = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Credits"));

                // Toinen tapa?
                //if (PropertyChanged != null)
                //{
                //    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Credits"));
                //}
            }
        }
    }

    public class Gender
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public Gender(int iD, string description)
        {
            ID = iD;
            Description = description;
        }

        public static List<Gender> Genders
        {
            get
            {
                var genders = new List<Gender>();
                genders.Add(new Gender(1, "Mies"));
                genders.Add(new Gender(2, "Nainen"));
                genders.Add(new Gender(3, "Muu"));

                return genders;
            }
        }

    }


    public class Studentlist
    {
        public static ObservableCollection<Student> GetAllStudents()
        {
            // "Tässä tulevaisuudessa hakisitte tiedon tietokannasta" -->

            var stud1 = new Student();
            stud1.Number = 1;
            stud1.Name = "Anssi";
            stud1.StartYear = 2020;
            stud1.Gender = 1;
            stud1.Credits = 61;

            var stud2 = new Student();
            stud2.Number = 2;
            stud2.Name = "Sirkku";
            stud2.StartYear = 2022;
            stud2.Gender = 2;

            var stud3 = new Student();
            stud3.Number = 3;
            stud3.Name = "Allan";
            stud3.StartYear = 2019;
            stud3.Gender = 1;

            var students = new ObservableCollection<Student>();
            students.Add(stud1);
            students.Add(stud2);
            students.Add(stud3);

            return students;

        }




    }



}
