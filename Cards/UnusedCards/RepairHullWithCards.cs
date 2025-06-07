using System;
using System.Collections.Generic;
using System.Reflection;
using RuhigMod.Actions;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class RepairHullWithCards : Card, IRegisterable
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
                rarity = Rarity.rare, 
                dontOffer = false, 
                upgradesTo = [Upgrade.A, Upgrade.B] 
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "RepairHullWithCards", "name"])
                .Localize,
            
        });
    }
    public override void OnDraw(State s, Combat c)
    {
        c.Queue( new RepairTheHullWithCards());
        c.Queue( new AHullMax()
        {
            targetPlayer = true,
            amount = 5
        });
        c.Queue( new AHeal()
        {
            targetPlayer = true,
            healAmount = 10
        });
    }

    public override CardData GetData(State state)
    {
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 0,
                artTint = "ff0000",
                art = StableSpr.cards_FumeCannon,
            };
        }
        if (upgrade == Upgrade.A)
        {
            return new CardData()
            {
                cost = 0,
                artTint = "0000ff",
                art = StableSpr.cards_FumeCannon
            };
        }
        if (upgrade == Upgrade.None)
        {
            return new CardData()
            {
                cost = 0,
                artTint = "ff0000",
                art = StableSpr.cards_FumeCannon,
                description = "On draw, <c=downside>remove your hand from the deck.</c> <c=heal>Gain 5 max hull. Heal 10.</c>",
                singleUse = true
            };
        }
        return default;
    }
};

