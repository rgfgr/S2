using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
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
using People;
namespace SkoleOversikt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<Person> people = new List<Person>();
        private readonly List<Student> students = new List<Student>();
        private readonly List<Teacher> teachers = new List<Teacher>();
        private string køn;
        private string role;

        public MainWindow()
        {
            InitializeComponent();
            if (File.Exists("Students.txt"))
            {
                using (StreamReader sr = new StreamReader("Students.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] vs = line.Split(' ');
                        students.Add(new Student(vs[0], int.Parse(vs[1]), vs[2], vs[4], vs[5]));
                    }
                }
            }
            if (File.Exists("Teachers.txt"))
            {
                using (StreamReader sr = new StreamReader("Teachers.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] vs = line.Split(' ');
                        teachers.Add(new Teacher(vs[0], int.Parse(vs[1]), vs[2], vs[4], vs[5]));
                    }
                }
            }
            if (File.Exists("People.txt"))
            {
                using (StreamReader sr = new StreamReader("People.txt"))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] vs = line.Split(' ');
                        if (vs[3] == "Elev")
                        {
                            people.Add(new Student(vs[0], int.Parse(vs[1]), vs[2], vs[4], vs[5]));
                        }
                        else
                        {
                            people.Add(new Teacher(vs[0], int.Parse(vs[1]), vs[2], vs[4], vs[5]));
                        }
                    }
                }
            }
        }

        private void Lærer_Radio_Checked(object sender, RoutedEventArgs e)
        {
            role = "Lærer";
            UpdateDataGrid(køn, role);
        }

        private void Elev_Radio_Checked(object sender, RoutedEventArgs e)
        {
            role = "Elev";
            UpdateDataGrid(køn, role);
        }

        private void Han_Radio_Checked(object sender, RoutedEventArgs e)
        {
            køn = "Han";
            UpdateDataGrid(køn, role);
        }

        private void Hun_Radio_Checked(object sender, RoutedEventArgs e)
        {
            køn = "Hun";
            UpdateDataGrid(køn, role);
        }

        private void Dem_Radio_Checked(object sender, RoutedEventArgs e)
        {
            køn = "Dem";
            UpdateDataGrid(køn, role);
        }

        private void Tilf_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (Role_Cmb.SelectedIndex != 0 && Kn_Cmb.SelectedIndex != 0 && Navn_Inp.GetLineLength(0) != 0 && Age_Inp.GetLineLength(0) != 0 && Email_Inp.GetLineLength(0) != 0 && Telf_Inp.GetLineLength(0) != 0)
            {
                switch (Role_Cmb.SelectedIndex)
                {
                    case 1:
                        Student student = new Student(Navn_Inp.Text, int.Parse(Age_Inp.Text), Kn_Cmb.Text, Email_Inp.Text, Telf_Inp.Text);
                        students.Add(student);
                        people.Add(student);
                        using(StreamWriter sw = new StreamWriter("Students.txt"))
                        {
                            foreach (Student item in students)
                            {
                                sw.WriteLine($"{item.Navn} {item.Alder} {item.Køn} {item.Role} {item.Email} {item.Telfnr}");
                            }
                        }
                        break;
                    case 2:
                        Teacher teacher = new Teacher(Navn_Inp.Text, int.Parse(Age_Inp.Text), Kn_Cmb.Text, Email_Inp.Text, Telf_Inp.Text);
                        teachers.Add(teacher);
                        people.Add(teacher);
                        using (StreamWriter sw = new StreamWriter("Teachers.txt"))
                        {
                            foreach (Teacher item in teachers)
                            {
                                sw.WriteLine($"{item.Navn} {item.Alder} {item.Køn} {item.Role} {item.Email} {item.Telfnr}");
                            }
                        }
                        break;
                    default:
                        break;
                }
                using (StreamWriter sw = new StreamWriter("People.txt"))
                {
                    foreach (Person item in people)
                    {
                        sw.WriteLine($"{item.Navn} {item.Alder} {item.Køn} {item.Role} {item.Email} {item.Telfnr}");
                    }
                }
                UpdateDataGrid(køn, role);
            }
        }

        private void Bkk_Radio_Checked(object sender, RoutedEventArgs e)
        {
            role = "Begge";
            UpdateDataGrid(køn, role);
        }

        private void All_Radio_Checked(object sender, RoutedEventArgs e)
        {
            køn = "Alle";
            UpdateDataGrid(køn, role);
        }

        private void UpdateDataGrid(string køn, string role)
        {
            List<Person> people1 = new List<Person>();
            Ppl_Dtb.ItemsSource = people1;
            switch (køn)
            {
                case "Alle":
                    switch (role)
                    {
                        case "Begge":
                            Ppl_Dtb.ItemsSource = people;
                            break;
                        case "Elev":
                            Ppl_Dtb.ItemsSource = students;
                            break;
                        case "Lærer":
                            Ppl_Dtb.ItemsSource = teachers;
                            break;
                    }
                    break;
                default:
                    {
                        switch (role)
                        {
                            case "Begge":
                                foreach (var item in people)
                                {
                                    if (item.Køn == køn)
                                        people1.Add(item);
                                }
                                break;
                            case "Elev":
                                foreach (var item in students)
                                {
                                    if (item.Køn == køn)
                                        people1.Add(item);
                                }
                                break;
                            case "Lærer":
                                foreach (var item in teachers)
                                {
                                    if (item.Køn == køn)
                                        people1.Add(item);
                                }
                                break;
                        }
                        break;
                    }
            }
            Ppl_Dtb.Items.Refresh();
        }
    }
}