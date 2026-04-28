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

namespace pr16_v1_Politov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // public List<string> student = new List<string>();
        StudentReg db = new StudentReg();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RefreshGrid(List<Student> list)
        {
            if (dgStudents == null) return;
            dgStudents.ItemsSource = null;
            dgStudents.ItemsSource = list;
        }

        private void addlst_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtForList.Text))
            {
                MessageBox.Show("Поле пустое");
                return;
            }
                if (lst_add.Items.Contains(txtForList.Text))
                {
                    MessageBox.Show("Пользователь с таким именем уже есть");
                return;
                }
                 if (!char.IsUpper(txtForList.Text[0]))
                {
                        
                    MessageBox.Show("Имя должно начинаться с большой буквы");
                return;
                }
                
                    lst_add.Items.Add(txtForList.Text);
                    txtForList.Clear();
                
                
            
            
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (txtInput.Text != "" && txtGroupInput.Text != "")
            {
                if (char.IsUpper(txtInput.Text[0]))
                {
                    Student st = new Student();
                    st.Name = txtInput.Text;
                    st.Group = txtGroupInput.Text;

                    db.Students.Add(st);
                    RefreshGrid(db.Students);

                    txtInput.Clear();
                    txtGroupInput.Clear();
                }
                else
                {
                    MessageBox.Show("Фамилия должна быть с большой буквы");
                }
            }
            else
            {
                MessageBox.Show("Заполните поля Фамилия и Группа");
            }
        }

        private void Delete_lst(object sender, RoutedEventArgs e)
        {
            lst_add.Items.Clear();
        }

        private void txtSearch_TextChang(object sender, TextChangedEventArgs e)
        {
            if (db.Students == null) return;
            string find = txtSearch.Text.ToLower();
            List<Student> filter = new List<Student>();
            foreach (Student s in db.Students)
            {
                if (s.Name.ToLower().Contains(find) || s.Group.ToLower().Contains(find))
                {
                    filter.Add(s);
                }
            }
            dgStudents.ItemsSource = filter;
        }

        private void cSort_Select(object sender, SelectionChangedEventArgs e)
        {
            if (db.Students == null || dgStudents == null) return;

            List<Student> sort = new List<Student>(db.Students);
            if (cSort.SelectedIndex == 1)
            {
                sort = sort.OrderBy(s => s.Name).ToList();
            }
            else if (cSort.SelectedIndex == 2)
            {
                sort = sort.OrderBy(s => s.Group).ToList();
            }
            RefreshGrid(sort);
        }

        private void Delete_Selected(object sender, RoutedEventArgs e)
        {
            if (dgStudents.SelectedItem != null)
            {
                Student select = (Student)dgStudents.SelectedItem;
                db.Students.Remove(select);
                RefreshGrid(db.Students);
            }
        }
    }
}
