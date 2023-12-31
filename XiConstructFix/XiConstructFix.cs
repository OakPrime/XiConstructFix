using BepInEx;
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
                    AISkillDriver skillDriverFlee = ((IEnumerable<AISkillDriver>)Addressables.LoadAssetAsync<GameObject>((object)"RoR2/DLC1/MajorAndMinorConstruct/MegaConstructMaster.prefab").WaitForCompletion().GetComponents<AISkillDriver>()).Where<AISkillDriver>((Func<AISkillDriver, bool>)(x => x.customName == "FleeStep")).First<AISkillDriver>();
                    //AISkillDriver skillDriverStop = ((IEnumerable<AISkillDriver>) Addressables.LoadAssetAsync<GameObject>((object)"RoR2/DLC1/MajorAndMinorConstruct/MegaConstructMaster.prefab").WaitForCompletion().GetComponents<AISkillDriver>()).Where<AISkillDriver>((Func<AISkillDriver, bool>)(x => x.customName == "StopStep")).First<AISkillDriver>();
                    AISkillDriver skillDriverFollow = ((IEnumerable<AISkillDriver>)Addressables.LoadAssetAsync<GameObject>((object)"RoR2/DLC1/MajorAndMinorConstruct/MegaConstructMaster.prefab").WaitForCompletion().GetComponents<AISkillDriver>()).Where<AISkillDriver>((Func<AISkillDriver, bool>)(x => x.customName == "FollowStep")).First<AISkillDriver>();
                    AISkillDriver skillDriverFollowFast = ((IEnumerable<AISkillDriver>)Addressables.LoadAssetAsync<GameObject>((object)"RoR2/DLC1/MajorAndMinorConstruct/MegaConstructMaster.prefab").WaitForCompletion().GetComponents<AISkillDriver>()).Where<AISkillDriver>((Func<AISkillDriver, bool>)(x => x.customName == "FollowFast")).First<AISkillDriver>();
                    AISkillDriver skillDriverShoot = ((IEnumerable<AISkillDriver>)Addressables.LoadAssetAsync<GameObject>((object)"RoR2/DLC1/MajorAndMinorConstruct/MegaConstructMaster.prefab").WaitForCompletion().GetComponents<AISkillDriver>()).Where<AISkillDriver>((Func<AISkillDriver, bool>)(x => x.customName == "ShootStep")).First<AISkillDriver>();
                    /*Log.LogDebug("flee min distance: " + skillDriverFlee.minDistance);
                    Log.LogDebug("flee max distance: " + skillDriverFlee.maxDistance);
                    Log.LogDebug("approach min distance: " + skillDriverFollow.minDistance);
                    Log.LogDebug("approach max distance: " + skillDriverFollow.maxDistance);
                    Log.LogDebug("chase min distance: " + skillDriverFollowFast.minDistance);
                    Log.LogDebug("chase max distance: " + skillDriverFollowFast.maxDistance);*/
                    skillDriverFlee.maxDistance = 15.0f;
                    skillDriverFollow.minDistance = 30.0f;
                    skillDriverFollowFast.minDistance = 75.0f;
                    /*Log.LogDebug("flee min distance: " + skillDriverFlee.minDistance);
                    Log.LogDebug("flee max distance: " + skillDriverFlee.maxDistance);
                    Log.LogDebug("approach min distance: " + skillDriverFollow.minDistance);
                    Log.LogDebug("approach max distance: " + skillDriverFollow.maxDistance);
                    Log.LogDebug("chase min distance: " + skillDriverFollowFast.minDistance);
                    Log.LogDebug("chase max distance: " + skillDriverFollowFast.maxDistance);*/
                };

            }
            catch (Exception e)
            {
                Logger.LogError(e.Message + " - " + e.StackTrace);
            }
        }
    }
}
