using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HarmonyLib;
using UnityEngine;

namespace BeltImmunity.Patches
{
    public class PlayerFirstPersonControllerPatch
    {
        [HarmonyPatch(typeof(PlayerFirstPersonController), "CalculateBeltMovement")]
        [HarmonyPrefix]
        static bool setRidingBeltFalse(PlayerFirstPersonController __instance) {
            Type type = typeof(PlayerFirstPersonController);
            FieldInfo fieldInfo = type.GetField("ridingBelt", BindingFlags.NonPublic | BindingFlags.Instance);
            if (fieldInfo != null) {
                fieldInfo.SetValue(__instance, false);
            }
            return false;
        }
    }
}
