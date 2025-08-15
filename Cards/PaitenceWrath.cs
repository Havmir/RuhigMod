using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.Features;

namespace RuhigMod.Cards; 

public class PaitenceWrath : Card, IRegisterable
{
    
    public static Spr EuinceTop;
    public static Spr EuinceBottom;
    public static void
        Register(IPluginPackage<IModManifest> package,
            IModHelper helper) 
    
    {
        EuinceTop = ModEntry.RegisterSprite(package, "assets/Card/EuinceTop.png").Sprite;
        EuinceBottom = ModEntry.RegisterSprite(package, "assets/Card/EuinceBottom.png").Sprite;
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "PaitenceWrath", "name"])
                .Localize,
            Art = StableSpr.cards_eunice,
        });
    }
        public override List<CardAction> GetActions(State s, Combat c)
    {
        return upgrade switch 
        {
            Upgrade.None => [
                new ADummyAction(),
                new AStatus
                {
                    status = RuhigSupportStatusesManager.Paitence.Status,
                    disabled = flipped, 
                    statusAmount = 1,
                    targetPlayer = true,
                },
                new ADummyAction(),
                new AStatus
                {
                    status = Status.heat,
                    disabled = !flipped, 
                    statusAmount = 10,
                    targetPlayer = true,
                },
                new ADummyAction()
            ],
            Upgrade.A => [
                new ADummyAction(),
                new AStatus
                {
                    status = RuhigSupportStatusesManager.Paitence.Status,
                    disabled = flipped, 
                    statusAmount = 1,
                    targetPlayer = true,
                },
                new ADummyAction(),
                new AStatus
                {
                    status = Status.heat,
                    disabled = !flipped, 
                    statusAmount = 10,
                    targetPlayer = true,
                },
                new ADummyAction()
            ],
            Upgrade.B => [
                new ADummyAction(),
                new AStatus
                {
                    status = RuhigSupportStatusesManager.Paitence.Status,
                    disabled = flipped, 
                    statusAmount = 2,
                    targetPlayer = true,
                },
                new ADummyAction(),
                new AStatus
                {
                    status = RuhigSupportStatusesManager.Wrath.Status,
                    disabled = !flipped, 
                    statusAmount = 2,
                    targetPlayer = true,
                },
                new AStatus
                {
                    status = Status.heat,
                    disabled = !flipped, 
                    statusAmount = 10,
                    targetPlayer = true,
                }
            ],
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public override CardData GetData(State state)
    {
        if (upgrade == Upgrade.None)
        {
            if (flipped == false)
            {
                return new CardData()
                {
                    cost = 1,
                    floppable = true,
                    artTint = "6868b9",
                    art = EuinceTop,
                    exhaust = true,
                };
            }
            if (flipped)
            {
                return new CardData()
                {
                    cost = 1,
                    floppable = true,
                    artTint = "6868b9",
                    art = EuinceBottom,
                    exhaust = true,
                };
            }
        }
        if (upgrade == Upgrade.A)
        {
            if (flipped == false)
            {
                return new CardData()
                {
                    cost = 0,
                    floppable = true,
                    artTint = "6868b9",
                    art = EuinceTop,
                    exhaust = true,
                };
            }
            if (flipped)
            {
                return new CardData()
                {
                    cost = 0,
                    floppable = true,
                    artTint = "6868b9",
                    art = EuinceBottom,
                    exhaust = true,
                };
            }
        }
        if (upgrade == Upgrade.B)
        {
            if (flipped == false)
            {
                return new CardData()
                {
                    cost = 1,
                    floppable = true,
                    artTint = "6868b9",
                    art = EuinceTop,
                    exhaust = true,
                };
            }
            if (flipped)
            {
                return new CardData()
                {
                    cost = 1,
                    floppable = true,
                    artTint = "6868b9",
                    art = EuinceBottom,
                    exhaust = true,
                };
            }
        }
        return default;
    }
};

