using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractableEvents
{
    event Action OnShoot;
    event Action<CellView> OnUpgradeMenuOpen;
    event Action OnTowerMenuOpen;
}
