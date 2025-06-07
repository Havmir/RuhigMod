using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using System.Collections.Generic;

namespace RuhigMod.Artifacts;
// Boss artifacts that sacrifies some of your max hull for 2 other boss artifacts

public class HullArtifacts : Artifact, IRegisterable
{
    private static Spr HullArtifactsSprite;

    
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        HullArtifactsSprite = helper.Content.Sprites
            .RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/HullArtifacts.png")).Sprite;
        
        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new ArtifactMeta
            {
                pools = [ArtifactPool.Boss],
                owner = ModEntry.Instance.RuhigDeck.Deck
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "HullArtifacts", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "HullArtifacts", "desc"]).Localize,
            /*
             * For Artifacts with multiple sprites, a sprite must still be defined.
             */
            Sprite = HullArtifactsSprite
        });
    }
    public override string Description()
    {
        return "If you see this, tell me you found the missing desctiption (and tell me where).";
    }

    public override void OnReceiveArtifact(State state)
    {
        state.ship.hullMax = (state.ship.hullMax * 3/4);
        if (state.ship.hullMax < state.ship.hull)
        {
            state.ship.hull = state.ship.hullMax;
        }
        
        state.GetCurrentQueue().QueueImmediate<CardAction>((CardAction) new AArtifactOffering()
        {
            amount = 2,
            limitPools = new List<ArtifactPool>()
            {
                ArtifactPool.Boss
            }
        });
        state.GetCurrentQueue().QueueImmediate<CardAction>((CardAction)new AArtifactOffering()
        {
            amount = 4,
            limitPools = new List<ArtifactPool>()
            {
                ArtifactPool.Boss
            }
        });
    }
}
   
