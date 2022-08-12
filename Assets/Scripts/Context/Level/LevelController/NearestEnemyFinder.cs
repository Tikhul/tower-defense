using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using UnityEngine;

public class NearestEnemyFinder
{
    public Vector3? NearestEnemy;
    private Dictionary<EnemyView, Vector3> _tempList = new Dictionary<EnemyView, Vector3>();
    
    private List<Vector3> GetAvailableEnemies(TowerModel towerModel, TowerView towerView)
    {
        foreach (var view in towerView.EnemyViews.Where(x => !x.IsTarget))
        {
            var percentage = (towerModel.ShootDelay + view.EnemyTween.Elapsed()) 
                             / view.EnemyTween.Duration();
            if (percentage < 1)
            {
                var getPoint = view.EnemyTween.PathGetPoint(percentage);
                _tempList.Add(view, getPoint);
            }
        }

        return _tempList.Values.ToList();
    }

    public void GetNearestEnemy(TowerModel towerModel, TowerView towerView)
    {
        var nearestEnemy = GetAvailableEnemies(towerModel, towerView).OrderBy(
            x => Vector3.Distance(towerView.transform.position, x)).First();
        var nearestEnemyView = _tempList.Where(
            x => x.Value == nearestEnemy).FirstOrDefault().Key;

        if (!nearestEnemyView.IsTarget)
        {
            nearestEnemyView.IsTarget = true;
            NearestEnemy = nearestEnemy;
        }
        else if (nearestEnemyView.IsTarget && towerView.EnemyViews.Where(x => !x.IsTarget).ToList().Any())
        {
            NearestEnemy = GetAvailableEnemies(towerModel, towerView).OrderBy(
                x => Vector3.Distance(towerView.transform.position, x)).First();
        }
        else
        {
            NearestEnemy = null;
        }
    }
}
