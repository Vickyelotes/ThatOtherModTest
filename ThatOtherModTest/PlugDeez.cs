using BepInEx;
using HarmonyLib;
using System;
using Unity;
using UnityEngine;

namespace LethalCompanyModTemplate
{
    [BepInPlugin(modGUID, modName, modVersion)] // Creating the plugin
    public class LethalCompanyModName : BaseUnityPlugin // MODNAME : BaseUnityPlugin
    {
        public const string modGUID = "Vickyelotes.SecondTest"; // a unique name for your mod
        public const string modName = "Second Test"; // the name of your mod
        public const string modVersion = "1.0.0.0"; // the version of your mod

        private readonly Harmony harmony = new Harmony(modGUID); // Creating a Harmony instance which will run the mods

        void Awake() // runs when Lethal Company is launched
        {
            var BepInExLogSource = BepInEx.Logging.Logger.CreateLogSource(modGUID); // creates a logger for the BepInEx console
            BepInExLogSource.LogMessage(modGUID + " LOADED SUCCESSFULLY"); // show the successful loading of the mod in the BepInEx console

            harmony.PatchAll(typeof(yourMod)); // run the "yourMod" class as a plugin
        }
    }

    [HarmonyPatch(typeof(LethalCompanyScriptName))] // selecting the Lethal Company script you want to mod
    [HarmonyPatch("Update")] // select during which Lethal Company void in the choosen script the mod will execute
    class yourMod // This is your mod if you use this is the harmony.PatchAll() command
    {
        [HarmonyPostfix] // Postfix means execute the plugin after the Lethal Company script. Prefix means execute plugin before.
        static void Postfix(ref ReferenceType ___LethalCompanyVar) // refer to variables in the Lethal Company script to manipulate them. Example: (ref int ___health). Use the 3 underscores to refer.
        {
            // YOUR CODE
            // Example: ___health = 100; This will set the health to 100 everytime the mod is executed
        }
    }
}