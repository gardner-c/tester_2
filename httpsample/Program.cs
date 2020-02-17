using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace httpsample
{


   public class Program
    {

        private const string URL = "https://takehome.io/facebook";


        static void Main(string[] args)
        {
          

        }

        public Boolean ProcessRequest()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(URL).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<Faceboook_ID>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                foreach (var d in dataObjects)
                {
                    Console.WriteLine("{0}", d.name);
                }

                return true;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
                client.Dispose();
                return false;
            }

            //Make any other calls using HttpClient here.

            //Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
        }

        public class Faceboook_ID
        {
            public string Id { get; set; }
            public string name { get; set; }
            public string status { get; set; }

        }
    }
}
