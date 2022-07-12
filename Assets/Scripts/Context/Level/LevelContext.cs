using context;
using context.level;
using context.ui;
using strange.extensions.signal.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelContext : CoreContext
{
    public LevelContext(MonoBehaviour view)
        : base(view)
    {

    }

    protected override Signal GetStartSignalInstance()
    {
        return injectionBinder.GetInstance<context.level.StartSignal>();
    }

    protected override void MapAsIndependentContext()
    {
        commandBinder.Bind<context.level.StartSignal>()
            .InSequence()
            .Once();
        
    }

    protected override void MapAsModuleContext()
    {
        commandBinder.Bind<context.level.StartSignal>()
            .InSequence()
            .Once();
    }
    protected override void MapSignals()
    {
        base.MapSignals();

        injectionBinder.Bind<OnEnemyDrawnSignal>().ToSingleton();
        injectionBinder.Bind<PassLevelDataSignal>();
        injectionBinder.Bind<PipelineEndedSignal>().ToSingleton().CrossContext();
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
        commandBinder.Bind<UpgradeChosenSignal>()
            .To<CheckMoneyForUpgradeCommand>()
            .To<UpgradeTowerCommand>()
            .InSequence();
    }
    protected override void MapMediators()
    {
        base.MapMediators();

        mediationBinder.BindView<BoardView>().ToMediator<BoardMediator>();
        mediationBinder.BindView<LevelView>().ToMediator<LevelMediator>();
    }
    protected override void MapEntities()
    {
        base.MapEntities();

        injectionBinder.Bind<LevelsPipelineModel>().ToSingleton();
        injectionBinder.Bind<WavePipelineModel>().ToSingleton();
        injectionBinder.Bind<LevelModel>();
        injectionBinder.Bind<WaveModel>();
    }
}
