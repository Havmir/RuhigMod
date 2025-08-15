
using Nickel;

namespace RuhigMod.Actions;


using System.Collections.Generic;


public class FakeEndTurn : CardAction
{
    public static Spr endTurnIconFromCobaltCore;
    
    public override void Begin(G g, State s, Combat c)
    {
        // Yep, this does nothing, the other half of the magic is in FakeEndTurn.cs ~ Havmir
    }

    public override Icon? GetIcon(State s)
    {
        return new Icon
        {
            path = endTurnIconFromCobaltCore,
            number = null,
        };
    }

    public override List<Tooltip> GetTooltips(State s)
    {
        var side = "FakeEndTurn";
        return
        [
            new GlossaryTooltip($"FakeEndTurn::{side}")
            {
                Icon = endTurnIconFromCobaltCore,
                Title = ModEntry.Instance.Localizations.Localize(["action", "FakeEndTurn", "title"]),
                TitleColor = Colors.card,
                Description = ModEntry.Instance.Localizations.Localize(["action", "FakeEndTurn", "desc"], this)
            },
        ];
    }
}
