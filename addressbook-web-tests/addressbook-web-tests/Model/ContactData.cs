using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>
    {
        private string firstName;
        private string lastName;
        private string middleName = "";
        private string nickName = "";
        private string title = "";
        private string company = "";
        private string address1 = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string fax = "";
        private string email1 = "";
        private string email2 = "";
        private string email3 = "";
        private string homepage = "";
        private string bday = "";
        private string bmonth = "";
        private string byear = "";
        private string aday = "";
        private string amonth = "";
        private string ayear = "";
        private string address2 = "";
        private string phone = "";
        private string notes = "";

        public ContactData(string firstName,string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string MiddleName
        {
            get { return middleName; }
            set { middleName = value; }
        }

        public string NickName
        {
            get { return nickName; }
            set { nickName = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public string Address1
        {
            get { return address1; }
            set { address1 = value; }
        }

        public string Home
        {
            get { return home; }
            set { home = value; }
        }

        public string Mobile
        {
            get { return mobile; }
            set { mobile = value; }
        }

        public string Work
        {
            get { return work; }
            set { work = value; }
        }

        public string Fax
        {
            get { return fax; }
            set { fax = value; }
        }

        public string Email1
        {
            get { return email1 ; }
            set { email1 = value; }
        }

        public string Email2
        {
            get { return email2; }
            set { email2 = value; }
        }

        public string Email3
        {
            get { return email3; }
            set { email3 = value; }
        }

        public string Homepage
        {
            get { return homepage; }
            set { homepage = value; }
        }

        public string Bday
        {
            get { return bday; }
            set { bday = value; }
        }

        public string Bmonth
        {
            get { return bmonth; }
            set { bmonth = value; }
        }

        public string Byear
        {
            get { return byear; }
            set { byear = value; }
        }

        public string Aday
        {
            get { return aday; }
            set { aday = value; }
        }

        public string Amonth
        {
            get { return amonth; }
            set { amonth = value; }
        }

        public string Ayear
        {
            get { return ayear; }
            set { ayear = value; }
        }

        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Notes
        {
            get { return notes; }
            set { notes = value; }
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return (lastName == other.lastName) && (firstName == other.firstName);
        }
    }
}

