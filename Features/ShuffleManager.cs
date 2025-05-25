namespace RuhigMod.Features;


public class ShuffleManager
{

    public void OnCombatStart(Combat combat)
    {
        ModEntry.Instance.Helper.ModData.SetModData(combat, "shuffleNumber", 0);
    }
    
    public void OnTurnStart(Combat combat)
    {
        ModEntry.Instance.Helper.ModData.SetModData(combat, "shuffleNumber", 0);
    }
    
    public void OnPlayerDeckShuffle(Combat combat)
    {
        int shuffleNumber;
        shuffleNumber = ModEntry.Instance.Helper.ModData.GetModDataOrDefault(combat, "shuffleNumber", 0);
        shuffleNumber ++;
        ModEntry.Instance.Helper.ModData.SetModData(combat, "shuffleNumber", shuffleNumber);
    }

    public ShuffleManager()
    {
        ModEntry.Instance.Helper.Events.RegisterAfterArtifactsHook(nameof(ShuffleManager.OnCombatStart), OnCombatStart);
        ModEntry.Instance.Helper.Events.RegisterAfterArtifactsHook(nameof(ShuffleManager.OnTurnStart), OnTurnStart);
        ModEntry.Instance.Helper.Events.RegisterAfterArtifactsHook(nameof(ShuffleManager.OnPlayerDeckShuffle), OnPlayerDeckShuffle);
    }
}