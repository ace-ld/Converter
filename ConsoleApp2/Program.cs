using System;
using System.Collections.Generic;
using System.Net;
using System.Xml.Linq;

namespace ConsoleApp2
{
    class Program
    {
        private static readonly Dictionary<string, decimal> rate = new Dictionary<string, decimal>();
        private static decimal singleRate;

        static void Main(string[] args)
        {
            Console.Write("Введите сумму: ");
            var number = decimal.Parse(Console.ReadLine());
            Console.Write("Введите валюту: ");
            var val = Console.ReadLine();

            WebClient client = new WebClient();

            var xml = client.DownloadString("http://www.cbr.ru/scripts/XML_daily.asp");
            XDocument xdoc = XDocument.Parse(xml);

            var el = xdoc.Element("ValCurs").Elements("Valute");

            foreach (var i in el)
            {
                rate.Add(i.Element("CharCode").Value, 100 / decimal.Parse(i.Element("Value").Value));
            }

            foreach (var i in rate)
                if (val == i.Key) singleRate = number * i.Value;

            foreach (var i in rate)
                if (val != i.Key) Console.WriteLine($"{i.Key} - {(number * number * i.Value) / singleRate}");
        }
    }
}