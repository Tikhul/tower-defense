using context;
using context.main;
using strange.extensions.signal.impl;
using UnityEngine;

public class MainContext : CoreContext
{
    public MainContext(MonoBehaviour view) 
        : base(view)
    {

    }

    protected override Signal GetStartSignalInstance()
    {
        return injectionBinder.GetInstance<StartSignal>();
    }

    protected override void MapEntities()
    {
        base.MapEntities();

        injectionBinder.Bind<EnemiesLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<TowersLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<UpgradesLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<LevelsLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<PlayerLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<BoardLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<WavesLibraryModel>().ToSingleton().CrossContext();
    }

    protected override void MapSignals()
    {
        base.MapSignals();

       // injectionBinder.Bind<LoadContextsSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<GameContextLoadedSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<LevelContextLoadedSignal>().ToSingleton().CrossContext();
    }

    protected override void MapMediators()
    {
        base.MapMediators();

        //mediationBinder.BindView<TowerButton>().ToMediator<TowerButtonMediator>();
        //mediationBinder.BindView<StartPanelView>().ToMediator<StartPanelMediator>();
        //mediationBinder.BindView<EndPanelView>().ToMediator<EndPanelMediator>();
        //mediationBinder.BindView<LevelRestartView>().ToMediator<LevelRestartMediator>();
        //mediationBinder.BindView<LevelNameView>().ToMediator<LevelNameMediator>();
        //mediationBinder.BindView<MenuView>().ToMediator<MenuMediator>();
        //mediationBinder.BindView<TowerMenuView>().ToMediator<TowerMenuMediator>();
        //mediationBinder.BindView<UserDataView>().ToMediator<UserDataMediator>();
        //mediationBinder.BindView<UpgradeMenuView>().ToMediator<UpgradeMenuMediator>();
        //mediationBinder.BindView<WarningsView>().ToMediator<WarningsMediator>();
    }

    protected override void MapAsIndependentContext()
    {
        commandBinder.Bind<StartSignal>()
            .To<LoadEnemiesConfigsCommand>()
            .To<LoadTowersConfigsCommand>()
            .To<LoadLevelPipelineConfigsCommand>()
            .To<LoadWavePipelinesConfigsCommand>()
            .To<LoadUpgradesConfigsCommand>()
            .To<LoadPlayerConfigCommand>()
            .To<LoadBoardConfigCommand>()
            .To<LoadUIContextCommand>()
            .InSequence()
            .Once();
    }

    protected override void MapAsModuleContext()
    {
        commandBinder.Bind<StartSignal>()
            .To<LoadEnemiesConfigsCommand>()
            .To<LoadTowersConfigsCommand>()
            .To<LoadLevelPipelineConfigsCommand>()
            .To<LoadWavePipelinesConfigsCommand>()
            .To<LoadUpgradesConfigsCommand>()
            .To<LoadPlayerConfigCommand>()
            .To<LoadBoardConfigCommand>()
            .To<LoadUIContextCommand>()
            .InSequence()
            .Once();
    }
}
