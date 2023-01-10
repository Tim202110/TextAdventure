using System;
using System.Collections.Generic;

namespace Zuul
{
	class Programs
	{
		static void Main(string[] args)
		{
			// Documentation: https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-6.0

			Dictionary<string, Item> itemDictionary = new Dictionary<string, Item>();

			itemDictionary.Add("hammer", new Item(15, "A heavy hammer"));
			itemDictionary.Add("axe", new Item(10, "A sharp axe"));
			itemDictionary.Add("potion", new Item(2, "A bottle labeled 'drink me'"));
			itemDictionary.Add("medkit", new Item(4, "A medkit"));

            // Voeg een Item toe (Add) met de Key "pill" en description "A bitter pill to swallow"
            itemDictionary.Add("Pill", new Item(2,"A better pill to swallow"));

			// Verwijder (Remove) de entry "medkit" uit de dictionary
			itemDictionary.Remove("medkit");

            // Bewijs met behulp van code dat er een entry is met de Key "potion". Laat de description zien van dat Item.
            if (itemDictionary.ContainsKey("potion"))
            {
                Console.WriteLine(itemDictionary["potion"].Description + "\n");
            }

            // Is er een Item "nailgun"? Zo ja, wat is de description? Zo nee, zeg beleefd dat je het Item niet kunt vinden.
            if (itemDictionary.ContainsKey("nailgun"))
			{
				Console.WriteLine(itemDictionary["nailgun"].Description);
			}
			else
			{
				Console.WriteLine("nailgun bestaat niet. \n\n");
			}


			// Laat zien hoeveel Items de itemDictionary bevat (gebruik Count)
			Console.WriteLine(itemDictionary.Count);

            // Console.WriteLine alle items. Laat zowel de Key zien, als de description van elk Item (Value).
			foreach (KeyValuePair<string, Item> item in itemDictionary)
			{
				Console.WriteLine("Key = {0}, Description = {1}", item.Key, item.Value.Description + "\n");
			}


			// Maak de volledige Dictionary leeg (Clear)
			itemDictionary.Clear();


			// Laat nogmaals zien hoeveel Items de itemDictionary bevat (gebruik Count)
			Console.WriteLine("\n" + itemDictionary.Count);


        }
	}
}
