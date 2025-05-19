using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.Actions;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class Meditation : Card, IRegisterable
{

    private static IKokoroApi.IV2.IConditionalApi Conditional => ModEntry.Instance.KokoroApi.Conditional; 
    public static Spr EuinceTop; /* Allows for the existence of this artwork 0701 */
    public static Spr EuinceBottom;
    public static void
        Register(IPluginPackage<IModManifest> package,
            IModHelper helper) 
    
    {
        EuinceTop = ModEntry.RegisterSprite(package, "assets/Card/EuinceTop.png").Sprite; /* Tells where to find artwork 0701 */
        EuinceBottom = ModEntry.RegisterSprite(package, "assets/Card/EuinceBottom.png").Sprite;
        helper.Content.Cards.RegisterCard(new CardConfiguration
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new CardMeta
            {
                deck = ModEntry.Instance.RuhigDeck
                    .Deck, 
                rarity = Rarity.common, 
                dontOffer = false, /* 767 */
                upgradesTo = [Upgrade.A, Upgrade.B] 
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "Meditation", "name"])
                .Localize,

            Art = StableSpr.cards_eunice, /* Defualt artwork 0701 */
        });
    }
        public override List<CardAction> GetActions(State s, Combat c)
    {
        return upgrade switch 
        {
            Upgrade.None => [
                new ADiscard()
                {   
                    disabled = flipped,
                    count = 1
                },
                new ADrawCard()
                {
                disabled = flipped, 
                count = 2
                },
                new ADummyAction(),
                new SelfDestruct()
                {   
                disabled = !flipped,
                },
                new RuhigSupport()
                {
                    disabled = !flipped, 
                    IsTempQuestionMark = ModEntry.Instance.Helper.Content.Cards.IsCardTraitActive(s, this, ModEntry.Instance.Helper.Content.Cards.TemporaryCardTrait )
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
                    count = 3
                },
                new ADrawCard()
                {
                    count = 4
                },
            ],
            Upgrade.B => [
                new ADiscard()
                {   
                    count = 4
                },
                new ADrawCard()
                {
                    count = 5
                },
            ]
        };
    }

    public override CardData GetData(State state)
    {
        if (upgrade == Upgrade.None)
        {
            if (flipped == false)
            {
                return new CardData()
                {
                    cost = 1,
                    floppable = true,
                    artTint = "6868b9",
                    art = EuinceTop, /* Tells the code what artwork to use when card is not flipped 0701 */
                    singleUse = false,
                    
                    
                };
            }
            if (flipped == true)
            {
                return new CardData()
                {
                    cost = 1,
                    floppable = true,
                    artTint = "6868b9",
                    art = EuinceBottom, /* Tells the code what artwork to use when card is flipped 0701 */
                    singleUse = true
                };
            }
            
        }
        if (upgrade == Upgrade.A)
        {
            return new CardData()
            {
                cost = 0,
                artTint = "6868b9",
                recycle = true
                /* There is no art here, so default is used instead 0701 */
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 1,
                artTint = "6868b9",
                singleUse = false,
                retain = true,
                exhaust = true
            };
        }
        return default;
    }
};

