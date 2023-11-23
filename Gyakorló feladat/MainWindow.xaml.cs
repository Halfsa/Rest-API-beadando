using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace Gyakorló_feladat
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Animals alatokwoo = new Animals();
		 Animal animal = new Animal();
		public MainWindow()
		{
			InitializeComponent();
			datagrid.ItemsSource = alatokwoo.GetAnimals();
			Combi.SelectedIndex = 0;
		}

		private void Adopt_Click(object sender, RoutedEventArgs e)
		{
			
			Animal selected = datagrid.SelectedItem as Animal;
			if (selected == null)
			{
				MessageBox.Show("válasszon ki egy állatot az adoptáláshoz");
				return;
			}
            if (selected.Available)
            {
				MessageBoxResult click =
			   MessageBox.Show($"Adoptálás folyamatban...\n Adoptálja a(z) {selected.Name} nevű állatot és elfogadja a vele járó kötelességeket?", "Adoptáció", MessageBoxButton.YesNo);
				if (click == MessageBoxResult.Yes)
					animal.Id = selected.Id;
					animal.Name = selected.Name;
					animal.Age = selected.Age;
					animal.Gender = selected.Gender;
					animal.Species = selected.Species;
					animal.Available = false;

				Animal adopted = alatokwoo.Adopt(this.animal.Id,animal);
				{
					if (adopted.Id != 0)
					{
						MessageBox.Show("Sikeres adoptáció");
					}
					else
					{
						MessageBox.Show("Hiba történt az adoptálás során. Kérjük próbálja újra.");
					}
					datagrid.ItemsSource = alatokwoo.GetAnimals();
				}
           
			}
            else
            {
				MessageBox.Show("Az állat jelenleg nem elérhető.\n" +
					" Iratkozzon fel hírlevelünkre további hírekért az adott állatról");
				return;
            }
        }

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			switch (Combi.SelectedIndex)
			{
				case 0: datagrid.ItemsSource = alatokwoo.GetAnimals();
					return;
				case 1: datagrid.ItemsSource = alatokwoo.GetAnimals().OrderBy((animal) => animal.Name);
					return;
				case 2: datagrid.ItemsSource = alatokwoo.GetAnimals().OrderByDescending((animal) => animal.Name);
					return;
				case 3: datagrid.ItemsSource = alatokwoo.GetAnimals().OrderBy((animal) => animal.Age);
					return;
				case 4: datagrid.ItemsSource = alatokwoo.GetAnimals().OrderByDescending((animal) => animal.Age);
					return;
				case 5: datagrid.ItemsSource = alatokwoo.GetAnimals().Where((animal) => animal.Gender == "male");
					if (datagrid.Items.Count == 0)
					{
						MessageBox.Show("Nincs a feltételnek megfelelő állat az adatbázisban");
						datagrid.ItemsSource = alatokwoo.GetAnimals();
					}
					return;
				case 6: datagrid.ItemsSource = alatokwoo.GetAnimals().Where((animal) => animal.Gender == "female");
					if (datagrid.Items.Count == 0)
					{
						MessageBox.Show("Nincs a feltételnek megfelelő állat az adatbázisban");
						datagrid.ItemsSource = alatokwoo.GetAnimals();
					}
					return;
				case 7: datagrid.ItemsSource = alatokwoo.GetAnimals().Where((animal) => animal.Species == "parrot");
					if (datagrid.Items.Count == 0)
					{
						MessageBox.Show("Nincs a feltételnek megfelelő állat az adatbázisban");
						datagrid.ItemsSource = alatokwoo.GetAnimals();
					}
					return;
				case 8: datagrid.ItemsSource = alatokwoo.GetAnimals().Where((animal) => animal.Species == "dog"|| animal.Species == "cat" || animal.Species == "human" || animal.Species == "hamster" || animal.Species == "elephant");
					if (datagrid.Items.Count == 0)
					{
						MessageBox.Show("Nincs a feltételnek megfelelő állat az adatbázisban");
						datagrid.ItemsSource = alatokwoo.GetAnimals();
					}
					return;
				case 9: datagrid.ItemsSource = alatokwoo.GetAnimals().Where((animal) => animal.Species == "amoeba"|| animal.Species == "nuclear particle");
					if (datagrid.Items.Count == 0)
					{
						MessageBox.Show("Nincs a feltételnek megfelelő állat az adatbázisban");
						datagrid.ItemsSource = alatokwoo.GetAnimals();
					}
					return;
				case 10: datagrid.ItemsSource = alatokwoo.GetAnimals().Where((animal) => animal.Species == "turtle");
					if (datagrid.Items.Count == 0)
					{
						MessageBox.Show("Nincs a feltételnek megfelelő állat az adatbázisban");
						datagrid.ItemsSource = alatokwoo.GetAnimals();
					}
					return;

			}
           

        }

		private void Put_Down_Click(object sender, RoutedEventArgs e)
		{
			Animal selected = datagrid.SelectedItem as Animal;
			if (selected == null)
			{
				MessageBox.Show("válasszon ki egy állatot az altatáshoz");
				return;
			}

			MessageBoxResult click =
				MessageBox.Show($"Biztosan el akarja altatni {selected.Name}-t?", "Altatás", MessageBoxButton.YesNo);
			if (click == MessageBoxResult.Yes)
			{
				if (alatokwoo.PutDown(selected))
				{
					MessageBox.Show("Sikeres altatás. Nyugodjon békében 😭😭😭😭😭");
				}
				else
				{
					MessageBox.Show("Hiba történt az altatás során, hála a jó égnek");
				}
				datagrid.ItemsSource = alatokwoo.GetAnimals();
			}
		}
	}
}
