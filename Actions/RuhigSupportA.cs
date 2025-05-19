using System.Collections.Generic;
using Nickel;
using RuhigMod.Cards;

namespace RuhigMod.Actions;
// This action is supposed to get you an option to add 1 out of 6 token cards, with the A upgrade ~ Havmir

public class RuhigSupportA : CardAction
{
    public static Spr RuhigSupportASprite;
    
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
                    new DraconicScales(){upgrade = Upgrade.A }, new NeedForSpeed() {upgrade = Upgrade.A },
                    new Zoning() {upgrade = Upgrade.A }, new DraconicShards() {upgrade = Upgrade.A },
                    new PaitenceWrath() {upgrade = Upgrade.A }, new DraconicPower() {upgrade = Upgrade.A }
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
                    new DraconicScales(){ temporaryOverride = true, upgrade = Upgrade.A }, new NeedForSpeed() { temporaryOverride = true, upgrade = Upgrade.A },
                    new Zoning() { temporaryOverride = true, upgrade = Upgrade.A }, new DraconicShards() { temporaryOverride = true, upgrade = Upgrade.A },
                    new PaitenceWrath() { temporaryOverride = true, upgrade = Upgrade.A }, new DraconicPower() { temporaryOverride = true, upgrade = Upgrade.A }
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
            path = RuhigSupportASprite,
            number = null,
        };
    }

    public override List<Tooltip> GetTooltips(State s)
    {
        var side = "RuhigSupportA";
        return
        [

            new GlossaryTooltip($"RuhigSupportA::{side}")
            {
                Icon = RuhigSupportASprite,
                Title = ModEntry.Instance.Localizations.Localize(["action", "RuhigSupportA", "title"]),
                TitleColor = Colors.card,
                Description = ModEntry.Instance.Localizations.Localize(["action", "RuhigSupportA", "desc"], this)
            },

        ];
    }


}