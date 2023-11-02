using System;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class SceneSwitchLeftButton
{
    private static readonly GUIContent ButtonContent = new GUIContent("Play Main", "This Play edit mode starts from the main scene");

    static SceneSwitchLeftButton()
    {
        ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
    }

    private static void OnToolbarGUI()
    {
        GUILayout.FlexibleSpace();

        using (new BackgroundColor(EditorApplication.isPlaying
                   ? new Color(.54f, 0.85f, 1f, 1f)
                   : Color.white))
        {
            if (GUILayout.Button(ButtonContent, ToolbarStyles.ButtonStyle))
            {
                if (EditorApplication.isPlaying)
                {
                    EditorApplication.isPlaying = false;
                    return;
                }

                SceneHelper.OpenScene("Main", () => EditorApplication.isPlaying = true);
            }
        }
    }

    private class BackgroundColor : IDisposable
    {
        private readonly Color _memory;

        public BackgroundColor(Color color)
        {
            _memory = GUI.backgroundColor;
            GUI.backgroundColor = color;
        }

        public void Dispose()
        {
            GUI.backgroundColor = _memory;
        }
    }
}