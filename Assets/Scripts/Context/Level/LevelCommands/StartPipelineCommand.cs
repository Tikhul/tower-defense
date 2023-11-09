using context.ui;
using strange.extensions.command.impl;

public class StartPipelineCommand : Command
{
    private LevelsPipelineModel LevelsPipelineModel => injectionBinder.GetInstance<LevelsPipelineModel>();
    public override void Execute()
    {
        LevelsPipelineModel.Config = injectionBinder.GetInstance<LevelsLibraryModel>().GetLibraryDataById("pipeline");
        LevelsPipelineModel.Begin();
        injectionBinder.GetInstance<PassLevelDataSignal>().Dispatch(LevelsPipelineModel.CurrentLevel);
    }
}
