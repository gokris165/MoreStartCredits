using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;

using HarmonyLib;

namespace MoreStartCredits
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class Plugin : BaseUnityPlugin
    {
        private const string modGUID = "Brocool.MoreStartCredits";
        private const string modName = "MoreStartCredits";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUID);

        public static Plugin Instance;
        
        internal static ManualLogSource logger;

        internal static ConfigEntry<int> startingCredits;

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            logger = BepInEx.Logging.Logger.CreateLogSource(modGUID);
            logger.LogInfo(modName + " has started!");

            startingCredits = Config.Bind("General", "startingCredits", 150, "Amount of credits available on a new save file");

            harmony.PatchAll();
        }

    }
}
