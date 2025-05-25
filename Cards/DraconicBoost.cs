using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class DraconicBoost : Card, IRegisterable
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
                dontOffer = false, 
                upgradesTo = [Upgrade.A, Upgrade.B] 
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "DraconicBoost", "name"])
                .Localize,
            Art = ModEntry.RegisterSprite(package, "assets/Card/DraconicBoost.png").Sprite,
        });
    }
        public override List<CardAction> GetActions(State s, Combat c) /* Card Actions go Here */
    {
        return upgrade switch 
        {
            Upgrade.A => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1 
                },
                new AStatus()
                {
                    status = Status.boost,
                    statusAmount = 3,
                    targetPlayer = true
                }
            ],
            Upgrade.B => [
                new AStatus()
                {
                    status = Status.boost,
                    statusAmount = 2,
                    targetPlayer = true
                },
            ],
            Upgrade.None => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1 
                },
                new AStatus()
                {
                    status = Status.boost,
                    statusAmount = 2,
                    targetPlayer = true
                }
            ]
        };
    }

    public override CardData GetData(State state) /* Card Properties Go Here */
    {
        if (upgrade == Upgrade.A) 
        {
            return new CardData()
            {
                cost = 0, 
                exhaust = false,
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
                exhaust = false,
                artTint = "6868b9"
            };
        }
        return default;
    }
};

