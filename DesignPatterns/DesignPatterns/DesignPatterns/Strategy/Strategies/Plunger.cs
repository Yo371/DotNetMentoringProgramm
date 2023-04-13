namespace DesignPatterns.Strategy.Strategies;

public class Plunger : IWeapon
{
    public void Shoot()
    {
        Console.WriteLine("attacks with a plunger");
    }
}