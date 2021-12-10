using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Alura.ByteBank.WebApp.Testes
{
    public class NavegandoNaPaginaHome:IDisposable
    {
        private readonly string diretorio;
        private ChromeDriver driver;

        //Setup
        public NavegandoNaPaginaHome()
        {
            diretorio = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            driver = new ChromeDriver(diretorio);
        }
        [Fact]
        public void CarregaPaginaHomeEVerificaTituloDaPagina()
        {
            //Arrange
            //IWebDriver driver = new ChromeDriver(diretorio);
            //Act
            driver.Navigate().GoToUrl("https://localhost:44309");
            //Assert
            Assert.Contains("WebApp", driver.Title);

        }

        [Fact]
        public void CarregadaPaginaHomeVerificaExistenciaLinkLoginEHome()
        {
            //Arrange
            //IWebDriver driver = new ChromeDriver(diretorio);
            //Act
            driver.Navigate().GoToUrl("https://localhost:44309");
            //Assert
            Assert.Contains("Login", driver.PageSource);
            Assert.Contains("Home", driver.PageSource);

        }

        //Cleanup
        public void Dispose()
        {
            //Fechar o navegador
            driver.Quit();
        }
    }
}
