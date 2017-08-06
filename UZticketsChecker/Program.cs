using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace UZticketsChecker
{
    class Program
    {
        private static string noPlacesMessage = "No places in this direction";
        private static string serviceMessage = "Service is temporarily unavailable";
        private static string gmail;
        private static string password;
        
        static void Main(string[] args)
        {
            IRestResponse response;

            Console.WriteLine("Gmail should allow to use an account in the application. " +
                              "Details: https://myaccount.google.com/u/2/lesssecureapps?rfn=27&rfnc=1&eid=-2507763922428972190&et=0&asae=2&pli=1");
            
            Console.WriteLine("Enter your google email:");
            gmail = Console.ReadLine();
            Console.WriteLine("Enter your google password:");
            password = Console.ReadLine();
           
            while (true)
            {
                response = new RestApiClient().GetResponse();

                if (response.Content.Contains(noPlacesMessage) | response.Content.Contains(serviceMessage) )
                {
                    Console.WriteLine("||: " + noPlacesMessage + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second);

                }
                else
                {
                    Console.WriteLine("||: " + response.Content);
                    Mailer.SendEmail(gmail, password, response.Content + " " + DateTime.Now.Hour + ":" + DateTime.Now.Minute);
                }

                Thread.Sleep(10000);
            }
        }
    }
}
