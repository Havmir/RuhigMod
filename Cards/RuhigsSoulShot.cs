using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class RuhigsSoulShot : Card, IRegisterable /* name of card needs to go first purple */
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "RuhigsSoulShot", "name"])
                .Localize, /* change middle orange name into the name of the card */
            Art = StableSpr.cards_TrashFumes,
        });
    }
        public override List<CardAction> GetActions(State s, Combat c) /* Card Actions go Here */
    {
        return upgrade switch 
        {
            Upgrade.None => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1 
                },
                new AAttack()
                {
                damage = this.GetDmg(s, this.GetMissingHealth(s)),
                }
            ],
            Upgrade.B => [
                new AHurt()
                {
                hurtAmount = (s.ship.hull - 1),
                targetPlayer = true
                },
                new AAttack()
                {
                    damage = this.GetDmg(s, this.GetMissingHealth(s)),
                },
                new AStatus()
                {
                    status = Status.serenity,
                    statusAmount = 0,
                    mode = AStatusMode.Set,
                    /* omitFromTooltips = true */
                    targetPlayer = true
                },
                new AStatus()
                {
                    status = Status.heat,
                    statusAmount = 99,
                    mode = AStatusMode.Set,
                    /* omitFromTooltips = true */
                    targetPlayer = true
                },
            ],
            Upgrade.A => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1 
                },
                new AAttack()
                {
                    damage = this.GetDmg(s, this.GetMissingHealth(s)), /* 447 */
                    onKillActions = new List<CardAction>()
                    {
                        new AHullMax()
                        {
                            amount = 2,
                            targetPlayer = true
                        },
                        new AHeal()
                        {
                        healAmount = 3,
                        targetPlayer = true
                    }
                    }
                }
            ]
        };
    }

    public int GetMissingHealth(State s)
    {
        return s.ship.hullMax - s.ship.hull +1; /* This makes typing in "GetMissingHealth(s)" for damage, the actual damage for your missing health 447 */
    }

    public override CardData GetData(State state) /* Card Properties Go Here */
    {
        if (upgrade == Upgrade.None) 
        {
            return new CardData()
            {
                cost = 2, 
                exhaust = false,
                description = "Lose 1 Hull. Attack = Missing Hull",
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 1,
                exhaust = false,
                description = "Set Hull = 1 & Attack = Missing Hull. Remove serenity & add 99 heat",
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.A)
        {
            return new CardData()
            {
                cost = 3,
                exhaust = false,
                description = "Lose 1 Hull & Attack = Missing Hull. If kills, +2 Max hull & heal 3",
                artTint = "6868b9"
            };
        }
        return default;
    }
};

