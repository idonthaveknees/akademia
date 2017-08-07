using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    class Game
    {
        public Character Player { get; set; }
		public Mission Quest { get; set; }

        public Game()
        {
            Player = new Character
            {
                Name = Console.ReadLine(),
                CharacterClass = "Gałgan",
                LevelOfCompetence = 1,
                ExperiencePoints = 0,
                WillToLive = 100,
                Money = 50
            };

			Quest = new Mission
			{
				Name = "Stwórz projekt na Akademię C#",
				Description = $"Pomysł, pomysł... wymyśl coś błyskotliwego, coś skomplikowanego, ale prostego do zrobienia..." +
							  $"{Environment.NewLine}Albo wal wszystko i stwórz meta gierkę o robieniu projektu na Akademię.",
				LevelOfCompletion = 0
			};
		}
	}
}
