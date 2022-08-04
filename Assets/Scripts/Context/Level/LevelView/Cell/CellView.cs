using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellView : BaseView, IInteractable
{
    public event Action OnTryInteract;
    public event Action OnInteract;

    public void TryOpenMenu()
    {
        Debug.Log("TryOpenMenu");
    }

    public void TryShoot()
    {
        Debug.Log("TryShoot");
    }
}
