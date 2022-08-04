using strange.extensions.mediation.impl;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemiesView : View
{
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private CellView _cellView;
    public List<GameObject> EnemyPrefabs => _enemyPrefabs;
    public CellView CellView => _cellView;
    public void ActivateEnemy(EnemyModel model)
    {
        foreach(var enemy in _enemyPrefabs)
        {
            if (enemy.GetComponent<EnemyView>().Config.Id.Equals(model.Config.Id))
            {
                GameObject _newEnemy = Instantiate(enemy);
                _newEnemy.transform.parent = transform;
                _newEnemy.transform.localPosition = transform.localPosition;
                _newEnemy.transform.localScale = enemy.transform.localScale;
            }
        }
    }
}
