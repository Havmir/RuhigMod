using System.Reflection;

using Nanoray.PluginManager;
using Nickel;

namespace RuhigMod.Artifacts;

// Artifact that heals
// Note, this can be reworked to be something that heals when you gain an artifact for a belnce adjustment: https://discord.com/channels/806989214133780521/1138540954761035827/1392961319216349255
public class HealthPotion : Artifact, IRegisterable
{
    public static Spr HealthPotionSprite;
    public static Spr HealthPotionDrank;
    public static void Register(IPluginPackage<IModManifest> package, IModHelper helper)
    {
        HealthPotionSprite = ModEntry.RegisterSprite(package, "assets/Artifact/HealthPotion.png").Sprite;
        HealthPotionDrank = ModEntry.RegisterSprite(package, "assets/Artifact/HealthPotionDrank.png").Sprite;
        
        helper.Content.Artifacts.RegisterArtifact(new ArtifactConfiguration
        {
            ArtifactType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new ArtifactMeta
            {
                pools = [ArtifactPool.Common],
                owner = ModEntry.Instance.RuhigDeck.Deck
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "HealthPotion", "name"]).Localize,
            Description = ModEntry.Instance.AnyLocalizations.Bind(["artifact", "HealthPotion", "desc"]).Localize,
            Sprite = HealthPotionSprite
        });
    }

    public int GetShipMaxHull(State state)
    {
        return state.ship.hullMax;
    }
    
    public override void OnReceiveArtifact(State state)
    {
        state.GetCurrentQueue().QueueImmediate(new AHeal
        {
            healAmount = GetShipMaxHull(state) / 2,
            targetPlayer = true
        });
        AlreadyActivated = true;
    }
    
    public override string Description()
    {
        return "Heal half of your ship's hull rounded down.";
    }
    
    public bool AlreadyActivated;
    public override Spr GetSprite()
    {
        return !AlreadyActivated ? HealthPotionSprite : HealthPotionDrank;
    }
}