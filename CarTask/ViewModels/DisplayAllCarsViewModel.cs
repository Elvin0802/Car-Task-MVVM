using CarTask.Commands;
using CarTask.DataBase;
using CarTask.Models;
using CarTask.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CarTask.ViewModels;

public class DisplayAllCarsViewModel : INotifyPropertyChanged
{
	private List<Car>? cars;

	public List<Car>? Cars
	{
		get => cars;
		set { cars = value; OnPropertyChanged(); }
	}


	public DisplayAllCarsViewModel()
    {
		Cars = ObjectDataBase.CarsDB;
	}


	// ---------------- Event for Property Changed Notification ---------------
	public event PropertyChangedEventHandler? PropertyChanged;
	public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	// -------------------------------------------------------------------------


}
