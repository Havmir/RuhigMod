using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 
public class FiftyFifty : Card, IRegisterable
{

    private static IKokoroApi.IV2.IConditionalApi Conditional => ModEntry.Instance.KokoroApi.Conditional; 
    public static Spr SolarBreezeTop;
    public static Spr SolarBreezeBottom;

    public static void
        Register(IPluginPackage<IModManifest> package,
            IModHelper helper) 
    {
        SolarBreezeTop = ModEntry.RegisterSprite(package, "assets/Card/SolarBreezeTop.png").Sprite;
        SolarBreezeBottom = ModEntry.RegisterSprite(package, "assets/Card/SolarBreezeBottom.png").Sprite;
        
        helper.Content.Cards.RegisterCard(new CardConfiguration
        {
            CardType = MethodBase.GetCurrentMethod()!.DeclaringType!,
            Meta = new CardMeta
            {
                deck = ModEntry.Instance.RuhigDeck
                    .Deck, 
                rarity = Rarity.uncommon, 
                dontOffer = true, 
                upgradesTo = [Upgrade.A, Upgrade.B] 
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "FiftyFifty", "name"])
                .Localize,
            Art = StableSpr.cards_SolarBreeze,
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
                new AStatus()
                {
                    status = Status.overdrive,
                    disabled = flipped, 
                    statusAmount = 1,
                    targetPlayer = true
                },
                new ADummyAction(),
                new AStatus()
                {
                    status = Status.evade,
                    statusAmount = 1,
                    targetPlayer = true,
                    disabled = !flipped
                },
                new AAttack()
                {
                    damage = GetDmg(s, 0),
                    piercing = true,
                    fast = true,
                    disabled = !flipped
                }
            ],
            Upgrade.A => [
                new AHurt()
                {   
                    disabled = flipped,
                    targetPlayer = true,
                    hurtAmount = 1 
                },
                new AStatus()
                {
                    status = Status.overdrive,
                    disabled = flipped, 
                    statusAmount = 2,
                    targetPlayer = true
                },
                new ADummyAction(),
                new AStatus()
                {
                    status = Status.evade,
                    statusAmount = 1,
                    targetPlayer = true,
                    disabled = !flipped
                },
                new AAttack()
                {
                    damage = GetDmg(s, 2),
                    piercing = true,
                    fast = true,
                    disabled = !flipped
                }
            ],
            Upgrade.B => [
                new AStatus()
                {
                    status = Status.maxShield,
                    disabled = flipped, 
                    statusAmount = 1,
                    targetPlayer = true
                },
                new AStatus()
                {
                    status = Status.tempShield,
                    disabled = flipped, 
                    statusAmount = 2,
                    targetPlayer = true
                },
                new ADummyAction(),
                new AStatus()
                {
                    status = Status.evade,
                    statusAmount = 2,
                    targetPlayer = true,
                    disabled = !flipped
                },
                new AAttack()
                {
                    damage = GetDmg(s, 0),
                    piercing = true,
                    fast = true,
                    stunEnemy = true,
                    disabled = !flipped
                }
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
                    cost = 0, 
                    exhaust = true,
                    floppable = true,
                    artTint = "6868b9",
                    art = SolarBreezeTop
                };
            }
            if (flipped == true)
            {
                return new CardData()
                {
                    cost = 0, 
                    exhaust = true,
                    floppable = true,
                    artTint = "6868b9",
                    art = SolarBreezeBottom
                };
            }
        }
        if (upgrade == Upgrade.A)
        {
            if (flipped == false)
            {
                return new CardData()
                {
                    cost = 1,
                    exhaust = true,
                    floppable = true,
                    artTint = "6868b9",
                    art = SolarBreezeTop
                };
            }
            if (flipped == true)
            {
                return new CardData()
                {
                    cost = 1,
                    exhaust = true,
                    floppable = true,
                    artTint = "6868b9",
                    art = SolarBreezeBottom
                };
            }
        }
        if (upgrade == Upgrade.B)
        {
            if (flipped == false)
            {
                return new CardData()
                {
                    cost = 1,
                    exhaust = true,
                    floppable = true,
                    artTint = "6868b9",
                    art = SolarBreezeTop
                };
            }
            if (flipped == true)
            {
                return new CardData()
                {
                    cost = 1,
                    exhaust = true,
                    floppable = true,
                    artTint = "6868b9",
                    art = SolarBreezeBottom
                };
            }
        }
        return default;
    }
};

