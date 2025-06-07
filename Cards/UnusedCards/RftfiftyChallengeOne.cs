using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

/*
 * Above is for helping setting key refferences
 */
namespace RuhigMod.Cards; /* puts in X deck */

public class RftfiftyChallengeOne : Card, IRegisterable /* name of card needs to go first purple */
{

    private static IKokoroApi.IV2.IConditionalApi Conditional => ModEntry.Instance.KokoroApi.Conditional; /* IDK */

    public static void
        Register(IPluginPackage<IModManifest> package,
            IModHelper helper) /* This is formatting to get properties of a card */
    {
        helper.Content.Cards.RegisterCard(new CardConfiguration
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new CardMeta
            {
                deck = ModEntry.Instance.RuhigDeck
                    .Deck, /* this declares which deck the card belongs too which ussually is the same as assigning it to a characer */
                rarity = Rarity.common, /* S.E. */
                dontOffer = false, /* false means you can get this cards at the end of fights */
                upgradesTo = [Upgrade.A, Upgrade.B] /* this allows the card to have 2 upgrade */
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "RftfiftyChallengeOne", "name"])
                .Localize, /* Now would be a good time to make sure this card is added to en.json in addition to ModEntry.cs 8110 */
        });
    }
        public override List<CardAction> GetActions(State s, Combat c) /* This controls what actions the card does when played, things like exhaust however would be in CardData which is after this */
    {
        return upgrade switch /* Each upgrade's action is defined here */
        {
            Upgrade.A => [
                new ADrawCard()
                {
                    count = 5
                },
            ],
            Upgrade.B => [
                new ADrawCard()
                {
                    count = 3
                },
            ],
            Upgrade.None => [
                new ADrawCard()
                {
                    count = 3
                },
            ]
        };
    }

    public override CardData GetData(State state) /* Each upgrade's action is defined here */
    {
        if (upgrade == Upgrade.A) /* This controls Upgrade A */
        {
            return new CardData()
            {
                cost = 1, /* controls how much energy it costs to play a card */
                exhaust = false /* I am unsure if this is needed, when false, but I don't want to test this */
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 0,
                exhaust = true
            };
        }
        if (upgrade == Upgrade.None)
        {
            return new CardData()
            {
                cost = 1,
                exhaust = false
            };
        }
        return default; /* needed for formatting otherwise error */
    }
};
