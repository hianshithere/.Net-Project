using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace StudentDAL
{
    class StudentConfiguration
    {
        public static string providerName;

        public static string ProviderName
        {
            get {return StudentConfiguration.providerName; }
            set {StudentConfiguration.providerName=value;  }
        }

        public static string connectionString;



        public static string ConnectionString
        {
            get {return StudentConfiguration.connectionString; }
            set {StudentConfiguration.connectionString=value; }
        }

        static StudentConfiguration()
        {
            providerName = ConfigurationManager.ConnectionStrings["StudentConnection"].ProviderName;
            connectionString = ConfigurationManager.ConnectionStrings["StudentConnection"].ConnectionString;
        }
    }
}
