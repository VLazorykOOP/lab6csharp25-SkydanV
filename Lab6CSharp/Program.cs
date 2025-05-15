
public interface ICanSail
{
    void Sail();
}

public interface ICanSteam
{
    void Steam();
}

public interface ICanNavigate
{
    void Navigate();
}

public abstract class Ship
{
    public string Name { get; set; }
    public double Speed { get; set; }
    public string Manufacturer { get; set; }

    public Ship(string name, double speed, string manufacturer)
    {
        Name = name;
        Speed = speed;
        Manufacturer = manufacturer;
    }

    public abstract void Show();
}

public class CargoShip : Ship, ICanSteam
{
    public CargoShip(string name, double speed, string manufacturer)
        : base(name, speed, manufacturer) { }

    public void Steam()
    {
        Console.WriteLine($"{Name} is steaming with speed {Speed} knots.");
    }

    public override void Show()
    {
        Console.WriteLine($"Cargo Ship: {Name}, Speed: {Speed} knots, Manufacturer: {Manufacturer}");
    }
}

public class SailingShip : Ship, ICanSail
{
    public SailingShip(string name, double speed, string manufacturer)
        : base(name, speed, manufacturer) { }

    public void Sail()
    {
        Console.WriteLine($"{Name} is sailing with wind at speed {Speed} knots.");
    }

    public override void Show()
    {
        Console.WriteLine($"Sailing Ship: {Name}, Speed: {Speed} knots, Manufacturer: {Manufacturer}");
    }
}

public class Corvette : Ship, ICanNavigate
{
    public Corvette(string name, double speed, string manufacturer)
        : base(name, speed, manufacturer) { }

    public void Navigate()
    {
        Console.WriteLine($"{Name} is navigating with advanced maneuverability at {Speed} knots.");
    }

    public override void Show()
    {
        Console.WriteLine($"Corvette: {Name}, Speed: {Speed} knots, Manufacturer: {Manufacturer}");
    }
}
class Program
{
    static void Main(string[] args)
    {
        Ship cargoShip = new CargoShip("Titanic", 30, "White Star Line");
        Ship sailingShip = new SailingShip("Mayflower", 15, "Unknown");
        Ship corvette = new Corvette("Invincible", 40, "Royal Navy");

        if (cargoShip is ICanSteam steamShip)
        {
            steamShip.Steam();
        }
        if (sailingShip is ICanSail sailShip)
        {
            sailShip.Sail();
        }
        if (corvette is ICanNavigate navigateShip)
        {
            navigateShip.Navigate();
        }

        cargoShip.Show();
        sailingShip.Show();
        corvette.Show();
    }
}
