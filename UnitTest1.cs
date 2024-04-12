using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

class Program
{
    private static object? ExpectedConditions;

    static void Main(string[] args)
    {
    
        string GenerateUniqueUsername()
        {
       
            return "user" + DateTime.Now.Ticks.ToString();
        }

  
        using (var driver = new ChromeDriver())
        {
          
            driver.Navigate().GoToUrl("http://www.way2automation.com/angularjs-protractor/webtables/");

         
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            try
            {
                object value = wait.Until(ExpectedConditions.ElementExists(By.Id("title")));
                Console.WriteLine("User List Table is displayed.");
            }
            catch
            {
                Console.WriteLine("User List Table is not displayed.");
                return;
            }

         
            IWebElement addUserButton = driver.FindElement(By.XPath("//button[text()='Add User']"));
            addUserButton.Click();

            string username = GenerateUniqueUsername();
            IWebElement usernameInput = driver.FindElement(By.Name("FirstName"));
            usernameInput.SendKeys(username);

            IWebElement submitButton = driver.FindElement(By.XPath("//button[text()='Save']"));
            submitButton.Click();

           
            try
            {
                IWebElement element = wait.Until(ExpectedConditions.ElementExists(By.Id("title")));

                // Check if the element is not null to ensure it exists
                if (element != null)
                {
                    Console.WriteLine("User List Table is displayed.");
                }
                else
                {
                    Console.WriteLine("User List Table is not displayed.");
            catch
            {
                Console.WriteLine($"Failed to add user '{username}' to the User List Table.");
            }
        }
    }
}
