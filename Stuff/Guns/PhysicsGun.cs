using DuckGame;

namespace DzhakesWeaponry;

[EditorGroup("DzhakesWEP|Guns")]
[BaggedProperty("isFatal", false)]
public class PhysicsGun : Gun
{
    public PhysicsGun(float x, float y) : base(x, y)
    {
        ammo = 9;
        _ammoType = new ATPhysics();
        _type = "gun";
        _graphic = new Sprite(GetPath("Weapons/PhysicsGun"));
        _center = new Vec2(16f, 16f);
        _collisionOffset = new Vec2(-8f, -4f);
        _collisionSize = new Vec2(14f, 9f);
        _barrelOffsetTL = new Vec2(24f, 14f);
        _holdOffset = new Vec2(7f, 3f);
        _fireSound = "pistolFire";
        _kickForce = 3f;
        _fireRumble = RumbleIntensity.Kick;
        _editorName = "Physics Gun";
        editorTooltip = "Gun which manimulates velocity of objects.";
        physicsMaterial = PhysicsMaterial.Metal;
    }
}
