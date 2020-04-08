using System;
using System.IO;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Test1
{
    [TestFixture]
   public class FirstTest

   {
       private readonly IWebDriver driver;
       private static readonly string url = "http://automationpractice.com/index.php";
       public FirstTest()
       {
           
           driver=new ChromeDriver(Directory.GetCurrentDirectory());
           driver.Manage().Window.Maximize();
           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
           driver.Navigate().GoToUrl(url);
       }

      

       [Test]
        public void ContactUsTest()
        {
            driver.FindElement(By.Id("contact-link")).Click();
            driver.FindElement(By.Id("email")).SendKeys("test@gmail.com");
            driver.FindElement(By.Id("id_order")).SendKeys("order id");
            driver.FindElement(By.Id("message")).SendKeys("your message");
            SelectElement oSelect = new SelectElement(driver.FindElement(By.Id("id_contact")));
            oSelect.SelectByText("Webmaster");
            driver.FindElement(By.Id("submitMessage")).Click();
           
           
        }
        [Test]
        public void AddToCartTest()
        {
            driver.FindElement(By.Id("search_query_top")).SendKeys("T-SHIRT"+Keys.Enter);
            driver.FindElement(By.LinkText("Faded Short Sleeve T-shirts")).Click();
            driver.FindElement(By.Name("Submit")).Click();
            driver.FindElement(By.LinkText("Proceed to checkout")).Click();
            
        }
    }
}