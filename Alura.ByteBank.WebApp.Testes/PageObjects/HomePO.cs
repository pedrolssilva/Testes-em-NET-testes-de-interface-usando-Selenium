using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.ByteBank.WebApp.Testes.PageObjects
{
    public class HomePO
    {
        private IWebDriver driver;
        private By linkHome;
        private By linkContaCorrentes;
        private By linkClientes;
        private By linkAgencias;

        public IWebDriver Driver { get => driver; set => driver = value; }

        public HomePO(IWebDriver driver)
        {
            this.Driver = driver;
            linkHome = By.Id("home");
            linkContaCorrentes = By.Id("contacorrente");
            linkClientes = By.Id("clientes");
            linkAgencias = By.Id("agencia");
        }

        public void Navegar(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void LinkHomeClick()
        {
            Driver.FindElement(linkHome).Click();
        }

        public void LinkContaCorrenteClick()
        {
            Driver.FindElement(linkContaCorrentes).Click();
        }

        public void LinkClientesClick()
        {
            Driver.FindElement(linkClientes).Click();
        }

        public void LinkAgenciaslick()
        {
            Driver.FindElement(linkAgencias).Click();
        }
    }
}
