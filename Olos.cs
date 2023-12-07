using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleOLOS
{
    class Olos
    {
        public static void Main(string[] args)
        {
            string url = "http://10.195.128.3/Olos/Login.aspx";

            StreamReader sr = new StreamReader("C:\\Users\\Helicon\\Pictures\\ControleOLOS\\ControleOLOS\\idCampaign.txt");

            String linha = sr.ReadLine();


            int idCampaign = 161;

            string username = "helicon.souza";
            string senha = "Ktech@1234";

            ChromeDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            driver.FindElement(By.XPath("//*[@id=\"UserTxt\"]")).SendKeys(username);

            driver.FindElement(By.XPath("//*[@id=\"Password\"]")).SendKeys(senha);
            driver.FindElement(By.XPath("//*[@id=\"BtnOK\"]")).Click();

            driver.FindElement(By.XPath("//*[@id=\"ctl00_PageMenu_LinkButton3\"]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"sidebar\"]/ul/li/h2[7]/a")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"ctl00_PageMenu_CampaignMenu1__labelCampaignMenu_Campaigns_List\"]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"ctl00_PageContent_TabContainer1_TabPanel1_ListBox\"]/option[1]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"ctl00_PageContent__Edit\"]")).Click();
            Thread.Sleep(2000);

            while (linha != null)
            {
                driver.Navigate().GoToUrl("http://10.195.128.3/SysConfiguration/CampaignsForm.aspx?CampaignId=" + linha);
                driver.FindElement(By.XPath("//*[@id=\"ctl00_PageContent_TabContainer1_TabPanelWorkingInfo_labelWorkingInfo\"]")).Click();
                driver.FindElement(By.XPath("//*[@id=\"ctl00_PageContent_TabContainer1_TabPanelWorkingInfo_SpecialDaysPlanId\"]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[@id=\"ctl00_PageContent_TabContainer1_TabPanelWorkingInfo_SpecialDaysPlanId\"]/option[23]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//*[@id=\"ctl00_PageContent_ButtonEditCampaign\"]")).Click();
                Thread.Sleep(2000);
                linha = sr.ReadLine();
            }
            sr.Close();
            Console.WriteLine("Concluido");

        }
    }
}
