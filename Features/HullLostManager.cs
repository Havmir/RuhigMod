namespace RuhigMod.Features;

// This file is used to keep track of how much hull the player has lost on a given turn, specifically for the Ruhig's Challenge Card ~ Havmir
// Also thanks to rft50 for helping me make this :)

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
        int hullLostNumber;
        hullLostNumber = ModEntry.Instance.Helper.ModData.GetModDataOrDefault(combat, "hullLostNumber", 0);
        hullLostNumber += amount;
        ModEntry.Instance.Helper.ModData.SetModData(combat, "hullLostNumber", hullLostNumber);
    }

    public HullLostManager()
    {
        ModEntry.Instance.Helper.Events.RegisterAfterArtifactsHook(nameof(HullLostManager.OnCombatStart), OnCombatStart);
        ModEntry.Instance.Helper.Events.RegisterAfterArtifactsHook(nameof(HullLostManager.OnTurnStart), OnTurnStart);
        ModEntry.Instance.Helper.Events.RegisterAfterArtifactsHook(nameof(HullLostManager.OnPlayerLoseHull), OnPlayerLoseHull);
    }
}