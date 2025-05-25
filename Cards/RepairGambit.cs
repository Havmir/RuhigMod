using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class RepairGambit : Card, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "RepairGambit", "name"])
                .Localize, 
            Art = StableSpr.cards_Repairs
        });
    }
        public override List<CardAction> GetActions(State s, Combat c) 
    {
        return upgrade switch 
        {
            Upgrade.None => [
                new AHeal()
                {
                    targetPlayer = true,
                    healAmount = 2 
                },
                new AStatus()
                {
                    status = Status.shield,
                    statusAmount = 0,
                    mode = AStatusMode.Set,
                    targetPlayer = true
                },
                new AStatus()
                {
                    status = Status.loseEvadeNextTurn,
                    statusAmount = 1,
                    targetPlayer = true
                },
                new AEndTurn()
            ],
            Upgrade.B => [
                new AHeal()
                {
                    targetPlayer = true,
                    healAmount = 4 
                },
                new AStatus()
                {
                    status = Status.shield,
                    statusAmount = 0,
                    mode = AStatusMode.Set,
                    targetPlayer = true
                },
                new AStatus()
                {
                    status = Status.loseEvadeNextTurn,
                    statusAmount = 1,
                    targetPlayer = true
                },
                new AStatus()
                {
                status = Status.powerdrive,
                statusAmount = 2,
                targetPlayer = false
                },
                new AEndTurn()
            ],
            Upgrade.A => [
                new AHeal()
                {
                    targetPlayer = true,
                    healAmount = 2 
                },
                new AStatus()
                {
                    status = Status.shield,
                    statusAmount = -2,
                    targetPlayer = true
                },
                new AStatus()
                {
                    status = Status.evade,
                    statusAmount = -2,
                    targetPlayer = true
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
                cost = 1, 
                exhaust = true,
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.A)
        {
            return new CardData()
            {
                cost = 1,
                exhaust = true,
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 0,
                exhaust = true,
                artTint = "6868b9"
            };
        }
        return default;
    }
};

