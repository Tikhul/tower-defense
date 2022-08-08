using strange.extensions.mediation.impl;
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
        foreach(var enemy in EnemyPrefabs)
        {
            if (enemy.GetComponent<EnemyView>().Config.Id.Equals(model.Config.Id))
            {
                GameObject newEnemy = Instantiate(enemy);
                newEnemy.transform.parent = transform;
                newEnemy.transform.position = transform.position;
                newEnemy.transform.localScale = enemy.transform.localScale;
            }
        }
    }
}
