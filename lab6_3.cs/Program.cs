using System;
using System.Collections.Generic;

struct CarStruct
{
    public string Brand;
    public int Year;
    public decimal Price;
    public string Color;

    public CarStruct(string brand, int year, decimal price, string color)
    {
        if (string.IsNullOrWhiteSpace(brand) || year < 1900 || year > 2025)
            throw new CarArrayException("Некоректні дані автомобіля: порожня марка або рік не в межах 1900–2025");

        Brand = brand;
        Year = year;
        Price = price;
        Color = color;
    }

    public void Show() =>
        Console.WriteLine($"[Struct] {Brand}, {Year}, {Price}$, {Color}");
}

public record CarRecord(string Brand, int Year, decimal Price, string Color);

public class CarArrayException : Exception
{
    public CarArrayException(string message) : base(message) { }
}

class Program
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Обери тип реалізації:");
            Console.WriteLine("1 - Struct");
            Console.WriteLine("2 - Tuple");
            Console.WriteLine("3 - Record");
            Console.Write("номер: ");
            var choice = Console.ReadLine();

            Console.Write("мінімальний рік авто: ");
            if (!int.TryParse(Console.ReadLine(), out int minYear))
            {
                Console.WriteLine("Введено некоректне значення. Встановлено 2010.");
                minYear = 2010;
            }

            switch (choice)
            {
                case "1":
                    UseStruct(minYear);
                    break;
                case "2":
                    UseTuple(minYear);
                    break;
                case "3":
                    UseRecord(minYear);
                    break;
                default:
                    Console.WriteLine("Не той номер.");
                    break;
            }

            object[] carsArray = new string[3];
            carsArray[0] = "BMW";
            carsArray[1] = "Audi";
            carsArray[2] = 1234; // ArrayTypeMismatchException
        }
        catch (ArrayTypeMismatchException ex)
        {
            Console.WriteLine("[Стандартний виняток] ArrayTypeMismatchException зловлено:");
            Console.WriteLine(ex.Message);
            throw new CarArrayException("Неможливо вставити елемент не того типу в масив автомобілів.");
        }
        catch (CarArrayException customEx)
        {
            Console.WriteLine("[Власний виняток] CarArrayException:");
            Console.WriteLine(customEx.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("[Інша помилка]: " + ex.Message);
        }
    }

    static void UseStruct(int minYear)
    {
        var cars = new List<CarStruct>
        {
            new CarStruct("BMW", 2010, 12000, "Black"),
            new CarStruct("Audi", 2018, 15000, "White"),
            new CarStruct("Lada", 2012, 3000, "Red"),
            new CarStruct("Tesla", 2022, 35000, "Blue")
        };

        cars.RemoveAll(c => c.Year < minYear);
        cars.Insert(0, new CarStruct("Toyota", 2000, 13000, "Silver"));

        Console.WriteLine("Struct cars:");
        foreach (var car in cars)
            car.Show();
    }

    static void UseTuple(int minYear)
    {
        var cars = new List<(string Brand, int Year, decimal Price, string Color)>
        {
            ("BMW", 2010, 12000, "Black"),
            ("Audi", 2018, 15000, "White"),
            ("Lada", 2012, 3000, "Red"),
            ("Tesla", 2022, 35000, "Blue")
        };

        cars.RemoveAll(c => c.Year < minYear);
        cars.Insert(0, ("Toyota", 2000, 13000, "Silver"));

        Console.WriteLine("Tuple cars:");
        foreach (var car in cars)
            Console.WriteLine($"[Tuple] {car.Brand}, {car.Year}, {car.Price}$, {car.Color}");
    }

    static void UseRecord(int minYear)
    {
        var cars = new List<CarRecord>
        {
            new("BMW", 2010, 12000, "Black"),
            new("Audi", 2018, 15000, "White"),
            new("Lada", 2012, 3000, "Red"),
            new("Tesla", 2022, 35000, "Blue")
        };

        cars.RemoveAll(c => c.Year < minYear);
        cars.Insert(0, new("Toyota", 2000, 13000, "Silver"));

        Console.WriteLine("Record cars:");
        foreach (var car in cars)
            Console.WriteLine($"[Record] {car.Brand}, {car.Year}, {car.Price}$, {car.Color}");
    }
}

