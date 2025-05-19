using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class RushAttack : Card, IRegisterable
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
                rarity = Rarity.uncommon, 
                dontOffer = false, 
                upgradesTo = [Upgrade.A, Upgrade.B] 
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "RushAttack", "name"])
                .Localize,
            Art = StableSpr.cards_Dodge,
        });
    }
        public override List<CardAction> GetActions(State s, Combat c) 
    {
        return upgrade switch 
        {
            Upgrade.None => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1 
                },
                new AMove()
                {
                    dir = -1,
                    targetPlayer = true
                },
                new AAttack()
                {
                    damage = GetDmg(s, 2),
                    piercing = true,
                    fast = true
                },
                new AMove()
                {
                    dir = 3,
                    targetPlayer = true
                },
                new AAttack()
                {
                    damage = GetDmg(s, 2),
                    piercing = true,
                    fast = true
                }
            ],
            Upgrade.A => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1 
                },
                new AMove()
                {
                    dir = -1,
                    targetPlayer = true
                },
                new AAttack()
                {
                    damage = GetDmg(s, 2),
                    piercing = true,
                    fast = true
                },
                new AMove()
                {
                    dir = 3,
                    targetPlayer = true
                },
                new AAttack()
                {
                    damage = GetDmg(s, 2),
                    piercing = true,
                    fast = true
                }
            ],
            Upgrade.B => [
                new AMove()
                {
                    dir = -1,
                    targetPlayer = true
                },
                new AAttack()
                {
                    damage = GetDmg(s, 2),
                    piercing = true,
                    fast = true
                },
                new AMove()
                {
                    dir = 3,
                    targetPlayer = true
                },
                new AAttack()
                {
                    damage = GetDmg(s, 2),
                    piercing = true,
                    fast = true
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
                cost = 1, 
                flippable = false,
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.A)
        {
            return new CardData()
            {
                cost = 0,
                flippable = true,
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 2,
                flippable = true,
                artTint = "6868b9"
            };
        }
        return default;
    }
};

