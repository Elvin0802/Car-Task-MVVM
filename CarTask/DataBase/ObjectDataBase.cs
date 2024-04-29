using CarTask.Models;
using CarTask.Views;
using System;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace CarTask.DataBase;

public static class ObjectDataBase
{
	public static JsonSerializerOptions op = new JsonSerializerOptions() { WriteIndented = true };

	public static List<Car>? CarsDB { get; set; } = new List<Car>();

	public static void Save(string? JsonPath)
	{
		try
		{
			File.WriteAllText(JsonPath!, JsonSerializer.Serialize<List<Car>>(ObjectDataBase.CarsDB!, op));

			MessageBox.Show("Cars Saved.", "Json Operation", MessageBoxButton.OK, 
				MessageBoxImage.Information);
		}
		catch
		{
			MessageBox.Show("Cars NOT Saved.", "Json Operation", MessageBoxButton.OK, 
				MessageBoxImage.Information);
		}
	}

	public static void Load(string? JsonPath)
	{
		try
		{
			var data = File.ReadAllText(JsonPath!);
			ObjectDataBase.CarsDB = JsonSerializer.Deserialize<List<Car>>(data);

			MessageBox.Show("Cars Loaded.", "Json Operation", 
				MessageBoxButton.OK, MessageBoxImage.Information);
		}
		catch
		{
			MessageBox.Show("Cars NOT Loaded.", "Json Operation", 
				MessageBoxButton.OK, MessageBoxImage.Information);
		}
	}
}
