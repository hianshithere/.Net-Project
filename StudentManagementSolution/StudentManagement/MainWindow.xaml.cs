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
using StudentEntity;
using StudentDAL;
using StudentBAL;
using StudentException;

namespace StudentManagement
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool insertready = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DisplayStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<StudentEntityCl> showlist = StudentBALCl.GetAllStudentsBL();
                dataGrid.ItemsSource = showlist;
                
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public void fieldReset()
        {
            textBox.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            DOA.SelectedDate = null;
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (!insertready)
            {
                fieldReset();
                int id = StudentBALCl.getNextIdBAL();
                textBox.Text = id.ToString();
                textBox.IsReadOnly = true;
                insertready = true;
            }
            else
            {

                try
                {


                    StudentEntityCl entobj = new StudentEntityCl();


                    entobj.STUDENTID = Convert.ToInt32(textBox.Text);
                    entobj.STUDENTNAME = textBox1.Text;
                    entobj.CITY = textBox2.Text;
                    entobj.COURSE = textBox3.Text;
                    entobj.DATEOFADMISSION = Convert.ToDateTime(DOA.Text);

                    if (StudentBALCl.AddStudentBL(entobj))
                    {
                        MessageBox.Show("Student Successfully Added");
                        insertready = false;
                        textBox.IsReadOnly = false;

                    }

                    else
                    {

                    }
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
               
            }

        }
        private void dataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                StudentEntityCl entobj = (StudentEntityCl)(object)(dataGrid.SelectedItem);

                textBox.Text = entobj.STUDENTID.ToString();
                textBox1.Text = entobj.STUDENTNAME;
                textBox2.Text = entobj.CITY;
                textBox3.Text = entobj.COURSE;
                DOA.Text = entobj.DATEOFADMISSION.ToString();
            }
            catch(Exception ex)
            {

            }


        }

        private void Find_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                int flag = 0;
                int id = Convert.ToInt32(textBox.Text);
                 StudentEntityCl entobj = StudentBALCl.SearchStudentBL(id);

                List<StudentEntityCl> showlist = StudentBALCl.GetAllStudentsBL();

                for (int index=0;index<showlist.Count;index ++)
                {
                    if(showlist[index].STUDENTID ==id)
                    {
                        flag = 1;
                        break;
                    }
                    else
                    {
                        flag = 0;
                    }
                }

                if(flag==0)
                {
                    MessageBox.Show("No such student found");
                    Environment.Exit(0);
                    
                }

                // MessageBox.Show(entobj.DATEOFADMISSION.ToString());
                textBox1.Text = entobj.STUDENTNAME;
                textBox2.Text = entobj.CITY;
                textBox3.Text = entobj.COURSE;
                DOA.Text = entobj.DATEOFADMISSION.ToString();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void UpdateStudent_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                StudentEntityCl entobj = new StudentEntityCl();

                entobj.STUDENTID = Convert.ToInt32(textBox.Text);
                entobj.STUDENTNAME = textBox1.Text;
                entobj.CITY = textBox2.Text;
                entobj.COURSE = textBox3.Text;
                entobj.DATEOFADMISSION = Convert.ToDateTime(DOA.Text);



                StudentBALCl.UpdateStudentBL(entobj);
                MessageBox.Show("Student Updated Successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


            
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox.Text);

                StudentBALCl.DeleteStudentBL(id);

                MessageBox.Show("Deleted Successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
          
        }
    }

}

