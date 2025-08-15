using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using RuhigMod;
using Microsoft.Extensions.Logging;
using Nickel;
using static RuhigMod.Dialogue.CommonDefinitions;

namespace RuhigMod.Dialogue;

internal static class CombatDialogue
{
    internal static void Inject()
    {
        Replies();
        ModdedInject();
        MainExtensions();
    }

    private static void MainExtensions()
    {
        DB.story.all["Ruhig_genericdamage_0"] = new()
		{
			type = NodeType.combat,
			playerShotJustHit = true,
			minDamageDealtToEnemyThisAction = 1,
			allPresent = [ Ruhig ],
			lines = new()
            {
                new CustomSay
			    {
				    who = Ruhig,
				    Text = "We hit.",
				    loopTag = "neutral"
			    }
            }
		};
		
        DB.story.all["Ruhig_genericdamage_1"] = new()
		{
			type = NodeType.combat,
			playerShotJustHit = true,
			minDamageDealtToEnemyThisAction = 1,
			maxDamageDealtToEnemyThisAction = 1,
			allPresent = [ Ruhig ],
			lines = new()
			{
				new CustomSay
				{
					who = Ruhig,
					Text = "We got some chip damage.",
					loopTag = "neutral"
				}
			}
		};

		DB.story.all["Ruhig_genericdamage_2"] = new()
		{
			type = NodeType.combat,
			playerShotJustHit = true,
			minDamageDealtToEnemyThisAction = 1,
			allPresent = [ Ruhig ],
			lines = new()
            {
                new CustomSay
			    {
				    who = Ruhig,
				    Text = "Attack landed.",
				    loopTag = "neutral" // Requires "aggressive" emote.
			    }
            }
		};
		
		
		DB.story.all["Ruhig_genericdamage_3"] = new()
		{
			type = NodeType.combat,
			playerShotJustHit = true,
			minDamageDealtToEnemyThisAction = 1,
			maxDamageDealtToEnemyThisAction = 1,
			allPresent = [ Ruhig ],
			lines = new()
			{
				new CustomSay
				{
					who = Ruhig,
					Text = "Some chip damage.",
					loopTag = "neutral"
				}
			}
		};
		

        DB.story.all["Ruhig_moving_Multi_0"] = new()
		{
			type = NodeType.combat,
            minMovesThisTurn = 1,
			allPresent = [ Ruhig ],
			lines = new()
            {
                new CustomSay
			    {
				    who = Ruhig,
				    Text = "A little evade.",
				    loopTag = "neutral"
			    }
            }
		};

        DB.story.all["Ruhig_moving_Multi_1"] = new()
		{
			type = NodeType.combat,
            minMovesThisTurn = 1,
			allPresent = [ Ruhig ],
			lines = new()
            {
                new CustomSay
			    {
				    who = Ruhig,
				    Text = "get a better position",
				    loopTag = "neutral"
			    }
            }
		};

		DB.story.all["Ruhig_moving_Multi_2"] = new()
		{
			type = NodeType.combat,
            minMovesThisTurn = 1,
			allPresent = [ Ruhig ],
			hasArtifacts = [ "Crosslink" ],
			lines = new()
            {
                new CustomSay
			    {
				    who = Ruhig,
				    Text = "Building up crosslink.",
				    loopTag = "neutral"
			    }
            }
		};

		DB.story.all["Ruhig_moving_Multi_3"] = new()
		{
			type = NodeType.combat,
			minMovesThisTurn = 5,
			allPresent = [ Ruhig ],
			lines = new()
			{
				new CustomSay
				{
					who = Ruhig,
					Text = "We schmov'in.",
					loopTag = "neutral"
				}
			}
		};

		DB.story.all["Ruhig_noOverlap_Multi_0"] = new()
		{
			type = NodeType.combat,
			allPresent = [Ruhig],
			priority = true,
			shipsDontOverlapAtAll = true,
			oncePerCombatTags = ["NoOverlapBetweenShips"],
			oncePerRun = true,
			nonePresent = ["crab", "scrap"],
			lines = new()
			{
				new CustomSay
				{
					who = Ruhig,
					Text = "Let's make em approch us.",
					loopTag = "neutral"
				}
			}
		};
		
		DB.story.all["Ruhig_noOverlap_Multi_1"] = new()
		{
			type = NodeType.combat,
			allPresent = [Ruhig],
			priority = true,
			shipsDontOverlapAtAll = true,
			oncePerCombatTags = ["NoOverlapBetweenShips"],
			oncePerRun = true,
			nonePresent = ["crab", "scrap"],
			lines = new()
			{
				new CustomSay
				{
					who = Ruhig,
					Text = "All right, let's camp.",
					loopTag = "neutral"
				}
			}
		};

        DB.story.all["Ruhig_OverheatGeneric_0"] = new()
		{
			type = NodeType.combat,
			goingToOverheat = true,
			oncePerCombatTags = [ "OverheatGeneric" ],
			allPresent = [ Ruhig ],
			lines = new()
            {
                new CustomSay
			    {
				    who = Ruhig,
				    Text = "It seems hot in here ...",
				    loopTag = "neutral"
			    }
            }
		};

        DB.story.all["Ruhig_OverheatGeneric_1"] = new()
		{
			type = NodeType.combat,
			goingToOverheat = true,
			oncePerCombatTags = [ "OverheatGeneric" ],
			allPresent = [ Ruhig ],
			lines = new()
            {
                new CustomSay
			    {
				    who = Ruhig,
				    Text = "Can we do something with this heat?",
				    loopTag = "neutral"
			    }
            }
		};
        
		DB.story.all["Ruhig_OverheatGeneric_2"] = new()
		{
			type = NodeType.combat,
			goingToOverheat = true,
			oncePerCombatTags = [ "OverheatGeneric" ],
			allPresent = [ Ruhig ],
			lines = new()
			{
				new CustomSay
				{
					who = Ruhig,
					Text = "We can use some hull to deal with this heat.",
					loopTag = "neutral"
				}
			}
		};
		
		DB.story.all["Ruhig_OverheatGeneric_3"] = new()
		{
			type = NodeType.combat,
			goingToOverheat = true,
			oncePerCombatTags = [ "OverheatGeneric" ],
			allPresent = [ Ruhig ],
			lines = new()
			{
				new CustomSay
				{
					who = Ruhig,
					Text = "Hopefully we used our hull wisely here.",
					loopTag = "neutral"
				}
			}
		};

        DB.story.all["Ruhig_OverheadDrakesFault_Multi_0"] = new()
		{
			type = NodeType.combat,
			goingToOverheat = true,
            whoDidThat = Eunice_Deck,
			oncePerCombatTags = [ "OverheatDrakesFault" ],
			allPresent = [ Ruhig, Eunice ],
			lines = new()
            {
                new CustomSay
			    {
				    who = Ruhig,
				    Text = "Drake, it's getting hot in here; do you have a plan?",
				    loopTag = "neutral"
			    }
            }
		};

        DB.story.all["Ruhig_OverheadDrakesFault_Multi_1"] = new()
		{
			type = NodeType.combat,
			goingToOverheat = true,
            whoDidThat = Eunice_Deck,
			oncePerCombatTags = [ "OverheatDrakesFault" ],
			allPresent = [ Ruhig, Eunice ],
			lines = new()
            {
                new CustomSay
			    {
				    who = Ruhig,
				    Text = "Drake, should I pick up some serenity when I get the chance?",
				    loopTag = "neutral"
			    },
                new CustomSay
                {
	                who = Eunice,
	                Text = "Nah, overheating is a myth.",
	                loopTag = "slyBlush"
                }
            }
		};

        DB.story.all["Ruhig_OneHullIsTheOnlyOneThatMatters_Multi_0"] = new()
		{
			type = NodeType.combat,
			oncePerCombatTags = [ "aboutToDie" ],
			allPresent = [ Ruhig ],
            oncePerRun = true,
            enemyShotJustHit = true,
            maxHull = 1,
			lines = new()
            {
                new CustomSay
			    {
				    who = Ruhig,
				    Text = "I have no more hull to use :(",
				    loopTag = "neutral"
			    }
            }
		};
        
		DB.story.all["Ruhig_OneHullIsTheOnlyOneThatMatters_Multi_1"] = new()
		{
			type = NodeType.combat,
			oncePerCombatTags = [ "aboutToDie" ],
			allPresent = [ Ruhig ],
			oncePerRun = true,
			enemyShotJustHit = true,
			maxHull = 1,
			lines = new()
			{
				new CustomSay
				{
					who = Ruhig,
					Text = "Does anyone have any healing? I need more hull.",
					loopTag = "neutral"
				}
			}
		};
		
		DB.story.all["Ruhig_OneHullIsTheOnlyOneThatMatters_Multi_2"] = new()
		{
			type = NodeType.combat,
			oncePerCombatTags = [ "aboutToDie" ],
			allPresent = [ Ruhig ],
			oncePerRun = true,
			enemyShotJustHit = true,
			maxHull = 1,
			lines = new()
			{
				new CustomSay
				{
					who = Ruhig,
					Text = "Welp, let's see if I used my hull wisely.",
					loopTag = "neutral"
				}
			}
		};
		
		DB.story.all["Ruhig_OneHullIsTheOnlyOneThatMatters_Multi_3"] = new()
		{
			type = NodeType.combat,
			oncePerCombatTags = [ "aboutToDie" ],
			allPresent = [ Ruhig ],
			oncePerRun = true,
			enemyShotJustHit = true,
			maxHull = 1,
			lines = new()
			{
				new CustomSay
				{
					who = Ruhig,
					Text = "The only hull that matters is the last one!",
					loopTag = "neutral"
				}
			}
		};

        DB.story.all["Ruhig_OneHullIsTheOnlyOneThatMatters_Multi_4"] = new()
		{
			type = NodeType.combat,
			oncePerCombatTags = [ "aboutToDie" ],
			allPresent = [ Ruhig ],
            oncePerRun = true,
            enemyShotJustHit = true,
            maxHull = 1,
			lines = new()
            {
                new CustomSay
			    {
				    who = Riggs,
				    Text = "Thinking back on this run, I think I know where we misplayed and figured out what we can try to do better next time.",
				    loopTag = "nuetral"
			    },

            }
		};

    }

    private static void Replies()
    {

    }

    private static void ModdedInject()
    {

    }
}