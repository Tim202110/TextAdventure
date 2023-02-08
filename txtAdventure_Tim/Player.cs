using System;
using System.Diagnostics.CodeAnalysis;

namespace Zuul
{
    public class Player
	{
		public Inventory inventory;
		private int health;
	    public Room CurrentRoom { get; set; }
		public Player()
		{
			CurrentRoom = null;
			health = 100;
			// 25kg is pretty heavy to carry around all day.
			inventory = new Inventory(25);
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

			if (CurrentRoom.Chest.Get(itemName) == null)
			{
				Console.WriteLine("There is no such item in this chest.");
				return false;
			}

			if (CurrentRoom.Chest.Get(itemName) != null)
			{
				Console.WriteLine("You grabbed the item.");
				inventory.Put(itemName, CurrentRoom.Chest.Get(itemName));
				return true;
			}

            // remove the Item from the Room
            // Is beng removed as you use the public method Get()

            // put it in your inventory
            // inventory.Put(itemName, CurrentRoom.Chest.Get(itemName)); I think this works.

            // inspect returned values
            // return false if the Get() method returns null and return true if it does not return null.

            // communicate to the user what's happening
            // at return false it'll say "There is no such item in this chest."
            // at return true it'll say "You grabbed the item."

            // return true/false for success/failure
            // returns true when the get() method does not return null.
            // returns false when the get() methoed does return null.

            return false;
        }
        public bool DropToChest(string itemName)
        {
            if (inventory.Get(itemName) == null)
			{
				Console.WriteLine("You don't have that item.");
				return false;
			}

			if (inventory.Get(itemName) != null)
			{
				Console.WriteLine("You dropped the item. You can take it again from the chest.");
				CurrentRoom.Chest.Put(itemName, inventory.Get(itemName));
				return true;
			}

            // remove Item from your inventory.
			// Is being removed as you use the method Get()

            // Add the Item to the Room
			// CurrentRoom.Chest.Put(itemName, inventory.Get(itemName)); I think this works.

            // inspect returned values
			// return false if the get value is null and true if it does not return null.

            // communicate to the user what's happening
			// when it returns false it'll say "You don't have that item."
			// When it returns true it'll say "you dropped the item. You can take it again from the chest."

            // return true/false for success/failure
			// returns true when the get() method does not return null.
			// returns false when the get() does return null.


            return false;
        }

		/*public string Use(string itemName)
		{
			//TODO implement
		}*/
    }
}