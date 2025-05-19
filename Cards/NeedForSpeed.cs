using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class NeedForSpeed : Card, IRegisterable
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
                dontOffer = true, 
                upgradesTo = [Upgrade.A, Upgrade.B] 
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "NeedForSpeed", "name"])
                .Localize,
            Art = StableSpr.cards_riggs,
        });
    }
        public override List<CardAction> GetActions(State s, Combat c)
    {
        return upgrade switch 
        {
            Upgrade.B => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 2 
                },
                new AStatus()
                {
                    status = Status.evade,
                    statusAmount = 15,
                    targetPlayer = true
                }
            ],
            Upgrade.A => [
                new AStatus()
                {
                    status = Status.evade,
                    statusAmount = 5,
                    targetPlayer = true
                },
                new AStatus()
                {
                status = Status.loseEvadeNextTurn,
                statusAmount = 1,
                targetPlayer = true
                }
            ],
            Upgrade.None => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1 
                },
                new AStatus()
                {
                    status = Status.evade,
                    statusAmount = 5,
                    targetPlayer = true
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
                exhaust = false,
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 1,
                exhaust = false,
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.None)
        {
            return new CardData()
            {
                cost = 1,
                exhaust = false,
                artTint = "6868b9"
            };
        }
        return default;
    }
};

