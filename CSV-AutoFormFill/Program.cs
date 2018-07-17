using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace CSV_AutoFormFill
{
    class Program
    {
        static void Main(string[] args)
        {
            //IWebDriver driver;
            //driver = new ChromeDriver();
            //driver.Navigate().GoToUrl("https://www.activepdf.com/products/ocr/download?hsCtaTracking=e71ff45f-425f-43cd-a196-e20f6fe59774%7C2acbcf88-0cf5-44e5-a98c-e4e8dfd58457");

            string[] tfSelectors = { "[name*='firstname']", "[name*='lastname']", "name*='email'", "[name*='phone']"};

            ReadCSV_GetValues();

            //iterate of numbersArr and send the values of each index into the formfield

        }



        //Reads the CSV file and then returns an array of values
        public static string[][] ReadCSV_GetValues()
        {
            StreamReader sr = new StreamReader(File.OpenRead(Directory.GetCurrentDirectory() + @"\fields.csv"));
            List<string[]> profilesList = new List<string[]>();
            string line;
            while( (line = sr.ReadLine()) != null)
            {
                line.Replace(" ", "");
                string[] profile = (line.Split(','));
                profilesList.Add(profile);
            }
            string[][] profilesArr = profilesList.ToArray();

            return profilesArr;

        }

        //Scrolls into whatever page you're looking for.
        //Without this method, looking for a sidebar page thumbnail
        //that is hidden from view will bug and crash.
        public static void Scroll(IWebDriver driver, IWebElement selector)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

            js.ExecuteScript("arguments[0].scrollIntoView();", selector);
        }

    }
}