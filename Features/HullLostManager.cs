using System;

namespace RuhigMod.Features;

// This file is used to keep track of how much hull the player has lost on a given turn, specifically for the Ruhig's Challenge Card ~ Havmir
// Also thanks to rft50 for helping me make this :)

// NOTE, you will need to make sure you add this to ModEntry, search for HullLostManager to find where ~ Havmir

public class HullLostManager
{

    public void OnCombatStart(Combat combat)
    {
        ModEntry.Instance.Helper.ModData.SetModData(combat, "hullLostNumber", 0);
    }
    
    public void OnTurnStart(Combat combat)
    {
        ModEntry.Instance.Helper.ModData.SetModData(combat, "hullLostNumber", 0);
    }
    
    public void OnPlayerLoseHull(Combat combat, int amount)
    {
        if (combat.isPlayerTurn == true)
        {
            int hullLostNumber;
            hullLostNumber = ModEntry.Instance.Helper.ModData.GetModDataOrDefault(combat, "hullLostNumber", 0);
            hullLostNumber += amount;
            ModEntry.Instance.Helper.ModData.SetModData(combat, "hullLostNumber", hullLostNumber);
        }
        if (combat.isPlayerTurn == false)
        {
            Console.WriteLine($"[Ruhig Mod] Hull Lost Manager detected: {amount} during the enemies's turn.");
        }
    }

    public HullLostManager()
    {
        ModEntry.Instance.Helper.Events.RegisterBeforeArtifactsHook(nameof(HullLostManager.OnCombatStart), OnCombatStart);
        ModEntry.Instance.Helper.Events.RegisterBeforeArtifactsHook(nameof(HullLostManager.OnTurnStart), OnTurnStart);
        ModEntry.Instance.Helper.Events.RegisterBeforeArtifactsHook(nameof(HullLostManager.OnPlayerLoseHull), OnPlayerLoseHull);
    }
}