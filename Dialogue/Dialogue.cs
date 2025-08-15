using System;
using Microsoft.Extensions.Logging;
using Nickel;
using RuhigMod;
using RuhigMod.Dialogue;

namespace RuhigMod.Dialogue;
internal static class Dialogue
{
    internal static void Inject()
    {
        CardDialogue.Inject();
        //StoryDialogue.Inject();
        CombatDialogue.Inject();
        ArtifactDialogue.Inject();
    }

    public static void ApplyInjections()
    {
        try
        {
            if (!ModEntry.Instance.ModDialogueInited)
            {
                ModEntry.Instance.ModDialogueInited = true;
                ModEntry.Instance.Logger.LogInformation("I have a mouth... and I can now speak!");
            }
        }
        catch (Exception exception)
        {
            ModEntry.Instance.Logger.LogError(exception, "Failed to inject dialogue for modded stuff");
        }
    }
}