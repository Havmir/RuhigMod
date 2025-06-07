using System.Reflection;
using Nanoray.PluginManager;
using Nickel;

namespace RuhigMod.Artifacts;
// Common Artifact that adds 5 max hull and heals 2 on pick-up ~ Havmir
public class HullAddOn : Artifact, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "HullAddOn", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "HullAddOn", "desc"]).Localize,

            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/HullAddOn.png")).Sprite
        });
    }
    
    public override void OnReceiveArtifact(State state)
    {
        state.ship.hullMax += 5;
        int baseAmount = 5;
        int amount = baseAmount;
        foreach (Artifact enumerateAllArtifact in state.EnumerateAllArtifacts())
            amount += enumerateAllArtifact.ModifyHealAmount(baseAmount, state, true);
        state.ship.Heal(2);
    }
}