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
            // check if your inventory has enough space for the item to be added.
            if (TotalWeight() + item.Weight > maxWeight)
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
                total = maxWeight + items(itemName);
            }
            return total;
        }

        public void Show()
        {
            foreach(string itemName in items.Keys)
            {
                Console.WriteLine("item name: " + itemName + "\ndescription: " + items.description + "\nWeight: (" + items.weight + " kg)");
            }
        }
    }
}
