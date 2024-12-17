using DuckGame;

namespace DzhakesWeaponry;

/// <summary>
/// Class which should make the mod work on both dgr and non-dgr (WIP because idc about non-dgr lol)
/// </summary>
public class DGRWrapper
{
    public static void Log(string message)
    {
        DevConsole.Log(message);
    }
}
