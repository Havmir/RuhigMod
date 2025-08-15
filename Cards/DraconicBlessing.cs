using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.Actions;

namespace RuhigMod.Cards; 

public class DraconicBlessing : Card, IRegisterable
{


    private static Spr _sprite1; /* both getting the artwork and the code to do this was a cursed process https://discord.com/channels/806989214133780521/1138540954761035827/1365799089404645439*/
    private static Spr _sprite2;
    private static Spr _sprite3;
    
    public static void
        

        Register(IPluginPackage<IModManifest> package,
            IModHelper helper)
    {
        _sprite1 = ModEntry.RegisterSprite(package, "assets/Card/DraconicBlessingBottom.png").Sprite;
        _sprite2 = ModEntry.RegisterSprite(package, "assets/Card/DraconicBlessingTop.png").Sprite;
        _sprite3 = ModEntry.RegisterSprite(package, "assets/Card/DraconicBlessingB.png").Sprite;
            
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "DraconicBlessing", "name"])
                .Localize

        });
    }
        public override List<CardAction> GetActions(State s, Combat c)
        { 
            return upgrade switch 
        {
            Upgrade.B => [
                new AEnergy()
                {
                    changeAmount = 2,
                },
                new AStatus()
                {
                    targetPlayer = true,
                    status = Status.energyNextTurn,
                    statusAmount = 1,
                    dialogueSelector = ".DraconicBlessingBottom"
                }
            ],
            Upgrade.A => [
                new SelfDestruct()
                {
                    disabled = flipped
                },
                new RuhigSupportDouble()
                {
                    disabled = flipped,
                    IsTempQuestionMark = ModEntry.Instance.Helper.Content.Cards.IsCardTraitActive(s, this, ModEntry.Instance.Helper.Content.Cards.TemporaryCardTrait )
                } ,
                new InvisableRuhigSupport()
                {
                    disabled = flipped,
                    IsTempQuestionMark = ModEntry.Instance.Helper.Content.Cards.IsCardTraitActive(s, this, ModEntry.Instance.Helper.Content.Cards.TemporaryCardTrait ),
                    dialogueSelector = ".DraconicBlessingTop"
                },
                new RuhigsAdaptability()
                {
                    disabled = !flipped,
                },
                new AEnergy()
                {
                    changeAmount = 3,
                    disabled = !flipped,
                    dialogueSelector = ".DraconicBlessingBottom"
                },
            ],
            Upgrade.None => [
                new SelfDestruct()
                {
                    disabled = flipped
                },
                new RuhigSupport()
                {
                    disabled = flipped,
                    IsTempQuestionMark = ModEntry.Instance.Helper.Content.Cards.IsCardTraitActive(s, this, ModEntry.Instance.Helper.Content.Cards.TemporaryCardTrait ),
                    dialogueSelector = ".DraconicBlessingTop"
                } ,
                new ADummyAction(),
                new RuhigsAdaptability()
                {
                    disabled = !flipped,
                },
                new AEnergy()
                {
                    changeAmount = 2,
                    disabled = !flipped,
                    dialogueSelector = ".DraconicBlessingBottom"
                },
            ],
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    
    
    public override CardData GetData(State state)
    {

        
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 0,
                artTint = "ffffff",
                art = _sprite3,
                exhaust = true
            };
        }
        if (upgrade == Upgrade.A)
        {
            if (flipped == false)
            {
                return new CardData()
                {
                    cost = 2,
                    exhaust = true,
                    artTint = "ffffff",
                    floppable = true,
                    art = _sprite2,
                    singleUse = true
                };
            }
            if (flipped)
            {
                return new CardData()
                {
                    cost = 0,
                    exhaust = true,
                    artTint = "ffffff",
                    floppable = true,
                    art = _sprite1,
                    singleUse = false
                };
            }
        }
        if (upgrade == Upgrade.None)
        {
            if (flipped == false)
            {
                return new CardData()
                {
                    cost = 3,
                    exhaust = true,
                    artTint = "ffffff",
                    floppable = true,
                    art = _sprite2,
                    singleUse = true
                };
            }
            if (flipped)
            {
                return new CardData()
                {
                    cost = 0,
                    exhaust = true,
                    artTint = "ffffff",
                    floppable = true,
                    art = _sprite1,
                    singleUse = false
                };
            }
        }
        return default;
    }
};

