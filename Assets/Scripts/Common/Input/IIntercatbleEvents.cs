using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractableEvents
{
    event Action OnTryInteract;
    event Action OnInteract;
}
