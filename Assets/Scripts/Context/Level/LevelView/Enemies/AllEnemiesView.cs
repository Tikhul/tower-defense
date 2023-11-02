using strange.extensions.mediation.impl;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemiesView : View
{
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private CellButtonView _cellButtonView;
    public CellButtonView CellButtonView => _cellButtonView;
    public void ActivateEnemy(EnemyModel model)
    {
        foreach(var enemy in _enemyPrefabs)
        {
            if (enemy.GetComponent<EnemyView>().Config.Id.Equals(model.Config.Id))
            {
                GameObject newEnemy = Instantiate(enemy, transform, true);
                newEnemy.transform.localPosition = transform.localPosition;
                newEnemy.transform.localScale = enemy.transform.localScale;
            }
        }
    }
}
