using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Alura.ByteBank.WebApp.Testes
{
    public class AgenciaSeleniumTestes
    {
        private readonly string diretorio;
        public AgenciaSeleniumTestes()
        {
            diretorio = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
        [Fact]
        public void CarregaPaginaIndexAgencia()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(diretorio);
            //Act
            driver.Navigate().GoToUrl("https://localhost:44309");
            //Assert
            Assert.Contains("WebApp", driver.Title);

        }

        [Fact]
        public void CarregadaPaginaIndexAgenciaVerificaExistenciaLinkAgencia()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(diretorio);
            //Act
            driver.Navigate().GoToUrl("https://localhost:44309/Agencia");
            //Assert
            Assert.Contains("Agência", driver.PageSource);

        }
    }
}
