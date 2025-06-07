using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class Zoning : Card, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Zoning", "name"])
                .Localize,
            Art = StableSpr.cards_goat,
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
                    hurtAmount = 1
                },
                new AStatus()
                {
                    status = Status.droneShift,
                    statusAmount = 2,
                    targetPlayer = true
                },
                new ASpawn()
                {
                    thing = new SpaceMine(),
                    offset = -1
                },
                new ASpawn()
                {
                    thing = new SpaceMine(),
                    offset = 0
                },
                new ASpawn()
                {
                    thing = new SpaceMine(),
                    offset = 1
                }
            ],
            Upgrade.A => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1
                },
                new AStatus()
                {
                    status = Status.droneShift,
                    statusAmount = 2,
                    targetPlayer = true
                },
                new ASpawn()
                {
                    thing = new Asteroid()
                    {
                        bubbleShield = true
                    },
                    offset = -1
                },
                new ASpawn()
                {
                    thing = new Asteroid()
                    {
                        bubbleShield = true
                    },
                    offset = 0
                },
                new ASpawn()
                {
                    thing = new Asteroid()
                    {
                        bubbleShield = true
                    },
                    offset = 1
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
                    status = Status.droneShift,
                    statusAmount = 2,
                    targetPlayer = true
                },
                new ASpawn()
                {
                    thing = new Asteroid(),
                    offset = -1
                },
                new ASpawn()
                {
                    thing = new Asteroid(),
                    offset = 0
                },
                new ASpawn()
                {
                    thing = new Asteroid(),
                    offset = 1
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
                cost = 1, 
                exhaust = true,
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 1,
                exhaust = true,
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.None)
        {
            return new CardData()
            {
                cost = 1,
                exhaust = true,
                artTint = "6868b9"
            };
        }
        return default;
    }
};

