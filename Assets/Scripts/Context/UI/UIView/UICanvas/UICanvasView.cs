using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvasView : MonoBehaviour
{
    private void OnEnable()
    {
        // TODO: канвасы в один класс
        gameObject.GetComponent<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
}
