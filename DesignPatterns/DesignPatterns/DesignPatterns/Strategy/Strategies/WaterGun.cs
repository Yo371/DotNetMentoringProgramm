namespace DesignPatterns.Strategy.Strategies;

public class WaterGun : IWeapon
{
    public void Shoot()
    {
        Console.WriteLine("attacks with a water gun");
    }
}