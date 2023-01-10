using System;

namespace Zuul
{
    public class Player
	{
		private Inventory inventory;
		private int health;
	    public Room CurrentRoom { get; set; }
		public Player()
		{
			CurrentRoom = null;
			health = 100;
			// 25kg is pretty heavy to carry around all day.
			inventory = new Inventory(50);
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
            // remove the Item from the Room
            // put it in your inventory
            // inspect returned values
            // communicate to the user what's happening
            // return true/false for success/failure
            return false;
        }
        public bool DropToChest(string itemName)
        {
            // remove Item from your inventory.
            // Add the Item to the Room
            // inspect returned values
            // communicate to the user what's happening
            // return true/false for success/failure
            return false;
        }

		public string Use(string itemName)
		{
			//TODO implement
		}
    }
}