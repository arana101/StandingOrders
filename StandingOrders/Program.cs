using StandingOrders.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace StandingOrders
{
    public class Program
    {
        static void Main(string[] args)
        {
            string xmlPath;

            string screensPath = Helper.SCREEN_SHOT_PATH;

            if (args.Count().Equals(0))
            {
                xmlPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\file.xml";
            }
            else
            {
                xmlPath = args[0];
            }

            Data data = null;

            XmlSerializer serializer = new XmlSerializer(typeof(Data));

            using (StreamReader reader = new StreamReader(xmlPath))
            {
                data = (Data)serializer.Deserialize(reader);
            }

            for (int i = 0; i < data.Scheduler.Count(); i++)
            {
                var methods = new Methods(Helper.BrowserTypes.Chrome);

                try
                {
                    methods.Initialize(data.URL, data.Scheduler[i].LoginInfo[0]);
                }
                catch (Exception ex)
                {
                    Driver.SaveScreenshot(screensPath);
                    Console.WriteLine($"{DateTime.Now}  -  Unable to login/navigate to trip scheduler. " +
                        $"Exception message {ex.Message}. \n Please, see the screenshot with error");
                    break;
                }

                try
                {
                    methods.FillStep1(data.Scheduler[i].Caller[0]);
                }
                catch (Exception ex)
                {
                    Driver.SaveScreenshot(screensPath);
                    Console.WriteLine($"{DateTime.Now}  -  Unable to fill step1 or go to step2. " +
                        $"Exception message {ex.Message}. \n Please, see the screenshot with error");
                    break;
                }

                try
                {
                    methods.FillStep2(data.Scheduler[i].Member[0].MemberId);
                }
                catch (Exception ex)
                {
                    Driver.SaveScreenshot(screensPath);
                    Console.WriteLine($"{DateTime.Now}  -  Unable to fill step2 or go to step3. " +
                        $"Exception message {ex.Message}. \n Please, see the screenshot with error");
                    break;
                }

                try
                {
                    methods.FillStep3();
                }
                catch (Exception ex)
                {
                    Driver.SaveScreenshot(screensPath);
                    Console.WriteLine($"{DateTime.Now}  -  Unable to go to step4. " +
                        $"Exception message {ex.Message}. \n Please, see the screenshot with error");
                    break;
                }

                try
                {
                    methods.FillStep4(data.Scheduler[i].AppointmentInfo[0]);
                }
                catch (Exception ex)
                {
                    Driver.SaveScreenshot(screensPath);
                    Console.WriteLine($"{DateTime.Now}  -  Unable to fill step4. " +
                        $"Exception message {ex.Message}. \n Please, see the screenshot with error");
                    break;
                }

                try
                {
                    methods.RoundTripRecurring(data.Scheduler[i].AppointmentInfo[0]);
                }
                catch (Exception ex)
                {
                    Driver.SaveScreenshot(screensPath);
                    Console.WriteLine($"{DateTime.Now}  -  Unable to fill recurring trip info or confirm a recurring trip. " +
                        $"Exception message {ex.Message}. \n Please, see the screenshot with error");
                    break;
                }

                try
                {
                    methods.FillStep5(data.Scheduler[i].Provider[0]);
                }
                catch (Exception ex)
                {
                    Driver.SaveScreenshot(screensPath);
                    Console.WriteLine($"{DateTime.Now}  -  Unable to select provider. " +
                        $"Exception message {ex.Message}. \n Please, see the screenshot with error");
                    break;
                }

                try
                {
                    methods.FillStep6();
                }
                catch (Exception ex)
                {
                    Driver.SaveScreenshot(screensPath);
                    Console.WriteLine($"{DateTime.Now}  -  Unable to go to step7. " +
                        $"Exception message {ex.Message}. \n Please, see the screenshot with error");
                    break;
                }

                try
                {
                    methods.OpenManageTripsStep7();
                }
                catch (Exception ex)
                {
                    Driver.SaveScreenshot(screensPath);
                    Console.WriteLine($"{DateTime.Now}  -  Unable to open manage trips. " +
                        $"Exception message {ex.Message}. \n Please, see the screenshot with error");
                    break;
                }

                methods.ValidateRecurringTrip(methods.aptDate, data.Scheduler[i].Member[0].MemberId);

                try
                {
                    Directory.Delete(screensPath);
                }
                catch
                {

                }

                Driver.StopBrowser();
            }
        }
    }
}
