using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIContext : UISignalContext
{
    public UIContext(MonoBehaviour view)
        : base(view)
    {

    }

    protected override void mapBindings()
    {
        base.mapBindings();

        mediationBinder.BindView<StartPanelView>().ToMediator<StartPanelMediator>();
        commandBinder.Bind<LoadGameContextSignal>().To<LoadGameContextCommand>().Once();
        injectionBinder.Bind<GameContextLoadedSignal>().ToSingleton();
    }
}
