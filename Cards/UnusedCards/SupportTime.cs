using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class SupportTime : Card, IRegisterable
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
                deck = ModEntry.Instance.RuhigDeck.Deck, 
                rarity = Rarity.common, 
                dontOffer = false, 
                upgradesTo = [Upgrade.A, Upgrade.B] 
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "ColorlessRuhigSummon", "name"])
                .Localize,
            Art = ModEntry.RegisterSprite(package, "assets/Card/DespreateEnergy.png").Sprite
        });
    }
        public override List<CardAction> GetActions(State s, Combat c) 
    {
        return upgrade switch 
        {
            Upgrade.A => [
                new ACardOffering()
                {
                    amount = 7,
                    limitDeck = ModEntry.Instance.RuhigDeck.Deck,
                    canSkip = false,
                    battleType = BattleType.Easy,
                    rarityOverride = Rarity.common,
                    isEvent = false,
                    overrideUpgradeChances = new bool?(false),
                    makeAllCardsTemporary = true,
                    inCombat = true,
                    discount = -31
                }
            ],
            Upgrade.B => [
                new ACardOffering()
                {
                    amount = 3,
                    limitDeck = ModEntry.Instance.RuhigDeck.Deck,
                    makeAllCardsTemporary = true,
                    overrideUpgradeChances = new bool?(false),
                    canSkip = false,
                    inCombat = true,
                    discount = -1
                }
            ],
            Upgrade.None => [
                new ACardOffering()
                {
                    amount = 2,
                    limitDeck = new Deck?(ModEntry.Instance.RuhigDeck.Deck),
                    makeAllCardsTemporary = true,
                    overrideUpgradeChances = new bool?(false),
                    canSkip = false,
                    inCombat = true,
                    discount = -1
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
                artTint = "6868b9",
                description = "Add 1 of 2 <c=cardtrait>discount, temp</c> <c=141491>Ruhig</c> cards to your hand."
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 1,
                exhaust = true,
                artTint = "6868b9",
                description = "Add 1 of 3 <c=cardtrait>discount, temp</c> <c=6868b9>Ruhig</c> cards to your hand."
            };
        }
        if (upgrade == Upgrade.None)
        {
            return new CardData()
            {
                cost = 1,
                exhaust = true,
                artTint = "6868b9",
                description = "Add 1 of 2 <c=cardtrait>discount, temp</c> <c=3e3ea5>Ruhig</c> cards to your hand."
            };
        }
        return default;
    }
};
