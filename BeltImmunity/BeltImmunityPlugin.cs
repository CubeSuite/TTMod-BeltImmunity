using BeltImmunity.Patches;
using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace BeltImmunity
{
    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class BeltImmunityPlugin : BaseUnityPlugin
    {
        private const string MyGUID = "com.equinox.BeltImmunity";
        private const string PluginName = "BeltImmunity";
        private const string VersionString = "1.0.0";

        private static readonly Harmony Harmony = new Harmony(MyGUID);
        public static ManualLogSource Log = new ManualLogSource(PluginName);

        private void Awake() {
            // Apply all of our patches
            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loading...");
            Harmony.PatchAll();
            Logger.LogInfo($"PluginName: {PluginName}, VersionString: {VersionString} is loaded.");
            Log = Logger;

            Harmony.CreateAndPatchAll(typeof(PlayerFirstPersonControllerPatch));
        }
    }
}
