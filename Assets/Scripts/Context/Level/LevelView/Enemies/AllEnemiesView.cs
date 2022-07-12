using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemiesView : View
{
    [SerializeField] private List<EnemyView> _enemyViews; 
    public List<EnemyView> EnemyViews => _enemyViews;
}
