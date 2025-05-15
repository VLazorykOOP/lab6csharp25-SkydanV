using System;
using System.Collections.Generic;

public interface IProgramSoftware
{
    void ShowInfo();
    bool CanBeUsedToday();
}

public class FreeSoftware : IProgramSoftware
{
    public string Name { get; set; }
    public string Manufacturer { get; set; }

    public FreeSoftware(string name, string manufacturer)
    {
        Name = name;
        Manufacturer = manufacturer;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Вільне ПЗ: {Name}, Виробник: {Manufacturer}");
    }

    public bool CanBeUsedToday()
    {
        return true; 
    }
}

public class SharewareSoftware : IProgramSoftware
{
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public DateTime InstallDate { get; set; }
    public int FreeUsagePeriod { get; set; } 

    public SharewareSoftware(string name, string manufacturer, DateTime installDate, int freeUsagePeriod)
    {
        Name = name;
        Manufacturer = manufacturer;
        InstallDate = installDate;
        FreeUsagePeriod = freeUsagePeriod;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Умовно-безкоштовне ПЗ: {Name}, Виробник: {Manufacturer}, Дата встановлення: {InstallDate.ToShortDateString()}, Період безкоштовного використання: {FreeUsagePeriod} днів");
    }

    public bool CanBeUsedToday()
    {
        return (DateTime.Now - InstallDate).Days <= FreeUsagePeriod;
    }
}

public class CommercialSoftware : IProgramSoftware
{
    public string Name { get; set; }
    public string Manufacturer { get; set; }
    public double Price { get; set; }
    public DateTime InstallDate { get; set; }
    public int UsagePeriod { get; set; } 

    public CommercialSoftware(string name, string manufacturer, double price, DateTime installDate, int usagePeriod)
    {
        Name = name;
        Manufacturer = manufacturer;
        Price = price;
        InstallDate = installDate;
        UsagePeriod = usagePeriod;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Комерційне ПЗ: {Name}, Виробник: {Manufacturer}, Ціна: {Price} грн, Дата встановлення: {InstallDate.ToShortDateString()}, Строк використання: {UsagePeriod} днів");
    }

    public bool CanBeUsedToday()
    {
        return (DateTime.Now - InstallDate).Days <= UsagePeriod;
    }
}

public class SoftwareDatabase
{
    public List<IProgramSoftware> Softwares { get; set; }

    public SoftwareDatabase()
    {
        Softwares = new List<IProgramSoftware>();
    }

    public void AddSoftware(IProgramSoftware software)
    {
        Softwares.Add(software);
    }

    public void FindUsableSoftware()
    {
        Console.WriteLine("Програмне забезпечення, яке можна використовувати сьогодні:");
        foreach (var software in Softwares)
        {
            if (software.CanBeUsedToday())
            {
                software.ShowInfo();
            }
        }
    }

    public void ShowAllSoftwareInfo()
    {
        Console.WriteLine("Вся інформація про програмне забезпечення:");
        foreach (var software in Softwares)
        {
            software.ShowInfo();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {

        FreeSoftware freeSoftware = new FreeSoftware("LibreOffice", "The Document Foundation");
        SharewareSoftware sharewareSoftware = new SharewareSoftware("WinRAR", "RARLab", DateTime.Now.AddDays(-5), 30);
        CommercialSoftware commercialSoftware = new CommercialSoftware("Microsoft Office", "Microsoft", 5000, DateTime.Now.AddMonths(-2), 365);
        SoftwareDatabase database = new SoftwareDatabase();
        database.AddSoftware(freeSoftware);
        database.AddSoftware(sharewareSoftware);
        database.AddSoftware(commercialSoftware);

        database.ShowAllSoftwareInfo();

        database.FindUsableSoftware();
    }
}
