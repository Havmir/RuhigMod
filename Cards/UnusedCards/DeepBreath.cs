using System;
using System.Collections.Generic;
using System.Reflection;
using RuhigMod.Actions;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class DeepBreath : Card, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "DeepBreath", "name"])
                .Localize,
            
        });
    }
        public override List<CardAction> GetActions(State s, Combat c) 
    {
        return upgrade switch 
        {
            Upgrade.B => [
                new AStatus()
                {
                    status = Status.tempShield,
                    statusAmount = 1,
                    targetPlayer = true
                },
                new AStatus()
                {
                    status = Status.evade,
                    statusAmount = 1,
                    targetPlayer = true
                },
                new ADrawCard()
                {
                    count = 1
                }
            ],
            Upgrade.A => [
                new AStatus()
                {
                    status = Status.tempShield,
                    statusAmount = 2,
                    targetPlayer = true
                },
                new AStatus()
                {
                    status = Status.evade,
                    statusAmount = 1,
                    targetPlayer = true
                },
            ],
            Upgrade.None => [
                new CardSelectDuplicate(),
                new AStatus()
                {
                    status = Status.tempShield,
                    statusAmount = 1,
                    targetPlayer = true
                },
                new AStatus()
                {
                    status = Status.evade,
                    statusAmount = 1,
                    targetPlayer = true
                },
            ]
        };
    }

    public override CardData GetData(State state)
    {
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 0,
                artTint = "6868b9",
                art = StableSpr.cards_FumeCannon,
                exhaust = true
            };
        }
        if (upgrade == Upgrade.A)
        {
            return new CardData()
            {
                cost = 1,
                artTint = "6868b9",
                art = StableSpr.cards_FumeCannon
            };
        }
        if (upgrade == Upgrade.None)
        {
            return new CardData()
            {
                cost = 1,
                artTint = "6868b9",
                art = StableSpr.cards_FumeCannon
            };
        }
        return default;
    }
};

