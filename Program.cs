 using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using Newtonsoft.Json;

namespace SeleniumTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //System.setProperty("webdriver.chrome.driver", "/Users/test/Desktop/Configs/chromedriver");

            WebDriver driver  = new ChromeDriver();
            using (StreamReader file = File.OpenText(@"www.youtube.com.cookies.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                var cooks = (List<Dictionary<string, object>>)serializer.Deserialize(file, typeof(List<Dictionary<string, object>>));
                driver.Navigate().GoToUrl("https://youtube.com/");

                foreach (var cook in cooks)
                {
                    driver.Manage().Cookies.AddCookie(Cookie.FromDictionary(cook));
                }



            }
            driver.Navigate().GoToUrl("https://youtube.com/channel/UC_jek2isBclB31pL9QjTcIw/about");
            var report = driver.FindElement(By.Id("button"));
            report.Click();

            Thread.Sleep(50000);
            driver.Quit();
        }

    }
    }