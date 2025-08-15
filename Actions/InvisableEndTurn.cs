
using Nickel;

namespace RuhigMod.Actions;


using System.Collections.Generic;


public class InvisableEndTurn : CardAction
{
    public static Spr InvisableRuhigSupportSprite;
    
    public override void Begin(G g, State s, Combat c)
    {
        timer = 0.0;
        foreach (CardAction cardAction in c.cardActions)
        {
            if (cardAction is AEndTurn)
                return;
        }
        c.isPlayerTurn = false;
        c.Queue( new ADiscard()
        {
            ignoreRetain = true
        });
        c.Queue( new AAfterPlayerTurn());
    }

    public override Icon? GetIcon(State s)
    {
        return new Icon
        {
            path = InvisableRuhigSupportSprite,
            number = null,
        };
    }

    public override List<Tooltip> GetTooltips(State s)
    {
        return
        [
            //new GlossaryTooltip($"FakeEndTurn::{side}")
            //{
                //Icon = endTurnIconFromCobaltCore,
                //Title = ModEntry.Instance.Localizations.Localize(["action", "FakeEndTurn", "title"]),
                //TitleColor = Colors.card,
                //Description = ModEntry.Instance.Localizations.Localize(["action", "FakeEndTurn", "desc"], this)
            //},
        ];
    }
}
