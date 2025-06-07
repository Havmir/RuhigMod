using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class DraconicShards : Card, IRegisterable
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
            Upgrade.B => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1
                },
                new AStatus()
                {
                    status = Status.maxShard,
                    statusAmount = 3,
                    targetPlayer = true
                },
                new AStatus()
                {
                    status = Status.shard,
                    statusAmount = 99, // If there is a better way to do max LMK ~ Havmir
                    targetPlayer = true
                },
            ],
            Upgrade.A => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1
                },
                new AStatus()
                {
                    status = Status.maxShard,
                    statusAmount = 3,
                    targetPlayer = true
                },
                new AStatus()
                {
                    status = Status.shard,
                    statusAmount = 3,
                    targetPlayer = true
                }
            ],
            Upgrade.None => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1
                },
                new AStatus()
                {
                    status = Status.maxShard,
                    statusAmount = 3,
                    targetPlayer = true
                },
                new AStatus()
                {
                status = Status.shard,
                statusAmount = 3,
                targetPlayer = true
                }
            ]
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
                artTint = "6868b9",
                retain = true
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

