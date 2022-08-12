using context.level;
using context.ui;
using strange.extensions.command.impl;
using UnityEngine;

public class ChangePlayerHealthCommand : Command
{
    [Inject] public EnemyView EnemyView { get; set; }
    public override void Execute()
    {
        Debug.Log("ChangePlayerHealthCommand");
        injectionBinder.GetInstance<GameModel>().Player.ActualHealth -= EnemyView.Config.Damage;
        injectionBinder.GetInstance<ChangePlayerDataSignal>().Dispatch(injectionBinder.GetInstance<GameModel>().Player);
    }
}
