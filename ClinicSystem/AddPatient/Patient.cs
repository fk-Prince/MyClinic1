using System;

namespace ClinicSystem
{
    public class Patient
    {
        private int roomNo;
        private int frontdeskId;
        private int doctorIds;
        private int operationCode;
        private string fname;
        private string mname;
        private string lname;
        private int age;
        private string address;
        private string gender;
        private string condition;
        private DateTime birthDate;
        private DateTime dateAdmitted;
        private long ContactNumber;
        private double bill;

        public Patient(int roomNo, int frontdeskId, int doctorId, int operationCode, string fname, string mname, string lname, int age, string address, string gender, string condition, DateTime birthDate, DateTime dateAdmitted, long contactNumber, double bill)
        {
            this.roomNo = roomNo;
            this.frontdeskId = frontdeskId;
            this.doctorIds = doctorId;
            this.operationCode = operationCode;
            this.fname = fname;
            this.mname = mname;
            this.lname = lname;
            this.age = age;
            this.address = address;
            this.gender = gender;
            this.condition = condition;
            this.birthDate = birthDate;
            this.dateAdmitted = dateAdmitted;
            ContactNumber = contactNumber;
            this.bill = bill;
        }

        public int getRoomNo()
        {
            return roomNo;
        }
        public int getFrontdeskId()
        {
            return frontdeskId;
        }
        public int doctorId()
        {
            return doctorIds;
        }
        public int getOperationCode()
        {
            return operationCode;
        }

        public int getAge()
        {
            return age;
        }
        public String getAddress()
        {
            return address;
        }
        public String getGender()
        {
            return gender;
        }
        public String getCondition()
        {
            return condition;
        }
        public DateTime getBirthDate()
        {
            return birthDate;
        }
        public DateTime getDateAdmitted()
        {
            return dateAdmitted;
        }
        public long getContactNumber()
        {
            return ContactNumber;
        }
        public double getBill()
        {
            return bill;
        }
        public String getFname()
        {
            return fname;
        }
        public String getMname()
        {
            return mname;
        }
        public String getLname()
        {
            return lname;
        }


    }
}