using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelContext : GameSignalContext
{
    public LevelContext(MonoBehaviour view)
        : base(view)
    {

    }

    protected override void mapBindings()
    {
        base.mapBindings();

        injectionBinder.Bind<LoadLevelContextSignal>().ToSingleton();
    }
}
