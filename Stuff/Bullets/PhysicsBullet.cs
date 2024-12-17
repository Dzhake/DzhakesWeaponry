using System;
using DuckGame;

namespace DzhakesWeaponry;

public class PhysicsBullet : Bullet
{
    public PhysicsBullet(float x, float y, AmmoType at, float angle = -1f, Thing? owner = null, bool rbound = true,
        float distance = -1f, bool tracer = false, bool network = true)
        : base(x, y, at, angle, owner, rbound, distance, tracer, network)
    {

    }

    public override void Update()
    {
        base.Update();
        Vec2 pos = BulletEnd.Position;
        foreach (PhysicsObject pObject in Level.CheckPointAll<PhysicsObject>(pos))
            pObject.vSpeed = -5f;
    }

    [AutoPatch(typeof(Duck), nameof(Duck.Hit), PatchType.Prefix)]
    public static bool Duck_Hit_Prefix(Bullet bullet)
    {
        return bullet is not PhysicsBullet;
    }
}
