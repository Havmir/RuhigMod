using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class DisposableHull : Card, IRegisterable
{

    private static IKokoroApi.IV2.IConditionalApi Conditional => ModEntry.Instance.KokoroApi.Conditional; 
    public static Spr DisposableHullB;
    
    public static void
        Register(IPluginPackage<IModManifest> package,
            IModHelper helper) 
    {
        DisposableHullB = ModEntry.RegisterSprite(package, "assets/Card/DisposableHullB.png").Sprite;
        
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "DisposableHull", "name"])
                .Localize,
            Art = ModEntry.RegisterSprite(package, "assets/Card/DisposableHull.png").Sprite
        });
    }
        public override List<CardAction> GetActions(State s, Combat c)
        {
            int x;
            return upgrade switch 
        {
            Upgrade.None => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1
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
            ],
            Upgrade.A => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1
                },
                new ASpawn()
                {
                    thing = new Asteroid(),
                    offset = -2
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
                },
            ],
            Upgrade.B => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1
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
            ]
        };
        }

    public override CardData GetData(State state)
    {
        if (upgrade == Upgrade.None) 
        {
            return new CardData()
            {
                cost = 0, 
                flippable = true,
                artTint = "6868b9",
                retain = true
            };
        }
        if (upgrade == Upgrade.A)
        {
            return new CardData()
            {
                cost = 0,
                flippable = true,
                artTint = "6868b9",
                retain = true
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 1,
                flippable = true,
                artTint = "6868b9",
                art = DisposableHullB,
                retain = true
            };
        }
        return default;
    }
};

