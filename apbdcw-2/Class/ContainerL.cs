using apbdcw_2.Exception;
using apbdcw_2.Interface;

namespace apbdcw_2.Class;

public class ContainerL : Container, IHazardNotifier
{
    public bool IsHazard { get; }

    public ContainerL(double height, double ownWeight, double depth, double maxCapacity, bool isHazard)
        : base(height, ownWeight, depth, maxCapacity)
    {
        IsHazard = isHazard;
        SerialNumber = SerialNumber.Replace("X", "L");
    }

    public override void Load(double weight)
    {
        double limit = IsHazard ? MaxCapacity * 0.5 : MaxCapacity * 0.9;

        if (weight > limit)
        {
            NotifyHazard("hazard", SerialNumber);
            throw new OverfillException("limit exceeded");
        }

        base.Load(weight);
    }

    public  void NotifyHazard(string message, string containerNumber)
    {
        Console.WriteLine($"[HAZARD] {containerNumber}: {message}");
    }
}