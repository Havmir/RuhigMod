using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.Actions;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class PowerUpShot : Card, IRegisterable /* name of card needs to go first purple */
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
                upgradesTo = [Upgrade.A, Upgrade.B],
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "PowerUpShot", "name"])
                .Localize, 
            Art = ModEntry.RegisterSprite(package, "assets/Card/IHateThisArtwork.png").Sprite
        });
    }
        public override List<CardAction> GetActions(State s, Combat c) 
    {
        return upgrade switch 
        {
            Upgrade.None => [
                new AHurt()
                {
                    hurtAmount = 1,
                    targetPlayer = true
                },
                new AAttack()
                {
                    piercing = true,
                    damage = GetDmg(s, 1)
                },
                new AStatus()
                {
                    status = Status.overdrive,
                    statusAmount = 1,
                    targetPlayer = true
                }
            ],
            Upgrade.A => [
                new AHurt()
                {
                    hurtAmount = 1,
                    targetPlayer = true
                },
                new AAttack()
                {
                    piercing = true,
                    damage = GetDmg(s, 1)
                },
                new AStatus()
                {
                    status = Status.overdrive,
                    statusAmount = 2,
                    targetPlayer = true
                }
            ],
            Upgrade.B => [
                new AHurt()
                {
                    hurtAmount = 1,
                    targetPlayer = true
                },
                new AAttack()
                {
                    piercing = true,
                    damage = GetDmg(s, 1),
                    stunEnemy = true
                },
                new AStatus()
                {
                    status = Status.overdrive,
                    statusAmount = 1,
                    targetPlayer = true
                }
            ]
        };
    }

        
    public override CardData GetData(State state)
    {
        if (upgrade == Upgrade.None)
        {
            return new CardData()
            {
                cost = 0,
                artTint = "ffffff"
            };
        }
        if (upgrade == Upgrade.A)
        {
            return new CardData()
            {
                cost = 0,
                artTint = "ffffff"
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 0,
                artTint = "ffffff"
            };
        }
        return default;
    }
}

