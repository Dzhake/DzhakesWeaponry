using DuckGame;

namespace DzhakesWeaponry;

[EditorGroup("DzhakesWEP|Guns")]
public class PhysicsGun : Gun
{
    public PhysicsGun(float x, float y) : base(x, y)
    {
        ammo = 9;
        _ammoType = new ATPhysics();
        _type = "gun";
        _graphic = new Sprite("sniper");
        _center = new Vec2(16f, 4f);
        _collisionOffset = new Vec2(-8f, -4f);
        _collisionSize = new Vec2(16f, 8f);
        _barrelOffsetTL = new Vec2(30f, 3f);
        _fireSound = "pistolFire";
        _kickForce = 3f;
        _fireRumble = RumbleIntensity.Kick;
        _editorName = "Physics Gun";
        editorTooltip = "Gun which manimulates velocity of objects.";
        physicsMaterial = PhysicsMaterial.Metal;
    }
}
