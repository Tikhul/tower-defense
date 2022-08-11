using System.Collections.Generic;
using context.ui;
using strange.extensions.command.impl;
using UnityEngine;

public class ChangeEnemyHealthCommand : Command
{
    [Inject] public EnemyView EnemyView { get; set; }
    [Inject] public int Damage { get; set; }
    private PlayerModel Player => injectionBinder.GetInstance<GameModel>().Player;
    private Dictionary<EnemyView, EnemyModel> _enemyData => injectionBinder.GetInstance<LevelsPipelineModel>()
        .CurrentLevel.LevelWaves.CurrentWave.EnemyData;
    public override void Execute()
    {
        Debug.Log(_enemyData.Count);
        EnemyModel model = _enemyData[EnemyView];
        model.ActualHealth -= Damage;
        if (model.ActualHealth <= 0)
        {
            Player.ActualCoins += EnemyView.Config.CoinsForKill;
            injectionBinder.GetInstance<ChangePlayerDataSignal>().Dispatch(Player);
        }
        else
        {
            EnemyView.ShowEnemyHealth(model.ActualHealth);
            Fail();
        }
    }
}
