using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;

namespace RuhigMod.Cards; 

public class ColorlessRuhigSummon : Card, IRegisterable /* name of card needs to go first purple */
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
                deck = Deck.colorless, 
                rarity = Rarity.common, 
                dontOffer = false, 
                upgradesTo = [Upgrade.A, Upgrade.B] 
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "ColorlessRuhigSummon", "name"])
                .Localize, /* change middle orange name into the name of the card */
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
                    amount = 2,
                    limitDeck = ModEntry.Instance.RuhigDeck.Deck,
                    makeAllCardsTemporary = true,
                    overrideUpgradeChances = false,
                    canSkip = false,
                    inCombat = true,
                    discount = -1
                }
            ],
            Upgrade.B => [
                new ACardOffering()
                {
                    amount = 3,
                    limitDeck = ModEntry.Instance.RuhigDeck.Deck,
                    makeAllCardsTemporary = true,
                    overrideUpgradeChances = false,
                    canSkip = false,
                    inCombat = true,
                    discount = -1
                }
            ],
            Upgrade.None => [
                new ACardOffering()
                {
                    amount = 2,
                    limitDeck = ModEntry.Instance.RuhigDeck.Deck,
                    makeAllCardsTemporary = true,
                    overrideUpgradeChances = false,
                    canSkip = false,
                    inCombat = true,
                    discount = -1
                }
            ]
        };
    }

    public override CardData GetData(State state) /* Each upgrade's action is defined here */
    {
        if (upgrade == Upgrade.A) /* This controls Upgrade A */
        {
            return new CardData()
            {
                cost = 0, /* controls how much energy it costs to play a card */
                exhaust = true, /* I am unsure if this is needed, when false, but I don't want to test this */
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
        return default; /* needed for formatting otherwise error */
    }
};
