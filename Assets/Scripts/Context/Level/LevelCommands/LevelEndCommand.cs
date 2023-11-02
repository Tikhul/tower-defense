using context.ui;
using strange.extensions.command.impl;

public class LevelEndCommand : Command
{
    public override void Execute()
    {
        injectionBinder.GetInstance<ShowRestartPanelSignal>().Dispatch();
        injectionBinder.GetInstance<HideMenuSignal>().Dispatch();
    }
}
