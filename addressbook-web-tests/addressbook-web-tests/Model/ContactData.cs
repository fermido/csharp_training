using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>
    {
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
        private string allPhones;
        private string allMails;

        public ContactData(string firstName,string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        
        public string LastName { get; set; }

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
            get
            {
                if (address1 == null)
                {
                    return "";
                }
                else
                {
                    return Regex.Replace(address1, "[ \r\n]", ""); 
                }
            }
            set
            {
                address1 = value;
            }
        }

        public string HomePhone
        {
            get { return home; }
            set { home = value; }
        }

        public string MobilePhone
        {
            get { return mobile; }
            set { mobile = value; }
        }

        public string WorkPhone
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

        public string AllMails
        {
            get
            {
                if (allMails != null)
                {
                    return allMails;
                }
                else
                {
                    allMails = Email1 + Email2 + Email3;
                    return Regex.Replace(allMails, "[ \r\n]", "");
                }
            }
            set
            {
                allMails = value;
            }
        }
        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        private string CleanUp(string phone)
        {
            if (phone == null || phone =="")
            {
                return "";
            }
            else
                return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
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
            return (LastName == other.LastName) && (FirstName == other.FirstName);
        }
    }
}

