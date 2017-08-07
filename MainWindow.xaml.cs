using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Game game;															//I'd like to dedicate "Beautiful Mess" by Jason Mraz
		public MainWindow()													//To everyone who'll ever read this
		{																	//Not because of the lyrics (obviously)
			InitializeComponent();											//But because of the title
			game = new Game();												//'Coz "beautiful mess" is imo exactly what you're reading
			DataContext = game;

			PlayersName.KeyDown += new KeyEventHandler(ConfirmPlayersName);
		}
		private string NotEnoughStats = "Nie masz wystarczająco dużo... czegoś..." + Environment.NewLine + "Wymagane: ";

		//simplest levelling-up system in the history of simple WPF games B)

		private void LevelUp()
		{
			//the actual levelling-up system
			if (game.Player.ExperiencePoints >= 200)
			{
				game.Player.LevelOfCompetence++;
				game.Player.ExperiencePoints = 0;
				game.Player.Money = game.Player.Money + 20;
			}

			//classes changing every five levels

			if (game.Player.LevelOfCompetence < 5)
				game.Player.CharacterClass = "Gałgan";
			else if (game.Player.LevelOfCompetence < 10)
				game.Player.CharacterClass = "Aspirujący młodziak";
			else if (game.Player.LevelOfCompetence < 15)
				game.Player.CharacterClass = "Prowadzący";
			else
				game.Player.CharacterClass = "Programista B)";
		}

		//if I am completely honest, this is fairly unnecessary now, but at the same time I liked the feature(?) so I kept it
		//also, maybe it adds to "immersion" (as if there is any) 

		private void ConfirmPlayersName(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter)
			{
				PlayersName.IsReadOnly = true;
				PlayersName.Background = Brushes.LightGray;
			}
		}

		//map-buttons

		private void WETI_Click(object sender, RoutedEventArgs e)
		{
			WETIOptions1.Visibility = Visibility.Visible;
			WETIOptions2.Visibility = Visibility.Visible;
			WETIOptions3.Visibility = Visibility.Visible;
			WETIOptions4.Visibility = Visibility.Visible;
			WETIOptions5.Visibility = Visibility.Visible;
			WETIOptions6.Visibility = Visibility.Visible;
			HomeOptionsCollapse();
			PomarańczaOptionsCollapse();
			HackerspaceOptionsCollapse();
			PRLOptionsCollapse();
			AutsajderOptionsCollapse();
		}

		private void Home_Click(object sender, RoutedEventArgs e)
		{
			WETIOptionsCollapse();
			HomeOptions1.Visibility = Visibility.Visible;
			HomeOptions2.Visibility = Visibility.Visible;
			HomeOptions3.Visibility = Visibility.Visible;
			PomarańczaOptionsCollapse();
			HackerspaceOptionsCollapse();
			PRLOptionsCollapse();
			AutsajderOptionsCollapse();
		}

		private void Pomarańcza_Click(object sender, RoutedEventArgs e)
		{
			WETIOptionsCollapse();
			HomeOptionsCollapse();
			PomarańczaOptions1.Visibility = Visibility.Visible;
			PomarańczaOptions2.Visibility = Visibility.Visible;
			PomarańczaOptions3.Visibility = Visibility.Visible;
			HackerspaceOptionsCollapse();
			PRLOptionsCollapse();
			AutsajderOptionsCollapse();
		}

		private void Hackerspace_Click(object sender, RoutedEventArgs e)
		{
			WETIOptionsCollapse();
			HomeOptionsCollapse();
			PomarańczaOptionsCollapse();
			HackerspaceOptions1.Visibility = Visibility.Visible;
			HackerspaceOptions2.Visibility = Visibility.Visible;
			PRLOptionsCollapse();
			AutsajderOptionsCollapse();
		}

		private void PRL_Click(object sender, RoutedEventArgs e)
		{
			WETIOptionsCollapse();
			HomeOptionsCollapse();
			PomarańczaOptionsCollapse();
			HackerspaceOptionsCollapse();
			PRLOptions1.Visibility = Visibility.Visible;
			PRLOptions2.Visibility = Visibility.Visible;
			PRLOptions3.Visibility = Visibility.Visible;
			AutsajderOptionsCollapse();
		}

		private void Autsajder_Click(object sender, RoutedEventArgs e)
		{
			WETIOptionsCollapse();
			HomeOptionsCollapse();
			PomarańczaOptionsCollapse();
			HackerspaceOptionsCollapse();
			PRLOptionsCollapse();
			AutsajderOptions1.Visibility = Visibility.Visible;
			AutsajderOptions2.Visibility = Visibility.Visible;
			AutsajderOptions3.Visibility = Visibility.Visible;
		}

		//methods for hiding not needed buttons
		private void WETIOptionsCollapse()
		{
			WETIOptions1.Visibility = Visibility.Collapsed;
			WETIOptions2.Visibility = Visibility.Collapsed;
			WETIOptions3.Visibility = Visibility.Collapsed;
			WETIOptions4.Visibility = Visibility.Collapsed;
			WETIOptions5.Visibility = Visibility.Collapsed;
			WETIOptions6.Visibility = Visibility.Collapsed;
		}
		private void HomeOptionsCollapse()
		{
			HomeOptions1.Visibility = Visibility.Collapsed;
			HomeOptions2.Visibility = Visibility.Collapsed;
			HomeOptions3.Visibility = Visibility.Collapsed;
		}
		private void PomarańczaOptionsCollapse()
		{
			PomarańczaOptions1.Visibility = Visibility.Collapsed;
			PomarańczaOptions2.Visibility = Visibility.Collapsed;
			PomarańczaOptions3.Visibility = Visibility.Collapsed;
		}
		private void HackerspaceOptionsCollapse()
		{
			HackerspaceOptions1.Visibility = Visibility.Collapsed;
			HackerspaceOptions2.Visibility = Visibility.Collapsed;
		}
		private void PRLOptionsCollapse()
		{
			PRLOptions1.Visibility = Visibility.Collapsed;
			PRLOptions2.Visibility = Visibility.Collapsed;
			PRLOptions3.Visibility = Visibility.Collapsed;
		}
		private void AutsajderOptionsCollapse()
		{
			AutsajderOptions1.Visibility = Visibility.Collapsed;
			AutsajderOptions2.Visibility = Visibility.Collapsed;
			AutsajderOptions3.Visibility = Visibility.Collapsed;
		}


		//Home Options Buttons

		private void DisplayHomePopup1(object sender, RoutedEventArgs e)
		{
			if (game.Player.WillToLive >= 20)
			{
				game.Player.ExperiencePoints = game.Player.ExperiencePoints + 50;
				game.Player.WillToLive = game.Player.WillToLive - 20;
				LevelUp();
				MessageBox.Show($"Po spędzeniu paru godzin na czytaniu dokumentacji Microsoftu, " +
								$"przeszukiwaniu SO i robieniu jakiegoś projekciku znalezionego w internecie,  " +
								$"nie czujesz się zbyt dobrze. Ale hej, jak tak dalej pójdzie, to czegoś się nauczysz!" +
								$"{Environment.NewLine}Doświadczenie: +50");
			}
			else
				MessageBox.Show($"{NotEnoughStats}{Environment.NewLine}Chęć do życia: 20");
		}

		private void DisplayHomePopup2(object sender, RoutedEventArgs e)
		{
			if (game.Player.WillToLive >= 30)
			{
				game.Player.ExperiencePoints = game.Player.ExperiencePoints + 100;
				game.Player.WillToLive = game.Player.WillToLive - 30;
				LevelUp();
				game.Quest.LevelOfCompletion++;
				if (game.Quest.LevelOfCompletion == 10)
				{
					MessageBox.Show($"UDAŁO CI SIĘ, BUDDY!{Environment.NewLine}PROJEKT JEST ZROBIONY ;)");
				}
				else
				{
					MessageBox.Show($"Przez kilka godzin nic ci nie wychodzi, Visual Studio się zacina niezmiernie, " +
									$"cholera cię bierze... ale jakimś cudem idziesz do przodu. Tak trzymać!" +
									$"{Environment.NewLine}Doświadczenie: +100");
				}
			}
			else
				MessageBox.Show($"{NotEnoughStats}{Environment.NewLine}Chęć do życia: 30");
		}

		private void DisplayHomePopup3(object sender, RoutedEventArgs e)
		{
			if (game.Player.ExperiencePoints >= 50)
			{
				game.Player.WillToLive = game.Player.WillToLive + 20;
				game.Player.ExperiencePoints = game.Player.ExperiencePoints - 50;
				MessageBox.Show($"HBO jednak potrafi tworzyć dobre seriale" +
								$"{Environment.NewLine}Chęć do życia: +20");
			}
			else
				MessageBox.Show($"{NotEnoughStats}{Environment.NewLine}Doświadczenie: 50");
		}

		//WETI Options Buttons

		private void DisplayWETIPopup1(object sender, RoutedEventArgs e)
		{
			if (game.Player.WillToLive >= 10)
			{
				game.Player.WillToLive = game.Player.WillToLive - 10;
				game.Player.ExperiencePoints = game.Player.ExperiencePoints + 25;
				LevelUp();
				MessageBox.Show($"Zmienne, if, for, switch... tak.{Environment.NewLine}Doświadczenie: +25");
			}
			else
				MessageBox.Show($"{NotEnoughStats}{Environment.NewLine}Chęć do życia: 10");
		}

		private void DisplayWETIPopup2(object sender, RoutedEventArgs e)
		{
			if (game.Player.LevelOfCompetence >= 5 && game.Player.WillToLive >= 20)
			{
				game.Player.WillToLive = game.Player.WillToLive - 20;
				game.Player.ExperiencePoints = game.Player.ExperiencePoints + 75;
				LevelUp();
				MessageBox.Show($"Obiektówka, obiektówka, więcej obiektówki... tak.{Environment.NewLine}Doświadczenie: +100");
			}
			else
				MessageBox.Show($"{NotEnoughStats}{ Environment.NewLine}Poziom: 5{Environment.NewLine}Chęć do życia: 20");
		}

		private void DisplayWETIPopup3(object sender, RoutedEventArgs e)
		{
			if (game.Player.LevelOfCompetence >= 10 && game.Player.WillToLive >= 25)
			{
				game.Player.WillToLive = game.Player.WillToLive - 25;
				game.Player.ExperiencePoints = game.Player.ExperiencePoints + 100;
				LevelUp();
				MessageBox.Show($"Enumy, WPF, ASP.NET... tak.{Environment.NewLine}Doświadczenie: +100");															//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
			}
			else
				MessageBox.Show($"{NotEnoughStats}{Environment.NewLine}Poziom: 10{Environment.NewLine}Chęć do życia: 25");
		}

		private void DisplayWETIPopup4(object sender, RoutedEventArgs e)
		{
			if(game.Player.LevelOfCompetence >= 5 && game.Player.WillToLive >= 15)
			{
				game.Player.WillToLive = game.Player.WillToLive - 15;
				game.Player.ExperiencePoints = game.Player.ExperiencePoints + 50;
				LevelUp();
				MessageBox.Show($"Stresik, mały stresik, duży stresik. Ale wyszło!{Environment.NewLine}Doświadczenie: +75");
			}
			else
				MessageBox.Show($"{NotEnoughStats}{Environment.NewLine}Poziom: 5{Environment.NewLine}Chęć do życia: 15");
		}

		private void DisplayWETIPopup5(object sender, RoutedEventArgs e)
		{
			if(game.Player.LevelOfCompetence >= 10 && game.Player.WillToLive >= 25)
			{
				game.Player.WillToLive = game.Player.WillToLive - 25;
				game.Player.ExperiencePoints = game.Player.ExperiencePoints + 100;
				LevelUp();
				MessageBox.Show($"Trochę mało przygotowania, ale nikt nie zarzekał, więc... wyszło?" +
								$"{Environment.NewLine}Doświadczenie: +100");
			}
			else
				MessageBox.Show($"{NotEnoughStats}{Environment.NewLine}Poziom: 10{Environment.NewLine}Chęć do życia: 25");
		}

		private void DisplayWETIPopup6(object sender, RoutedEventArgs e)
		{
			if(game.Player.LevelOfCompetence >= 15 && game.Player.WillToLive >=30)
			{
				game.Player.WillToLive = game.Player.WillToLive - 30;
				game.Player.ExperiencePoints = game.Player.ExperiencePoints + 150;
				LevelUp();
				MessageBox.Show($"Po jakimś czasie człowiek się przyzwyczaja do prowadzenia. " +
								$"I wszystko [czyt. większość] wychodzi dobrze.{Environment.NewLine}Doświadczenie: +150");
			}
			else
				MessageBox.Show($"{NotEnoughStats}{Environment.NewLine}Poziom: 15{Environment.NewLine}Chęć do życia: 30");
		}

		//Pomarańcza Options Buttons

		private void DisplayPomarańczaPopup1(object sender, RoutedEventArgs e)
		{
			if(game.Player.Money >= 10)
			{
				game.Player.Money = game.Player.Money - 10;
				game.Player.WillToLive = game.Player.WillToLive + 20;
				MessageBox.Show("No i faaajnieeee");
			}
			else
				MessageBox.Show($"{NotEnoughStats}{Environment.NewLine}Pieniądze: 10");
		}

		private void DisplayPomarańczaPopup2(object sender, RoutedEventArgs e)
		{
			if(game.Player.Money >= 20)
			{
				game.Player.Money = game.Player.Money - 20;
				game.Player.WillToLive = game.Player.WillToLive + 30;
				MessageBox.Show($"Wygrana? Przegrana? Nieważne, jest morowo{Environment.NewLine}Chęć do życia: +30");
			}
			else
				MessageBox.Show($"{NotEnoughStats}{Environment.NewLine}Pieniądze: 20");
		}

		private void DisplayPomarańczaPopup3(object sender, RoutedEventArgs e)
		{
			if(game.Player.Money >= 5)
			{
				game.Player.Money = game.Player.Money - 5;
				game.Player.WillToLive = game.Player.WillToLive + 10;
				MessageBox.Show($"Ehm.{Environment.NewLine}Chęć do życia: +10");
			}
			else
				MessageBox.Show($"{NotEnoughStats}{Environment.NewLine}Pieniądze: 5");
		}

		//Hackerspace Options Buttons

		private void DisplayHackerspacePopup1(object sender, RoutedEventArgs e)
		{
			if (game.Player.Money >= 15)
			{
				game.Player.Money = game.Player.Money - 15;
				game.Player.ExperiencePoints = game.Player.ExperiencePoints + 25;
				game.Player.WillToLive = game.Player.WillToLive + 20;
				LevelUp();
				MessageBox.Show($"Kurdebalans, uwielbiam to miejsce{Environment.NewLine}Doświadczenie: +25" +
								$"{Environment.NewLine}Chęć do życia: +20");
			}
			else
				MessageBox.Show($"{NotEnoughStats}{Environment.NewLine}Pieniądze: 15");
		}

		private void DisplayHackerspacePopup2(object sender, RoutedEventArgs e)
		{
			if (game.Player.Money >= 30 && game.Player.WillToLive >= 10)
			{
				game.Player.Money = game.Player.Money - 30;
				game.Player.ExperiencePoints = game.Player.ExperiencePoints + 55;
				game.Player.WillToLive = game.Player.WillToLive + 10;
				LevelUp();
				MessageBox.Show($"Pouczający wykład, ciekawi prowadzący, nienadążanie za live codingiem... " +
								$"Prawie idealnie{Environment.NewLine}Doświadczenie: +55{Environment.NewLine}Chęć do życia: +10");
			}
			else
				MessageBox.Show($"{NotEnoughStats}{Environment.NewLine}Pieniądze: 30{Environment.NewLine}Chęć do życia: 10");
		}

		//PRL Options Buttons

		private void DisplayPRLPopup1(object sender, RoutedEventArgs e)
		{
			if (game.Player.Money >= 20)
			{
				game.Player.Money = game.Player.Money - 20;
				game.Player.WillToLive = game.Player.WillToLive + 20;
				MessageBox.Show($"Wiosenna, pepperoni, salami... Pizza.{Environment.NewLine}Chęć do życia: +20");
			}
			else
				MessageBox.Show($"{NotEnoughStats}{Environment.NewLine}Pieniądze: 20");
		}

		private void DisplayPRLPopup2(object sender, RoutedEventArgs e)
		{
			if (game.Player.Money >= 20)
			{
				game.Player.Money = game.Player.Money - 20;
				if (game.Player.WillToLive >= 10)
				{
					game.Player.WillToLive = game.Player.WillToLive - 10;
					MessageBox.Show($"To... to nie był dobry pomysł...{Environment.NewLine}Chęć do życia: -10");
				}
				MessageBox.Show("To... to nie był dobry pomysł...");
			}
			else
				MessageBox.Show($"{NotEnoughStats}{Environment.NewLine}Pieniądze: 20");
		}

		private void DisplayPRLPopup3(object sender, RoutedEventArgs e)
		{
			if (game.Player.Money >= 5)
			{
				game.Player.Money = game.Player.Money - 5;
				game.Player.WillToLive = game.Player.WillToLive + 10;
				MessageBox.Show($"Towarzystwo dobre, ale żeby pizzy nie kupić?{Environment.NewLine}Chęć do życia: +10");
			}
			else
				MessageBox.Show($"{NotEnoughStats}{Environment.NewLine}Pieniądze: 5");
		}

		//Autsajder Options Buttons

		private void DisplayAutsajderPopup1(object sender, RoutedEventArgs e)
		{
			if (game.Player.Money >= 15)
			{
				game.Player.Money = game.Player.Money - 10;
				game.Player.WillToLive = game.Player.WillToLive + 25;
				MessageBox.Show("No i faaajnieeee");
			}
			else
				MessageBox.Show($"{NotEnoughStats}{Environment.NewLine}Pieniądze: 10");
		}

		private void DisplayAutsajderPopup2(object sender, RoutedEventArgs e)
		{
			if (game.Player.Money >= 20)
			{
				game.Player.Money = game.Player.Money - 20;
				game.Player.WillToLive = game.Player.WillToLive + 30;
				MessageBox.Show($"Zaraz będzie bilaaard{Environment.NewLine}Zamknij się *zamknij się... się... się...*" +
					$"{Environment.NewLine}Chęć do życia: +30");
			}
			else
				MessageBox.Show($"{NotEnoughStats}{Environment.NewLine}Pieniądze: 20");
		}

		private void DisplayAutsajderPopup3(object sender, RoutedEventArgs e)
		{
			if (game.Player.Money >= 5)
			{
				game.Player.Money = game.Player.Money - 5;
				game.Player.WillToLive = game.Player.WillToLive + 10;
				MessageBox.Show($"*wzdycha*.{Environment.NewLine}Chęć do życia: +10");
			}
			else
				MessageBox.Show($"{NotEnoughStats}{Environment.NewLine}Pieniądze: 5");
		}
	}
}
