using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.Features;

namespace RuhigMod.Cards; 

public class DraconicScales : Card, IRegisterable /* name of card needs to go first purple */
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "DraconicScales", "name"])
                .Localize,
            Art = StableSpr.cards_dizzy,
        });
    }
        public override List<CardAction> GetActions(State s, Combat c)
    {
        return upgrade switch 
        {
            Upgrade.A => [
                new AStatus
                {
                    targetPlayer = true,
                    status = RuhigSupportStatusesManager.DraconicScales.Status,
                    statusAmount = 1
                }
            ],
            Upgrade.B => [
                new AStatus
                {
                    targetPlayer = true,
                    status = RuhigSupportStatusesManager.DraconicScalesB.Status,
                    statusAmount = 1
                }
            ],
            Upgrade.None => [
                new AStatus
                {
                    targetPlayer = true,
                    status = RuhigSupportStatusesManager.DraconicScales.Status,
                    statusAmount = 1
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
                cost = 0,
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
                artTint = "6868b9",
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

