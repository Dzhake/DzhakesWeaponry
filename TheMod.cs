using System;
using System.Reflection;
using DuckGame;

namespace DzhakesWeaponry;

public class TheMod : Mod
{
    public static ModConfiguration Config;

    public static bool Disabled
    {
        get => (bool) DisabledField.GetValue(Config);
        set => DisabledField.SetValue(Config, value);
    }

    private static readonly PropertyInfo SteamIdField =
        typeof(ModConfiguration).GetProperty("workshopID", BindingFlags.Instance | BindingFlags.NonPublic)!;

    private static readonly PropertyInfo DisabledField =
        typeof(ModConfiguration).GetProperty("disabled", BindingFlags.Instance | BindingFlags.NonPublic)!;

    public static bool DGR;

	// This function is run before all mods are finished loading.
	protected override void OnPreInitialize()
	{
        DGR = typeof(Program).GetField("CURRENT_VERSION_ID", BindingFlags.Public | BindingFlags.Static) is { IsLiteral: true, IsInitOnly: false };

        if (!DGR) throw new Exception("You must have DuckGameRebuilt mod to use this one.");

        Config = configuration;
		DependencyResolver.ResolveDependencies();
		base.OnPreInitialize();
	}

	// This function is run after all mods are loaded.
	protected override void OnPostInitialize()
    {
        if (!DGR) return;
		AutoPatchHandler.Patch();
		base.OnPostInitialize();
	}
}
