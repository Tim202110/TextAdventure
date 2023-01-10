using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Zuul
{
    public class Inventory
    {
        private int maxWeight;
        private Dictionary<string, Item> items;
        public Inventory(int maxWeight)
        {
            this.maxWeight = maxWeight;
            this.items = new Dictionary<string, Item> ();
        }
        public bool Put(string itemName, Item item)
        {
            // check the Weight of the Item!
            // put Item in the items Collection
            // return true/false for success/failure
            if (TotalWeight() + item.Weight > maxWeight)
            {
                items.Add(itemName, item);
                return false;
            }
            return true;
        }
        public Item Get(string itemName)
        {
            // find Item in items Collection
            // remove Item from items Collection if found
            // return Item
            if(items.ContainsKey(itemName))
            {
                Item item = items[itemName];
                items.Remove(itemName);
                return item;
            }
            return null;
        }

        private int TotalWeight()
        {
            int total = 0;
            foreach(string itemName in items.Keys)
            {
                total = maxWeight + items(itemName);
            }
            return total;
        }
    }
}
