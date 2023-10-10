using BepInEx;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;
using RoR2;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine;
using RoR2.CharacterAI;
using System.Linq;

namespace XiConstructFix
{

    //This is an example plugin that can be put in BepInEx/plugins/ExamplePlugin/ExamplePlugin.dll to test out.
    //It's a small plugin that adds a relatively simple item to the game, and gives you that item whenever you press F2.

    //This attribute is required, and lists metadata for your plugin.
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]

    //This is the main declaration of our plugin class. BepInEx searches for all classes inheriting from BaseUnityPlugin to initialize on startup.
    //BaseUnityPlugin itself inherits from MonoBehaviour, so you can use this as a reference for what you can declare and use in your plugin class: https://docs.unity3d.com/ScriptReference/MonoBehaviour.html
    public class HappiestMaskRework : BaseUnityPlugin
    {
        //The Plugin GUID should be a unique ID for this plugin, which is human readable (as it is used in places like the config).
        //If we see this PluginGUID as it is on thunderstore, we will deprecate this mod. Change the PluginAuthor and the PluginName !
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "OakPrime";
        public const string PluginName = "XiConstructFix";
        public const string PluginVersion = "1.0.0";

        //The Awake() method is run at the very start when the game is initialized.
        public void Awake()
        {
            Log.Init(Logger);
            try
            {
                RoR2Application.onLoad += () =>
                {
                    AISkillDriver aiSkillDriver1 = ((IEnumerable<AISkillDriver>)Addressables.LoadAssetAsync<GameObject>((object)"RoR2/DLC1/MajorAndMinorConstruct/MegaConstructMaster.prefab").WaitForCompletion().GetComponents<AISkillDriver>()).Where<AISkillDriver>((Func<AISkillDriver, bool>)(x => x.customName == "FleeStep")).First<AISkillDriver>();
                    //AISkillDriver aiSkillDriver2 = ((IEnumerable<AISkillDriver>) Addressables.LoadAssetAsync<GameObject>((object)"RoR2/DLC1/MajorAndMinorConstruct/MegaConstructMaster.prefab").WaitForCompletion().GetComponents<AISkillDriver>()).Where<AISkillDriver>((Func<AISkillDriver, bool>)(x => x.customName == "StopStep")).First<AISkillDriver>();
                    AISkillDriver aiSkillDriver3 = ((IEnumerable<AISkillDriver>)Addressables.LoadAssetAsync<GameObject>((object)"RoR2/DLC1/MajorAndMinorConstruct/MegaConstructMaster.prefab").WaitForCompletion().GetComponents<AISkillDriver>()).Where<AISkillDriver>((Func<AISkillDriver, bool>)(x => x.customName == "FollowStep")).First<AISkillDriver>();
                    AISkillDriver aiSkillDriver4 = ((IEnumerable<AISkillDriver>)Addressables.LoadAssetAsync<GameObject>((object)"RoR2/DLC1/MajorAndMinorConstruct/MegaConstructMaster.prefab").WaitForCompletion().GetComponents<AISkillDriver>()).Where<AISkillDriver>((Func<AISkillDriver, bool>)(x => x.customName == "FollowFast")).First<AISkillDriver>();
                    AISkillDriver aiSkillDriver5 = ((IEnumerable<AISkillDriver>)Addressables.LoadAssetAsync<GameObject>((object)"RoR2/DLC1/MajorAndMinorConstruct/MegaConstructMaster.prefab").WaitForCompletion().GetComponents<AISkillDriver>()).Where<AISkillDriver>((Func<AISkillDriver, bool>)(x => x.customName == "ShootStep")).First<AISkillDriver>();
                    Log.LogDebug("flee min distance: " + aiSkillDriver1.minDistance);
                    Log.LogDebug("flee max distance: " + aiSkillDriver1.maxDistance);
                    Log.LogDebug("approach min distance: " + aiSkillDriver3.minDistance);
                    Log.LogDebug("approach max distance: " + aiSkillDriver3.maxDistance);
                    Log.LogDebug("chase min distance: " + aiSkillDriver4.minDistance);
                    Log.LogDebug("chase max distance: " + aiSkillDriver4.maxDistance);
                    aiSkillDriver1.maxDistance = 15.0f;
                    aiSkillDriver3.minDistance = 30.0f;
                    aiSkillDriver4.minDistance = 75.0f;
                    Log.LogDebug("flee min distance: " + aiSkillDriver1.minDistance);
                    Log.LogDebug("flee max distance: " + aiSkillDriver1.maxDistance);
                    Log.LogDebug("approach min distance: " + aiSkillDriver3.minDistance);
                    Log.LogDebug("approach max distance: " + aiSkillDriver3.maxDistance);
                    Log.LogDebug("chase min distance: " + aiSkillDriver4.minDistance);
                    Log.LogDebug("chase max distance: " + aiSkillDriver4.maxDistance);
                };

            }
            catch (Exception e)
            {
                Logger.LogError(e.Message + " - " + e.StackTrace);
            }
        }
    }
}
