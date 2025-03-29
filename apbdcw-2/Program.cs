namespace apbdcw_2;

using apbdcw_2.Class;
using apbdcw_2.Exception;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Create a ship
            var ship = new Ship(28, 5, 100); // max 5 containers, max 100 tons

            // Create containers
            var liquid = new ContainerL(200, 400, 500, 1000, false); // non-hazardous
            liquid.Load(800);

            var gas = new ContainerG(200, 400, 500, 1000, 6);
            gas.Load(950);

            var fridge = new ContainerC(200, 400, 500, 1000, ContainerC.ProductType.Fish, 3);
            fridge.Load(700);

            // Load containers onto the ship
            ship.LoadContainer(liquid);
            ship.LoadContainer(gas);
            ship.LoadContainer(fridge);

            // Print ship status
            ship.PrintShipInfo();
        }
        catch (OverfillException ex)
        {
            Console.WriteLine($"[Overfill Error] {ex.Message}");
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"[Error] {ex.Message}");
        }
    }
}