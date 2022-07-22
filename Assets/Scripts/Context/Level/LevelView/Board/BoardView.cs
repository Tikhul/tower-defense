using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BoardView : BaseView
{
    [SerializeField] private GameObject _boardParent;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private GameObject _cameraPosition;
    public GameObject BoardParent
    {
        get => _boardParent;
        set => _boardParent = value;
    }

    private void OnEnable()
    {
        Camera _mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _mainCamera.orthographic = false;
        _mainCamera.transform.position = _cameraPosition.transform.position;
        _mainCamera.transform.rotation = _cameraPosition.transform.rotation;
        _canvas.worldCamera = _mainCamera;
    }
}
