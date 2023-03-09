using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XDocument x = XDocument.Load("File.xml");
            XElement e = x.Root;

            e.Add(new XElement("phone",
                new XAttribute("name", "13pro max"),
                new XElement("creator", "Iphone"),
                new XElement("price", "50000"),
                new XElement("date", "2021")));
            x.Save("File.xml");

            var search = x.Element("phone")?
                .Elements("phone")?
                .FirstOrDefault(p => p.Attribute("name")?.Value == "13pro max");
            var name_s = search?.Attribute("name")?.Value;
            var company_s = search?.Element("creator")?.Value;
            var price_s = search?.Element("price")?.Value;
            var date_s = search?.Element("date")?.Value;
            Console.WriteLine($"Name: {name_s}  Creator: {company_s}  Price: {price_s}  Date: {date_s}");

            var tom = x.Element("phone")?
                .Elements("phone")
                .FirstOrDefault(p => p.Attribute("name")?.Value == "13pro max");

            if (tom != null)
            {
                var name_e = tom.Attribute("name");
                if (name_e != null) name_e.Value = "Nokia S50";
                var company_e = tom.Element("creator");
                if (company_e != null) company_e.Value = "Nokia";
                var price_e = tom.Element("price");
                if (company_e != null) company_e.Value = "10000";
                var date_e = tom.Element("date");
                if (company_e != null) company_e.Value = "2001";
                x.Save("File.xml");
            }
            var name_sh = search?.Attribute("name")?.Value;
            var company_sh = search?.Element("creator")?.Value;
            var price_sh = search?.Element("price")?.Value;
            var date_sh = search?.Element("date")?.Value;
            Console.WriteLine($"Name: {name_sh}  Creator: {company_sh}  Price: {price_sh}  Date: {date_sh}");

            if (e != null)
            {
                var bob = e.Elements("phone")
                    .FirstOrDefault(p => p.Attribute("name")?.Value == "13pro max");
                if (bob != null)
                {
                    bob.Remove();
                    x.Save("File.xml");
                }
            }
        }
    }
}