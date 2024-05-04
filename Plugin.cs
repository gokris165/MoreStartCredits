using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using MoreStartCredits.Patches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreStartCredits
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private const string modGUID = "Brocool.MoreStartCredits";
        private const string modName = "MoreStartCredits";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);
        private static Plugin Instance;
        internal ManualLogSource logger;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            logger = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            logger.LogWarning(modName + " has started!");

            harmony.PatchAll();
        }

    }
}
