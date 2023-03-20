using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chromium;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.VirtualAuth;
using OpenQA.Selenium.DevTools.V110.Page;
using System.Threading;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;
using System.Threading;

namespace vk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void vk()
        {
            IWebDriver driver;

            driver = new ChromeDriver(textBox2.Text); //C:\\3dparty\\chrome
            driver.Navigate().GoToUrl(textBox1.Text);
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            int jojo = 150;

            string scrollscript = textBox3.Text + jojo.ToString(); //vk1.a.e9U7C5vQWT34v0moC716oSO6gYAufOqjUHgbYMlnwEu-VSWC7pqVbMdWdGpJ3BgcDy3s8nn9Z3jcUkf5-aFNtW97KT0NLHRyM4SekZ5wfVndFV2dtNFFr98zOhmBGeOoVry3sB554ft8OSnknccrk8_XwMo4kKRvlPEl_wH4bUiKTKLQgar4LbqZJb-z7IFWFRiUGiMnqPc7WVwRFnFVeA
            scrollscript.Insert(19, textBox3.Text);
            js.ExecuteScript(textBox3.Text); //window.scrollBy(0,9500);
            var api = new VkApi();
            //String[] allText = new String[all.Count];

            api.Authorize(new ApiAuthParams
            {
                AccessToken = textBox4.Text
            });

            IList<IWebElement> all = driver.FindElements(By.XPath("//a[@class='PostHeaderSubtitle__item']"));
            Thread.Sleep(5000);
            String[] allText = new String[all.Count];
            foreach (IWebElement element in all)
            {

                // count == 8 

                //.Write(element.GetAttribute("href"));
                Console.Write("\n");
                //js.ExecuteScript("window.scrollBy(0,1500);");
                var rnd = new Random();
                try
                {
                    api.Messages.Send(new VkNet.Model.RequestParams.MessagesSendParams
                    {
                        RandomId = rnd.Next(),// рандомный id, 
                        UserId = Int32.Parse(element.GetAttribute("href").ToString().Substring(17)), // володя это твой id
                        Message = "привет",
                    });
                    Thread.Sleep(2500);

                }
                catch (VkNet.Exception.CannotSendDuePrivacyException e)
                {
                    continue;
                }
                catch (VkNet.Exception.PermissionToPerformThisActionException e)
                {
                    continue;
                }
                Thread.Sleep(200);



                //allText = allText.Where(w => w != allText[2]).ToArray();




                //delete alltext
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            vk();
        }
    }
}
