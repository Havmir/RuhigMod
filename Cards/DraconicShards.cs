using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.Features;

namespace RuhigMod.Cards; 

public class DraconicShards : Card, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "DraconicShards", "name"])
                .Localize,
            Art = StableSpr.cards_shard,
            
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
                    status = RuhigSupportStatusesManager.DraconicShards.Status,
                    statusAmount = 1
                }
            ],
            Upgrade.B => [
                new AStatus
                {
                    targetPlayer = true,
                    status = RuhigSupportStatusesManager.DraconicShardsB.Status,
                    statusAmount = 1
                }
            ],
            Upgrade.None => [
                new AStatus
                {
                    targetPlayer = true,
                    status = RuhigSupportStatusesManager.DraconicShards.Status,
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
                flippable = false,
                artTint = "6868b9",
                exhaust = true,
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 2,
                exhaust = true,
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.None)
        {
            return new CardData()
            {
                cost = 1,
                flippable = false,
                artTint = "6868b9",
                exhaust = true,
            };
        }
        return default;
    }
};

