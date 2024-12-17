using DuckGame;

namespace DzhakesWeaponry;

public class ATPhysics : AmmoType
{
    public ATPhysics()
    {
        range = 1000f;
        accuracy = 1f;
        penetration = 2f;
        bulletSpeed = 12f;
        speedVariation = 0f;
        bulletType = typeof(PhysicsBullet);
    }

    public override void PopShell(float x, float y, int dir)
    {
        PistolShell pistolShell = new PistolShell(x, y)
        {
            hSpeed = dir * (1.5f + Rando.Float(1f))
        };
        Level.Add(pistolShell);
    }
}
