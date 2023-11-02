using context;
using context.level;
using context.ui;
using strange.extensions.signal.impl;
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

        injectionBinder.Bind<OnEnemyWayDefinedSignal>().ToSingleton();
        injectionBinder.Bind<ActivateWaveSignal>().ToSingleton();
        injectionBinder.Bind<PassLevelDataSignal>();
        injectionBinder.Bind<StartShootingSignal>().ToSingleton();
        injectionBinder.Bind<RenewTowerDataSignal>().ToSingleton();
        injectionBinder.Bind<EnemyDestroyedSignal>().ToSingleton();
        commandBinder.Bind<BulletHitEnemySignal>()
            .To<ChangeEnemyHealthCommand>()
            .To<UpdateEnemyDataCommand>()
            .InSequence();
        commandBinder.Bind<PipelineEndedSignal>().To<PipelineEndCommand>();
        commandBinder.Bind<DrawBoardSignal>().To<DrawBoardCommand>().Once();
        commandBinder.Bind<FillCellListSignal>().To<FillCellListCommand>();
        commandBinder.Bind<PipelineStartSignal>().To<StartPipelineCommand>().Once();
        commandBinder.Bind<NextLevelChosenSignal>()
            .To<EndCurrentLevelCommand>()
            .To<RenewPlayerHealthCommand>()
            .To<BeginNextLevelCommand>()
            .InSequence();
        commandBinder.Bind<RestartLevelChosenSignal>()
            .To<ClearEnemyWayCommand>()
            .To<DefineEnemyWayCommand>()
            .To<RenewPlayerHealthCommand>()
            .To<RenewPlayerMoneyCommand>()
            .To<RestartLevelCommand>()
            .InSequence();
        commandBinder.Bind<DefineEnemyWaySignal>()
            .To<ClearEnemyWayCommand>()
            .To<DefineEnemyWayCommand>()
            .InSequence();
        commandBinder.Bind<TowerChosenSignal>()
            .To<CheckMoneyForTowerCommand>()
            .To<CreateTowerModelCommand>()
            .InSequence();
        commandBinder.Bind<UpgradeChosenSignal>()
            .To<CheckMoneyForUpgradeCommand>()
            .To<UpgradeTowerCommand>()
            .InSequence();
        commandBinder.Bind<WaveEndedSignal>()
            .To<EndCurrentWaveCommand>()
            .To<BeginNextWaveCommand>()
            .InSequence();
        commandBinder.Bind<EnemyWayCompletedSignal>()
            .To<ChangePlayerHealthCommand>()
            .To<UpdateEnemyDataCommand>()
            .InSequence();
        commandBinder.Bind<LevelEndedSignal>().To<LevelEndCommand>();
    }
    protected override void MapMediators()
    {
        base.MapMediators();

        mediationBinder.BindView<BoardView>().ToMediator<BoardMediator>();
        mediationBinder.BindView<LevelView>().ToMediator<LevelMediator>();
        mediationBinder.BindView<EnemyView>().ToMediator<EnemyMediator>();
        mediationBinder.BindView<AllEnemiesView>().ToMediator<AllEnemiesMediator>();
        mediationBinder.BindView<BulletView>().ToMediator<BulletMediator>();
        mediationBinder.BindView<TowerView>().ToMediator<TowerMediator>();
        mediationBinder.BindView<CellView>().ToMediator<CellMediator>();
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
