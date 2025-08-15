using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using RuhigMod;
using Microsoft.Extensions.Logging;
using Nickel;
using RuhigMod.Artifacts;
using static RuhigMod.Dialogue.CommonDefinitions;

namespace RuhigMod.Dialogue;

internal static class ArtifactDialogue
{
    internal static ModEntry Instance => ModEntry.Instance;
    internal static string F(this string Name)
    {
        // Shockah recommended I try using Instance.Package.Manifest.UniqueName https://discord.com/channels/806989214133780521/1138540954761035827/1394202554912735264
        return $"{Instance.UniqueName}::{Name}";
    }
    internal static void Inject()
    {
        DB.story.all["Ruhig_HullAddOn_Multi_0"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig ],
            hasArtifacts = [ "HullAddOn".F() ],
            oncePerRunTags = [ "HullAddOnTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I found something that adds onto our hull quite nicely.",
                    loopTag = "neutral"
                }
            }
        };

        DB.story.all["Ruhig_HullAddOn_Multi_1"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig ],
            hasArtifacts = [ "HullAddOn".F() ],
            oncePerRunTags = [ "HullAddOnTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We'll get a couple more uses from my cards now.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HullAddOn_Multi_2"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig],
            hasArtifacts = [ "HullAddOn".F() ],
            oncePerRunTags = [ "HullAddOnTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I found something that will give us a couple extra hull next time we repair at Cleo's.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HullAddOn_Multi_3"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig],
            hasArtifacts = [ "HullPlating".F() ],
            oncePerRunTags = [ "HullAddOnTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "This is some nice hull plating.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HullAddOn_Multi_4"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig],
            hasArtifacts = [ "HullPlating".F() ],
            oncePerRunTags = [ "HullAddOnTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I have some cards that will make good use of the extra hull.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HullAddOn_Multi_5"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig],
            hasArtifacts = [ "HullPlating".F() ],
            oncePerRunTags = [ "HullAddOnTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Nice, we got some extra hull to use.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HealthPotion_Multi_0"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig],
            hasArtifacts = [ "HealthPotion".F() ],
            oncePerRunTags = [ "HealthPotionTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Health Potion anyone?",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HealthPotion_Multi_1"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig],
            hasArtifacts = [ "HealthPotion".F() ],
            oncePerRunTags = [ "HealthPotionTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "That cork was sealed TIGHT.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HealthPotion_Multi_2"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig],
            hasArtifacts = [ "HealthPotion".F() ],
            oncePerRunTags = [ "HealthPotionTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "That cork was sealed TIGHT.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HeavyHull_Multi_0"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig ],
            hasArtifacts = [ "HeavyHull".F() ],
            oncePerRunTags = [ "HeavyHullTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I like the extra hull ... but it does make us slower.",
                    loopTag = "neutral"
                }
            }
        };
       
        DB.story.all["Ruhig_HeavyHull_Multi_1"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig, Dizzy],
            hasArtifacts = [ "HeavyHull".F() ],
            oncePerRunTags = [ "HeavyHullTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We can handle a lot more shielding now.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HeavyHull_Multi_2"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig, Hyperia ],
            hasArtifacts = [ "HeavyHull".F() ],
            oncePerRunTags = [ "HeavyHullTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "This hull is heavy ... let's see if we can get through these enimies quickly.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HeavyHull_Multi_3"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig ],
            hasArtifacts = [ "HeavyHull".F() ],
            oncePerRunTags = [ "HeavyHullTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "That's a lot of hull we just added.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HeavyHull_Multi_4"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig ],
            hasArtifacts = [ "HeavyHull".F() ],
            oncePerRunTags = [ "HeavyHullTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Getting more hull per repairs is going to be nice.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HullGraft_Multi_0"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig ],
            hasArtifacts = [ "HullGraft".F() ],
            oncePerRunTags = [ "HullGraftTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I'm looking forward to stopping at Cleo's to add even more hull to this ship.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HullGraft_Multi_1"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig ],
            hasArtifacts = [ "HullGraft".F() ],
            oncePerRunTags = [ "HullGraftTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "After this fight, I'mma grab some of their hull.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HullGraft_Multi_2"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig ],
            hasArtifacts = [ "HullGraft".F() ],
            oncePerRunTags = [ "HullGraftTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Let's get better repairs going.",
                    loopTag = "neutral"
                }
            }
        };

        DB.story.all["Ruhig_RuhigAmulet_Multi_0"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig ],
            hasArtifacts = [ "RuhigAmulet".F() ],
            oncePerRunTags = [ "RuhigAmuletTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Look, I found my lost amulet again.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigAmulet_Multi_1"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig ],
            hasArtifacts = [ "RuhigAmulet".F() ],
            oncePerRunTags = [ "RuhigAmuletTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I got my amulet back, nice.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigAmulet_Multi_2"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig ],
            hasArtifacts = [ "RuhigAmulet".F() ],
            oncePerRunTags = [ "RuhigAmuletTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We can get some lost hull back now.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigAmulet_Multi_3"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig, Books ],
            hasArtifacts = [ "RuhigAmulet".F() ],
            oncePerRunTags = [ "RuhigAmuletTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Books, look; I have my enchanted amulet back.",
                    loopTag = "neutral"
                },
                new CustomSay
                {
                who = Books,
                Text = "Books, look; I have my enchanted amulet back.",
                loopTag = "stoked"
            }
            }
        };
        
        DB.story.all["Ruhig_RuhigsRepaitKit_Multi_0"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig ],
            hasArtifacts = [ "RuhigsRepaitKit".F() ],
            oncePerRunTags = [ "RuhigsRepaitKitTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Look, I found my lost repair kit again.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigsRepaitKit_Multi_1"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig ],
            hasArtifacts = [ "RuhigsRepaitKit".F() ],
            oncePerRunTags = [ "RuhigsRepaitKitTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I got my repair kit back, nice.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigAmulet_Multi_2"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig ],
            hasArtifacts = [ "RuhigAmulet".F() ],
            oncePerRunTags = [ "RuhigAmuletTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I can help with repairs now.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigBoostedNano_Multi_0"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig ],
            hasArtifacts = [ "NanofiberHull".F(), "HealBooster".F() ],
            oncePerRunTags = [ "RuhigBoostedNanoTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I love the Boosted Nanofiber combo, really helps out with getting more hull to spend. ;)",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigSimpleEdges_Multi_0"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig ],
            hasArtifacts = [ "Simplicity".F(), "SharpEdges".F() ],
            oncePerRunTags = [ "RuhigSimpleEdgesTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We have Simplicity and SharpEdges, are we going for a reshuffle build?",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigSimpleEdges_Multi_0"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig ],
            hasArtifacts = [ "Simplicity".F(), "SharpEdges".F() ],
            oncePerRunTags = [ "RuhigSimpleEdgesTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We have Simplicity and SharpEdges, are we going for a reshuffle build?",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigSimpleEdges_Multi_0"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig ],
            hasArtifacts = [ "Simplicity".F(), "SharpEdges".F() ],
            oncePerRunTags = [ "RuhigSimpleEdgesTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We have Simplicity and SharpEdges, are we going for a reshuffle build?",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigRevengeDrive_Multi_0"] = new()
        {
            type = NodeType.combat,
            allPresent = [ Ruhig, Hyperia ],
            hasArtifacts = [ "RevengeDrive".F() ],
            oncePerRunTags = [ "RuhigRevengeDriveTag" ],
            turnStart = true,
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Nice to see other people using hull to get benefits.",
                    loopTag = "neutral"
                }
            }
        };
    }
}