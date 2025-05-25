using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class PainfulMemory : Card, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "PainfulMemory", "name"])
                .Localize,
            Art = ModEntry.RegisterSprite(package, "assets/Card/PainfulMemory.png").Sprite
        });
    }
        public override List<CardAction> GetActions(State s, Combat c)
    {
        return upgrade switch 
        {
            Upgrade.None => [
                new AHurt()
                {   
                    disabled = flipped,
                    targetPlayer = true,
                    hurtAmount = 1 
                },
                new ACardSelect()
                {
                    disabled = flipped,
                    browseAction =  new ChooseCardToPutInHand(),
                    browseSource = CardBrowse.Source.DrawOrDiscardPile,
                    filterUUID = uuid // I have no idea why this is here ~ Havmir
                },
                new AHurt()
                {   
                disabled = !flipped,
                targetPlayer = true,
                hurtAmount = 1 
                },
                new ACardSelect()
                {
                    disabled = !flipped,
                    browseAction = new CloudSavePickCard(),
                    browseSource = CardBrowse.Source.ExhaustPile,
                }
            ],
            Upgrade.A => [
                new AHurt()
                {   
                    disabled = flipped,
                    targetPlayer = true,
                    hurtAmount = 1 
                },
                new ACardSelect()
                {
                    disabled = flipped,
                    browseAction =  new ChooseCardToPutInHand(),
                    browseSource = CardBrowse.Source.DrawOrDiscardPile,
                    filterUUID = uuid // I have no idea why this is here ~ Havmir
                },
                new ACardSelect()
                {
                    disabled = flipped,
                    browseAction =  new ChooseCardToPutInHand(),
                    browseSource = CardBrowse.Source.DrawOrDiscardPile,
                    filterUUID = uuid // I have no idea why this is here ~ Havmir
                },
                new AHurt()
                {   
                    disabled = !flipped,
                    targetPlayer = true,
                    hurtAmount = 1 
                },
                new ACardSelect()
                {
                    disabled = !flipped,
                    browseAction = new CloudSavePickCard(),
                    browseSource = CardBrowse.Source.ExhaustPile,
                },
                new ACardSelect()
                {
                disabled = !flipped,
                browseAction = new CloudSavePickCard(),
                browseSource = CardBrowse.Source.ExhaustPile
                }
            ],
            Upgrade.B => [
                new AHurt()
                {   
                    targetPlayer = true,
                    hurtAmount = 1 
                },
                new ACardSelect()
                {
                    browseAction = new CloudSavePickCard(),
                    browseSource = CardBrowse.Source.ExhaustPile,
                },
                new ACardSelect()
                {
                    browseAction = new CloudSavePickCard(),
                    browseSource = CardBrowse.Source.ExhaustPile,
                },
                new ACardSelect()
                {
                    browseAction = new CloudSavePickCard(),
                    browseSource = CardBrowse.Source.ExhaustPile,
                },
                new ACardSelect()
                {
                    browseAction = new CloudSavePickCard(),
                    browseSource = CardBrowse.Source.ExhaustPile,
                }
            ]
        };
    }

    public override CardData GetData(State state)
    {
        if (upgrade == Upgrade.None)
        {
            // the heal colour on the text is to help the player know which option is getting picked ~ Havmir
            if (flipped == false)
            {
                return new CardData()
                {
                    cost = 0,
                    floppable = true,
                    artTint = "6868b9",
                    description = "<c=damage>Hull -1</c> & get a card from your <c=heal>(draw or discard pile)</c> OR exhaust pile."
                };
            }
            if (flipped == true)
            {
                return new CardData()
                {
                    cost = 0,
                    floppable = true,
                    artTint = "6868b9",
                    description = "<c=damage>Hull -1</c> & get a card from your (draw or discard pile) OR <c=heal>exhaust pile</c>."
                };
            }
        }
        if (upgrade == Upgrade.A)
        {
            if (flipped == false)
            {
                return new CardData()
                {
                    cost = 0,
                    floppable = true,
                    artTint = "6868b9",
                    description = "<c=damage>Hull -1</c> & get 2 cards from your <c=heal>(draw or discard pile)</c> OR exhaust pile."
                };
            }
            if (flipped == true)
            {
                return new CardData()
                {
                    cost = 0,
                    floppable = true,
                    artTint = "6868b9",
                    description = "<c=damage>Hull -1</c> & get 2 cards from your (draw or discard pile) OR <c=heal>exhaust pile</c>."
                };
            }
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 2,
                artTint = "6868b9",
                description = "<c=damage>Hull -1</c> & get 4 cards from your exhaust pile."
            };
        }
        return default;
    }
};

