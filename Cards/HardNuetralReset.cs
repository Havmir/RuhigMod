using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;

namespace RuhigMod.Cards; 

public class HardNuetralReset : Card, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "HardNuetralReset", "name"])
                .Localize,
            Art = StableSpr.cards_DesperateMeasures,
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
                    hurtAmount = 1 
                },
                new ADiscard()
                {
                    count = 10
                },
                new ADrawCard()
                {
                count = 10,
                dialogueSelector = ".HardNuetralReset"
                }
            ],
            Upgrade.A => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1 
                },
                new ADiscard()
                {
                    count = 10
                },
                new ADrawCard()
                {
                    count = 10,
                    dialogueSelector = ".HardNuetralReset"
                }
            ],
            Upgrade.B => [
                new ADiscard()
                {
                    count = 10
                },
                new ADrawCard()
                {
                    count = 10,
                    dialogueSelector = ".HardNuetralReset"
                }
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
                cost = 1, 
                exhaust = true,
                artTint = "6868b9"
            };
        }
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
        return default;
    }
};

