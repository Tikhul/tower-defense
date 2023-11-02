using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellHover : BaseView
{
    [SerializeField] Color _mouseOverColor;
    [SerializeField] Color _originalColor;
    [SerializeField] MeshRenderer _meshRenderer;
    public MeshRenderer MeshRenderer
    {
        get => _meshRenderer;
        set => _meshRenderer = value;
    }
    public bool Interactable { get; set; }
    void OnMouseOver()
    {
        if (Interactable)
        {
            _meshRenderer.material.color = _mouseOverColor;
        }
    }
    void OnMouseExit()
    {
        if (Interactable)
        {
            _meshRenderer.material.color = _originalColor;
        }      
    }
    public void ClearColor()
    {
        _meshRenderer.material.color = _originalColor;
    }
}
