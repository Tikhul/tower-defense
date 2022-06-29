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
            .To<LoadUpgradesConfigsCommand>()
            .To<LoadPlayerConfigCommand>()
            .To<LoadBoardConfigCommand>()
            .To<LoadUIContextCommand>()
            .To<LoadWavePipelinesConfigsCommand>()
            .InSequence()
            .Once();
        injectionBinder.Bind<UIContextLoadedSignal>().ToSingleton();
        injectionBinder.Bind<EnemiesLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<TowersLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<UpgradesLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<LevelsLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<PlayerLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<BoardLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<WavesLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<PlayerSO>().ToSingleton().CrossContext();
        injectionBinder.Bind<BoardSO>().ToSingleton().CrossContext();
        injectionBinder.Bind<LevelsPipelineSO>().ToSingleton().CrossContext();
        injectionBinder.Bind<WavePipelineSO>().ToSingleton().CrossContext();
    }
}
