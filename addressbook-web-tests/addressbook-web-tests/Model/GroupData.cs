﻿using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        private string name;
        private string header = "";
        private string footer = "";

        public GroupData()
        {
        }

        public GroupData(string name)
        {
            this.name = name;
        }

        [Column(Name = "group_name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [Column(Name = "group_header")]
        public string Header
        {
            get { return header; }
            set { header = value; }
        }

        [Column(Name = "group_footer")]
        public string Footer
        {
            get { return footer; }
            set { footer = value; }
        }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return "name=" + Name;
        }

        public static List<GroupData> GetDataFromDb()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups.Where(x => x.Deprecated == "0000-00-00 00:00:00") select g).ToList();
            }
        }
        
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
