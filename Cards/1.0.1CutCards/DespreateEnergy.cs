using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;

namespace RuhigMod.Cards; 

public class DespreateEnergy : Card, IRegisterable
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
                dontOffer = false, 
                upgradesTo = [Upgrade.A, Upgrade.B] 
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "DespreateEnergy", "name"])
                .Localize,
            Art = ModEntry.RegisterSprite(package, "assets/Card/DespreateEnergy.png").Sprite
        });
    }
        public override List<CardAction> GetActions(State s, Combat c) 
    {
        return upgrade switch 
        {
            Upgrade.None => [
                new AHurt
                {
                    targetPlayer = true,
                    hurtAmount = 1 
                },
                new AEnergy
                {
                    changeAmount = 2,
                    dialogueSelector = ".DespreateEnergy"
                }
            ],
            Upgrade.A => [
                new AHurt
                {
                    targetPlayer = true,
                    hurtAmount = 1 
                },
                new AEnergy
                {
                    changeAmount = 3,
                    dialogueSelector = ".DespreateEnergy"
                },
            ],
            Upgrade.B => [
                new AHurt
                {
                    targetPlayer = true,
                    hurtAmount = 1 
                },
                new AEnergy
                {
                    changeAmount = 2,
                    dialogueSelector = ".DespreateEnergy"
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
                cost = 0, 
                infinite = false,
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.A)
        {
            return new CardData()
            {
                cost = 0,
                infinite = false,
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 0,
                infinite = true,
                retain = true,
                artTint = "6868b9"
            };
        }
        return default;
    }
};
