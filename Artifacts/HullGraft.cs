using System.Reflection;
using Nanoray.PluginManager;
using Nickel;

namespace RuhigMod.Artifacts;

// Boss Artifact that gives the player 1 max hull and heals 1 hull at the end of each combat ~ Havmir
public class HullGraft : Artifact, IRegisterable
{
    private static Spr HullGrafterSprite;
    
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        HullGrafterSprite = helper.Content.Sprites
            .RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/HullGrafter.png")).Sprite;
        
        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new ArtifactMeta
            {
                pools = [ArtifactPool.Boss],
                owner = ModEntry.Instance.RuhigDeck.Deck
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "HullGraft", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "HullGraft", "desc"]).Localize,
            Sprite = HullGrafterSprite
        });
    }
    
    public override void OnCombatEnd(State state)
    {
        state.ship.hullMax += 1;
        state.ship.hull += 1;
    }
    
}