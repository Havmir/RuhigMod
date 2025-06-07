namespace RuhigMod.Features;


public class ShuffleManager
{
    public int _shuffleAmount;
    public void OnCombatStart(Combat combat)
    {
        ModEntry.Instance.Helper.ModData.SetModData(combat, "shuffleNumber", 0);
        ModEntry.Instance.Helper.ModData.SetModData(combat, "shuffleNumberB", 0);
        _shuffleAmount = 0;
    }
    
    public void OnTurnStart(Combat combat)
    {
        _shuffleAmount = 0;
    }
    
    public void OnPlayerDeckShuffle(Combat combat)
    {
        if (_shuffleAmount > 1)
        {
            _shuffleAmount++;
        }
        if (_shuffleAmount == 1)
        {
            int shuffleNumberB;
            shuffleNumberB = ModEntry.Instance.Helper.ModData.GetModDataOrDefault(combat, "shuffleNumberB", 0);
            shuffleNumberB ++;
            ModEntry.Instance.Helper.ModData.SetModData(combat, "shuffleNumberB", shuffleNumberB);
            
            _shuffleAmount++;
        }
        if (_shuffleAmount == 0)
        {
            int shuffleNumber;
            shuffleNumber = ModEntry.Instance.Helper.ModData.GetModDataOrDefault(combat, "shuffleNumber", 0);
            shuffleNumber ++;
            ModEntry.Instance.Helper.ModData.SetModData(combat, "shuffleNumber", shuffleNumber);
            
            int shuffleNumberB;
            shuffleNumberB = ModEntry.Instance.Helper.ModData.GetModDataOrDefault(combat, "shuffleNumberB", 0);
            shuffleNumberB ++;
            ModEntry.Instance.Helper.ModData.SetModData(combat, "shuffleNumberB", shuffleNumberB);
            
            _shuffleAmount++;
        }
    }

    public ShuffleManager()
    {
        ModEntry.Instance.Helper.Events.RegisterAfterArtifactsHook(nameof(ShuffleManager.OnCombatStart), OnCombatStart);
        ModEntry.Instance.Helper.Events.RegisterAfterArtifactsHook(nameof(ShuffleManager.OnTurnStart), OnTurnStart);
        ModEntry.Instance.Helper.Events.RegisterAfterArtifactsHook(nameof(ShuffleManager.OnPlayerDeckShuffle), OnPlayerDeckShuffle);
    }
}