using apbdcw_2.Exception;
using apbdcw_2.Interface;

namespace apbdcw_2.Class;

public class ContainerG : Container, IHazardNotifier
{
    public double Pressure { get; }

    public ContainerG(double height, double ownWeight, double depth, double maxCapacity, double pressure)
        : base(height, ownWeight, depth, maxCapacity)
    {
        Pressure = pressure;
        SerialNumber = SerialNumber.Replace("X", "G");
    }

    public override void Load(double weight)
    {
        if (weight > MaxCapacity)
        {
            throw new OverfillException("limit exceeded");
        }

        base.Load(weight);
    }

    public override void Unload()
    {
        LoadWeight *= 0.05;
    }

    public void NotifyHazard(string message, string containerNumber)
    {
        Console.WriteLine($"[GAZ - ALERT] {containerNumber}: {message}");
    }
}