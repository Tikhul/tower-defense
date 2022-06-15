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
            .To<LoadUIContextCommand>()
            .To<LoadEnemiesConfigsCommand>()
            .To<LoadTowersConfigsCommand>()
            .To<LoadLevelPipelineConfigsCommand>()
            .To<LoadPlayerConfigCommand>()
            .Once();
        injectionBinder.Bind<UIContextLoadedSignal>().ToSingleton();
    }
}
