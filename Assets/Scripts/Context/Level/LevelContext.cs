using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelContext : LevelSignalContext
{
    public LevelContext(MonoBehaviour view)
        : base(view)
    {

    }

    protected override void mapBindings()
    {
        base.mapBindings();

        mediationBinder.BindView<BoardView>().ToMediator<BoardMediator>();
        mediationBinder.BindView<LevelView>().ToMediator<LevelMediator>();

        commandBinder.Bind<DrawBoardSignal>().To<DrawBoardCommand>().Once();
        commandBinder.Bind<FillCellListSignal>().To<FillCellListCommand>();
        commandBinder.Bind<PipelineStartSignal>().To<StartPipelineCommand>().Once();
        commandBinder.Bind<NextLevelChosenSignal>()
            .To<EndCurrentLevelCommand>()
            .To<BeginNextLevelCommand>()
            .InSequence();
        commandBinder.Bind<RestartLevelChosenSignal>().To<RestartLevelCommand>();
        commandBinder.Bind<DrawEnemyWaySignal>()
            .To<ClearEnemyWayCommand>()
            .To<SetEnemyWayCommand>()
            .InSequence();
        commandBinder.Bind<TowerChosenSignal>()
            .To<CheckMoneyForTowerCommand>()
            .To<CreateTowerModelCommand>()
            .InSequence();
        commandBinder.Bind<UpgradeChosenSignal>().To<UpgradeTowerCommand>();

        injectionBinder.Bind<OnEnemyDrawnSignal>().ToSingleton();
        injectionBinder.Bind<PassLevelDataSignal>();
        injectionBinder.Bind<PipelineEndedSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<LevelsPipelineModel>().ToSingleton();
        injectionBinder.Bind<WavePipelineModel>().ToSingleton();
        injectionBinder.Bind<LevelModel>();
        injectionBinder.Bind<WaveModel>();
    }
}
