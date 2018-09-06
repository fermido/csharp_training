using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string address1 = "";
        private string home = "";
        private string mobile = "";
        private string work = "";
        private string allPhones;
        private string allMails;
        private string allData;
        private string middlename = "";
        private string nickname = "";
        private string title = "";

        public ContactData()
        {
        }

        public ContactData(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "middlename")]
        public string MiddleName
        {
            get
            {
                if (middlename == null)
                {
                    return "";
                }
                else
                {
                    return middlename;
                }
            }
            set
            {
                middlename = value;
            }
        }

        [Column(Name = "nickname")]
        public string NickName
        {
            get
            {
                if (nickname == null)
                {
                    return "";
                }
                else
                {
                    return nickname;
                }
            }
            set
            {
                nickname = value;
            }
        }

        [Column(Name = "title")]
        public string Title
        {
            get
            {
                if (title == null)
                {
                    return "";
                }
                else
                {
                    return title;
                }
            }
            set
            {
                title = value;
            }
        }

        [Column(Name = "company")] 
        public string Company { get; set; }
        
        [Column(Name = "home")]
        public string HomePhone 
        {
            get
            {
                if (home == null)
                {
                    return "";
                }
                else
                {
                    return home;
                }
            }
            set
            {
                home = value;
            }
        }

        [Column(Name = "mobile")]
        public string MobilePhone
        {
            get
            {
                if (mobile == null)
                {
                    return "";
                }
                else
                {
                    return mobile;
                }
            }
            set
            {
                mobile = value;
            }
        }

        [Column(Name = "work")]
        public string WorkPhone
        {
           get
            {
                if (work == null)
                {
                    return "";
                }
                else
                {
                    return work;
                }
            }
            set
            {
                work = value;
            }
        }

        [Column(Name = "fax")]
        public string Fax { get; set; }
        
        [Column(Name = "email")] 
        public string Email1 { get; set; }
        
        [Column(Name = "email2")]
        public string Email2 { get; set; }
        
        [Column(Name = "email3")] 
        public string Email3 { get; set; }
        
        [Column(Name = "homepage")]
        public string Homepage { get; set; }
        
        public string Bday { get; set; }
       
        public string Bmonth { get; set; }
       
        public string Byear { get; set; }
        
        public string Aday { get; set; }
        
        public string Amonth { get; set; }
        
        public string Ayear { get; set; }
        
        public string Address2 { get; set; }
        
        public string Phone { get; set; }
        
        public string Notes { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }
        
        [Column(Name = "address")]
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

        public string AllData
        {
            get
            {
                if (allData != null)
                {
                    return allData;
                }
                else
                {
                    allData =
                        NameProccessing(FirstName) + NameProccessing(MiddleName) + LastName
                        + NickName + Title + Company + Address1
                        + PhoneProcessing(HomePhone)
                        + PhoneProcessing(MobilePhone)
                        + PhoneProcessing(WorkPhone)
                        + Email1 + Email2 + Email3
                        + Address2;
                    return allData;
                }
            }
            set
            {
                allData = value;
            }
        }

        private string NameProccessing(string name)
        {
            if (name == null || name == "")
            {
                return "";
            }
            else
            {
                return name + " ";
            }
        }

        private string PhoneProcessing(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            else
            {
                if (phone == HomePhone)
                {
                    return "H: " + HomePhone;
                }
                else if(phone == MobilePhone)
                {
                    return "M: " + MobilePhone;
                }
                else if (phone == WorkPhone)
                {
                    return "W: " + WorkPhone;
                }
                else throw new InvalidOperationException("unknown phone");
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

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (FirstName.CompareTo(other.FirstName) == 0)
            {
                if (LastName.CompareTo(other.LastName) == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                return 1;
            }
        }

        public override string ToString()
        {
            return String.Format("FirstName=${0},LastName=${1}", FirstName, LastName);
        }

        public static List<ContactData> GetDataFromDb()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }

    }
}

