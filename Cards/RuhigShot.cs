using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.Actions;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class RuhigShot : Card, IRegisterable
{

    private static IKokoroApi.IV2.IConditionalApi Conditional => ModEntry.Instance.KokoroApi.Conditional;


    public static Spr CorrodeBottom;
    public static Spr CorrodeTop;
    
    public static void
        

        Register(IPluginPackage<IModManifest> package,
            IModHelper helper)
    {
        CorrodeBottom = ModEntry.RegisterSprite(package, "assets/Card/CorrodeBottom.png").Sprite;
        CorrodeTop = ModEntry.RegisterSprite(package, "assets/Card/CorrodeTop.png").Sprite;
            
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "RuhigShot", "name"])
                .Localize,

        });
    }
        public override List<CardAction> GetActions(State s, Combat c) 
    {
        return upgrade switch 
        {
            Upgrade.A => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1,
                    
                },
                new AAttack()
                {
                    damage = GetDmg(s, 1),
                    piercing = true,
                    fast = true
                },
                new AAttack()
                {
                    damage = GetDmg(s, 1),
                    piercing = true
                },
                new AEnergy()
                {
                    changeAmount = 1
                }
            ],
            Upgrade.B => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1 
                },
                new AStatus()
                {
                    status = Status.evade,
                    statusAmount = 1,
                    targetPlayer = true
                },
                new AStatus()
                {
                    status = Status.shield,
                    statusAmount = 2,
                    targetPlayer = true
                },
                new AAttack()
                {
                    damage = GetDmg(s, 1),
                    piercing = true,
                    fast = true
                },
                new AAttack()
                {
                    damage = GetDmg(s, 1),
                    piercing = true,
                    fast = true
                }
            ],
            Upgrade.None => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1, 
                    disabled = flipped
                },
                new AAttack()
                {
                    damage = GetDmg(s, 2),
                    piercing = true,
                    fast = true,
                    disabled = flipped
                },
                new AAttack()
                {
                    damage = GetDmg(s, 2),
                    piercing = true,
                    fast = true,
                    disabled = flipped
                },
                new ADummyAction(),
                new RuhigsAdaptability()
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
            return new CardData()
            {
                cost = 0,
                artTint = "6868b9",
                art = StableSpr.cards_Corrode,
                recycle = true
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 1,
                exhaust = false,
                artTint = "6868b9",
                art = StableSpr.cards_Corrode
            };
        }
        if (upgrade == Upgrade.None)
        {
            if (flipped == false)
            {
                return new CardData()
                {
                    cost = 1,
                    exhaust = false,
                    artTint = "6868b9",
                    floppable = true,
                    art = CorrodeTop
                };
            }
            if (flipped == true)
            {
                return new CardData()
                {
                    cost = 0,
                    exhaust = true,
                    artTint = "6868b9",
                    floppable = true,
                    art = CorrodeBottom
                };
            }
        }
        return default;
    }
};

