using System;
using System.Collections.Generic;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.External;

namespace RuhigMod.Cards; 

public class ComboSetUp : Card, IRegisterable 
{

    private static IKokoroApi.IV2.IConditionalApi Conditional => ModEntry.Instance.KokoroApi.Conditional; 
    public static Spr ComboTop; /* both getting the artwork and the code to do this was a cursed process https://discord.com/channels/806989214133780521/1138540954761035827/1365799089404645439*/
    public static Spr ComboBottom;

    public static void
        Register(IPluginPackage<IModManifest> package,
            IModHelper helper) 
    {
        ComboTop = ModEntry.RegisterSprite(package, "assets/Card/ComboTop.png").Sprite;
        ComboBottom = ModEntry.RegisterSprite(package, "assets/Card/ComboBottom.png").Sprite;
        
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
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "ComboSetUp", "name"])
                .Localize, 
            Art = ModEntry.RegisterSprite(package, "assets/Card/Combo.png").Sprite /* Default Art */
        });
    }
        public override List<CardAction> GetActions(State s, Combat c) 
    {
        return upgrade switch 
        {
            Upgrade.None => [
                new ASpawn()
                {
                    thing = new JupiterDrone()
                    {
                        targetPlayer = true
                    },
                    offset = 0,
                    disabled = flipped
                },
                new ADummyAction(),
                new ADummyAction(),
                new AStatus()
                {
                    status = Status.payback,
                    disabled = !flipped, 
                    statusAmount = 1,
                    targetPlayer = true
                },
                new ADummyAction(),
            ],
            Upgrade.A => [
                new AHurt()
                {
                disabled = flipped,
                targetPlayer = true,
                hurtAmount = 4 
                },
                new ASpawn()
                {
                    thing = new JupiterDrone()
                    {
                        targetPlayer = true
                    },
                    offset = 0,
                },
                new AStatus()
                {
                    status = Status.payback,
                    statusAmount = 1,
                    targetPlayer = true
                }
            ],
            Upgrade.B => [
                new ASpawn()
                {
                    thing = new JupiterDrone()
                    {
                        targetPlayer = true
                    },
                    offset = 0,
                },
                new AStatus()
                {
                    status = Status.payback,
                    statusAmount = 1,
                    targetPlayer = true
                },
                new AEndTurn()
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
                    cost = 3,
                    exhaust = false,
                    artTint = "6868b9",
                    floppable = true,
                    art = ComboTop
                };
            }
            if (flipped == true)
            {
                return new CardData()
                {
                    cost = 3,
                    exhaust = false,
                    artTint = "6868b9",
                    floppable = true,
                    art = ComboBottom
                };
            }
        }
        if (upgrade == Upgrade.A)
        {
            return new CardData()
            {
                cost = 2,
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 4,
                floppable = false,
                artTint = "6868b9"
            };
        }
        return default;
    }
};

