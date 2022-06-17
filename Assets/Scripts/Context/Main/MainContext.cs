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
            .To<LoadPlayerConfigCommand>()
            .To<LoadBoardConfigCommand>()
            .To<LoadUIContextCommand>().
            InSequence()
            .Once();
        injectionBinder.Bind<UIContextLoadedSignal>().ToSingleton();
        injectionBinder.Bind<EnemiesLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<TowersLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<LevelsLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<PlayerLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<BoardLibraryModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<PlayerSO>().ToSingleton().CrossContext();
        injectionBinder.Bind<BoardSO>().ToSingleton().CrossContext();
    }
}
