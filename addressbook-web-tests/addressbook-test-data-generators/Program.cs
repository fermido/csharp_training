using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WebAddressbookTests;
using Newtonsoft.Json;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string generatorTypeData = (args[0]);
            int count = Convert.ToInt32(args[1]);
            StreamWriter writer = new StreamWriter(args[2]);
            string formatTypeData = (args[3]);

            if (generatorTypeData == "groups")
            {
                List<GroupData> groups = new List<GroupData>();
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(100),
                        Footer = TestBase.GenerateRandomString(100),
                    });
                }

                if (formatTypeData == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (formatTypeData == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (formatTypeData == "json")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unkonwn format: " + formatTypeData);
                }
            }
            else if (generatorTypeData == "contacts")
            {
                List<ContactData> contacts = new List<ContactData>();
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(30), TestBase.GenerateRandomString(30))
                    {
                        Address1 = TestBase.GenerateRandomString(100),
                        MiddleName = TestBase.GenerateRandomString(100),
                        NickName = TestBase.GenerateRandomString(100),
                        Title = TestBase.GenerateRandomString(100)
                    });
                }

                if (formatTypeData == "csv")
                {
                    writeContactsToCsvFile(contacts, writer);
                }
                else if (formatTypeData == "xml")
                {
                    writeContactsToXmlFile(contacts, writer);
                }
                else if (formatTypeData == "json")
                {
                    writeContactsToJsonFile(contacts, writer);
                }
                else
                {
                    System.Console.Out.Write("Unkonwn format: " + formatTypeData);
                }

            }
            else
            {
                System.Console.Out.Write("You are trying to generate unknown data: " + generatorTypeData);
            }
            writer.Close();
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Formatting.Indented));
        }

        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2},${3},${4},${5}",
                    contact.FirstName, contact.LastName, contact.Address1,
                    contact.MiddleName, contact.NickName, contact.Title));
            }
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void writeContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Formatting.Indented));
        }
    }
}
