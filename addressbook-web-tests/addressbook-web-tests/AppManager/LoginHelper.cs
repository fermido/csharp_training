using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(IWebDriver driver) : base (driver){
            this.driver = driver;
        }

        public LoginHelper Login(AccountData account)
        {
            driver.FindElement(By.Name("user")).Clear();
            driver.FindElement(By.Name("user")).SendKeys(account.Username);
            driver.FindElement(By.Name("pass")).Clear();
            driver.FindElement(By.Name("pass")).SendKeys(account.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
            return this;
        }

        public LoginHelper LogOut()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }
    }
}
