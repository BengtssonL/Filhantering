using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;



namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class2 = new Class1();
           // class2.Run();

            GetEmails webb2 = new GetEmails();
            webb2.RetrieveEmails("https://liu.se/forskning/kontakt");
        }
    }
}
