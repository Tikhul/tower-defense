using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContext : GameSignalContext
{
    public GameContext(MonoBehaviour view)
        : base(view)
    {

    }

    protected override void mapBindings()
    {
        base.mapBindings();

        commandBinder.Bind<LoadLevelContextSignal>().To<LoadLevelContextCommand>();
        commandBinder.Bind<PlayerLibraryCreatedSignal>().To<CreatePlayerCommand>();
        commandBinder.Bind<BoardLibraryCreatedSignal>().To<CreateBoardCommand>();
        injectionBinder.Bind<PlayerCreatedSignal>().ToSingleton();
        injectionBinder.Bind<BoardCreatedSignal>().ToSingleton();
        injectionBinder.Bind<LevelContextLoadedSignal>().ToSingleton();
    }
}
