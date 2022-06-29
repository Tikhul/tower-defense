using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCanvas : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    public Canvas Canvas
    { 
        get => _canvas;
        set => _canvas = value;
    }
}
