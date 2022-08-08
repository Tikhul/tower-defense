using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractableEvents
{
    event Action<TowerView> OnShoot;
    event Action<CellView> OnUpgradeMenuOpen;
    event Action<CellView> OnTowerMenuOpen;
}
