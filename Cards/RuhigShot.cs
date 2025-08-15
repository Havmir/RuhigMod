using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.Actions;
using RuhigMod.Features;


namespace RuhigMod.Cards; 

public class RuhigShot : Card, IRegisterable
{
        
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
                new AHurt
                {
                    targetPlayer = true,
                    hurtAmount = 1, 
                    disabled = flipped
                },
                new AAttack
                {
                    damage = GetDmg(s, 2),
                    piercing = true,
                    fast = true,
                    disabled = flipped
                },
                new AAttack
                {
                    damage = GetDmg(s, 2),
                    piercing = true,
                    fast = true,
                    disabled = flipped,
                    dialogueSelector = ".RuhigShot"
                },
                new ADummyAction(),
                new RuhigsAdaptability
                {
                    disabled = !flipped,
                    dialogueSelector = ".RuhigAdaptability"
                } 
            ],
            Upgrade.B => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 1 
                },
                new AAttack()
                {
                    damage = GetDmg(s, 2),
                    piercing = true,
                    fast = true
                },
                new AAttack()
                {
                    damage = GetDmg(s,2),
                    piercing = true,
                    fast = true
                },
                new AAttack()
                {
                    damage = GetDmg(s,2),
                    piercing = true,
                    fast = true
                },
                new AStatus()
                {
                    status = Status.overdrive,
                    statusAmount = 1,
                    targetPlayer = true,
                    dialogueSelector = ".RuhigShot"
                },
            ],
            Upgrade.None => [
                new AHurt
                {
                    targetPlayer = true,
                    hurtAmount = 1, 
                    disabled = flipped,
                },
                new AAttack
                {
                    damage = GetDmg(s, 2),
                    piercing = true,
                    fast = true,
                    disabled = flipped
                },
                new AAttack
                {
                    damage = GetDmg(s, 2),
                    piercing = true,
                    fast = true,
                    disabled = flipped,
                    dialogueSelector = ".RuhigShot"
                },
                new ADummyAction(),
                new RuhigsAdaptability
                {
                    disabled = !flipped,
                    dialogueSelector = ".RuhigAdaptability"
                } ,
            ],
            

            
            _ => throw new ArgumentOutOfRangeException()
        };
        //return default!;
        
    }

        
    public override CardData GetData(State state)
    {
        switch (upgrade)
        {
            case Upgrade.A when flipped == false:
                return new CardData()
                {
                    cost = 0,
                    exhaust = false,
                    artTint = "6868b9",
                    floppable = true,
                    art = CorrodeTop
                };
            case Upgrade.A when flipped:
                return new CardData()
                {
                    cost = 0,
                    exhaust = true,
                    artTint = "6868b9",
                    floppable = true,
                    art = CorrodeBottom
                };
            case Upgrade.B:
                return new CardData()
                {
                    cost = 2,
                    exhaust = false,
                    artTint = "6868b9",
                    art = StableSpr.cards_Corrode
                };
            case Upgrade.None when flipped == false:
                return new CardData()
                {
                    cost = 1,
                    exhaust = false,
                    artTint = "6868b9",
                    floppable = true,
                    art = CorrodeTop
                };
            case Upgrade.None when flipped:
                return new CardData()
                {
                    cost = 0,
                    exhaust = true,
                    artTint = "6868b9",
                    floppable = true,
                    art = CorrodeBottom
                };
            default:
                return default;
        }
    }
};

