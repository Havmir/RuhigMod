using System.Collections.Generic;
using System.Linq;
using Nickel;

namespace RuhigMod.Actions;

// This action is usd to show an icon to the player when one half of a card will self desturct for dual card. - Havmir
public class SelfDestruct : CardAction
{
    public static Spr SelfDestructSprite;
    
    public override void Begin(G g, State s, Combat c)
    {
        
    }
    
    public override Icon? GetIcon(State s)
    {
        return new Icon
        {
            path = SelfDestructSprite,
            number = null,
        };
    }
    
    public override List<Tooltip> GetTooltips(State s)
    {
        var side = "SelfDestruct";
        return
        [
            new GlossaryTooltip($"SelfDestruct::{side}")
            {
                Icon = SelfDestructSprite,
                Title = ModEntry.Instance.Localizations.Localize(["action", "SelfDestruct", "title"]),
                TitleColor = Colors.card,
                Description = ModEntry.Instance.Localizations.Localize(["action", "SelfDestruct", "desc"], this)
            }
        ];
    }
}