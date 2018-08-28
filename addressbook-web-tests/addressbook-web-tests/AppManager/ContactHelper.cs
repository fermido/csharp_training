using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;


namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(IWebDriver driver) : base(driver) {
            this.driver = driver;
        }

        public ContactHelper SubmitNewContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitNewContactData()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        private List<ContactData> contactCache = null;

        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath(".//*[@id='maintable']/tbody/tr"));

                for (int i = 1; i < elements.Count; i++)
                {
                    var lastName = driver.FindElement(By.XPath(".//*[@id='maintable']/tbody/tr[" + (i + 1) + "]/td[2]"));
                    var firstName = driver.FindElement(By.XPath(".//*[@id='maintable']/tbody/tr[" + (i + 1) + "]/td[3]"));

                    ContactData contact = new ContactData(lastName.Text, firstName.Text);
                    contactCache.Add(contact);
                }
            }
            return new List<ContactData>(contactCache);
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.FirstName);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.MiddleName);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.LastName);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(contact.NickName);
            driver.FindElement(By.Name("title")).Clear();
            driver.FindElement(By.Name("title")).SendKeys(contact.Title);
            /*
            driver.FindElement(By.Name("company")).Clear();
            driver.FindElement(By.Name("company")).SendKeys(contact.Company);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address1);
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(contact.Home);
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(contact.Mobile);
            driver.FindElement(By.Name("work")).Clear();
            driver.FindElement(By.Name("work")).SendKeys(contact.Work);
            driver.FindElement(By.Name("fax")).Clear();
            driver.FindElement(By.Name("fax")).SendKeys(contact.Fax);
            driver.FindElement(By.Name("email")).Clear();
            driver.FindElement(By.Name("email")).SendKeys(contact.Email1);
            driver.FindElement(By.Name("email2")).Clear();
            driver.FindElement(By.Name("email2")).SendKeys(contact.Email2);
            driver.FindElement(By.Name("email3")).Clear();
            driver.FindElement(By.Name("email3")).SendKeys(contact.Email3);
            driver.FindElement(By.Name("homepage")).Clear();
            driver.FindElement(By.Name("homepage")).SendKeys(contact.Homepage);
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys(contact.Ayear);
            driver.FindElement(By.Name("address2")).Clear();
            driver.FindElement(By.Name("address2")).SendKeys(contact.Address2);
            driver.FindElement(By.Name("phone2")).Clear();
            driver.FindElement(By.Name("phone2")).SendKeys(contact.Phone);
            driver.FindElement(By.Name("notes")).Clear();
            driver.FindElement(By.Name("notes")).SendKeys(contact.Notes);
            */
            return this;
        }

        public bool IsContactExisted()
        {
            return IsElementPresented(By.XPath(".//*[@id='maintable']/tbody/tr[2]/td[1]"));
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper SelectGroup(int v)
        {
            driver.FindElement(By.XPath(".//*[@id='maintable']/tbody/tr[" + (v + 1) + "]/td[1]")).Click();
            return this;
        }

        public ContactHelper InitContactRemoval()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper ConfirmContactRemoval()
        {
            driver.SwitchTo().Alert().Accept();
            contactCache = null;
            return this;
        }

        public ContactHelper EditContact(int v)
        {
            driver.FindElement(By.XPath(".//*[@id='maintable']/tbody/tr[" + (v+1) + "]/td[8]/a/img")).Click();
            return this;
        }

        public void CreateNewContact(ContactData contact)
        {
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitNewContactCreation();
        }

    }
}
