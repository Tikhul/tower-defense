using System;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class SceneHelper
{
    public static void OpenScene(string sceneName, Action callback = null)
    {
        if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
        {
            var guids = AssetDatabase.FindAssets($"t:scene {sceneName}");
            if (guids.Length == 0)
            {
                Debug.LogWarning("Couldn't find scene file");
                return;
            }

            var scenePath = "Assets/Scenes/Main.unity";
            EditorSceneManager.OpenScene(scenePath);

            callback?.Invoke();
            return;
        }

        callback?.Invoke();
    }
}