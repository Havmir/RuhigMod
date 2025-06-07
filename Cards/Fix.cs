using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class Fix : Card, IRegisterable
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
                dontOffer = false, 
                upgradesTo = [Upgrade.A, Upgrade.B] 
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Fix", "name"])
                .Localize,
            Art = StableSpr.cards_Repairs,
        });
    }
        public override List<CardAction> GetActions(State s, Combat c)
    {
        return upgrade switch 
        {
            Upgrade.None => [
                new AExhaustEntireHand(),
                new AHeal()
                {
                    targetPlayer = true,
                    healAmount = 1,
                },
                new AEndTurn()
            ],
            Upgrade.A => [
                new AExhaustEntireHand(),
                new AHeal()
                {
                    targetPlayer = true,
                    healAmount = 2,
                },
                new AEndTurn()
            ],
            Upgrade.B => [
                new AExhaustEntireHand(),
                new AHeal()
                {
                    targetPlayer = true,
                    healAmount = 1,
                },
                new AEndTurn()
            ]
        };
    }

    public override CardData GetData(State state)
    {
        if (upgrade == Upgrade.None) 
        {
            return new CardData()
            {
                cost = 2, 
                exhaust = true,
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.A)
        {
            return new CardData()
            {
                cost = 2,
                exhaust = true,
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 3,
                exhaust = true,
                retain = true,
                artTint = "6868b9"
            };
        }
        return default;
    }
};

