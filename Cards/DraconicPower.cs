using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.Features;

namespace RuhigMod.Cards; 

public class DraconicPower : Card, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "DraconicPower", "name"])
                .Localize,
            Art = StableSpr.cards_peri,
        });
    }
        public override List<CardAction> GetActions(State s, Combat c)
        {
        return upgrade switch 
        {
            Upgrade.A => [
                new AStatus
                {
                    status = RuhigSupportStatusesManager.DraconicPower.Status,
                    statusAmount = 1,
                    targetPlayer = true,
                }
            ],
            Upgrade.B => [
                new AStatus
                {
                    status = RuhigSupportStatusesManager.DraconicPower.Status,
                    statusAmount = 2,
                    targetPlayer = true,
                }
            ],
            Upgrade.None => [
                new AStatus
                {
                    status = RuhigSupportStatusesManager.DraconicPower.Status,
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

