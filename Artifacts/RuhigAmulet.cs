using System.Reflection;
using Nanoray.PluginManager;
using Nickel;

namespace RuhigMod.Artifacts;


// Common Artifact that heals one when you lose 2 hull in a single turn once per combat ~ Havmir

public class RuhigAmulet : Artifact, IRegisterable
{
    private bool _alreadyActivated;
    public static Spr MeldHullOnSprite;
    public static Spr MeldHullOffSprite;
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        
        MeldHullOnSprite = ModEntry.RegisterSprite(package, "assets/Artifact/RuhigAmuletPre.png").Sprite;
        MeldHullOffSprite = ModEntry.RegisterSprite(package, "assets/Artifact/RuhigAmuletPost.png").Sprite;
        
        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new ArtifactMeta
            {
                pools = [ArtifactPool.Common],
                owner = ModEntry.Instance.RuhigDeck.Deck
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "MeldHull", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "MeldHull", "desc"]).Localize,
            Sprite = MeldHullOnSprite
        });
    }

    public int HullLostManagersNumber(Combat combat)
    {
        return ModEntry.Instance.Helper.ModData.GetModDataOrDefault(combat, "hullLostNumber", 0);
    }
    
    public override Spr GetSprite()
    {
        return !_alreadyActivated ? MeldHullOnSprite : MeldHullOffSprite;
    }
    
    public override void OnPlayerLoseHull(State state, Combat combat, int amount)
    {
        if (_alreadyActivated)
            return;
        if (HullLostManagersNumber(combat) >= 2)
        {
            _alreadyActivated = true;
            Combat combat1 = combat;
            AHeal a = new AHeal();
            a.targetPlayer = true;
            a.healAmount = 1;
            a.artifactPulse = Key();
            combat1.QueueImmediate(a);
        }
        if (HullLostManagersNumber(combat) < 2)
        {
        }
    }
    
    public override void OnCombatEnd(State state) => _alreadyActivated = false;
}
