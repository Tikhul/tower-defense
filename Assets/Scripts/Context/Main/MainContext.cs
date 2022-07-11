using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainContext : MainSignalContext
{
    public MainContext(MonoBehaviour view) 
        : base(view)
    {

    }

    protected override void mapBindings()
    {
        base.mapBindings();
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
       // commandBinder.Bind<LoadContextsSignal>().To<LoadGameContextCommand>();

        injectionBinder.Bind<LoadContextsSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<EnemiesLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<TowersLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<UpgradesLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<LevelsLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<PlayerLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<BoardLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<WavesLibraryModel>().ToSingleton().CrossContext();
    }
}
