using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Project
{
	public class Character : INotifyPropertyChanged
	{
		private string name;
		private string characterClass;
		private int levelOfCompetence;
		private int experiencePoints;
		private int willToLive;
		private int money;

		public string Name
		{
			get { return name; }
			set
			{
				name = value;
				OnPropertyChanged("Name");
			}
		}
		public string CharacterClass
		{
			get { return characterClass; }
			set
			{
				characterClass = value;
				OnPropertyChanged("CharacterClass");
			}
		}
		public int LevelOfCompetence
		{
			get { return levelOfCompetence; }
			set
			{
				levelOfCompetence = value;
				OnPropertyChanged("LevelOfCompetence");
			}
		}
		public int ExperiencePoints
		{
			get { return experiencePoints; }
			set
			{
				experiencePoints = value;
				OnPropertyChanged("ExperiencePoints");
			}
		}
		public int WillToLive
		{
			get { return willToLive; }
			set
			{
				willToLive = value;
				OnPropertyChanged("WillToLive");
			}
		}
		public int Money
		{
			get { return money; }
			set
			{
				money = value;
				OnPropertyChanged("Money");
			}
		}
		
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
