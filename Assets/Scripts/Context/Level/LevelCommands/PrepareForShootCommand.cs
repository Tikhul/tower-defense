using context.level;
using DG.Tweening;
using strange.extensions.command.impl;
using System.Collections.Generic;
using UnityEngine;

public class PrepareForShootCommand : Command
{
    [Inject] public TowerModel TowerModel { get; set; }
    [Inject] public TowerView TowerView { get; set; }

    public override void Execute()
    {
        Dictionary<Vector3, EnemyView> tempList = new Dictionary<Vector3, EnemyView>();
        Debug.Log(TowerView.EnemyViews.Count);
        foreach (var view in TowerView.EnemyViews)
        {
            
            var _percentage = (TowerModel.ShootDelay + view.EnemyTween.Elapsed()) 
                / view.EnemyTween.Duration();

            if (_percentage < 1)
            {
                var getPoint = view.EnemyTween.PathGetPoint(_percentage);
                tempList.Add(getPoint, view);
            }
        }
        Debug.Log("PrepareForShootCommand");
        injectionBinder.GetInstance<ReadyToShootSignal>().Dispatch(tempList, TowerModel);
    }
}
