using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ClusterVR.CreatorKit.Gimmick;
using ClusterVR.CreatorKit.Gimmick.Implements;
using ClusterVR.CreatorKit.Trigger.Implements;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace HatoSword
{
    public static class HatoSwordKeyAssigner
    {
        const string WarpSwordShiftKeyPrefix = "warpsword.shift";

        [MenuItem("HatoSword/UpdateKeys")]
        static void UpdateHatoSwordKeys()
        {
            if (Application.isPlaying) return;

            var warpPlayerGimmickKeyFieldInfo = typeof(WarpPlayerGimmick).GetField("key", BindingFlags.NonPublic | BindingFlags.Instance);
            var useUpTriggersFieldInfo = typeof(UseItemTrigger).GetField("upTriggers", BindingFlags.NonPublic | BindingFlags.Instance);
            var itemTriggerKeyFieldInfo = typeof(ItemTrigger).GetField("key", BindingFlags.NonPublic | BindingFlags.Instance);

            var scene = SceneManager.GetActiveScene();

            foreach (var (warpPlayerGimmick, i) in GatherComponentsInScene<WarpPlayerGimmick>(scene)
                .Where(g => IsWarpSwordKey(((IGimmick) g).Key))
                .Select((g, i) => (g, i)))
            {
                var warpPlayerKey = CreateWarpPlayerKey(i);
                var gimmickKey = (GimmickKey) warpPlayerGimmickKeyFieldInfo.GetValue(warpPlayerGimmick);
                if (gimmickKey.Key != warpPlayerKey)
                {
                    var newKey = new GimmickKey(gimmickKey.Target, warpPlayerKey);
                    warpPlayerGimmickKeyFieldInfo.SetValue(warpPlayerGimmick, newKey);
                    EditorUtility.SetDirty(warpPlayerGimmick);
                    EditorSceneManager.MarkSceneDirty(scene);
                }

                var useItemTrigger  = warpPlayerGimmick.GetComponent<UseItemTrigger>();
                if (useItemTrigger == null) continue;

                var upTriggers = (ItemTrigger[]) useUpTriggersFieldInfo.GetValue(useItemTrigger);
                foreach (var trigger in upTriggers)
                {
                    if (!IsWarpSwordKey(trigger.Key)) continue;
                    if (trigger.Key == warpPlayerKey) continue;
                    itemTriggerKeyFieldInfo.SetValue(trigger, warpPlayerKey);
                    EditorUtility.SetDirty(useItemTrigger);
                    EditorSceneManager.MarkSceneDirty(scene);
                }
            }
        }

        static string CreateWarpPlayerKey(int i)
        {
            return $"{WarpSwordShiftKeyPrefix}{i}";
        }

        static bool IsWarpSwordKey(string key)
        {
            return key.StartsWith(WarpSwordShiftKeyPrefix);
        }

        static IEnumerable<T> GatherComponentsInScene<T>(Scene scene)
        {
            var rootObjects = scene.GetRootGameObjects();
            return rootObjects.SelectMany(o => o.GetComponentsInChildren<T>(true));
        }
    }
}