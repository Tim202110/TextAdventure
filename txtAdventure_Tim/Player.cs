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
	}
}