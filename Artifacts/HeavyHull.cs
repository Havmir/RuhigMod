using System.Reflection;
using Nanoray.PluginManager;
using Nickel;

namespace RuhigMod.Artifacts;


// Common Artifact that adds max hull, heals a little and gives some extra sheild capabilityies, for the cost of making it harder to move ~ Havmir

public class HeavyHull : Artifact, IRegisterable


{
 
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new ArtifactMeta
            {
                pools = [ArtifactPool.Boss],
                owner = ModEntry.Instance.RuhigDeck.Deck
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "HeavyHull", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "HeavyHull", "desc"]).Localize,

            Sprite = helper.Content.Sprites.RegisterSprite(package.PackageRoot.GetRelativeFile("assets/Artifact/HeavyHull.png")).Sprite
        });
    }
    // Data about the artifact above. Artifact effect below ~ Havmir

    public override void OnTurnStart(State state, Combat combat)
    {
        
        if (state.ship.Get(Status.engineStall) < 2)
        {
            combat.QueueImmediate([
                new AStatus
                {
                    status = Status.engineStall,
                    statusAmount = 2,
                    mode = AStatusMode.Set,
                    targetPlayer = true
                }
            ]);
        }
    }
    public override void OnReceiveArtifact(State state)
    {
        state.ship.hullMax += 15;
        state.ship.shieldMaxBase += 5;
        int baseAmount = 10;
        int amount = baseAmount;
        foreach (Artifact enumerateAllArtifact in state.EnumerateAllArtifacts())
            amount += enumerateAllArtifact.ModifyHealAmount(baseAmount, state, true);
        state.ship.Heal(amount);
    }

    public override void OnCombatStart(State state, Combat combat)
    {
        new AStatus
        {
            status = Status.shield,
            statusAmount = 5,
            targetPlayer = true
        };
    }
}