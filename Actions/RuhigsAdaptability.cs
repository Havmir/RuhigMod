using System.Collections.Generic;
using Nickel;

namespace RuhigMod.Actions;
// This action is usd to show an icon to the player when one half of a card will be exhausted for dual cards. ~ Havmir
public class RuhigsAdaptability : CardAction
{
    public static Spr RuhigsAdaptabilitySprite;
    
    public override void Begin(G g, State s, Combat c)
    {

    }
    
    public override Icon? GetIcon(State s)
    {
        return new Icon
        {
            path = RuhigsAdaptabilitySprite,
            number = null,
        };
    }
    
    public override List<Tooltip> GetTooltips(State s)
    {
        var side = "RuhigsAdaptability";
        return
        [
            new GlossaryTooltip($"RuhigsAdaptability::{side}")
            {
                Icon = RuhigsAdaptabilitySprite,
                Title = ModEntry.Instance.Localizations.Localize(["action", "RuhigsAdaptability", "title"]),
                TitleColor = Colors.card,
                Description = ModEntry.Instance.Localizations.Localize(["action", "RuhigsAdaptability", "desc"], this)
            }
        ];
    }
}