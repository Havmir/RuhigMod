using System;
using System.Collections.Generic;
using Nickel;
using RuhigMod.Cards;

namespace RuhigMod.Actions;

// rft50 is so nice and cool for helping me with this feature :)
// This action is supposed to get you an option to add 1 out of 6 token cards ~ Havmir
// Getting the IsTempQuestionMark to work as intended took like 15 hours to learn how to do btw ... ~ Havmir

public class RuhigSupport : CardAction
{
    public static Spr RuhigSupportSprite;

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
                    new DraconicScales() , new NeedForSpeed() ,
                    new Zoning() , new DraconicShards() ,
                    new PaitenceWrath() , new DraconicPower()
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
                    new DraconicScales() { temporaryOverride = true }, new NeedForSpeed() { temporaryOverride = true },
                    new Zoning() { temporaryOverride = true }, new DraconicShards() { temporaryOverride = true },
                    new PaitenceWrath() { temporaryOverride = true }, new DraconicPower() { temporaryOverride = true }
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
            path = RuhigSupportSprite,
            number = null,
        };
    }

    public override List<Tooltip> GetTooltips(State s)
    {
        var side = "RuhigSupport";
        return
        [
            new GlossaryTooltip($"RuhigSupport::{side}")
            {
                Icon = RuhigSupportSprite,
                Title = ModEntry.Instance.Localizations.Localize(["action", "RuhigSupport", "title"]),
                TitleColor = Colors.card,
                Description = ModEntry.Instance.Localizations.Localize(["action", "RuhigSupport", "desc"], this)
            },

        ];
    }
}