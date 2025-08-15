using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;

namespace RuhigMod.Cards; 

public class SwordShot : Card, IRegisterable
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
                rarity = Rarity.common, 
                dontOffer = true, 
                upgradesTo = [Upgrade.A, Upgrade.B] 
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "SwordShot", "name"])
                .Localize,
            Art = ModEntry.RegisterSprite(package, "assets/Card/Sword.png").Sprite
        });
    }
        public override List<CardAction> GetActions(State s, Combat c)
    {
        return upgrade switch 
        {
            Upgrade.B => [
                new AStatus
                {
                    status = Status.drawLessNextTurn,
                    statusAmount = 1,
                    targetPlayer = true
                },
                new ASpawn
                {
                    thing = new Missile
                    {
                        missileType = MissileType.heavy,
                        skin = "sword"
                    },
                    offset = 0
                },
                new ASpawn
                {
                    thing = new Missile
                    {
                    missileType = MissileType.heavy,
                    skin = "sword"
                    },
                    offset = -1
                }
            ],
            Upgrade.A => [
                new ASpawn
                {
                    thing = new Missile
                    {
                        missileType = MissileType.heavy,
                        skin = "sword"
                    },
                    offset = 0
                }
            ],
            Upgrade.None => [
                new AStatus
                {
                    status = Status.drawLessNextTurn,
                    statusAmount = 1,
                    targetPlayer = true
                },
                new ASpawn
                {
                    thing = new Missile
                    {
                        missileType = MissileType.heavy,
                        skin = "sword"
                    },
                    offset = 0
                }
            ],
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public override CardData GetData(State state)
    {
        if (upgrade == Upgrade.A) 
        {
            return new CardData()
            {
                cost = 1, 
                artTint = "ffffff"
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 2,
                artTint = "ffffff",
                flippable = true
            };
        }
        if (upgrade == Upgrade.None)
        {
            return new CardData()
            {
                cost = 1,
                artTint = "ffffff"
            };
        }
        return default;
    }
};

