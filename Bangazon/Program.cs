using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bangazon
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("*********************************************************");
            sb.AppendLine("* *Welcome to Bangazon!Command Line Ordering System * *");
            sb.AppendLine("*********************************************************");
            sb.AppendLine("1.Create an account");
            sb.AppendLine("2.Create a payment option");
            sb.AppendLine("3.Order a product");
            sb.AppendLine("4.Complete an order");
            sb.AppendLine("5.See product popularity");
            sb.AppendLine("6.Leave Bangazon!");
            sb.AppendLine(">");
            Console.WriteLine(sb.ToString());

            Console.ReadLine();
        }
    }
}
