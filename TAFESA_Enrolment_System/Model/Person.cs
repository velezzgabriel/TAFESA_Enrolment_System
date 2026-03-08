using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAFESA_Enrolment_System.Model
{
    internal class Person
    {
        // constants for all attributes
        protected const string DEF_NAME = "No name provided";
        protected const string DEF_EMAIL = "No email provided";
        protected const string DEF_PHONENUMBER = "No phone number provided";
        protected const string DEF_ADDRESS = "No address provided";


        // attributes
        private string name;
        private string email;
        private string phoneNumber;
        private string address; // fk


        // no args constructor
        public Person() : this(DEF_NAME, DEF_EMAIL, DEF_PHONENUMBER, DEF_ADDRESS)
        {

        }

        // all args constructor
        public Person(string name, string email, string phoneNumber, string address)
        {
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.address = address;
        }

        // Property Assessor Methods
        public string PersonName
        {
            get { return name; }
            set { name = value; }
        }
        public string PersonEmail
        {
            get { return email; }
            set { email = value; }
        }
        public string PersonPhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string PersonAddress
        {
            get { return address; }
            set { address = value; }
        }

        // override ToString
        public override string ToString()
        {
            return "Name: " + PersonName + ", Email: " + PersonEmail + ", Phone Number: " + PersonPhoneNumber + ", Address: " + PersonAddress;
        }
    }
}
