using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CarTask.Models;

public class Car : INotifyPropertyChanged
{
	private string? model;
	private string? make;
	private DateTime? year;
	private int? passengers;

	public string? Model { get => model; set { model = value; OnPropertyChanged(); } }
	public string? Make { get => make; set { make = value; OnPropertyChanged(); } }
	public DateTime? Year { get => year; set { year = value; OnPropertyChanged(); } }
	public int? Passengers { get => passengers; set { passengers = value; OnPropertyChanged(); } }

	public Car(string? model, string? make, DateTime? year, int? passengers)
	{
		Model = model; Make = make; Year = year; Passengers = passengers;
	}
	public Car() { }

	public override string ToString() => $"{Year} {Make} {Model} with {Passengers} passengers";

	#region INotify Property Change Part
	// -----------------------------------------------------------

	public event PropertyChangedEventHandler? PropertyChanged;
	public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
	{
		PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
	// -----------------------------------------------------------
	#endregion


}
