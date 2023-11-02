using context;
using context.level;
using strange.extensions.signal.impl;
using UnityEngine;
using StartSignal = context.game.StartSignal;

public class GameContext : CoreContext
{
    public GameContext(MonoBehaviour view)
        : base(view)
    {

    }

    protected override Signal GetStartSignalInstance()
    {
        return injectionBinder.GetInstance<StartSignal>();
    }

    protected override void MapAsIndependentContext()
    {
        commandBinder.Bind<StartSignal>().To<CreateGameCommand>();
    }

    protected override void MapAsModuleContext()
    {
        commandBinder.Bind<StartSignal>()
            .To<CreateGameCommand>()
            .To<FillCellListCommand>()
            .InSequence();
    }

    protected override void MapEntities()
    {
        base.MapEntities();

        injectionBinder.Bind<PlayerModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<BoardModel>().ToSingleton().CrossContext();
        injectionBinder.Bind<GameModel>().ToSingleton().CrossContext();
    }
}
