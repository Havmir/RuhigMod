using System;
using System.Collections.Generic;
using Nickel;
using RuhigMod.Cards;

namespace RuhigMod.Actions;

// If you are looking at how I managed to get two card offerings in one custom action, I am sorry to disapoint you ...
// I used two actions instead, just one of them was invisable (InvisableRuhigSupport). ~ Havmir

public class RuhigSupportDouble : CardAction
{

public static Spr RuhigSupportDoubleSprite;

public bool IsTempQuestionMark;
public bool ExtraHullCard;

public override Route? BeginWithRoute(G g, State s, Combat c)
    {
        
        
        if (IsTempQuestionMark == false && ExtraHullCard == false)
        {
            timer = 0.0;
            return new CardReward()
            {
                cards =
                {
                    new DraconicScales(), new NeedForSpeed() ,
                    new Zoning() , new DraconicShards() ,
                    new PaitenceWrath() , new DraconicPower()
                },
                canSkip = false,
            };
        }
        if (IsTempQuestionMark == true && ExtraHullCard == false)
        {
            timer = 0.0;
            return new CardReward()
            {
                cards =
                {
                    new DraconicScales() { temporaryOverride = true }, new NeedForSpeed() { temporaryOverride = true },
                    new Zoning() { temporaryOverride = true }, new DraconicShards() { temporaryOverride = true },
                    new PaitenceWrath() { temporaryOverride = true }, new DraconicPower() { temporaryOverride = true }
                },
                canSkip = false,
            };
        }
        if (ExtraHullCard == true && IsTempQuestionMark == false)
        {
            timer = 0.0;
            return new CardReward()
            {
                cards =
                {
                    new DraconicScales() { exhaustOverride = false }, new NeedForSpeed() { exhaustOverride = false },
                    new Zoning() { exhaustOverride = false }, new DraconicShards() { exhaustOverride = false },
                    new PaitenceWrath() { exhaustOverride = false }, new DraconicPower() { exhaustOverride = false }
                },
                canSkip = false,
            };
        }
        if (ExtraHullCard == false && IsTempQuestionMark == true)
        {
            timer = 0.0;
            return new CardReward()
            {
                cards =
                {
                    new DraconicScales() { temporaryOverride = true, exhaustOverride = false }, new NeedForSpeed() { temporaryOverride = true, exhaustOverride = false },
                    new Zoning() { temporaryOverride = true, exhaustOverride = false }, new DraconicShards() { temporaryOverride = true, exhaustOverride = false },
                    new PaitenceWrath() { temporaryOverride = true, exhaustOverride = false }, new DraconicPower() { temporaryOverride = true, exhaustOverride = false }
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
        path = RuhigSupportDoubleSprite,
        number = null,
    };
}

public override List<Tooltip> GetTooltips(State s)
{
    var side = "RuhigSupportDouble";
    return
    [
        new GlossaryTooltip($"RuhigSupportDouble::{side}")
        {
            Icon = RuhigSupportDoubleSprite,
            Title = ModEntry.Instance.Localizations.Localize(["action", "RuhigSupportDouble", "title"]),
            TitleColor = Colors.card,
            Description = ModEntry.Instance.Localizations.Localize(["action", "RuhigSupportDouble", "desc"], this)
        },

    ];
}
}

// new DraconicScales() { upgrade = upgradeCheck, temporaryOverride = tempCheck, exhaustOverride = false } , new NeedForSpeed() { upgrade = upgradeCheck, temporaryOverride = tempCheck, exhaustOverride = false },
// new Zoning() { upgrade = upgradeCheck, temporaryOverride = tempCheck, exhaustOverride = false }, new DraconicShards() { upgrade = upgradeCheck, temporaryOverride = tempCheck, exhaustOverride = false },
// new PaitenceWrath() { upgrade = upgradeCheck, temporaryOverride = tempCheck, exhaustOverride = false }, new DraconicPower() { upgrade = upgradeCheck, temporaryOverride = tempCheck, exhaustOverride = false }