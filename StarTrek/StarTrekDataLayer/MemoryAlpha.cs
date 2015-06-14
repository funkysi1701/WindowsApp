using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarTrek.DataLayer.InfoTableAdapters;

namespace StarTrek.DataLayer
{
    public class MemoryAlpha
    {
        public MemoryAlpha()
        {
            Items = new List<MemoryAlpha>();
        }
        public List<MemoryAlpha> Items { get; set; }

        public string Name { get; set; }

        public static List<MemoryAlpha> GetAll()
        {
            MemoryAlphaTableAdapter taMemoryAlpha = new MemoryAlphaTableAdapter();
            
            var dtMemoryAlpha = taMemoryAlpha.GetData();
            List<MemoryAlpha> allItems = new List<MemoryAlpha>();
            foreach (Info.MemoryAlphaRow memoryAlphaRow in dtMemoryAlpha.Rows)
            {
                MemoryAlpha currentMemoryAlpha = new MemoryAlpha();
                
                currentMemoryAlpha.Name = memoryAlphaRow.Title;

                allItems.Add(currentMemoryAlpha);


            }
            return allItems;
        }
    }
}
