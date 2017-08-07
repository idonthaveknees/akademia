using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Project
{
    class Mission : INotifyPropertyChanged
    {
		private int levelOfCompletion;

		public string Name { get; set; }
		public string Description { get; set; }
		public int LevelOfCompletion {
			get { return levelOfCompletion; }
			set
			{
				levelOfCompletion = value;
				OnPropertyChanged("LevelOfCompletion");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
