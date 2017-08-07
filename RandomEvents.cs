using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
	// this class has never been used... unfortunately
	//					[*] [*] [*]

	public class RandomEvents
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get;  set; }
		public int NeededLevelOfCompetence { get; set; }
		public int NeededMoney { get; set; }
		public int ExperiencePrize { get; set; }
		public int WillToLivePrize { get; set; }

		public RandomEvents(int id, string name, string description, int neededLevelOfCompetence, int neededMoney, int experiencePrize, int willToLivePrize)
		{
			ID = id;
			Name = name;
			Description = description;
			NeededLevelOfCompetence = neededLevelOfCompetence;
			NeededMoney = neededMoney;
			ExperiencePrize = experiencePrize;
			WillToLivePrize = willToLivePrize;
		}

		private static List<RandomEvents> randomevents;

		public RandomEvents()
		{
			randomevents = new List<RandomEvents>
			{
				new RandomEvents(1, "Wyjście do Jumpcity", "", 1, 30, 20, 20),
				new RandomEvents(2, "Konferencja", "", 10, 0, 50, 20),
				new RandomEvents(3, "Parapetówka Hackerspace", "", 5, 0, 40, 30),
				new RandomEvents(4, "Wyjście do teatru", "", 1, 60, 30, 40),
				new RandomEvents(5, "Wyjście na ASG", "", 1, 50, 30, 30),
				new RandomEvents(6, "Hackaton", "", 5, 0, 60, 30),
				new RandomEvents(7, "Odwołane zajęcia", "", 1, 1, 1, 1)
			};
		}
	}
}
