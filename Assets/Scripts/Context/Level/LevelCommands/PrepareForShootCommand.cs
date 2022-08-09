using context.level;
using DG.Tweening;
using strange.extensions.command.impl;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrepareForShootCommand : Command
{
    [Inject] public TowerModel TowerModel { get; set; }
    [Inject] public TowerView TowerView { get; set; }

    public override void Execute()
    {
     //   Debug.Log("PrepareForShootCommand");
        List<Vector3> tempList = new List<Vector3>();
 
        foreach (var view in TowerView.EnemyViews)
        {
            var percentage = (TowerModel.ShootDelay + view.EnemyTween.Elapsed()) 
                / view.EnemyTween.Duration();
            Debug.Log("PrepareForShootCommand " + view.EnemyTween.Duration());
            if (percentage < 1)
            {
                var getPoint = view.EnemyTween.PathGetPoint(percentage);
                Debug.Log("ќжидание " + getPoint);
                tempList.Add(getPoint);
            }
        }

        if (tempList.Any())
        {
            injectionBinder.GetInstance<ReadyToShootSignal>().Dispatch(GetNearestEnemy(tempList), TowerModel);
        }
    }

    private Vector3 GetNearestEnemy(List<Vector3> enemiesTransforms)
    {
        return enemiesTransforms.OrderBy(x => Vector3.Distance(TowerView.transform.position, x)).First();
    }
}
