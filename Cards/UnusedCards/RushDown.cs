using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using RuhigMod.Actions;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class RushDown : Card, IRegisterable
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "RushDown", "name"])
                .Localize,
            Art = StableSpr.cards_Ace
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
                new AVariableHint()
                {
                    status = (Status.evade)
                },
                new AAttack()
                {
                damage = GetDmg(s, GetEvadeAmt(s)),
                piercing = true,
                xHint = 1
                }
            ],
            Upgrade.A => [
                new AHurt()
                {
                    targetPlayer = true,
                    hurtAmount = 2 
                },
                new AVariableHint()
                {
                    status = (Status.evade),
                    secondStatus = (Status.heat)
                },
                new AAttack()
                {
                    damage = GetDmg(s, GetEvadePlusHeatAmt(s)),
                    piercing = true,
                    xHint = 1
                }
            ],
            Upgrade.B => [
                new AStatus()
                {
                    status = Status.maxShield,
                    statusAmount = -99,
                    mode = AStatusMode.Set,
                    targetPlayer = true
                },
                new AStatus()
                {
                    status = Status.tempShield,
                    statusAmount = 0,
                    mode = AStatusMode.Set,
                    targetPlayer = true
                },
                new AVariableHint()
                {
                    status = (Status.evade)
                },
                new AAttack()
                {
                    damage = GetDmg(s, GetEvadeAmt(s)),
                    piercing = true,
                    xHint = 1
                }
            ],
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public int GetEvadeAmt(State s)
    {
        int evadeAmt = 0;
        if (s.route is Combat)
            evadeAmt = s.ship.Get(Status.evade);
        return evadeAmt;
    }
    
    public int GetEvadePlusHeatAmt(State s)
    {
        int num = 0;
        if (s.route is Combat)
            num = ( s.ship.Get(Status.evade)  + s.ship.Get(Status.heat));
        return num;
    }
    
    public override CardData GetData(State state)
    {
        if (upgrade == Upgrade.None) 
        {
            return new CardData()
            {
                cost = 4, 
                exhaust = false,
                artTint = "6868b9",
            };
        }
        if (upgrade == Upgrade.A)
        {
            return new CardData()
            {
                cost = 3,
                exhaust = false,
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 3,
                exhaust = false,
                artTint = "6868b9"
            };
        }
        return default;
    }
};

