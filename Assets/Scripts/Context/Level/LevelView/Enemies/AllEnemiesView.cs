using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemiesView : View
{
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private CellButtonView _cellButtonView;
    public List<GameObject> EnemyPrefabs => _enemyPrefabs;
    public CellButtonView CellButtonView => _cellButtonView;
    public void ActivateEnemy(EnemyModel model)
    {
        
            foreach(var enemy in _enemyPrefabs)
            {
                if (enemy.GetComponent<EnemyView>().Config.Id.Equals(model.Config.Id))
                {
                    GameObject _newEnemy = Instantiate(enemy);
                    _newEnemy.transform.parent = transform;
                    _newEnemy.transform.localPosition = enemy.transform.position;
                    _newEnemy.transform.localScale = enemy.transform.localScale;
                }
            }
        
    }
}
