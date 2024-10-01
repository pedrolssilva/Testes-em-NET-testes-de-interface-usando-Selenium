using Alura.ByteBank.WebApp.Testes.PageObjects;
using Alura.ByteBank.WebApp.Testes.Util;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.ByteBank.WebApp.Testes
{
    public class AposRealizarLogin : IClassFixture<Fixture>
    {
        private IWebDriver driver;
        public ITestOutputHelper SaidaConsoleTeste;
        public AposRealizarLogin(Fixture fixture, ITestOutputHelper _saidaConsoleTeste)
        {
            driver = fixture.Driver;
            SaidaConsoleTeste = _saidaConsoleTeste;
        }

        [Fact]
        public void AposRealizarLoginVerificaSeExisteOpcaoAgenciaMenu()
        {
            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("andre@email.com", "senha01");
            loginPO.Logar();

            //Assert
            Assert.Contains("Agência", driver.PageSource);
        }

        [Fact]
        public void TentaRealizarLoginSemPreencherCampos()
        {
            //Arrange          
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("", "");
            loginPO.Logar();

            //Assert
            Assert.Contains("The Email field is required.", driver.PageSource);
            Assert.Contains("The Senha field is required.", driver.PageSource);
        }

        [Fact]
        public void TentaRealizarLoginComSenhaInvalida()
        {
            //Arrange          
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("andre@email.com", "senha01x");
            loginPO.Logar();

            //Assert
            Assert.Contains("Login", driver.PageSource);
        }

        [Fact]
        public void AposRealizarLoginAcessaMenuAgencia()
        {
            ////Arrange          
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("andre@email.com", "senha01");
            loginPO.Logar();
            var homePO = new HomePO(driver);
            homePO.LinkAgenciaslick();

            //Assert
            Assert.Contains("Adicionar Agência", driver.PageSource);
        }

        [Fact]
        public void RealizarLoginAcessaListagemDeContas()
        {
            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            //Act
            loginPO.PreencherCampos("andre@email.com", "senha01");
            loginPO.Logar();

            var homePO = new HomePO(driver);
            homePO.LinkContaCorrenteClick();

            IReadOnlyCollection<IWebElement> elements = homePO.Driver.FindElements(By.TagName("a"));
            var elemento = (from webElemento in elements
                            where webElemento.Text.Contains("Detalhes")
                            select webElemento).First();

            // Act
            elemento.Click();

            //Assert   
            Assert.Contains("Voltar", driver.PageSource);

        }

        [Fact]
        public void RealizarLoginAcessaMenuCadastraCliente()
        {
            //Arrange
            var loginPO = new LoginPO(driver);
            loginPO.Navegar("https://localhost:44309/UsuarioApps/Login");

            loginPO.PreencherCampos("andre@email.com", "senha01");
            loginPO.Logar();

            var homePO = new HomePO(driver);
            homePO.Driver.FindElement(By.LinkText("Cliente")).Click();
            homePO.Driver.FindElement(By.LinkText("Adicionar Cliente")).Click();

            homePO.Driver.FindElement(By.Name("Identificador")).Click();
            homePO.Driver.FindElement(By.Name("Identificador")).SendKeys("6c00bb98-807c-4147-a113-f0a4038855af");

            homePO.Driver.FindElement(By.Name("CPF")).Click();
            homePO.Driver.FindElement(By.Name("CPF")).SendKeys("69981034096");

            homePO.Driver.FindElement(By.Name("Nome")).Click();
            homePO.Driver.FindElement(By.Name("Nome")).SendKeys("Tobey Garfield");

            homePO.Driver.FindElement(By.Name("Profissao")).Click();
            homePO.Driver.FindElement(By.Name("Profissao")).SendKeys("Cientista");

            //Act
            homePO.Driver.FindElement(By.CssSelector(".btn-primary")).Click();
            homePO.Driver.FindElement(By.LinkText("Home")).Click();

            //Assert   
            Assert.Contains("Logout", driver.PageSource);
        }

    }
}
