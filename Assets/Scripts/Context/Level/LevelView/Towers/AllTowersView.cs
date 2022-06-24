using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllTowersView : MonoBehaviour
{
    [SerializeField] private List<TowerView> _towerViews;

    public List<TowerView> TowerViews
    {
        get => _towerViews;
        set => _towerViews = value;
    }
}
