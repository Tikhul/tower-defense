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
        
        injectionBinder.Bind<GameContextLoadedSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<LevelContextLoadedSignal>().ToSingleton().CrossContext();
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
