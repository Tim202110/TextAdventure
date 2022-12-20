using System;

namespace Zuul
{
    public class Player
	{
		private int health;
	    public Room CurrentRoom { get; set; }
		public Player()
		{
			CurrentRoom = null;
			health = 100;
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