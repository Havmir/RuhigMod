using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.Actions;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class ExpandHull : Card, IRegisterable
{

    private static IKokoroApi.IV2.IConditionalApi Conditional => ModEntry.Instance.KokoroApi.Conditional;
    
    
    public static void
        

        Register(IPluginPackage<IModManifest> package,
            IModHelper helper)
    {
            
        helper.Content.Cards.RegisterCard(new CardConfiguration
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new CardMeta
            {
                deck = ModEntry.Instance.RuhigDeck
                    .Deck, 
                rarity = Rarity.rare, 
                dontOffer = false, 
                upgradesTo = [Upgrade.A, Upgrade.B],
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "ExpandHull", "name"])
                .Localize,
            Art = ModEntry.RegisterSprite(package, "assets/Card/IDontKnowWhatToDoForArtWork.png").Sprite

        });
    }

    public override List<CardAction> GetActions(State s, Combat c)
    {
        return upgrade switch 
        {
            Upgrade.A => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 2
                },
                new AHullMax()
                {
                    targetPlayer = true,
                    amount = 5
                },
                new RuhigSupport()
                {
                    ExtraHullCard = true,
                    IsTempQuestionMark = ModEntry.Instance.Helper.Content.Cards.IsCardTraitActive(s, this, ModEntry.Instance.Helper.Content.Cards.TemporaryCardTrait )
                }
            ],
            Upgrade.B => [
                new AHeal()
                {
                    targetPlayer = true,
                    healAmount = 2
                },
                new RuhigSupport()
                {
                    ExtraHullCard = false,
                    IsTempQuestionMark = true
                }
            ],
            Upgrade.None => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 2
                },
                new AHullMax()
                {
                    targetPlayer = true,
                    amount = 5
                },
                new RuhigSupport()
                {
                    ExtraHullCard = true,
                    IsTempQuestionMark = ModEntry.Instance.Helper.Content.Cards.IsCardTraitActive(s, this, ModEntry.Instance.Helper.Content.Cards.TemporaryCardTrait )
                }
            ]
        };
    }






    public override CardData GetData(State state)
    {
        if (upgrade == Upgrade.A)
        {
            return new CardData()
            {
                cost = 2,
                singleUse = true,
                description = "<c=damage>Lose 2 Hull.</c> <c=heal>Gain 5 max hull</c> & 1 non-exhaust <c=cardtrait> Ruhig Support.</c>"
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 2,
                exhaust = true,
                description = "<c=heal>Heal 2.</c> Gain 1 temp <c=cardtrait> Ruhig Support.</c>"
            };
        }
        if (upgrade == Upgrade.None)
        {
            return new CardData()
            {
                cost = 3,
                singleUse = true,
                description = "<c=damage>Lose 2 Hull.</c> <c=heal>Gain 5 max hull</c> & 1 non-exhaust <c=cardtrait> Ruhig Support.</c>"
            };
        }
        return default;
    }
};

