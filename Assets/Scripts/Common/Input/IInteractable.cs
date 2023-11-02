using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable : IInteractableEvents
{
    void TryShoot();
    void TryOpenMenu();
}
