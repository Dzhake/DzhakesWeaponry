using DuckGame;

namespace DzhakesWeaponry;

[EditorGroup("DzhakesWEP|Guns")]
public class MagShotgun : Shotgun
{
    public MagShotgun(float xval, float yval)
        : base(xval, yval)
    {
        _ammoType = new ATMag
        {
            penetration = 0.4f,
            accuracy = 0.6f,
            range = 115f,
            rangeVariation = 10f,
            combustable = true
        };
        _graphic = new Sprite(GetPath("Weapons/MagShotgun"));
        _loaderSprite = new SpriteMap(GetPath("Weapons/MagShotgunLoader"), 8, 8)
        {
            center = new Vec2(4f, 4f)
        };
        _kickForce = 8f;
        editorTooltip = "Mag Blaster combined with shotgun.";
    }
}