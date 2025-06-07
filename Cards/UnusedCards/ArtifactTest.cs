using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Nanoray.PluginManager;
using Nickel;
using RuhigMod.Artifacts;
using RuhigMod.External;

namespace RuhigMod.Cards; 
// This card was used to see if adding an Artifact via a card was viable or not.


public class ArtifactTest : Card, IRegisterable
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
                rarity = Rarity.uncommon, 
                dontOffer = false, 
                upgradesTo = [Upgrade.A, Upgrade.B] 
            },
            Name = ModEntry.Instance.AnyLocalizations.Bind(["card", "ArtifactTest", "name"])
                .Localize,
            Art = StableSpr.cards_DesperateMeasures,
        });
    }
        public override List<CardAction> GetActions(State s, Combat c)
    {
        return upgrade switch 
        {
            Upgrade.None => [
                new AAddArtifact()
                {
                    artifact = new RuhigsRepairKit()
                }
            ],
            Upgrade.A => [
                new AAddArtifact()
                {
                    artifact = new SharpEdges()
                }
            ],
            Upgrade.B => [
                new AAddArtifact()
                {
                    artifact = new HullArtifacts()
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
                cost = 1, 
                exhaust = true,
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.A)
        {
            return new CardData()
            {
                cost = 0,
                exhaust = true,
                artTint = "6868b9"
            };
        }
        if (upgrade == Upgrade.B)
        {
            return new CardData()
            {
                cost = 1,
                exhaust = true,
                artTint = "6868b9"
            };
        }
        return default;
    }
};

