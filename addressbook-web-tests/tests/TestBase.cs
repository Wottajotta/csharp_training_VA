using NUnit.Framework;
using System;
using System.Text;


namespace WebAddressbookTests
{
  
    public class TestBase
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int maxLength)
        {
            int length = rnd.Next(1, maxLength + 1);
            StringBuilder builder = new StringBuilder();

            string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            for (int i = 0; i < length; i++)
            {
                char c = chars[rnd.Next(chars.Length)];
                builder.Append(c);
            }

            return builder.ToString();
        }

        public static string GenerateRandomPhone()
        {
            int[] parts = new int[10];
            for (int i = 0; i < 10; i++)
            {
                parts[i] = rnd.Next(0, 10);
            }

            return $"+7 {parts[0]}{parts[1]}{parts[2]} {parts[3]}{parts[4]}{parts[5]}-{parts[6]}{parts[7]}-{parts[8]}{parts[9]}";
        }

        public static string GenerateRandomEmail(int maxNameLength = 10)
        {
            int length = rnd.Next(1, maxNameLength + 1);
            StringBuilder nameBuilder = new StringBuilder();

            string nameChars = "abcdefghijklmnopqrstuvwxyz0123456789";
            for (int i = 0; i < length; i++)
            {
                char c = nameChars[rnd.Next(nameChars.Length)];
                nameBuilder.Append(c);
            }

            string[] domains = { "example.com", "test.org", "mail.com", "mydomain.net", "gmail.com", "yahoo.com" };
            string domain = domains[rnd.Next(domains.Length)];

            return nameBuilder.ToString() + "@" + domain;
        }



    }
}
