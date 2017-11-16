using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace TesteAutomatizado
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver;
        string url = "http://learnseleniumtesting.com/demo/";

        [TestInitialize]
        public void TestSetup()
        {
            driver = new ChromeDriver();
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }

        [TestMethod]
        public void PreencherCamposCustomer()
        {
            this.url = "http://localhost:50362/Customer/Criar";
            driver.Navigate().GoToUrl(url);

            var saveButton = driver.FindElement(By.Name("botaoSalvar"));

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("document.getElementById('Name').setAttribute('value', 'teste selenium')");
            js.ExecuteScript("document.getElementById('Email').setAttribute('value', 'teste@selenium.com.br')");
            js.ExecuteScript("document.getElementById('BirthDate').setAttribute('value', '2017-11-16')");

            Thread.Sleep(10000);

            saveButton.Click();

            Thread.Sleep(10000);
        }
    }
}
