using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;


namespace Zuul
{
    public class Inventory
    {
        public Item item;

        private int MaxWeight;
        private Dictionary<string, Item> items;
        public Inventory(int maxWeight)
        {
            this.MaxWeight = maxWeight;
            this.items = new Dictionary<string, Item> ();
        }
        public bool Put(string itemName, Item item)
        {
            // check if your inventory has enough space for the item to be added.
            if (TotalWeight() + item.Weight > MaxWeight)
            {
                // return true for success
                return false;
            }

            // put Item in the items Collection
            items.Add(itemName, item);

            // return false for failure
            return true;
        }
        public Item Get(string itemName)
        {
            if (items.ContainsKey(itemName))
            {
                // find Item in items Collection
                Item item = items[itemName];

                // remove Item from items Collection if found
                items.Remove(itemName);

                // return Item
                return item;
            }
            return null;
        }

        private int TotalWeight()
        {
            //total starts at 0
            int total = 0;

            //foreach to see how much weight you carry in your inventory.
            foreach(string itemName in items.Keys)
            {
                total = total + items[itemName].Weight;
            }
            return total;
        }

        public string Show()
        {
            string str = "";
            if (!IsEmpty())
            {
                foreach (string itemName in items.Keys)
                {
                    Item item = items[itemName];
                    str += " - " + itemName + ": " + item.Description + " (" + item.Weight + "kg)\n";
                }
            }
            return str;
        }

        public bool IsEmpty()
        {
            return items.Count == 0;
        }
    }
}
