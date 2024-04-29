using CarTask.Commands;
using CarTask.DataBase;
using CarTask.Models;
using CarTask.Views;
using Microsoft.Win32;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace CarTask.ViewModels;

public class AppCoreViewModel
{

	private Car? newCar;
	public Car? NewCar { get => newCar; set { newCar = value; OnPropertyChanged(); } }

	public ICommand AddCommand { get; set; }
	public ICommand GetAllCarCommand { get; set; }
	public ICommand RemoveCarCommand { get; set; }
	public ICommand EditCarCommand { get; set; }
	public ICommand SaveCarsCommand { get; set; }
	public ICommand LoadCarsCommand { get; set; }

	public AppCoreViewModel()
	{
		NewCar = new Car();
		AddCommand = new RelayCommand(AddCar, IsAddCarEnabled);
		GetAllCarCommand = new RelayCommand(GetAllCars);
		RemoveCarCommand = new RelayCommand(RemoveCarFromDB);
		EditCarCommand = new RelayCommand(EditCar);
		LoadCarsCommand = new RelayCommand(LoadCars);
		SaveCarsCommand = new RelayCommand(SaveCars);
	}

	private void RemoveCarFromDB(object? obj)
	{
		RemoveCarView view = new();

		view.DataContext = new RemoveCarViewModel();

		view.ShowDialog();
	}
	private void SaveCars(object? obj)
	{
		try
		{
			SaveFileDialog fileD = new();

			if (fileD.ShowDialog() == true)
				ObjectDataBase.Save(fileD.FileName);
		}
		catch (Exception ex)
		{
			MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}
	private void LoadCars(object? obj)
	{
		try
		{
			OpenFileDialog fileD = new();

			if (fileD.ShowDialog() == true)
				ObjectDataBase.Load(fileD.FileName);
		}
		catch (Exception ex)
		{
			MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
		}
	}
	private void GetAllCars(object? obj)
	{
		DisplayAllCarsView view = new DisplayAllCarsView();

		view.DataContext = new DisplayAllCarsViewModel();

		view.ShowDialog();
	}
	private void EditCar(object? obj)
	{
		EditCarView view = new();

		view.ShowDialog();
	}

	public bool IsAddCarEnabled(object? parameter)
	{
		return NewCar?.Model?.Length >= 3 && NewCar?.Make?.Length >= 3 && NewCar?.Year != null && NewCar?.Passengers != null;
	}
	public void AddCar(object? parameter)
	{
		ObjectDataBase.CarsDB?.Add(NewCar!);

		NewCar = new Car();
	}

	// ---------------- Event for Property Changed Notification ---------------
	public event PropertyChangedEventHandler? PropertyChanged;
	public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	// -------------------------------------------------------------------------
}
