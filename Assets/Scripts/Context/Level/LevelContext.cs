using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelContext : LevelSignalContext
{
    public LevelContext(MonoBehaviour view)
        : base(view)
    {

    }

    protected override void mapBindings()
    {
        base.mapBindings();

        mediationBinder.BindView<BoardView>().ToMediator<BoardMediator>();
        injectionBinder.Bind<LoadLevelContextSignal>().ToSingleton();
        commandBinder.Bind<DrawBoardSignal>().To<DrawBoardCommand>().Once();
    }
}
