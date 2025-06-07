using System.Reflection;
using Nanoray.PluginManager;
using Nickel;

namespace RuhigMod.Artifacts;

public class HullBlink : Artifact, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "HullBlink", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "HullBlink", "desc"]).Localize,

            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/HullPlating.png")).Sprite
        });
    }
    /* Data about the artifact above. Artifact effect below */

    public override void OnTurnStart(State state, Combat combat)
    {
        Combat combat2 = combat;
        AHurt b = new AHurt();
        b.hurtAmount = 1;
        b.targetPlayer = true;
        b.timer = 0.0;
        combat2.QueueImmediate(b);
        
        Combat combat1 = combat;
        AHeal a = new AHeal();
        a.healAmount = 1;
        a.targetPlayer = true;
        a.timer = 0.0;
        combat1.QueueImmediate(a);
        


    }
}