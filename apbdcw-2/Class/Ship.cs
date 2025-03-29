namespace apbdcw_2.Class;
using apbdcw_2.Exception;

public class Ship {
    public double MaxSpeed { get; }
    public int MaxContainerCount { get; }
    public double MaxWeightTons { get; }

    private readonly List<Container> _containers = new();

    public Ship(double maxSpeed, int maxContainerCount, double maxWeightTons)
    {
        MaxSpeed = maxSpeed;
        MaxContainerCount = maxContainerCount;
        MaxWeightTons = maxWeightTons;
    }

    public void LoadContainer(Container container)
    {
        if (_containers.Count >= MaxContainerCount)
            throw new OverfillException("limit exceeded");

        double totalWeight = _containers.Sum(c => c.LoadWeight + c.OwnWeight);
        double newWeight = container.LoadWeight + container.OwnWeight;

        if ((totalWeight + newWeight) / 1000 > MaxWeightTons)
        {
            throw new OverfillException("limit exceeded");
        }

        _containers.Add(container);
    }

    public void LoadContainers(List<Container> containers)
    {
        foreach (Container container in containers)
        {
            LoadContainer(container);
        }
    }


    public void UnloadContainer(string serialNumber)
    {
        foreach (Container container in _containers)
        {
            if (container.SerialNumber == serialNumber)
            {
                container.Unload();
                _containers.Remove(container);
                break;
            }
        }
    }

    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        int index = _containers.FindIndex(c => c.SerialNumber == serialNumber);
        if (index != -1)
        {
            _containers[index] = newContainer;
        }
    }

    public void TransferContainer(Ship targetShip, string serialNumber)
    {
        for (int i = 0; i < _containers.Count; i++)
        {
            if (_containers[i].SerialNumber == serialNumber)
            {
                var container = _containers[i];
                _containers.RemoveAt(i);
                targetShip.LoadContainer(container);
                break;
            }
        }
    }


    public void PrintShipInfo()
    {
        Console.WriteLine($"max speed: {MaxSpeed} wezlow");
        Console.WriteLine($"loaded containers: {_containers.Count}, max containers: {MaxContainerCount}");
        Console.WriteLine($"weight sum: {_containers.Sum(c => c.LoadWeight + c.OwnWeight)}");
    }
}