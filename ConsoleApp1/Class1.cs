using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Class1
    {
        public void Run()
        {
            string path = @"C:\Users\bengtsson.lucas\filercs\Filer";

            Console.WriteLine("vad ska filen heta?");

            string namn = Console.ReadLine();

            Console.WriteLine("Vill du lägga till text eller skriva över en fil ifall den redan finns?");
            string ans  = Console.ReadLine();
            bool append = false;
            while(true)
            {
                if(ans == "y" || ans == "yes")
                {
                    append = true;
                    break;
                }
                else if(ans == "n" || ans == "no")
                {
                    append = false;
                    break;
                }
                else
                {
                    Console.WriteLine("vänligen skriv ja eller nej.");
                    break;
                }
            }


            string fullPath = path + "\\" + namn + ".txt";

            try
            {
               if(append == true)
                {
                    string text = "";
                    Console.WriteLine("vad vill du skriva? ");
                    text = Console.ReadLine();
                    using(StreamWriter sw = File.AppendText(fullPath))
                    {
                        sw.WriteLine(text);
                    }

                }
                else if(append == false )
                {
                    //gör filen eller overridar om den finns 
                    using (FileStream fs = File.Create(fullPath))
                    {

                        Console.WriteLine("Vad vill du skriva i filen?");
                        string text = Console.ReadLine();

                        byte[] info = new UTF8Encoding(true).GetBytes(text);
                        //add info
                        fs.Write(info, 0, info.Length);
                    }

                }
                //öppnar filen och läser den 
                using (StreamReader sr = File.OpenText(fullPath))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }


                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.ReadLine();
        }
    }
        
}
