using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class Support : Card, IRegisterable
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
                    status = Status.tableFlip,
                    statusAmount = 1,
                    targetPlayer = true
                },
                new AStatus()
                {
                    status = Status.overdrive,
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
                hurtAmount = 2 
                },
                new AStatus()
                {
                    status = Status.evade,
                    statusAmount = 2,
                    targetPlayer = true
                }
            ],
            Upgrade.A => [
                new AStatus()
                {
                    status = Status.tableFlip,
                    statusAmount = 1,
                    targetPlayer = true
                },
                new AStatus()
                {
                status = Status.powerdrive,
                statusAmount = 1,
                targetPlayer = true
                },
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1 
                },
                new AStatus()
                {
                    status = Status.evade,
                    statusAmount = 2,
                    targetPlayer = true
                }
            ],
            Upgrade.B => [
                new AStatus()
                {
                    status = Status.tableFlip,
                    statusAmount = 1,
                    targetPlayer = true
                },
                new AStatus()
                {
                    status = Status.cleanExhaust,
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
                    hurtAmount = 2
                },
                new AStatus()
                {
                    status = Status.evade,
                    statusAmount = 1,
                    targetPlayer = true
                }
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
                artTint = "6868b9"
            };
        }
        return default;
    }
};

