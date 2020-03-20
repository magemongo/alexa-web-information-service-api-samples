using System;
using System.Net.Http;
using System.Threading.Tasks;
using Aws4RequestSigner;
using System.Web;
using System.Linq;

namespace dotnet_core_awis
{
    class Program
    {
        static private async Task api(string[] args)
        {
            var signer = new AWS4RequestSigner(args[0], args[1]);
				    var request = new HttpRequestMessage {
        		Method = HttpMethod.Get,
				        RequestUri = new Uri("https://awis.us-west-1.amazonaws.com/api?Action=urlInfo&ResponseGroup=Rank&Url="+args[2])
				    };

			    request = await signer.Sign(request, "awis", "us-west-1");

			    var client = new HttpClient();
			    var response = await client.SendAsync(request);

			    var responseStr = await response.Content.ReadAsStringAsync(); 
          Console.WriteLine(responseStr);
        }

        static void Main(string[] args)
        {
          try{
            api(args).Wait();
          }catch(Exception ex){
            Console.WriteLine(ex);
          }
        }
    }
}
