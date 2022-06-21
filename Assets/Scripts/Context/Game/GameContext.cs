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

        commandBinder.Bind<LoadLevelContextSignal>()
            .To<CreateGameCommand>()
            .To<LoadLevelContextCommand>()
            .InSequence();
        injectionBinder.Bind<LevelContextLoadedSignal>().ToSingleton();
        injectionBinder.Bind<PlayerModel>().ToSingleton();
        injectionBinder.Bind<BoardModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<GameModel>().ToSingleton().CrossContext();
    }
}
