using System.Reflection;

using Nanoray.PluginManager;
using Nickel;

namespace RuhigMod.Artifacts;

// Artifact that gives all healing a 50% boost
public class RuhigsRepairKit : Artifact, IRegisterable
{
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new ArtifactMeta
            {
                pools = [ArtifactPool.Common],
                owner = ModEntry.Instance.RuhigDeck.Deck
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "RuhigsRepairKit", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "RuhigsRepairKit", "desc"]).Localize,
 
            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/RepairKit.png")).Sprite
        });
    }
    
    public override int ModifyHealAmount(int baseAmount, State state, bool targetPlayer)
    {
        return targetPlayer ? baseAmount *1/2 : 0;
    }
}