using System;
using System.Collections.Generic;
using System.Reflection;
using RuhigMod.Actions;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class CardCopier : Card, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "CardCopier", "name"])
                .Localize,
            Art = ModEntry.RegisterSprite(package, "assets/Card/NotTheBestArtButIThinkTheConceptItWasGoingForIsNeat.png").Sprite
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
                new ACardSelect()
                {
                    browseAction = new CardCopyEffect(),
                    browseSource = CardBrowse.Source.Hand
                },
                new AEndTurn()
            ],
            Upgrade.A => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1
                },
                new ACardSelect()
                {
                    browseAction = new CardCopyEffect(),
                    browseSource = CardBrowse.Source.Deck
                },
                new AEndTurn()
            ],
            Upgrade.B => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1
                },
                new ACardSelect()
                {
                    browseAction = new CardCopyEffectDouble(),
                    browseSource = CardBrowse.Source.Hand
                },
                new AEndTurn()
            ]
        };
    }

    public override CardData GetData(State state)
    {
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 3,
                artTint = "ffffff",
                description = "<c=damage>Lose 1 hull.</c> Duplicate a card in your hand twice. <c=downside>End turn.</c>",
                singleUse = true
            };
        }
        if (upgrade == Upgrade.A)
        {
            return new CardData()
            {
                cost = 3,
                artTint = "ffffff",
                description = "<c=damage>Lose 1 hull.</c> Duplicate a card in your deck. <c=downside>End turn.</c>",
                singleUse = true
            };
        }
        if (upgrade == Upgrade.None)
        {
            return new CardData()
            {
                cost = 3,
                artTint = "ffffff",
                description = "<c=damage>Lose 1 hull.</c> Duplicate a card in your hand. <c=downside>End turn.</c> ",
                singleUse = true
            };
        }
        return default;
    }
};

