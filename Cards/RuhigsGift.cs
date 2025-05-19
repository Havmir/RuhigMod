using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.Actions;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class RuhigGift : Card, IRegisterable /* name of card needs to go first purple */
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
                rarity = Rarity.uncommon, 
                dontOffer = false, 
                upgradesTo = [Upgrade.A, Upgrade.B],
                /* extraGlossary = new string[] {"You may flip and play this card to exhaust it"} */
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "RuhigGift", "name"])
                .Localize, /* change middle orange name into the name of the card */
            Art = ModEntry.RegisterSprite(package, "assets/Card/RuhigGift.png").Sprite
        });
    }
        public override List<CardAction> GetActions(State s, Combat c) 
    {
        return upgrade switch 
        {
            Upgrade.A => [
                new RuhigSupportA()
                {
                    IsTempQuestionMark = ModEntry.Instance.Helper.Content.Cards.IsCardTraitActive(s, this, ModEntry.Instance.Helper.Content.Cards.TemporaryCardTrait )
                },
                new AStatus()
                {
                    status = Status.drawNextTurn,
                    statusAmount = 2,
                    targetPlayer = true
                },
                new AStatus()
                {
                    status = Status.energyNextTurn,
                    statusAmount = 2,
                    targetPlayer = true
                }
            ],
            Upgrade.B => [
                new RuhigSupportB()
                {
                    IsTempQuestionMark = ModEntry.Instance.Helper.Content.Cards.IsCardTraitActive(s, this, ModEntry.Instance.Helper.Content.Cards.TemporaryCardTrait )
                },
                new AStatus()
                {
                    status = Status.drawNextTurn,
                    statusAmount = 2,
                    targetPlayer = true
                },
                new AStatus()
                {
                    status = Status.energyNextTurn,
                    statusAmount = 2,
                    targetPlayer = true
                }
            ],
            Upgrade.None => [
                new RuhigSupport()
                {
                    IsTempQuestionMark = ModEntry.Instance.Helper.Content.Cards.IsCardTraitActive(s, this, ModEntry.Instance.Helper.Content.Cards.TemporaryCardTrait )
                },
                new AStatus()
                {
                status = Status.drawNextTurn,
                    statusAmount = 1,
                    targetPlayer = true
                },
                new AStatus()
                {
                status = Status.energyNextTurn,
                statusAmount = 1,
                targetPlayer = true
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
                cost = 2, /* controls how much energy it costs to play a card */
                exhaust = false, /* I am unsure if this is needed, when false, but I don't want to test this */
                artTint = "6868b9",
                singleUse = true
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 2,
                exhaust = false,
                artTint = "6868b9",
                singleUse = true
            };
        }
        if (upgrade == Upgrade.None)
        {
            return new CardData()
            {
                cost = 3,
                exhaust = false,
                artTint = "6868b9",
                singleUse = true
            };
        }
        return default; /* needed for formatting otherwise error */
    }
};
/* To Do ~ make a starter Card */
