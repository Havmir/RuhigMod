using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;

namespace RuhigMod.Cards; 

public class FinishingBlow : Card, IRegisterable /* name of card needs to go first purple */
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
                rarity = Rarity.uncommon, 
                dontOffer = false, 
                upgradesTo = [Upgrade.A, Upgrade.B] 
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "FinishingBlow", "name"])
                .Localize, /* change middle orange name into the name of the card */
            Art = ModEntry.RegisterSprite(package, "assets/Card/FinalBlow.png").Sprite
        });
    }
        public override List<CardAction> GetActions(State s, Combat c) /* Card Actions go Here */
    {
        return upgrade switch 
        {
            Upgrade.None => [
                new AAttack
                {
                damage = GetDmg(s, 1),
                onKillActions = new List<CardAction>
                {
                    new AHullMax
                    {
                        amount = 1,
                        targetPlayer = true
                    }
                }
                }
            ],
            Upgrade.B => [
                new AAttack
                {
                    damage = GetDmg(s, 1),
                    onKillActions = new List<CardAction>
                    {
                        new AHullMax
                        {
                            amount = 2,
                            targetPlayer = true
                        }
                    }
                }
            ],
            Upgrade.A => [
                new AAttack
                {
                    damage = GetDmg(s, 1),
                    onKillActions = new List<CardAction>
                    {
                        new AHullMax
                        {
                            amount = 1,
                            targetPlayer = true
                        }
                    }
                }
            ],
            _ => throw new ArgumentOutOfRangeException()
        };
    }
    

    public override CardData GetData(State state) /* Card Properties Go Here */
    {
        if (upgrade == Upgrade.None) 
        {
            return new CardData
            {
                cost = 3, 
                description = $"Attack for <c=redd>{GetDmg(state, 1)}</c> damage. <c=heal>If kills, +1 max hull.</c>",
                artTint = "ffffff"
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData
            {
                cost = 3, 
                description = $"Attack for <c=redd>{GetDmg(state, 1)}</c> damage. <c=heal>If kills, +2 max hull.</c>",
                artTint = "ffffff"
            };
        }
        if (upgrade == Upgrade.A)
        {
            return new CardData
            {
                cost = 2, 
                description = $"Attack for <c=redd>{GetDmg(state, 1)}</c> damage. <c=heal>If kills, +1 max hull.</c>",
                artTint = "ffffff",
                retain = true
            };
        }
        return default;
    }
};

