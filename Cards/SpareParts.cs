using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.Actions;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class SpareParts : Card, IRegisterable
{

    private static IKokoroApi.IV2.IConditionalApi Conditional => ModEntry.Instance.KokoroApi.Conditional;


    public static Spr sprite1;
    public static Spr sprite2;
    public static Spr sprite3;
    
    public static void
        

        Register(IPluginPackage<IModManifest> package,
            IModHelper helper)
    {
        sprite1 = ModEntry.RegisterSprite(package, "assets/Card/SparePartsBottom.png").Sprite;
        sprite2 = ModEntry.RegisterSprite(package, "assets/Card/SparePartsTop.png").Sprite;
        sprite3 = ModEntry.RegisterSprite(package, "assets/Card/DespreateEnergy.png").Sprite;
            
        helper.Content.Cards.RegisterCard(new CardConfiguration
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new CardMeta
            {
                deck = ModEntry.Instance.RuhigDeck
                    .Deck, 
                rarity = Rarity.common, 
                dontOffer = false, 
                upgradesTo = [Upgrade.A, Upgrade.B],

            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "SpareParts", "name"])
                .Localize,

        });
    }
        public override List<CardAction> GetActions(State s, Combat c) 
    {
        return upgrade switch 
        {
            Upgrade.B => [
                new AHeal()
                {
                    healAmount = 4,
                    disabled = flipped,
                    targetPlayer = true
                },
                new AEndTurn()
                {
                    disabled = flipped
                },
                new InvisableRuhigSupport()
                {
                    disabled = !flipped,
                    IsTempQuestionMark = ModEntry.Instance.Helper.Content.Cards.IsCardTraitActive(s, this, ModEntry.Instance.Helper.Content.Cards.TemporaryCardTrait )
                },
                new RuhigSupportDouble()
                {
                    disabled = !flipped,
                    IsTempQuestionMark = ModEntry.Instance.Helper.Content.Cards.IsCardTraitActive(s, this, ModEntry.Instance.Helper.Content.Cards.TemporaryCardTrait )
                },
                new AEndTurn()
                {
                    disabled = !flipped
                }
            ],
            Upgrade.A => [
                new ADummyAction(),
                new AHeal()
                {
                    healAmount = 1,
                    disabled = flipped,
                    targetPlayer = true
                },
                new ADummyAction(),
                new RuhigSupport()
                {
                    disabled = !flipped,
                    IsTempQuestionMark = ModEntry.Instance.Helper.Content.Cards.IsCardTraitActive(s, this, ModEntry.Instance.Helper.Content.Cards.TemporaryCardTrait )
                } ,
                new ADummyAction(),
            ],
            Upgrade.None => [
                new AHeal()
                {
                    healAmount = 1,
                    disabled = flipped,
                    targetPlayer = true
                },
                new AEndTurn()
                {
                    disabled = flipped
                },
                new ADummyAction(),
                new RuhigSupport()
                {
                    disabled = !flipped,
                    IsTempQuestionMark = ModEntry.Instance.Helper.Content.Cards.IsCardTraitActive(s, this, ModEntry.Instance.Helper.Content.Cards.TemporaryCardTrait )
                } ,
                new AEndTurn()
                {
                    disabled = !flipped  
                }
            ]
        };
    }

        
    public override CardData GetData(State state) 
    {
        if (upgrade == Upgrade.A) 
        {
            if (flipped == false)
            {
                return new CardData()
                {
                    cost = 1,
                    exhaust = false,
                    artTint = "ffffff",
                    floppable = true,
                    art = sprite2,
                    singleUse = true
                };
            }
            if (flipped == true)
            {
                return new CardData()
                {
                    cost = 1,
                    exhaust = false,
                    artTint = "ffffff",
                    floppable = true,
                    art = sprite1,
                    singleUse = true
                };
            }
        }

        if (upgrade == Upgrade.B)
        {
            if (flipped == false)
            {
                return new CardData()
                {
                    cost = 2,
                    exhaust = false,
                    artTint = "ffffff",
                    floppable = true,
                    art = sprite2,
                    singleUse = true
                };
            }
            if (flipped == true)
            {
                return new CardData()
                {
                    cost = 2,
                    exhaust = false,
                    artTint = "ffffff",
                    floppable = true,
                    art = sprite1,
                    singleUse = true
                };
            }
        }
        /* if (upgrade == Upgrade.B)
        {
            {
                CardData data = new CardData();
                data.cost = 1;
                data.unplayable = state.route is Combat route1 && !IsPlayable(route1);
                object[] objArray = new object[3]
                {
                    $"{GetDmg(state, DamageAmount())}",
                    $"{GoalAmount()}",
                    null!
                };
                string str1;
                if (!(state.route is Combat route2))
                    str1 = "";
                else
                    str1 =
                        $" (<c={(IsPlayable(route2) ? "heal" : "hurt")}>{route2.cardsPlayedThisTurn}/{GoalAmount()}</c>)";
                objArray[2] = str1;
                data.description = string.Format(ModEntry.Instance.Localizations.Localize([
                    "card",
                    "SpareParts", "descB"
                ]), objArray);
                data.art = StableSpr.cards_Repairs;
                data.artTint = "6868b9";
                return data;
            }
        } scraped for being too transformaitve ~ havmir */ 
        if (upgrade == Upgrade.None)
        {
            if (flipped == false)
            {
                return new CardData()
                {
                    cost = 2,
                    exhaust = false,
                    artTint = "ffffff",
                    floppable = true,
                    art = sprite2,
                    singleUse = true
                };
            }
            if (flipped == true)
            {
                return new CardData()
                {
                    cost = 2,
                    exhaust = false,
                    artTint = "ffffff",
                    floppable = true,
                    art = sprite1,
                    singleUse = true
                };
            }
        }
        return default;
    }
    
};

