using System.Collections.Generic;
using Nickel;
using RuhigMod.Cards;

namespace RuhigMod.Actions;

// This action is supposed to get you an option to add 1 out of 6 token cards, with the B upgrade ~ Havmir

public class RuhigSupportB : CardAction
{
    public static Spr RuhigSupportBSprite;
    
    public bool IsTempQuestionMark;
    
    public override Route? BeginWithRoute(G g, State s, Combat c)
    { 
        if (IsTempQuestionMark == false)
        {
            timer = 0.0;
            return new CardReward()
            {
                cards =
                {
                    new DraconicScales(){upgrade = Upgrade.B }, new NeedForSpeed() {upgrade = Upgrade.B },
                    new Zoning() {upgrade = Upgrade.B }, new DraconicShards() {upgrade = Upgrade.B },
                    new PaitenceWrath() {upgrade = Upgrade.B }, new DraconicPower() {upgrade = Upgrade.B }
                },
                canSkip = false,

            };
        }
        if (IsTempQuestionMark == true)
        {
            timer = 0.0;
            return new CardReward()
            {
                cards =
                {
                    new DraconicScales(){ temporaryOverride = true, upgrade = Upgrade.B }, new NeedForSpeed() { temporaryOverride = true, upgrade = Upgrade.B },
                    new Zoning() { temporaryOverride = true, upgrade = Upgrade.B }, new DraconicShards() { temporaryOverride = true, upgrade = Upgrade.B },
                    new PaitenceWrath() { temporaryOverride = true, upgrade = Upgrade.B }, new DraconicPower() { temporaryOverride = true, upgrade = Upgrade.B }
                },
                canSkip = false,

            };
        }
        return default;
    }


    public override Icon? GetIcon(State s)
    {
        return new Icon
        {
            path = RuhigSupportBSprite,
            number = null,
        };
    }

    public override List<Tooltip> GetTooltips(State s)
    {
        var side = "B";
        return
        [

            new GlossaryTooltip($"RuhigSupportB::{side}")
            {
                Icon = RuhigSupportBSprite,
                Title = ModEntry.Instance.Localizations.Localize(["action", "RuhigSupportB", "title"]),
                TitleColor = Colors.card,
                Description = ModEntry.Instance.Localizations.Localize(["action", "RuhigSupportB", "desc"], this)
            },

        ];
    }


}