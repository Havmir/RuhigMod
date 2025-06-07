using System.Collections.Generic;
using System.Linq;
using Nickel;

namespace RuhigMod.Actions;

// This action is usd for the expand hull card - Havmir
public class ExpandHullTracking : CardAction
{
    public static Spr ExpandHullTrackingSprite;
    
    public override void Begin(G g, State s, Combat c)
    {
        ModEntry.Instance.Helper.ModData.SetModData(c, "ExpandHullTracking", 0);
    }
    
    /* public override Icon? GetIcon(State s)
    {
        return new Icon
        {
            path = SelfDestructSprite,
            number = null,
        };
    } */
    
    public override List<Tooltip> GetTooltips(State s)
    {
        var side = "ExpandHullTracking";
        return
        [
            new GlossaryTooltip($"ExpandHullTracking::{side}")
            {
                // Icon = SelfDestructSprite,
                Title = ModEntry.Instance.Localizations.Localize(["action", "ExpandHullTracking", "title"]),
                TitleColor = Colors.card,
                Description = ModEntry.Instance.Localizations.Localize(["action", "ExpandHullTracking", "desc"], this)
            }
        ];
    }
}