using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEntity
{
    public class StudentEntityCl
    {
        #region Fields

        private int _studentID;
        private string _studentname;
        private string _city;
        private string _course;
        private DateTime _dateofadmission;
        #endregion

        #region Property

        public int STUDENTID { get {return _studentID; } set {_studentID=value; } }
        public string STUDENTNAME { get {return _studentname; } set {_studentname=value; } }

        public string CITY { get {return _city; } set {_city=value; } }

        public string COURSE { get {return _course; } set {_course=value; } }


        public DateTime DATEOFADMISSION { get {return _dateofadmission; } set {_dateofadmission=value; } }

        #endregion

        #region Method

        #endregion

        #region Constructor

        public StudentEntityCl()
        {

        }

        public StudentEntityCl(int id,string name,string city,string course,DateTime dateofadmission)
        {
            _studentID = id;
            _studentname = name;
            _city = city;
            _course = course;
            _dateofadmission = dateofadmission;
        }

        #endregion
    }
}
