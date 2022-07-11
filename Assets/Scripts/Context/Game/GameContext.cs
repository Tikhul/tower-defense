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

        commandBinder.Bind<GameContextLoadedSignal>().To<CreateGameCommand>();

        injectionBinder.Bind<PlayerModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<BoardModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<GameModel>().ToSingleton().CrossContext();
    }
}
