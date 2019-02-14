using OpenQA.Selenium;
using TestWebProject.Webdriver;
using System.Threading;

namespace TestWebProject.Forms
{
    public class StartPage : BasePage
    {
        private static readonly By StartPageLocator = By.XPath("//a[@id='PH_authLink']");

        public StartPage() : base(StartPageLocator, "Start Page")
        {

        }

        private readonly BaseElement loginButton = new BaseElement(By.XPath("//a[@id='PH_authLink']"));
        private readonly BaseElement signInFrame = new BaseElement(By.ClassName("ag-popup__frame__layout__iframe"));
        private readonly BaseElement loginInputField = new BaseElement(By.XPath("//input[@name='Login']"));
        private readonly BaseElement passwordInputField = new BaseElement(By.XPath("//input[@name='Password']"));
        private readonly BaseElement submitButton = new BaseElement(By.XPath("//button[@type='submit']"));
        private readonly BaseElement newEmailButton = new BaseElement(By.XPath("//div[@class = 'b-sticky']//a[@data-name='compose'] | //div[@class = 'b-sticky js-not-sticky']//a[@data-name='compose']"));

        public void Login(string username, string password)
        {
            this.loginButton.Click();
            Browser.GetDriver().SwitchTo().Frame(this.signInFrame.GetElement());
            this.loginInputField.Click();
            this.loginInputField.SendKeys(username);
            this.passwordInputField.Click();
            this.passwordInputField.SendKeys(password);
            this.submitButton.Click();
            Browser.GetDriver().SwitchTo().DefaultContent();
        }

        public bool IsLoginSucceeded()
        {
            return this.newEmailButton.Displayed;
        }
    }
}