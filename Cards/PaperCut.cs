using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.Actions;

namespace RuhigMod.Cards; 

public class PaperCut : Card, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "PaperCut", "name"])
                .Localize,
            Art = StableSpr.cards_Repairs,
        });
    }
        public override List<CardAction> GetActions(State s, Combat c)
    {
        return upgrade switch 
        {
            Upgrade.None => [
                new PaperCutAction(),
                new ADrawCard
                {
                    count = 1
                }
            ],
            Upgrade.A => [
                new PaperCutAction(),
                new PaperCutAction(),
                new ADrawCard
                {
                    count = 1
                }
            ],
            Upgrade.B => [
                new PaperCutAction(),
                new PaperCutAction(),
                new PaperCutAction()
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
                artTint = "ff0000"
            };
        }
        if (upgrade == Upgrade.A)
        {
            return new CardData()
            {
                cost = 0,
                artTint = "ff0000"
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 0,
                artTint = "ff0000"
            };
        }
        return default;
    }
};

