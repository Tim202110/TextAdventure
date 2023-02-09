using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Zuul;

namespace Zuul
{
    public class Player
	{
        private int health;

        public Inventory inventory { get; }
	    public Room CurrentRoom { get; set; }
        public int Health
        {
            get { return health; }
        }

        public Player()
		{
			CurrentRoom = null;
			health = 100;
			// 25kg is pretty heavy to carry around all day.
			inventory = new Inventory(30);
		}

		public int Damage(int amount)
		{
			health -= amount;
			return health;
		}

		public int Heal(int amount)
		{
			health += amount;
			return health;
		}

		public bool IsAlive()
		{
			return health > 0;
		}

        public bool TakeFromChest(string itemName)
        {
			Item item = CurrentRoom.Chest.Get(itemName);
			if (item == null)
			{
                Console.WriteLine("There is no " + itemName + " in this room");
                return false;
            }

            if (inventory.Put(itemName, item))
            {
                Console.WriteLine("You've successfully picked up " + itemName);
                return true;
            }

            Console.WriteLine("You are unable to carry " + itemName);
            CurrentRoom.Chest.Put(itemName, item);
            return true;

        }
        public bool DropToChest(string itemName)
        {

            Item item = inventory.Get(itemName);
            if (item == null)
            {
                Console.WriteLine("You don't have " + itemName + ".");
                return false;
            }

            CurrentRoom.Chest.Put(itemName, item);
            Console.WriteLine("You've dropped " + itemName + ".");
            return true;

        }

		public string Use(string itemName)
		{
            string str = "";
            if (itemName == "Medkit")
            {
                Heal(50);
                str = "You have used medkit.\nYou healed 50 points.";
            }
            if (itemName == "Potion")
            {
                Damage(10);
                str = "You have used the suspicious Potion.\nYou got damaged! -10hp;";
            }
            if (itemName == "Axe")
            {
                str = "You have used your axe.\nSLASH!\n";
            }
            if (itemName == "Revolver")
            {
                str = "You have used your revolver.\nPEW!\n";
            }
            else
            {
                str = "You don't have this item";
            }
            return str;
		}
    }
}