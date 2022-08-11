using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class NearestEnemyFinder
{
    private List<Vector3> GetAvailableEnemies(TowerModel towerModel, TowerView towerView)
    {
        List<Vector3> tempList = new List<Vector3>();
        
        foreach (var view in towerView.EnemyViews)
        {
            var percentage = (towerModel.ShootDelay + view.EnemyTween.Elapsed()) 
                             / view.EnemyTween.Duration();
            if (percentage < 1)
            {
                var getPoint = view.EnemyTween.PathGetPoint(percentage);
                tempList.Add(getPoint);
            }
        }

        return tempList;
    }

    public Vector3 GetNearestEnemy(TowerModel towerModel, TowerView towerView)
    {
        return GetAvailableEnemies(towerModel, towerView).OrderBy(
            x => Vector3.Distance(towerView.transform.position, x)).First();
    }
}
