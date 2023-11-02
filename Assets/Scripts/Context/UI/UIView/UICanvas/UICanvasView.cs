using UnityEngine;

public class UICanvasView : BaseCanvas
{
    private void OnEnable()
    {
        Canvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
}
