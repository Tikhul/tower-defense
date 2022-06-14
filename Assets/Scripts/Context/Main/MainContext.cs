using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainContext : SignalContext
{
    public MainContext(MonoBehaviour view) 
        : base(view)
    {

    }

    protected override void mapBindings()
    {
        base.mapBindings();
        commandBinder.Bind<StartSignal>().To<LoadUIContextCommand>().Once();
        injectionBinder.Bind<UIContextLoadedSignal>().ToSingleton();
    }
}
