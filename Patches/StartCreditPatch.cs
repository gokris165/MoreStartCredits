using BepInEx.Logging;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreStartCredits.Patches
{
    [HarmonyPatch(typeof(StartOfRound))]
    internal class StartCreditPatch
    {
        internal static ManualLogSource logger; 
        

        [HarmonyPatch("SetTimeAndPlanetToSavedSettings")]
        [HarmonyPostfix]
        static void changeStartingCredits(ref EndOfGameStats ___gameStats, ref bool ___isChallengeFile)
        {
            logger = BepInEx.Logging.Logger.CreateLogSource("Brocool.MoreStartCredits");
            logger.LogWarning("Beginning the change");

            try
            {
                if (___gameStats.daysSpent == 0 && !___isChallengeFile)
                {
                    TimeOfDay.Instance.quotaVariables.startingCredits = 300;
                }
            }
            catch(Exception e)
            { 
                logger.LogWarning("FAILED: Brocool.MoreStartCredits");
            }
        }
    }
}
