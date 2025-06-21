using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.Actions;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class Meditation : Card, IRegisterable
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
                rarity = Rarity.common, 
                dontOffer = false, /* 767 */
                upgradesTo = [Upgrade.A, Upgrade.B] 
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Meditation", "name"])
                .Localize,

            Art = StableSpr.cards_eunice,
        });
    }
        public override List<CardAction> GetActions(State s, Combat c)
    {
        return upgrade switch 
        {
            Upgrade.None => [
                new ADiscard()
                {   
                    count = 2
                },
                new ADrawCard()
                {
                    count = 2
                },
            ],
            Upgrade.A => [
                new ADiscard()
                {   
                    count = 3
                },
                new ADrawCard()
                {
                    count = 4
                },
            ],
            Upgrade.B => [
                new ADiscard()
                {   
                    count = 2
                },
                new ADrawCard()
                {
                    count = 2
                },
            ]
        };
    }

    public override CardData GetData(State state)
    {
        if (upgrade == Upgrade.None)
        {
            return new CardData()
            {
                cost = 1,
                artTint = "6868b9",
                singleUse = false,
            };
            
        }
        if (upgrade == Upgrade.A)
        {
            return new CardData()
            {
                cost = 1,
                artTint = "6868b9",
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 0,
                artTint = "6868b9",
            };
        }
        return default;
    }
};

