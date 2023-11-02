using UnityEngine;
using UnityEditor;

public static class ToolbarStyles
{
    public static readonly GUIStyle ButtonStyle;

    static ToolbarStyles()
    {
        var bt = EditorStyles.toolbar;
        ButtonStyle = new GUIStyle("Command")
        {
            active = bt.active,
            focused = bt.focused,
            normal = bt.normal,
            fixedWidth = 100,
            fontSize = 16,
            alignment = TextAnchor.MiddleCenter,
            imagePosition = ImagePosition.ImageAbove,
            fontStyle = FontStyle.Normal
        };
    }
}