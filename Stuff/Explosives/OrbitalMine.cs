using System.Reflection;
using DuckGame;

namespace DzhakesWeaponry
{
    [EditorGroup("DzhakesWEP|Explosives")]
    public class OrbitalMine : Mine
    {
        protected FieldInfo _spriteField = typeof(Mine).GetField("_sprite", BindingFlags.Instance | BindingFlags.NonPublic)!;
        protected FieldInfo _mineFlashField = typeof(Mine).GetField("_mineFlash", BindingFlags.Instance | BindingFlags.NonPublic)!;

        public OrbitalMine(float xval, float yval)
          : base(xval, yval)
        {
            SpriteMap sprite = new SpriteMap(GetPath("Weapons/OrbitalMine"), 18, 16);
            sprite.AddAnimation("pickup", 1f, true, new int[1]);
            sprite.AddAnimation("idle", 0.05f, true, 1, 2);
            sprite.SetAnimation("pickup");
            _spriteField.SetValue(this, sprite);
            _graphic = sprite;
            Sprite mineFlash = new Sprite(GetPath("Weapons/OrbitalMineFlash"));
            mineFlash.CenterOrigin();
            mineFlash.alpha = 0f;
            _mineFlashField.SetValue(this, mineFlash);
            _editorName = "Orbital Mine";
            editorTooltip = "Like standart mine, but waaay more powerful.";
        }

        [AutoPatch(typeof(Mine), nameof(Mine.BlowUp), PatchType.Prefix)]
        public static bool Mine_BlowUp_Prefix(Mine __instance)
        {
            if (__instance is not OrbitalMine) return true;

            if (__instance.blownUp || !__instance.isServerForObject)
                return false;
            __instance.blownUp = true;
            if (DGRSettings.ActualParticleMultiplier > 0) Level.Add(new ExplosionPart(__instance.x, __instance.y - 2f));
            Level.Add(new IonCannon(new Vec2(__instance.x, __instance.y + 3000f), new Vec2(__instance.x, __instance.y - 3000f))
            {
                serverVersion = __instance.isServerForObject
            });
            Graphics.FlashScreen();
            SFX.Play("laserBlast");
            Level.Remove(__instance);
            return false;
        }
    }
}
