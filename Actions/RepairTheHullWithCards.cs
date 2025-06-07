
using FMOD;
using Nickel;

namespace RuhigMod.Actions;


using System.Collections.Generic;


public class RepairTheHullWithCards : CardAction
{
    private int Count;
    public static Spr InvisableRuhigSupportSprite;
    public static Spr endTurnIconFromCobaltCore;
    
    public override void Begin(G g, State s, Combat c)
    {
        timer = 0.0;
        foreach (Card card in c.hand)
            c.Queue( new DestroyThisCardEffect()
            {
                uuid = card.uuid
            });
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
