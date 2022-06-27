using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMenuView : BaseView
{
    [SerializeField] private GameObject _parentPanel;

    public GameObject ParentPanel
    {
        get => _parentPanel;
        set => _parentPanel = value;
    }

    public virtual void ClearMenu() { }
}
