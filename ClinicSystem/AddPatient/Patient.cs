using System;

namespace ClinicSystem
{
    internal class Patient
    {
        private string firstName;
        private string middleName;
        private string lastName;
        private string address;
        private string gender;
        private int age;
        private DateTime birthDate;
        private int contactNumber;
        private DateTime dateAdmitted;
        private string condition;
        private int operationid;
        private string doctorAssigned;
        private string medicalHistory;
        private double bill;

        public Patient(string firstName, string middleName, string lastName, string address, string gender, int age, DateTime birthDate, int contactNumber, DateTime dateAdmitted, string condition, int operationid, string doctorAssigned, string medicalHistory, double bill)
        {
            this.firstName = firstName;
            this.middleName = middleName;
            this.lastName = lastName;
            this.address = address;
            this.gender = gender;
            this.age = age;
            this.birthDate = birthDate.Date;
            this.contactNumber = contactNumber;
            this.dateAdmitted = dateAdmitted.Date;
            this.condition = condition;
            this.operationid = operationid;
            this.doctorAssigned = doctorAssigned;
            this.medicalHistory = medicalHistory;
            this.bill = bill;
        }

        public string getFirstName() { return firstName; }
        public string getMiddleName() { return middleName; }
        public string getLastName() { return lastName; }
        public string getAddress() { return address; }
        public string getGender()
        {
            return gender;
        }
        public int getAge()
        {
            return age;
        }
        public DateTime getBirthDate()
        {
            return birthDate;
        }
        public int getContactNumber()
        {
            return contactNumber;
        }
        public DateTime getDateAdmitted()
        {
            return dateAdmitted;
        }
        public string getCondition()
        {
            return condition;
        }
        public int getOperationID()
        {
            return operationid;
        }
        public string getDoctorAssigned()
        {
            return doctorAssigned;
        }
        public string getMedicalHistory()
        {
            return medicalHistory;
        }
        public double getBill()
        {
            return bill;
        }

    }
}