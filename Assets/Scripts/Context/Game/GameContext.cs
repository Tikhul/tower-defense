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
        injectionBinder.Bind<LevelContextLoadedSignal>().ToSingleton();
    }
}
