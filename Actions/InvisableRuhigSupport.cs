using System;
using System.Collections.Generic;
using Nickel;
using RuhigMod.Cards;

namespace RuhigMod.Actions;

// Yeah, this exists as I couldn't figure out how to que two CardRewards within the same custom action. So we have an invisable action instead. ~ Havmir

public class InvisableRuhigSupport : CardAction
{
    public static Spr InvisableRuhigSupportSprite;

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
            path = InvisableRuhigSupportSprite,
            number = null,
        };
    }

    public override List<Tooltip> GetTooltips(State s)
    {
        var side = "InvisableRuhigSupport";
        return
        [
            /*
            new GlossaryTooltip($"InvisableRuhigSupport::{side}")
            {
                // Icon = DoubleRuhigSupportSprite,
                // Title = ModEntry.Instance.Localizations.Localize(["action", "InvisableRuhigSupport", "title"]),
                // TitleColor = Colors.card,
                // Description = ModEntry.Instance.Localizations.Localize(["action", "InvisableRuhigSupport", "desc"], this)
            },
            */
        ];
    }

}