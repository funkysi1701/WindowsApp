using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using StarTrek.DataLayer;

namespace StarTrekConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //read("C:\\Projects\\WindowsApp\\StarTrek\\enmemoryalpha_pages_current.xml");
            List<MemoryAlpha> ArticlesFromDB = MemoryAlpha.GetAll();
            MemoryAlpha firstArticle = ArticlesFromDB[10];

            Console.WriteLine("The Total is " + firstArticle.Name);


            Console.ReadKey();
        }

        public static void read(string filename)
        {
            XDocument doc = XDocument.Load(filename);

            foreach (XElement el in doc.Root.Elements())
            {
                Console.WriteLine("{0} {1}", el.Name, el.Attribute("id").Value);
                Console.WriteLine("  Attributes:");
                foreach (XAttribute attr in el.Attributes())
                {
                    Console.WriteLine("    {0}", attr);
                }
                
                Console.WriteLine("  Elements:");

                foreach (XElement element in el.Elements())
                {
                    Console.WriteLine("    {0}: {1}", element.Name, element.Value);
                }
                 
            }
        }
    }
}
