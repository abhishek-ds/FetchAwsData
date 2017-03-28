using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FetchAWSData
{
    class Program
    {
        static void Main()
        {
            List<string> awsUrl = new List<string>();

            using (var reader = new StreamReader(@"C:\Users\Abhishek\Desktop\test.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    awsUrl.Add(line);
                }
            }
            string[] urlArray = awsUrl.ToArray();
 
            Console.WriteLine(urlArray[2]);
            Console.ReadKey();
        }
    }
}
