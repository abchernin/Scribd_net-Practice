using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scribd.Net;

namespace ScribdTester
{
    class Program
    {
        private static string api = "4bi2w0zz3jo9zvg3dd4e8";
        private static string pubid = "pub-18462777553040191112";
        private static string secret = "sec-binf9hkrjs1mxdh07l38xxfpmx";

        static void Main(string[] args)
        {
            SetupEnv();
            Program.Login("abchernin", "ii20qrn8");
        }

        private static void SetupEnv()
        {
            Service.APIKey = api;
            Service.SecretKey = secret;
            Service.PublisherID = pubid;
            Service.EnforceSigning = true;
        }
        private static void Login(string name, string pass)
        {
            User.LoggedIn += new EventHandler<UserEventArgs>(User_LoggedIn);

            bool signed = User.Login(name, pass);
        }

        static void User_LoggedIn(object sender, UserEventArgs e)
        {
            User user = sender as User;
            string info = 
                String.Format("Succesfully logged in as {0} using:\n{1}\t as API key;\n{2}\t as secret key;\n{3}\t as publisher key."
                , user.UserName, Service.APIKey, Service.SecretKey, Service.PublisherID);

            Console.WriteLine(info);
        }
    }
}
