using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicSystem
{
    public class Doctor
    {

        private int doctorID;
        private string doctorFirstName;
        private string doctorMiddleName;
        private string doctorLastName;
        private int age;
        private DateTime dateHired;
        private string password;
        private int operationid;

        public Doctor(int doctorID, string doctorFirstName, string doctorMiddleName, string doctorLastName, int age, DateTime dateHired, string password, int operationid)
        {
            this.doctorID = doctorID;
            this.doctorFirstName = doctorFirstName;
            this.doctorMiddleName = doctorMiddleName;
            this.doctorLastName = doctorLastName;
            this.age = age;
            this.dateHired = dateHired.Date;
            this.password = password;
            this.operationid = operationid;
        }

        public int getDoctorID()
        {
            return doctorID;
        }

        public string getDoctorFirstName()
        {
            return doctorFirstName;
        }
        public string getDoctorMiddleName()
        {
            return doctorMiddleName;
        }

        public string getDoctorLastName()
        {
            return doctorLastName;
        }
        public int getAge()
        {
            return age;
        }   
        public DateTime getDateHired()
        {
            return dateHired;
        }   
        public string getPassword()
        {
            return password;
        }
        public int getOperationID()
        {
            return operationid;
        }
    }
}
