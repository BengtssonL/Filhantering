using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;


namespace ConsoleApp1
{
    public class GetEmails
    {

        //metod 
        public void RetrieveEmails(string webPage)
        {
            GetAllEmails(RetrieveContent(webPage));
        }

        //get the content of the web page passed in 
        private string RetrieveContent(string webPage)
        {
            HttpWebResponse response = null;//used to get response 

            StreamReader respStream = null;//used to read response into string 
            try
            {
                //gör en request som skickas till sidan  
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(webPage);
                request.Timeout = 10000;

                //får ett svar  
                response = (HttpWebResponse)request.GetResponse();

                //Streamreadern läser av responsen  
                respStream = new StreamReader(response.GetResponseStream());

                //returnar responsen som en string 
                return respStream.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                response.Close();
                respStream.Close();
            }
        }


        //letar efter alla länkar på sidan. 
        private void GetAllEmails(string content)
        {
            //regular expression 
            string pattern = @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@" + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\." + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|" + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})";

            //Set up regex object 
            Regex RegExpr = new Regex(pattern, RegexOptions.IgnoreCase);

            //get the first match 
            Match match = RegExpr.Match(content);


            //loop through matches 
            while (match.Success)
            {


                //skriver in mail addresserna i en txt fil 
                Console.WriteLine("href match: " + match.Groups[0].Value);
                WriteToLog("C:\\Users\\bengtsson.lucas\\filercs\\Filer\\matchlog.txt", "Email match: " + match.Groups[0].Value + Environment.NewLine);


                match = match.NextMatch();
            }

        }


        private void WriteToLog(string file, string message)
        {
            using (StreamWriter w = File.AppendText(file))
            {
                w.WriteLine(DateTime.Now.ToString() + ": " + message); w.Close();
            }
        }
    }


}

