using System;
using SimpleStatisticsComsumer.ServiceReference1;

namespace SimpleStatisticsComsumer
{
    class Program
    {
        // Note that I made a service reference to the service's WSDL file
        static void Main()
        {
            string endpointName = "StatisticsSoap12"; // found in App.config
            using (StatisticsSoapClient client = new StatisticsSoapClient(endpointName))
            {
                double[] numbers = { 1.1, 2.2, 4.5 };
                double average, standardDeviation, skewness, kursosis;
                // This service uses out parameters to be able to send 5 results in a single request/response.
                // 5 = 4 out parameters + 1 ordinary result (return)
                // Alternatives to out parameters:
                // 1. Return an object with 5 properties
                // 2. Return an XML document with 5 elements
                double sum = client.GetStatistics(numbers, out average, out standardDeviation, out skewness, out kursosis);
                Console.WriteLine("sum \t" + sum);
                Console.WriteLine("average \t" + average);
                Console.WriteLine("standard deviation \t" + standardDeviation);
                Console.WriteLine("skewness \t" + skewness);
                Console.WriteLine("kurtosis \t" + kursosis);
            }
        }
    }
}
