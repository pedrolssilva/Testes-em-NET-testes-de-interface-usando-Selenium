using Alura.ByteBank.WebApp.Testes.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;
using Xunit;

namespace Alura.ByteBank.WebApp.Testes
{
    public class NavegandoNaPaginaHome : IClassFixture<Fixture>
    {
        //private readonly string diretorio;
        private IWebDriver driver;

        //Setup
        public NavegandoNaPaginaHome(Fixture fixture)
        {
            //diretorio = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            //driver = new ChromeDriver(diretorio);
            driver = fixture.Driver;
        }
        [Fact]
        public void CarregaPaginaHomeEVerificaTituloDaPagina()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            //Act
            driver.Navigate().GoToUrl("https://localhost:44309");
            //Assert
            Assert.Contains("WebApp", driver.Title);

        }

        [Fact]
        public void CarregadaPaginaHomeVerificaExistenciaLinkLoginEHome()
        {
            //Arrange
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)); ;
            //Act
            driver.Navigate().GoToUrl("https://localhost:44309");
            //Assert
            Assert.Contains("Login", driver.PageSource);
            Assert.Contains("Home", driver.PageSource);

        }

        [Fact]
        public void LogandoNoSistema()
        {
            //Arrange 
            IWebDriver driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            
            //Act 
            driver.Navigate().GoToUrl("https://localhost:44309");
            driver.Manage().Window.Size = new System.Drawing.Size(1252, 652);
            driver.FindElement(By.LinkText("Login")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("andre@email.com");
            driver.FindElement(By.Id("Senha")).Click();
            driver.FindElement(By.Id("Senha")).SendKeys("senha01");
            driver.FindElement(By.Id("btn-logar")).Click();
            driver.FindElement(By.Id("agencia")).Click();
            driver.FindElement(By.Id("home")).Click();
            
            //Assert

        }

        [Fact]
        public void ValidaLinkDeLoginNaHome()
        {
            //Arrange 
            driver.Navigate().GoToUrl("https://localhost:44309");
            var linkLogin = driver.FindElement(By.LinkText("Login"));

            //Act 
            linkLogin.Click();

            //Assert
            Assert.Contains("img", driver.PageSource);
        }

        [Fact]
        public void TentaAcessarPaginaSemEstarLogado()
        {
            //Arrange 
            //Act 
            driver.Navigate().GoToUrl("https://localhost:44309/Agencia/Index");

            //Assert
            Assert.Contains("401", driver.PageSource);
        }

        [Fact]
        public void TentaAcessarPaginaSemEstarLogadoVerificaURL()
        {
            //Arrange 
            //Act 
            driver.Navigate().GoToUrl("https://localhost:44309/Agencia/Index");

            //Assert
            Assert.Contains("https://localhost:44309/Agencia/Index", driver.Url);
            Assert.Contains("401", driver.PageSource);
        }

        ////Cleanup
        //public void Dispose()
        //{
        //    //Fechar o navegador
        //    driver.Quit();
        //}
    }
}
