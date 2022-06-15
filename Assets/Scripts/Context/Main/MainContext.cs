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
        commandBinder.Bind<LoadUIContextSignal>().To<LoadUIContextCommand>().Once();
        injectionBinder.Bind<UIContextLoadedSignal>().ToSingleton();
    }
}
