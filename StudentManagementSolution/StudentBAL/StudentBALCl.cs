using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentEntity;
using StudentException;
using StudentDAL;
using System.Windows;
using System.Text.RegularExpressions;

namespace StudentBAL
{
    public class StudentBALCl
    {

        public static bool Validation(StudentEntityCl entobj)
        {
            bool valid = true;

            StringBuilder build = new StringBuilder();
           
            //if((entobj.STUDENTID==null) ||(entobj.STUDENTNAME==null) || (entobj.CITY==null) 
            //    || (entobj.COURSE==null)|| (entobj.DATEOFADMISSION==null))
            //{
            //    valid = false;
            //    build.AppendLine("Please fill all the fields");
            //}

              if (entobj.STUDENTID <= 0 )
              {
                valid = false;
                build.AppendLine("1.ID cannot be negative");
              }

            if (!Regex.IsMatch(entobj.STUDENTNAME, @"^[a-zA-Z]+$"))
            {
                valid = false;
                build.AppendLine("2.Name must contain alphabets only");
            }


            if (!Regex.IsMatch(entobj.CITY, @"^[a-zA-Z]+$"))
                {
                valid = false;
                build.AppendLine("3.City must contain Alphabets only");
                }


            if(!Regex.IsMatch(entobj.COURSE, @"JAVA|DOTNET|J2EE|Python"))
            {
                valid = false;
                build.AppendLine("4.Courses must be among specified ones");

            }
            if (entobj.DATEOFADMISSION > DateTime.Now)

            {
                valid = false;
                build.AppendLine("5.Date cannot be greater than current date");

            }






            if (valid==false)
            {
                MessageBox.Show(build.ToString());
            }
            
           


            return valid;

        }

        public static bool AddStudentBL(StudentEntityCl entobj)
        {
            bool studentAdded = false;
            try
            {


                if (Validation(entobj))
                {
                StudentDALCl dal = new StudentDALCl();
                studentAdded = dal.AddStudentDAL(entobj);
                }
            }
            catch (StudentExceptionCl ex)
            {
                MessageBox.Show(ex.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return studentAdded;
        }

        public static List<StudentEntityCl> GetAllStudentsBL()
        {
            List<StudentEntityCl> studentList = null;
            try
            {
                StudentDALCl dal = new StudentDALCl();
                studentList = dal.GetAllStudentsDAL();
            }


            catch (StudentExceptionCl ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return studentList;
        }



        public static bool UpdateStudentBL(StudentEntityCl entobj)
        {
            bool studentUpdated = false;
            try
            {
                StudentDALCl dal = new StudentDALCl();
                studentUpdated = dal.UpdateStudentDAL(entobj);
                //if (ValidateGuest(updateGuest))
                //{
                //    GuestDAL guestDAL = new GuestDAL();
                //    guestUpdated = guestDAL.UpdateGuestDAL(updateGuest);
                //}
            }
            catch (StudentExceptionCl)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return studentUpdated;
        }


        public static StudentEntityCl SearchStudentBL(int studentID)
        {
            StudentEntityCl entobj = null;

            try
            {
                StudentDALCl dal = new StudentDALCl();
                entobj = dal.SearchStudentDAL(studentID);
            }
            catch (StudentExceptionCl ex)
            {
                 throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }



            return entobj;
        }


        public static bool DeleteStudentBL(int studentID)
        {
            bool delstudent = false;

            try
            {
                if (studentID > 0)
                {
                    StudentDALCl dal = new StudentDALCl();
                    delstudent = dal.DeleteStudentDAL(studentID);
                }
                else
                {
                    throw new StudentExceptionCl("Invalid Student ID");
                }
            }
            catch (StudentExceptionCl)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw ex;
            }



            return delstudent;
        }


        public static int getNextIdBAL()
        {
            int studentid=0;

            StudentDALCl dal = new StudentDALCl();
            studentid = dal.getNextIdDAL();

            return studentid;
        }

    }
}
