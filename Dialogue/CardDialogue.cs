using static RuhigMod.Dialogue.CommonDefinitions;

namespace RuhigMod.Dialogue;

// 662

internal static class CardDialogue
{
    internal static void Inject()
    {
        DB.story.all["Ruhig_RuhigShot_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigShot" ],
            oncePerRunTags = [ "ruhigRuhigShotTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "A good time to use my signature attack.",
                    loopTag = "neutral"
                },
            }
        };

        DB.story.all["Ruhig_RuhigShot_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigShot" ],
            oncePerRunTags = [ "ruhigRuhigShotTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I had to use some hull, but I put some good power behind that attack.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigShot_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            //lookup = [ "RuhigShot" ],
            lines = new()
            {

            }
        };
        
        DB.story.all["Ruhig_RuhigShot_Multi_11"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            //lookup = [ "RuhigShot" ],
            lines = new()
            {

            }
        };
        
        DB.story.all["Ruhig_RuhigShot_Multi_3"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            //lookup = [ "RuhigShot" ],
            lines = new()
            {

            }
        };
        
        /*DB.story.all["Ruhig_RuhigShot_Multi_4"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigShot" ],
            lines = new()
            {

            }
        };
        
        DB.story.all["Ruhig_RuhigShot_Multi_5"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigShot" ],
            lines = new()
            {

            }
        };
        
        DB.story.all["Ruhig_RuhigShot_Multi_6"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigShot" ],
            lines = new()
            {

            }
        };
        
        DB.story.all["Ruhig_RuhigShot_Multi_7"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigShot" ],
            lines = new()
            {

            }
        };
        
        DB.story.all["Ruhig_RuhigShot_Multi_8"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigShot" ],
            lines = new()
            {

            }
        };
        
        DB.story.all["Ruhig_RuhigShot_Multi_9"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigShot" ],
            oncePerRunTags = [ "ruhigRuhigShotTag" ],
            lines = new()
            {

            }
        };
        
        DB.story.all["Ruhig_RuhigShot_Multi_10"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigShot" ],
            oncePerRunTags = [ "ruhigRuhigShotTag" ],
            lines = new()
            {

            }
        };*/
        
        DB.story.all["Ruhig_RuhigAdaptability_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigAdaptability" ],
            oncePerCombatTags = [ "ruhigRuhigAdaptabilityTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We shouldn't need to use this here.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigAdaptability_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigAdaptability" ],
            oncePerCombatTags = [ "ruhigRuhigAdaptabilityTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Let's preserve some of our hull for now.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigAdaptability_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigAdaptability" ],
            oncePerCombatTags = [ "ruhigRuhigAdaptabilityTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "...",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigAdaptability_Multi_3"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigAdaptability" ],
            oncePerCombatTags = [ "ruhigRuhigAdaptabilityTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "To the exhaust pile you go.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigAdaptability_Multi_4"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigAdaptability" ],
            oncePerCombatTags = [ "ruhigRuhigAdaptabilityTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I don't think we need to lose hull here.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigAdaptability_Multi_5"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigAdaptability" ],
            oncePerCombatTags = [ "ruhigRuhigAdaptabilityTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "No need to use this right now.",
                    loopTag = "neutral"
                }
            }
        };

        DB.story.all["Ruhig_RuhigAdaptability_Multi_6"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [Ruhig],
            lookup = ["RuhigAdaptability"],
            lines = new()
        };
        DB.story.all["Ruhig_RuhigAdaptability_Multi_7"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [Ruhig],
            lookup = ["RuhigAdaptability"],
            lines = new()
        };
        DB.story.all["Ruhig_RuhigAdaptability_Multi_8"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [Ruhig],
            lines = new()
        };
        DB.story.all["Ruhig_RuhigAdaptability_Multi_9"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [Ruhig],
            lookup = ["RuhigAdaptability"],
            lines = new()
        };
        DB.story.all["Ruhig_RuhigAdaptability_Multi_10"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [Ruhig],
            lookup = ["RuhigAdaptability"],
            lines = new()
        };
        DB.story.all["Ruhig_RuhigAdaptability_Multi_11"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [Ruhig],
            lookup = ["RuhigAdaptability"],
            lines = new()
        };
        DB.story.all["Ruhig_RuhigAdaptability_Multi_12"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [Ruhig],
            lookup = ["RuhigAdaptability"],
            lines = new()
        };
        DB.story.all["Ruhig_RuhigAdaptability_Multi_13"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [Ruhig],
            lookup = ["RuhigAdaptability"],
            lines = new()
        };
        DB.story.all["Ruhig_RuhigAdaptability_Multi_14"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [Ruhig],
            lookup = ["RuhigAdaptability"],
            lines = new()
        };
        DB.story.all["Ruhig_RuhigAdaptability_Multi_15"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [Ruhig],
            lookup = ["RuhigAdaptability"],
            lines = new()
        };
        
        DB.story.all["Ruhig_HullCost_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "HullCost" ],
            oncePerCombatTags = [ "ruhigHullCostTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "A worthy use of hull.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HullCost_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "HullCost" ],
            oncePerCombatTags = [ "ruhigHullCostTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "A good use use of hull.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HullCost_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "HullCost" ],
            oncePerCombatTags = [ "ruhigHullCostTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "This should be a decent investment in hull use.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HullCost_Multi_3"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "HullCost" ],
            oncePerCombatTags = [ "ruhigHullCostTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "When we stop at Cleo's Workshop next time, we should look into getting some more hull.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_CardCopier_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "CardCopier" ],
            oncePerCombatTags = [ "ruhigCardCopierTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We seem to like this card, so I used some of the hull to make a copy of it.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_CardCopier_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "CardCopier" ],
            oncePerCombatTags = [ "ruhigCardCopierTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "That's a good card, let's make a copy of it.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_CardCopier_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "CardCopier" ],
            oncePerCombatTags = [ "ruhigCardCopierTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "There we go, I made a copy of that card we really like.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_CardCopierB_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "CardCopierB" ],
            oncePerCombatTags = [ "ruhigCardCopierBTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We seem to like this card, so I used some of the hull to make 2 copies of it.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_CardCopierB_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "CardCopierB" ],
            oncePerCombatTags = [ "ruhigCardCopierBTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "That's a good card, let's make a copy of it ... twice.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_CardCopierB_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "CardCopierB" ],
            oncePerCombatTags = [ "ruhigCardCopierBTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "There we go, I made 2 copies of that card we really like.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Cat_ColorlessRuhigSummon_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Cat ],
            lookup = [ "ColorlessRuhigSummon" ],
            oncePerCombatTags = [ "ruhigColorlessRuhigSummonTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Cat,
                    Text = "We might lose some hull from this.",
                    loopTag = "intense"
                }
            }
        };

        DB.story.all["Cat_ColorlessRuhigSummon_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Cat ],
            lookup = [ "ColorlessRuhigSummon" ],
            oncePerCombatTags = [ "ruhigColorlessRuhigSummonTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Cat,
                    Text = "I set a reminder to double check out hull when were at the next repair yard.",
                    loopTag = "intense"
                }
            }
        };
        
        DB.story.all["Cat_ColorlessRuhigSummon_Multi_3"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Cat ],
            lookup = [ "ColorlessRuhigSummon" ],
            oncePerCombatTags = [ "ruhigColorlessRuhigSummonTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Cat,
                    Text = "What would Ruhig do here?",
                    loopTag = "neutral"
                }
            }
        };

        DB.story.all["Cat_ColorlessRuhigSummon_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Cat, Ruhig ],
            lookup = [ "ColorlessRuhigSummon" ],
            oncePerCombatTags = [ "ruhigColorlessRuhigSummonTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Cat,
                    Text = "Why do your programs remove hull Ruhig?",
                    loopTag = "worried"
                },
                new CustomSay
                {
                    who = Ruhig,
                    Text = "The only hull that matters is the one that keeps this ship from blowing up; the rest can be used to help us win our fights.",
                    loopTag = "neutral"
                },
            }
        };
        
        DB.story.all["Ruhig_DespreateEnergy_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "DespreateEnergy" ],
            oncePerCombatTags = [ "ruhigDespreateEnergyTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I found some extra energy in the hull we could use.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DespreateEnergy_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "DespreateEnergy" ],
            oncePerCombatTags = [ "ruhigDespreateEnergyTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I found some extra energy in the hull we could use.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DespreateEnergy_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "DespreateEnergy" ],
            oncePerCombatTags = [ "ruhigDespreateEnergyTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I took some hull to convert to energy.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DespreateEnergy_Multi_3"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "DespreateEnergy" ],
            oncePerCombatTags = [ "ruhigDespreateEnergyTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I know were is a rough spot, but hopefully this extra energy can get us out of it.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DespreateEnergy_Multi_4"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            oncePerRun = true,
            allPresent = [ Ruhig, Hyperia ],
            lookup = [ "DespreateEnergy" ],
            oncePerCombatTags = [ "ruhigDespreateEnergyTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Looking into getting an extra battery might be a good idea so we can save on using some hull.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DisposableHull_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "DisposableHull" ],
            oncePerCombatTags = [ "ruhigDisposableHullTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We can use some hull to block some damage",
                    loopTag = "neutral"
                }
            }
        };
        
        /* DB.story.all["Ruhig_DraconicBlessingTop_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "DraconicBlessingTop" ],
            oncePerCombatTags = [ "ruhigDraconicBlessingTopTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I just blessed the ship y'all, hopefully this will make us stronger for the upcoming fights.",
                    loopTag = "neutral"
                }
            }
        }; */
        
        DB.story.all["Ruhig_DraconicBlessingTop_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "DraconicBlessingTop" ],
            oncePerCombatTags = [ "ruhigDraconicBlessingTopTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Let's see what that Draconic Blessing got us.",
                    loopTag = "neutral"
                }
            }
        };
        
        /*DB.story.all["Ruhig_DraconicBlessingBottom_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "DraconicBlessingBottom" ],
            oncePerCombatTags = [ "ruhigDraconicBlessingBottomTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I gave the ship a minor blessing, so we should have a little bit more energy to use now.",
                    loopTag = "neutral"
                }
            }
        };*/
        
        DB.story.all["Ruhig_DraconicBlessingBottom_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "DraconicBlessingBottom" ],
            oncePerCombatTags = [ "ruhigDraconicBlessingBottomTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Does anyone need some extra energy?",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DraconicBlessingBottom_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "DraconicBlessingBottom" ],
            oncePerCombatTags = [ "ruhigDraconicBlessingBottomTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Here's some extra energy.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DraconicBlessingBottom_Multi_3"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "DraconicBlessingBottom" ],
            oncePerCombatTags = [ "ruhigDraconicBlessingBottomTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We have some extra energy now; use it wisely.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DraconicBoost_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "DraconicBoost" ],
            oncePerCombatTags = [ "ruhigDraconicBoostTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Do we need a boost?",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DraconicBoost_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "DraconicBoost" ],
            oncePerCombatTags = [ "ruhigDraconicBoostTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Who needs a boost?",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DraconicBoost_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "DraconicBoost" ],
            oncePerCombatTags = [ "ruhigDraconicBoostTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Boost time!",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DraconicPower_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Hyperia ],
            lookup = [ "DraconicPower" ],
            oncePerCombatTags = [ "ruhigDraconicPowerTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Peri, I got some overdrive to help boost your damage output.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DraconicPower_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "DraconicPower" ],
            oncePerCombatTags = [ "ruhigDraconicPowerTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I used some hull to overdrive our cannons.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DraconicPower_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "DraconicPower" ],
            oncePerCombatTags = [ "ruhigDraconicPowerTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Let's try to burst down our opponnent!",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DraconicPower_Multi_3"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Hyperia ],
            lookup = [ "DraconicPower" ],
            oncePerCombatTags = [ "ruhigDraconicPowerTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Peri, I got some overdrive to use for multiattacks.",
                    loopTag = "neutral"
                },
                new CustomSay
                {
                    who = Hyperia,
                    Text = "Got it.",
                    loopTag = "vengeful"
                }
            }
        };
        
        DB.story.all["Ruhig_DraconicScales_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "DraconicScales" ],
            oncePerCombatTags = [ "ruhigDraconicScalesTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We should be able to handle more shields now.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DraconicScales_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "DraconicScales" ],
            oncePerCombatTags = [ "ruhigDraconicScalesTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Our shield capcity is boosted.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DraconicScales_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Dizzy ],
            lookup = [ "DraconicScales" ],
            oncePerCombatTags = [ "ruhigDraconicScalesTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Dizzy, the ship can handle more shielding now.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DraconicScales_Multi_3"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Dizzy ],
            lookup = [ "DraconicScales" ],
            oncePerCombatTags = [ "ruhigDraconicScalesTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Dizzy,
                    Text = "Shield capacity got increased.",
                    loopTag = "neutral"
                },
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Now we just need to fill it up with shields.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DraconicShards_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "DraconicShards" ],
            oncePerCombatTags = [ "ruhigDraconicShardsTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I converted some hull into shards for y'all to use.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DraconicShards_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "DraconicShards" ],
            oncePerCombatTags = [ "ruhigDraconicShardsTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "It's shard time.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DraconicShards_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Books ],
            lookup = [ "DraconicShards" ],
            oncePerCombatTags = [ "ruhigDraconicShardsTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Books, I got us some shards and I need a mighty spell to defeat this enemy.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_DraconicShards_Multi_3"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Books ],
            lookup = [ "DraconicShards" ],
            oncePerCombatTags = [ "ruhigDraconicShardsTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Books, here's some shards to use.",
                    loopTag = "neutral"
                },
                new CustomSay
                {
                    who = Books,
                    Text = "Thank you Mx.Ruhig.",
                    loopTag = "crystal"
                }
            }
        };
        
        DB.story.all["Ruhig_ExpandHull_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "ExpandHull" ],
            oncePerCombatTags = [ "ruhigExpandHullTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I used some hull, so were able to hold more hull.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_ExpandHull_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Dizzy ],
            lookup = [ "ExpandHull" ],
            oncePerCombatTags = [ "ruhigExpandHullTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We took some damage doing that, can we get some shielding?",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_ExpandHull_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Isaac ],
            lookup = [ "ExpandHull" ],
            oncePerCombatTags = [ "ruhigExpandHullTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We took some damage doing that, do we have anything disposable to help avoid more damage?",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_ExpandHull_Multi_3"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Hyperia ],
            lookup = [ "ExpandHull" ],
            oncePerCombatTags = [ "ruhigExpandHullTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We took some damage doing that, can we get this fight over with quickly to do repairs?",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_ExpandHull_Multi_4"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Riggs ],
            lookup = [ "ExpandHull" ],
            oncePerCombatTags = [ "ruhigExpandHullTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We took some damage doing that, can dodge some attacks to avoid further damage?",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_ExpandHull_Multi_5"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Cat ],
            lookup = [ "ExpandHull" ],
            oncePerCombatTags = [ "ruhigExpandHullTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Cat,
                    Text = "RUHIG, DO YOU KNOW WHAT YOUR DOING?",
                    loopTag = "worried"
                },
                new CustomSay
                {
                    who = Ruhig,
                    Text = "yes, we should recover the hull lost next time we repair.",
                    loopTag = "neutral"
                }
            }
        };
        
        // No lines for Fix, not every card needs dialouge when played ~ Havmir
        
        DB.story.all["Ruhig_HardNuetralReset_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "HardNuetralReset" ],
            oncePerCombatTags = [ "ruhigHardNuetralResetTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We need a new hand now!",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HardNuetralReset_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "HardNuetralReset" ],
            oncePerCombatTags = [ "ruhigHardNuetralResetTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We need a new hand now!",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HardNuetralReset_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "HardNuetralReset" ],
            oncePerCombatTags = [ "ruhigHardNuetralResetTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "That was a pretty poor hand we had there.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HardNuetralReset_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Riggs ],
            lookup = [ "HardNuetralReset" ],
            oncePerCombatTags = [ "ruhigHardNuetralResetTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Riggs, we might need to find ways to get more options soon ...",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_HardNuetralReset_Multi_3"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Max ],
            lookup = [ "HardNuetralReset" ],
            oncePerCombatTags = [ "ruhigHardNuetralResetTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Max, we might need to find ways to get more options soon ...",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_Meditation_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "Meditation" ],
            oncePerCombatTags = [ "ruhigMeditationTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We just need to focus up here ...",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_Meditation_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "Meditation" ],
            oncePerCombatTags = [ "ruhigMeditationTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Gotta take Deep breaths ...",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_Meditation_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "Meditation" ],
            oncePerCombatTags = [ "ruhigMeditationTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We just need to stay calm ...",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_Meditation_Multi_3"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "Meditation" ],
            oncePerCombatTags = [ "ruhigMeditationTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Let's see what other options we have ...",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_Meditation_Multi_4"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "Meditation" ],
            oncePerCombatTags = [ "ruhigMeditationTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "...",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_Meditation_Multi_4"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "Meditation" ],
            oncePerCombatTags = [ "ruhigMeditationTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "...",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_NeedForSpeed_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "NeedForSpeed" ],
            oncePerCombatTags = [ "ruhigNeedForSpeedTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We should be able to evade some attacks now.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_NeedForSpeed_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "NeedForSpeed" ],
            oncePerCombatTags = [ "ruhigNeedForSpeedTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I removed some hull, so we can dodge better.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_NeedForSpeed_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Riggs ],
            lookup = [ "NeedForSpeed" ],
            oncePerCombatTags = [ "ruhigNeedForSpeedTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Riggs, I got evasion for us to use.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_NeedForSpeed_Multi_3"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Riggs ],
            lookup = [ "NeedForSpeed" ],
            oncePerCombatTags = [ "ruhigNeedForSpeedTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Riggs,
                    Text = "Just felt the engines get a boost.",
                    loopTag = "crystal"
                },
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Riggs, we need to get moving!",
                    loopTag = "neutral"
                }
            }
        };
        
        // No Lines for Painful Memory ~ Havmir
        
        DB.story.all["Ruhig_Paitence_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "Paitence" ],
            oncePerCombatTags = [ "ruhigPaitenceTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "There we go, heat should be less of a problem now.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_Wrath_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "Wrath" ],
            oncePerCombatTags = [ "ruhigWrathTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Let's heat up the engine.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_Paitence_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Eunice ],
            lookup = [ "Paitence" ],
            oncePerCombatTags = [ "ruhigPaitenceTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Drake, I can take care of some heat, do what you need to do.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_Wrath_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Eunice ],
            lookup = [ "Wrath" ],
            oncePerCombatTags = [ "ruhigWrathTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Drake, here's some heat for you to use.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_Paitence_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Eunice ],
            lookup = [ "Paitence" ],
            oncePerCombatTags = [ "ruhigPaitenceTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Drake, I can take care of some heat, do what you need to do.",
                    loopTag = "neutral"
                },
                new CustomSay
                {
                who = Eunice,
                Text = "I got this.",
                loopTag = "sly"
                }
            }
        };
        
        DB.story.all["Ruhig_Wrath_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Eunice ],
            lookup = [ "Wrath" ],
            oncePerCombatTags = [ "ruhigWrathTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Drake, I overheated the engines, do what you need to do.",
                    loopTag = "neutral"
                },
                new CustomSay
                {
                    who = Eunice,
                    Text = "I got it from here.",
                    loopTag = "sly"
                }
            }
        };
        
        // No PowerUpShot Lines ~ Havmir
        
        DB.story.all["Ruhig_RepairGambit_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RepairGambit" ],
            oncePerCombatTags = [ "ruhigRepairGambitTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "It's a risk to make repairs like this ...",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RepairGambit_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RepairGambit" ],
            oncePerCombatTags = [ "ruhigRepairGambitTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "This looks like a spot we can get some hull repaired ...",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RepairGambit_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RepairGambit" ],
            oncePerCombatTags = [ "ruhigRepairGambitTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We're going to need to make some emergency reapirs ...",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigsChallenge_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigsChallenge" ],
            oncePerCombatTags = [ "ruhigRuhigsChallengeTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Challenge complete.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigsChallenge_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigsChallenge" ],
            oncePerCombatTags = [ "ruhigRuhigsChallengeTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Challenge complete.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigsChallenge_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigsChallenge" ],
            oncePerCombatTags = [ "ruhigRuhigsChallengeTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Let's get back the hull we just lost there.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigsChallenge_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigsChallenge" ],
            oncePerCombatTags = [ "ruhigRuhigsChallengeTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Let's go hull manipulation strats!",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigsChallenge_Multi_3"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigsChallenge" ],
            oncePerCombatTags = [ "ruhigRuhigsChallengeTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Hard play, but it payed off.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigsGift_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigsGift" ],
            oncePerCombatTags = [ "ruhigRuhigsGiftTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Have a present gang",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigsGift_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigsGift" ],
            oncePerCombatTags = [ "ruhigRuhigsGiftTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I have a gift for y'all.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_RuhigsGift_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "RuhigsGift" ],
            oncePerCombatTags = [ "ruhigRuhigsGiftTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "This should help support our gameplan.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_SoulShot_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "SoulShot" ],
            oncePerCombatTags = [ "ruhigSoulShotTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Let's use some of that lost hull to our advantage.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_SoulShot_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "SoulShot" ],
            oncePerCombatTags = [ "ruhigSoulShotTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Time to gain some extra value from the hull we've used.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_SoulShot_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "SoulShot" ],
            oncePerCombatTags = [ "ruhigSoulShotTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Time for a soul read.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_SoulShotB_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "SoulShotB" ],
            oncePerCombatTags = [ "ruhigSoulShotBTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Welp, sorry gang, I'll see you next loop.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_SoulShotB_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "SoulShotB" ],
            oncePerCombatTags = [ "ruhigSoulShotBTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I'm sorry for failing everyone.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_SoulShotB_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "SoulShotB" ],
            oncePerCombatTags = [ "ruhigSoulShotBTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I'm sorry for failing everyone.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_SoulShotB_Multi_3"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig, Eunice ],
            lookup = [ "SoulShotB" ],
            oncePerCombatTags = [ "ruhigSoulShotBTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Drake, now would be a good time to have flash point.",
                    loopTag = "neutral"
                }
            }
        };
        
        // No dialouge for RushAttack ~ Havmir
        
        // No dialouge for ScrapeForIdeas ~ Havmir
        
        DB.story.all["Ruhig_SparePartsTop_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "SparePartsTop" ],
            oncePerCombatTags = [ "ruhigSparePartsTopTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I found some spare parts we can use to repair our ship with.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_SparePartsTop_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "SparePartsTop" ],
            oncePerCombatTags = [ "ruhigSparePartsTopTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I'm going to repair some damage to the ship now.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_SparePartsTop_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "SparePartsTop" ],
            oncePerCombatTags = [ "ruhigSparePartsTopTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "That should buy us a little bit more time.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_SparePartsBottom_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "SparePartsBottom" ],
            oncePerCombatTags = [ "ruhigSparePartsBottomTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "I found something that should be able to help our gameplan more.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_SparePartsBottom_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "SparePartsBottom" ],
            oncePerCombatTags = [ "ruhigSparePartsBottomTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "A fine addition to our deck.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_SparePartsBottom_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "SparePartsBottom" ],
            oncePerCombatTags = [ "ruhigSparePartsBottomTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Let's see what these spare parts can do.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_Stall_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "Stall" ],
            oncePerCombatTags = [ "ruhigStallTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We should stall for a little bit.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_Stall_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "Stall" ],
            oncePerCombatTags = [ "ruhigStallTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We needed to get out of there.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_Stall_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "Stall" ],
            oncePerCombatTags = [ "ruhigStallTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "That should put some distance between us.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_Support_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "Support" ],
            oncePerCombatTags = [ "ruhigSupportTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Let me help y'all out.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_Support_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "Support" ],
            oncePerCombatTags = [ "ruhigSupportTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Support time.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_Support_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig ],
            lookup = [ "Support" ],
            oncePerCombatTags = [ "ruhigSupportTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "We need some extra support for this fight.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_Zoning_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "Zoning" ],
            oncePerCombatTags = [ "ruhigZoningTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "This should soak up some damage.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_Zoning_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Isaac ],
            lookup = [ "Zoning" ],
            oncePerCombatTags = [ "ruhigZoningTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Isaac, I launched some things out of the missle bay, be careful where you launch your droids.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_Zoning_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig, Isaac ],
            lookup = [ "Zoning" ],
            oncePerCombatTags = [ "ruhigZoningTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Isaac, heads up--I launched some stuff out of the missle bay.",
                    loopTag = "neutral"
                },
                new CustomSay
                {
                    who = Isaac,
                    Text = "Got it.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_ZoningB_Multi_0"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig ],
            lookup = [ "ZoningB" ],
            oncePerCombatTags = [ "ruhigZoningBTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "That should make it harder for the enemy to hit us.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_ZoningB_Multi_1"] = new()
        {
            type = NodeType.combat,
            oncePerCombat = true,
            allPresent = [ Ruhig, Isaac ],
            lookup = [ "ZoningB" ],
            oncePerCombatTags = [ "ruhigZoningBTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Ruhig,
                    Text = "Isaac, I launched some mines, really be careful where you launch your droids.",
                    loopTag = "neutral"
                }
            }
        };
        
        DB.story.all["Ruhig_ZoningB_Multi_2"] = new()
        {
            type = NodeType.combat,
            oncePerRun = true,
            allPresent = [ Ruhig, Isaac ],
            lookup = [ "ZoningB" ],
            oncePerCombatTags = [ "ruhigZoningBTag" ],
            lines = new()
            {
                new CustomSay
                {
                    who = Isaac,
                    Text = "That's a lot of mines Ruhig.",
                    loopTag = "panic"
                },
                new CustomSay
                {
                    who = Ruhig,
                    Text = "You just need to be careful about drone placement, I believe in you.",
                    loopTag = "neutral"
                },
            }
        };
    }
}