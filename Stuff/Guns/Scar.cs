using System;
using DuckGame;

namespace DzhakesWeaponry;

[EditorGroup("DzhakesWEP|Guns")]
public class Scar : Sniper
{
    public Scar(float xval, float yval)
        : base(xval, yval)
    {
        _graphic = new Sprite(GetPath("Weapons/Scar"));
        _fireSound = "sniper";
        _kickForce = 1f;
        laserSight = true;
        _laserOffsetTL = new Vec2(32f, 3.5f);
        _manualLoad = false;
        editorTooltip = "Long range automatic rifle with lazer sight.";
        loseAccuracy = 0.2f;
        maxAccuracyLost = 1f;
        ammo = 5;
    }

    public override void OnPressAction()
    {
        _ammoType.accuracy = 1f / Math.Max(1f, _accuracyLost);
        base.OnPressAction();
        if (ammo <= 0) return;
        _loadState = 3;
    }
}