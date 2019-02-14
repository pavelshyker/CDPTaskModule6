using OpenQA.Selenium;
using TestWebProject.Webdriver;
using System.Threading;
using System.Linq;

namespace TestWebProject.Forms
{
    public class SentPage : BasePage
    {
        private static readonly By SentPageLocator = By.XPath("//div[@class='b-sticky js-not-sticky']//div[@data-cache-key='500000_undefined_false']//div[@data-name='archive'] | //div[@class='b-sticky']//div[@data-cache-key='500000_undefined_false']//div[@data-name='archive']");

        public SentPage() : base(SentPageLocator, "Sent Page")
        {

        }

        private readonly BaseElement sentEmailItems = new BaseElement(By.XPath("//div[@data-cache-key='500000_undefined_false']//div[@class='b-datalist__item__addr']"));
        private readonly BaseElement emptyBlock = new BaseElement(By.ClassName("b-datalist__empty__block"));
        private readonly BaseElement checkBoxSelectAllSend2Options = new BaseElement(By.XPath("//div[@class = 'b-sticky']//div[@data-cache-key = '500000_undefined_false']//div[contains(@class, 'selectAll')]//div[contains(@class, 'b-checkbox__box')] | //div[@class = 'b-sticky js-not-sticky']//div[@data-cache-key = '500000_undefined_false']//div[contains(@class, 'selectAll')]//div[contains(@class, 'b-checkbox__box')]"));
        private readonly BaseElement deleteAllOptionSend2Options = new BaseElement(By.XPath("//div[@class = 'b-sticky']//div[@data-cache-key='500000_undefined_false']//div[@data-shortcut-title='Del'] | //div[@class = 'b-sticky js-not-sticky']//div[@data-cache-key='500000_undefined_false']//div[@data-shortcut-title='Del']"));
        private readonly BaseElement newEmailButton = new BaseElement(By.XPath("//div[@class = 'b-sticky']//a[@data-name='compose'] | //div[@class = 'b-sticky js-not-sticky']//a[@data-name='compose']"));

        public bool DeleteAllSent()
        {
            var sentElements = Browser.GetDriver().FindElements(sentEmailItems.Locator);
            if (sentElements.Any())
            {
                this.checkBoxSelectAllSend2Options.Click();
                this.deleteAllOptionSend2Options.Click();
            }
            bool sentEmpty = this.emptyBlock.Displayed;
            return sentEmpty;
        }

        public void GoToNewEmailPage()
        {
            this.newEmailButton.Click();
        }

        public bool SentEmailExist()
        {
            var sentElements = Browser.GetDriver().FindElements(sentEmailItems.Locator);
            bool isAnySent = sentElements.Any();
            return isAnySent;
        }
    }
}
