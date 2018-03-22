using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentEntity;
using StudentException;
using System.Data;
using System.Data.Common;
using System.Windows;

namespace StudentDAL
{
    public class StudentDALCl
    {

        public bool AddStudentDAL(StudentEntityCl entobj)
        {
            bool studentAdded = false;
            try
            {
                DbCommand command = DataConnection.CreateCommand();
                //PROCEDURE NAME
                command.CommandText = "uspAddStudent";


                //ID
                DbParameter param = command.CreateParameter();
                param.ParameterName = "@ipv_iStudentID";
                param.DbType = DbType.Int32;
                param.Value = entobj.STUDENTID;
                command.Parameters.Add(param);

                //NAME
                param = command.CreateParameter();
                param.ParameterName = "@ipv_vcStudentName";
                param.DbType = DbType.String;
                param.Value = entobj.STUDENTNAME;
                command.Parameters.Add(param);

                //CITY
                param = command.CreateParameter();
                param.ParameterName = "@ipv_vcCity";
                param.DbType = DbType.String;
                param.Value = entobj.CITY;
                command.Parameters.Add(param);

                //COURSE
                param = command.CreateParameter();
                param.ParameterName = "@ipv_vcCourse";
                param.DbType = DbType.String;
                param.Value = entobj.COURSE;
                command.Parameters.Add(param);


                //DATE OF ADMISSION
                param = command.CreateParameter();
                param.ParameterName = "@ipv_vcDOA";
                param.DbType = DbType.String;
                param.Value = entobj.DATEOFADMISSION;
                command.Parameters.Add(param);


                int affectedRows = DataConnection.ExecuteNonQueryCommand(command);

                if (affectedRows > 0)
                    studentAdded = true;
            }
            catch (DbException ex)
            {
                string errormessage;

                switch (ex.ErrorCode)
                {
                    case -2146232060:
                        errormessage = "Database Does NotExists Or AccessDenied";
                        break;
                    default:
                        errormessage = ex.Message;
                        break;
                }
                throw new StudentExceptionCl(errormessage);
            }
            return studentAdded;

        }

        public List<StudentEntityCl> GetAllStudentsDAL()
        {
            List<StudentEntityCl> studentList = null;

            try
            {
                DbCommand command = DataConnection.CreateCommand();
                command.CommandText = "uspGetAllStudents";
                DataTable dataTable = DataConnection.ExecuteSelectCommand(command);
                if (dataTable.Rows.Count > 0)
                {
                    studentList = new List<StudentEntityCl>();
                    for (int rowCounter = 0; rowCounter < dataTable.Rows.Count; rowCounter++)
                    {
                        StudentEntityCl entobj = new StudentEntityCl();
                        entobj.STUDENTID = (int)dataTable.Rows[rowCounter][0];
                        entobj.STUDENTNAME = (string)dataTable.Rows[rowCounter][1];
                        entobj.CITY = (string)dataTable.Rows[rowCounter][2];
                        entobj.COURSE = (string)dataTable.Rows[rowCounter][3];
                        entobj.DATEOFADMISSION = (DateTime)dataTable.Rows[rowCounter][4];
                        studentList.Add(entobj);
                    }
                }

            }

            catch(DbException ex)
            {
                throw new StudentExceptionCl(ex.Message);

            }
            return studentList;
        }



        public bool UpdateStudentDAL(StudentEntityCl entobj)
        {
            bool updateStudent = false;

            try
            {
                DbCommand command = DataConnection.CreateCommand();
                command.CommandText = "uspUpdateStudent";


                
                //ID
                DbParameter param = command.CreateParameter();
                param.ParameterName = "@ipv_iStudentID";
                param.DbType = DbType.Int32;
                param.Value = entobj.STUDENTID;
                command.Parameters.Add(param);


                //NAME
                param = command.CreateParameter();
                param.ParameterName = "@ipv_vcStudentName";
                param.DbType = DbType.String;
                param.Value = entobj.STUDENTNAME;
                command.Parameters.Add(param);

                //CITY
                param = command.CreateParameter();
                param.ParameterName = "@ipv_vcCity";
                param.DbType = DbType.String;
                param.Value = entobj.CITY;
                command.Parameters.Add(param);

                //COURSE
                param = command.CreateParameter();
                param.ParameterName = "@ipv_vcCourse";
                param.DbType = DbType.String;
                param.Value = entobj.COURSE;
                command.Parameters.Add(param);


                //DATE OF ADMISSION
                param = command.CreateParameter();
                param.ParameterName = "@ipv_vcDOA";
                param.DbType = DbType.String;
                param.Value = entobj.DATEOFADMISSION;
                command.Parameters.Add(param);


                int affectedRows = DataConnection.ExecuteNonQueryCommand(command);

                if (affectedRows > 0)
                    updateStudent = true;




            }
            catch(DbException ex)
            {
                throw new StudentExceptionCl(ex.Message);
            }

            return updateStudent;
        }


        public StudentEntityCl SearchStudentDAL(int searchStudentID)
        {
            StudentEntityCl searchStudent = null;
            try
            {
                DbCommand command = DataConnection.CreateCommand();
                command.CommandText = "uspSearchStudent";

                DbParameter param = command.CreateParameter();
                param.ParameterName = "@ipv_iStudentID";
                param.DbType = DbType.Int32;
                param.Value = searchStudentID;
                command.Parameters.Add(param);

               
                DataTable dataTable = DataConnection.ExecuteSelectCommand(command);
                if (dataTable.Rows.Count > 0)
                {
                    searchStudent = new StudentEntityCl();
                    searchStudent.STUDENTID = (int)dataTable.Rows[0][0];
                    searchStudent.STUDENTNAME = (string)dataTable.Rows[0][1];
                    searchStudent.CITY = (string)dataTable.Rows[0][2];
                    searchStudent.COURSE = (string)dataTable.Rows[0][3];
                    searchStudent.DATEOFADMISSION = Convert.ToDateTime(dataTable.Rows[0][4]);

                }
            }
            catch (DbException ex)
            {

                throw new StudentExceptionCl(ex.Message);
            }
            catch (Exception ex) {
                throw new StudentExceptionCl(ex.Message);
            }
            return searchStudent;
        }


        public bool DeleteStudentDAL(int studentID)
        {
            bool deleteStudent = false;

          try
            {
                DbCommand command = DataConnection.CreateCommand();
                command.CommandText = "uspDeleteStudent";


                DbParameter param = command.CreateParameter();
                param.ParameterName = "@ipv_iStudentID";
                param.DbType = DbType.Int32;
                param.Value = studentID;
                command.Parameters.Add(param);

                int affectedRows = DataConnection.ExecuteNonQueryCommand(command);

                if (affectedRows > 0)
                    deleteStudent = true;

            }
            catch(Exception ex)
            {
                throw new StudentExceptionCl(ex.Message);
            }



            return deleteStudent; 


        }


        public int getNextIdDAL()
        {
            int nextid=0;

            DbCommand command = DataConnection.CreateCommand();
            command.CommandText = "uspGetNextID";
            DataTable dataTable = DataConnection.ExecuteSelectCommand(command);
            if (dataTable.Rows.Count > 0)
            {

                nextid = (int)dataTable.Rows[0][0];

            }


                return nextid;
        }

    }
}
