using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHover : BaseView
{
    [SerializeField] Color _mouseOverColor;
    [SerializeField] Color _originalColor;
    [SerializeField] MeshRenderer _meshRenderer;

    void OnMouseOver()
    {
        _meshRenderer.material.color = _mouseOverColor;
    }

    void OnMouseExit()
    {
        _meshRenderer.material.color = _originalColor;
    }
}
