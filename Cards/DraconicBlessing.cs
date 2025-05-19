using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.Actions;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class DraconicBlessing : Card, IRegisterable
{

    private static IKokoroApi.IV2.IConditionalApi Conditional => ModEntry.Instance.KokoroApi.Conditional;


    private static Spr _sprite1; /* both getting the artwork and the code to do this was a cursed process https://discord.com/channels/806989214133780521/1138540954761035827/1365799089404645439*/
    private static Spr _sprite2;
    private static Spr _sprite3;
    private static Spr _sprite4;
    
    public static void
        

        Register(IPluginPackage<IModManifest> package,
            IModHelper helper)
    {
        _sprite1 = ModEntry.RegisterSprite(package, "assets/Card/DraconicBlessingBottom.png").Sprite;
        _sprite2 = ModEntry.RegisterSprite(package, "assets/Card/DraconicBlessingTop.png").Sprite;
        _sprite3 = ModEntry.RegisterSprite(package, "assets/Card/CursedBackground.png").Sprite;
        _sprite4 = ModEntry.RegisterSprite(package, "assets/Card/DespreateEnergy.png").Sprite;
            
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
            Upgrade.A => [
                new RuhigSupport()
                {
                    IsTempQuestionMark = ModEntry.Instance.Helper.Content.Cards.IsCardTraitActive(s, this, ModEntry.Instance.Helper.Content.Cards.TemporaryCardTrait )
                },
                new RuhigSupport()
                {
                    IsTempQuestionMark = ModEntry.Instance.Helper.Content.Cards.IsCardTraitActive(s, this, ModEntry.Instance.Helper.Content.Cards.TemporaryCardTrait )
                },
                new AEndTurn()
            ],
            Upgrade.B => [
                new AHeal()
                {
                    healAmount = 1,
                    targetPlayer = true
                },
                new AEnergy()
                {
                    changeAmount = 2
                }
            ],
            Upgrade.None => [
                new SelfDestruct()
                {
                    disabled = flipped
                },
                new RuhigSupport()
                {
                    disabled = flipped,
                    IsTempQuestionMark = ModEntry.Instance.Helper.Content.Cards.IsCardTraitActive(s, this, ModEntry.Instance.Helper.Content.Cards.TemporaryCardTrait )
                } ,
                new ADummyAction(),
                new RuhigsAdaptability()
                {
                    disabled = !flipped,
                },
                new AEnergy()
                {
                    changeAmount = 2,
                    disabled = !flipped
                },
            ]
        };
    }

    
        
    public override CardData GetData(State state)
    {

        
        if (upgrade == Upgrade.A)
        {
            return new CardData()
            {
                cost = 3,
                artTint = "6868b9",
                art = _sprite4,
                singleUse = true
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 0,
                exhaust = true,
                artTint = "6868b9",
                art = _sprite3
            };
        }
        if (upgrade == Upgrade.None)
        {
            if (flipped == false)
            {
                return new CardData()
                {
                    cost = 3,
                    exhaust = true,
                    artTint = "6868b9",
                    floppable = true,
                    art = _sprite2,
                    singleUse = true
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
                    art = _sprite1,
                    singleUse = false
                };
            }
        }
        return default;
    }
};

