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
        mediationBinder.BindView<LevelView>().ToMediator<LevelMediator>();
        commandBinder.Bind<DrawBoardSignal>().To<DrawBoardCommand>().Once();
        commandBinder.Bind<FillCellListSignal>().To<FillCellListCommand>().Once();
       // commandBinder.Bind<PipelineStartSignal>().To<StartPipelineCommand>();
        injectionBinder.Bind<PipelineEndedSignal>();
        injectionBinder.Bind<LevelsPipelineModel>().ToSingleton();
    }
}
