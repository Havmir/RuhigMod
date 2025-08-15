using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.Features;

namespace RuhigMod.Cards; 

public class TrueGrit : Card, IRegisterable
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
                rarity = Rarity.rare, 
                dontOffer = true, 
                upgradesTo = [Upgrade.A, Upgrade.B] 
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "TrueGrit", "name"])
                .Localize,
            Art = ModEntry.RegisterSprite(package, "assets/Card/ITriedToDoSomethingCool.png").Sprite
        });
    }
        public override List<CardAction> GetActions(State s, Combat c)
    {
        return upgrade switch 
        {
            Upgrade.B => [
                new AStatus
                {
                    status = RuhigSupportStatusesManager.TrueGrit.Status,
                    statusAmount = 1,
                    targetPlayer = true,
                },
                new ADrawCard
                {
                    count = 2
                }
            ],
            Upgrade.A => [
                new AStatus
                {
                    status = RuhigSupportStatusesManager.TrueGrit.Status, 
                    statusAmount = 1,
                    targetPlayer = true,
                }
            ],
            Upgrade.None => [
                new AStatus
                {
                    status = RuhigSupportStatusesManager.TrueGrit.Status,
                    statusAmount = 1,
                    targetPlayer = true,
                }
            ],
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public override CardData GetData(State state)
    {
        if (upgrade == Upgrade.A) 
        {
            return new CardData
            {
                cost = 2, 
                exhaust = true,
                artTint = "999999"
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData
            {
                cost = 3,
                exhaust = true,
                artTint = "999999"
                //artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.None)
        {
            return new CardData
            {
                cost = 3,
                exhaust = true,
                artTint = "999999"
            };
        }
        return default;
    }
};

