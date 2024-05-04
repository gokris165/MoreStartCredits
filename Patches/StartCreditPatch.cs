using HarmonyLib;
using System;

namespace MoreStartCredits.Patches
{
    [HarmonyPatch(typeof(StartOfRound))]
    internal class StartCreditPatch
    {
        [HarmonyPatch("SetTimeAndPlanetToSavedSettings")]
        [HarmonyPostfix]
        static void changeStartingCredits(ref EndOfGameStats ___gameStats, ref bool ___isChallengeFile)
        {
            Plugin.logger.LogInfo("IN PROGRESS: Changing starting credits...");       
            try
            {
                if (___gameStats.daysSpent == 0 && !___isChallengeFile)
                {
                    TimeOfDay.Instance.quotaVariables.startingCredits = Plugin.startingCredits.Value;
                }
            }
            catch(Exception e)
            { 
                Plugin.logger.LogError("FAILED: error while changing starting credits");
                Plugin.logger.LogError(e.Message);
            }
            Plugin.logger.LogInfo("SUCCESS: starting credits set to " + Plugin.startingCredits.Value);
        }
    }
}
