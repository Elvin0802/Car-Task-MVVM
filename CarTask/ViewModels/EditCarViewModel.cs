using CarTask.Commands;
using CarTask.DataBase;
using CarTask.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;

namespace CarTask.ViewModels;

public class EditCarViewModel : INotifyPropertyChanged
{

	private Car? newCar;
	private List<Car>? cars;
	private int selectedIndexForCars;

	public int SelectedIndexForCars
	{
		get => selectedIndexForCars;
		set
		{
			selectedIndexForCars = value;
			OnPropertyChanged();
			SelectCar();
		}
	}

	public List<Car>? Cars
	{
		get => cars;
		set { cars = value; OnPropertyChanged(); }
	}

	public Car? NewCar
	{
		get => newCar;
		set { newCar = value; OnPropertyChanged(); }
	}

	public ICommand EditCommand { get; set; }

	public EditCarViewModel()
	{
		Cars = ObjectDataBase.CarsDB;
		EditCommand = new RelayCommand(EditCar);
		NewCar = new();
		SelectedIndexForCars = -1;
	}


	public void SelectCar()
	{
		if (NewCar is not null && SelectedIndexForCars >= 0 && SelectedIndexForCars < Cars?.Count)
		{
			NewCar.Make = Cars?[selectedIndexForCars].Make;
			NewCar.Model = Cars?[selectedIndexForCars].Model;
			NewCar.Passengers = Cars?[selectedIndexForCars].Passengers;
			NewCar.Year = Cars?[selectedIndexForCars].Year;
		}
	}

	void EditCar(object? param)
	{
		ListView? lv = param as ListView;

		if (lv is not null)
		{
			Cars![SelectedIndexForCars] = NewCar!;
			lv?.Items.Refresh();
			NewCar = new();

			MessageBox.Show("Car Edited.", "Editing", MessageBoxButton.OK, MessageBoxImage.Information);
			return;
		}

		MessageBox.Show("Car NOT Edited.", "Editing", MessageBoxButton.OK, MessageBoxImage.Information);
	}


	// ---------------- Event for Property Changed Notification ---------------
	public event PropertyChangedEventHandler? PropertyChanged;
	public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	// -------------------------------------------------------------------------


}
