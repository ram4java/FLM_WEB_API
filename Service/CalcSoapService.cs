using ServiceReference;
using System.ServiceModel;

namespace FLM_WEB_API.Service
{
    public class CalcSoapService
    {
        public async Task<string> Calculate(int a, int b)
        {
            var binding = new BasicHttpBinding();
            var endpoint = new EndpointAddress(new Uri("http://www.dneonline.com/calculator.asmx"));
            var channelFactory = new ChannelFactory<CalculatorSoap>(binding, endpoint);
            var wsClient = channelFactory.CreateChannel();

            string resultStr = "";
            int result=0;
           
            result = await wsClient.AddAsync(a, b);
            resultStr += "Addition: " + result + "\n";

            result = await wsClient.SubtractAsync(a, b);
            resultStr += "Subtraction: " + result + "\n";

            result = await wsClient.MultiplyAsync(a, b);
            resultStr += "Multiplication: " + result + "\n";

            result = await wsClient.DivideAsync(a, b);
            resultStr += "Division: " + result + "\n";

            
            channelFactory.Close();

            Console.WriteLine(resultStr);
            return resultStr;
        }
    }
}
