using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;

namespace RuhigMod.Cards; 

public class Support : Card, IRegisterable
{

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
                upgradesTo = [Upgrade.A, Upgrade.B] 
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Support", "name"])
                .Localize,
            Art = StableSpr.cards_Scattershot
        });
    }
        public override List<CardAction> GetActions(State s, Combat c)
    {
        return upgrade switch 
        {
            Upgrade.None => [
                new AStatus()
                {
                    status = Status.overdrive,
                    statusAmount = 1,
                    targetPlayer = true
                },
                new AStatus()
                {
                    status = Status.tableFlip,
                    statusAmount = 1,
                    targetPlayer = true
                },
                new AHeal()
                {
                    targetPlayer = true,
                    healAmount = 1
                },
                new AHurt()
                {
                targetPlayer = true,
                hurtAmount = 2,
                dialogueSelector = ".Support"
                },
            ],
            Upgrade.A => [
                new AStatus()
                {
                    status = Status.powerdrive,
                    statusAmount = 1,
                    targetPlayer = true
                },
                new AStatus()
                {
                status = Status.tableFlip,
                statusAmount = 1,
                targetPlayer = true
                },
                new AHeal()
                {
                    targetPlayer = true,
                    healAmount = 1
                },
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 2,
                    dialogueSelector = ".Support"
                },
            ],
            Upgrade.B => [
                new AStatus() // this being infront of cleanExhaust is intentional, to make this upgrade sneakly less viable as an aggressive card - Havmir
                {
                    status = Status.cleanExhaust,
                    statusAmount = 1,
                    targetPlayer = true
                },
                new AStatus()
                {
                    status = Status.overdrive,
                    statusAmount = 1,
                    targetPlayer = true
                },
                new AStatus()
                {
                    status = Status.tableFlip,
                    statusAmount = 1,
                    targetPlayer = true
                },
                new AHeal()
                {
                    targetPlayer = true,
                    healAmount = 1
                },
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 2,
                    dialogueSelector = ".Support"
                },
            ],
            _ => throw new ArgumentOutOfRangeException()
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
                artTint = "6868b9"
            };
        }
        return default;
    }
};

