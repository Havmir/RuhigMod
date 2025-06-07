using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class Stall : Card, IRegisterable
{

    private static IKokoroApi.IV2.IConditionalApi Conditional => ModEntry.Instance.KokoroApi.Conditional; 
    public static Spr SeekerMissleCardTop;
    public static Spr SeekerMissleCardBottom;

    public static void
        Register(IPluginPackage<IModManifest> package,
            IModHelper helper) 
    {
        SeekerMissleCardTop = ModEntry.RegisterSprite(package, "assets/Card/SeekerMissleCardTop.png").Sprite;
        SeekerMissleCardBottom = ModEntry.RegisterSprite(package, "assets/Card/SeekerMissleCardBottom.png").Sprite;
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Stall", "name"])
                .Localize,
            Art = StableSpr.cards_SeekerMissileCard,
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
                    hurtAmount = 3 
                },
                new AMove()
                {
                    dir = -20,
                    targetPlayer = true,
                }
            ],
            Upgrade.A => [
                new AHurt()
                {   
                    targetPlayer = true,
                    hurtAmount = 2,
                },
                new AMove()
                {
                    dir = -20,
                    targetPlayer = true,
                }
            ],
            Upgrade.B => [
                new AMove()
                {
                    dir = -20,
                    targetPlayer = true,
                },
                new AStatus()
                {
                    status = Status.drawLessNextTurn,
                    targetPlayer = true,
                    statusAmount = 1,
                },
                new AStatus()
                {
                    status = Status.energyLessNextTurn,
                    targetPlayer = true,
                    statusAmount = 1,
                },
            ]
        };
    }

    public override CardData GetData(State state)
    {
        if (upgrade == Upgrade.None)
        {
            return new CardData()
            {
                cost = 0, 
                exhaust = true,
                retain = true,
                artTint = "6868b9",
            };
        }
        if (upgrade == Upgrade.A)
        {
            return new CardData()
            {
                cost = 0,
                exhaust = true,
                retain = true,
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 2,
                exhaust = true,
                artTint = "6868b9",
            };
        }
        return default;
    }
};