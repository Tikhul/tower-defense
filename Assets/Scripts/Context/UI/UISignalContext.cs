using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using strange.extensions.context.api;

public class UISignalContext : MVCSContext
{
    public UISignalContext(MonoBehaviour contextView)
        : base(contextView, ContextStartupFlags.MANUAL_MAPPING)
    {

    }

    protected override void addCoreComponents()
    {
        base.addCoreComponents();

        injectionBinder.Unbind<ICommandBinder>();
        injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();
    }

    public override void Launch()
    {
        base.Launch();
    }
}
