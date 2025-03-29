using apbdcw_2.Exception;

namespace apbdcw_2.Class;

public class ContainerC : Container
{
    public enum ProductType
    {
        Banana,
        Chocolate,
        Fish,
        Meat,
        IceCream,
        FrozenPizza,
        Cheese,
        Sausage,
        Butter,
        Egg
    }

    public static readonly Dictionary<ProductType, Double> MinimumTemperatures = new()
    {
        { ProductType.Banana, 13.3 },
        { ProductType.Chocolate, 18 },
        { ProductType.Fish, 2 },
        { ProductType.Meat, -15 },
        { ProductType.IceCream, -18 },
        { ProductType.FrozenPizza, -30 },
        { ProductType.Cheese, 7.2 },
        { ProductType.Sausage, 5 },
        { ProductType.Butter, 20.5 },
        { ProductType.Egg, 19 }
    };

    public ProductType Product { get; }
    public double Temperature { get; }

    public ContainerC(double height, double ownWeight, double depth, double maxCapacity, ProductType product, double temperature)
        : base(height, ownWeight, depth, maxCapacity)
    {
        if (temperature < MinimumTemperatures[product])
        {}

        Product = product;
        Temperature = temperature;
        SerialNumber = SerialNumber.Replace("X", "C");
    }

    public override void Load(double weight)
    {
        if (weight > MaxCapacity)
        {
            throw new OverfillException("limit exceeded");
        }

        base.Load(weight);
    }
}