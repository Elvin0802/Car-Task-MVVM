using CarTask.Commands;
using CarTask.DataBase;
using CarTask.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CarTask.ViewModels;

public class RemoveCarViewModel : INotifyPropertyChanged
{

	private List<Car>? cars;

	public List<Car>? Cars
	{
		get => cars;
		set { cars = value; OnPropertyChanged(); }
	}

	public ICommand RemoveCommand { get; set; }

	public RemoveCarViewModel()
	{
		Cars = ObjectDataBase.CarsDB;
		RemoveCommand = new RelayCommand(RemoveCarFromList);
	}

	void RemoveCarFromList(object? param)
	{
		if (param is not null)
		{
			ListView? lv = param as ListView;

			Car? c = lv?.SelectedItem as Car;

			if (c is not null)
			{
				Cars?.Remove(c);
				ObjectDataBase.CarsDB = Cars;
				lv?.Items.Refresh();

				MessageBox.Show("Car Removed.", "Removing", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}
		}
		MessageBox.Show("Car NOT Removed.", "Removing", MessageBoxButton.OK, MessageBoxImage.Information);
	}


	// ---------------- Event for Property Changed Notification ---------------
	public event PropertyChangedEventHandler? PropertyChanged;
	public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	// -------------------------------------------------------------------------


}
