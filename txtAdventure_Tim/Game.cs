using System;
using System.Reflection.Metadata.Ecma335;

namespace Zuul
{
	public class Game
	{
		private Parser parser;
		private Player player;
		private Room room;
		private Inventory inventory;
		public Game()
		{
			parser = new Parser();
			player = new Player();
			CreateRooms();
		}

		private void CreateRooms()
		{
			// create the rooms
			Room outside = new Room("outside the main entrance of the university");
			Room theatre = new Room("in a lecture theatre");
			Room pub = new Room("in the campus pub");
			Room lab = new Room("in a computing lab");
			Room office = new Room("in the computing admin office");
			Room storage = new Room("in the storage room");

			// initialise room exits
			outside.AddExit("east", theatre);
			outside.AddExit("south", lab);
			outside.AddExit("west", pub);

			theatre.AddExit("west", outside);

			pub.AddExit("east", outside);

			lab.AddExit("north", outside);
			lab.AddExit("east", office);
			lab.AddExit("south", storage);

			office.AddExit("west", lab);
			
			storage.AddExit("north", lab);

			player.CurrentRoom = outside;  // start game outside

			outside.Chest.Put("Axe", new Item(20, "An sharp axe"));
			theatre.Chest.Put("Potion", new Item(5, "A healing Potion"));
			pub.Chest.Put("Revolver", new Item(20, "A cowboy revolver."));
			storage.Chest.Put("Medkit", new Item(5, "A medkit to heal your wounds."));
		}

		/**
		 *  Main play routine.  Loops until end of play.
		 */
		public void Play()
		{
			PrintWelcome();

			// Enter the main command loop.  Here we repeatedly read commands and
			// execute them until the player wants to quit.
			bool finished = false;
			while (!finished)
			{
				if (!player.IsAlive())
				{
					Console.WriteLine("\nYou died.\n");
					finished = true;
					continue;
                }
                Command command = parser.GetCommand();
                finished = ProcessCommand(command);

            }
			Console.WriteLine("Thank you for playing.");
		}

		/**
		 * Print out the opening message for the player.
		 */
		private void PrintWelcome()
		{
			Console.WriteLine();
			Console.WriteLine("Welcome to Zuul!");
			Console.WriteLine("Zuul is a new, incredibly boring adventure game.");
			Console.WriteLine("Type 'help' if you need help.");
			Console.WriteLine();
			Console.WriteLine("\n" + player.CurrentRoom.GetLongDescription() + "\n");
        }

		/**
		 * Given a command, process (that is: execute) the command.
		 * If this command ends the game, true is returned, otherwise false is
		 * returned.
		 */
		private bool ProcessCommand(Command command)
		{
			bool wantToQuit = false;

			if(command.IsUnknown())
			{
				Console.WriteLine("I don't know what you mean...");
				return false;
			}

			string commandWord = command.GetCommandWord();
			switch (commandWord)
			{
				case "help":
					PrintHelp();
					break;
				case "go":
					GoRoom(command);
					break;
				case "quit":
					wantToQuit = true;
					break;
				case "inventory":
					Console.WriteLine("Items in your inventory:\n" + player.inventory.Show());
					break;
				case "look":
					Console.WriteLine(player.CurrentRoom.GetLongDescription() + "\n");
					break;
				case "take":
					take(command);
					break;
				case "drop":
					Drop(command);
					break;
				case "use":
					Use(command);
					break;
            }

			return wantToQuit;
		}

		// implementations of user commands:

		/**
		 * Print out some help information.
		 * Here we print the mission and a list of the command words.
		 */
		private void PrintHelp()
		{
			Console.WriteLine("You are lost. You are alone.");
			Console.WriteLine("You wander around at the university.");
			Console.WriteLine();
			// let the parser print the commands
			parser.PrintValidCommands();
		}

		/**
		 * Try to go to one direction. If there is an exit, enter the new
		 * room, otherwise print an error message.
		 */
		private void GoRoom(Command command)
		{
			if(!command.HasSecondWord())
			{
				// if there is no second word, we don't know where to go...
				Console.WriteLine("Go where?");
				return;
			}

			string direction = command.GetSecondWord();

			// Try to go to the next room.
			Room nextRoom = player.CurrentRoom.GetExit(direction);

			if (nextRoom == null)
			{
				Console.WriteLine("There is no door to "+direction+"!");
			}
			else
			{
				player.CurrentRoom = nextRoom;
				player.Damage(5);
				Console.WriteLine("\n");
                Console.WriteLine(player.CurrentRoom.GetLongDescription() + "\n");
				Console.WriteLine("Your current health: " + player.Health + "\n");
            }
		}

		private void take(Command command)
		{
			if(!command.HasSecondWord())
			{
				Console.WriteLine("Take what?");
				return;
			}
            string ItemNamed = command.GetSecondWord();
			player.TakeFromChest(ItemNamed);
        }
		
		private void Drop(Command command)
		{
            if (!command.HasSecondWord())
            {
                Console.WriteLine("Drop what?");
                return;
            }

			string ItemNamed = command.GetSecondWord();
			player.DropToChest(ItemNamed);
			
        }

		private void Use(Command command)
		{
			if (!command.HasSecondWord())
			{
				Console.WriteLine("Use what?");
				return;
			}

			string itemNamed = command.GetSecondWord();
			player.Use(itemNamed);
		}
	}
}
