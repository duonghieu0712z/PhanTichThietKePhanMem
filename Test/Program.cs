using BusinessLayer.Functions;
using System;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HRFunctions hrFunctions = HRFunctions.Instance;
            foreach (var item in hrFunctions.SelectAllRoute())
            {
                Console.WriteLine($"{item.RouteID} ${item.RouteName}");
            }
        }
    }
}
