using context.ui;
using strange.extensions.command.impl;

/// <summary>
/// ?????? ????????? ????? ? ?????? ?????? (??????? ??????-??????)
/// </summary>
public class CreateTowerModelCommand : Command
{
    [Inject] public TowerButtonView TowerButtonView { get; set; }

    public override void Execute()
    {
        TowerModel newTower = new TowerModel(TowerButtonView.TowerView.TowerConfig);
        injectionBinder.GetInstance<LevelsPipelineModel>().CurrentLevel.TowerData.Add(TowerButtonView.TowerView, newTower);
        injectionBinder.GetInstance<ShowTowerDataSignal>().Dispatch(newTower);
    }
}
