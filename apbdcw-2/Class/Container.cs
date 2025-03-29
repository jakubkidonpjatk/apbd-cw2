using apbdcw_2.Exception;

namespace apbdcw_2.Class;
    
public abstract class Container
{
    private static int counter = 1;
    
    public Double LoadWeight { get; protected set; }
    public Double Height { get; }
    public Double OwnWeight { get; }
    public Double Depth { get; }
    public Double MaxCapacity { get;  }
    public string SerialNumber { get; protected set; }
    
    

    public Container(Double height, Double ownWeight, Double depth, Double maxCapacity)
    {
        LoadWeight = 0;
        Height = height;
        OwnWeight = ownWeight;
        Depth = depth;
        MaxCapacity = maxCapacity;
        SerialNumber = $"KON-X-{counter++}"; // X in number -  just as for now

    }

    public virtual void Load(double weight)
    {
        if (LoadWeight + weight > MaxCapacity)
        {
            throw new OverfillException("Overfilled, too much load");
        }
        LoadWeight += weight;
    }

    public virtual void Unload()
    {
        LoadWeight = 0;
    }
    
}