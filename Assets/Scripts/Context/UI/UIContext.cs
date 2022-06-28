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
        mediationBinder.BindView<EndPanelView>().ToMediator<EndPanelMediator>();
        mediationBinder.BindView<LevelRestartView>().ToMediator<LevelRestartMediator>();
        mediationBinder.BindView<LevelNameView>().ToMediator<LevelNameMediator>();
        mediationBinder.BindView<MenuView>().ToMediator<MenuMediator>();
        mediationBinder.BindView<TowerMenuView>().ToMediator<TowerMenuMediator>();
        mediationBinder.BindView<UserDataView>().ToMediator<UserDataMediator>();
        mediationBinder.BindView<UpgradeMenuView>().ToMediator<UpgradeMenuMediator>();

        commandBinder.Bind<LoadGameContextSignal>().To<LoadGameContextCommand>().Once();
        commandBinder.Bind<CreateTowerMenuSignal>().To<CreateTowerMenuCommand>();
        commandBinder.Bind<CreateUpgradeMenuSignal>().To<CreateUpgradeMenuCommand>();

        injectionBinder.Bind<NextLevelChosenSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<RestartLevelChosenSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<ShowEndPanelSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<ShowRestartPanelSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<GameContextLoadedSignal>().ToSingleton();
        injectionBinder.Bind<PassLevelDataSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<CellButtonCreatedSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<BlockBoardSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<UnblockBoardSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<ChangePlayerDataSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<TowerMenuCreatedSignal>().ToSingleton();
        injectionBinder.Bind<UpgradeMenuCreatedSignal>().ToSingleton();
        injectionBinder.Bind<HideMenuSignal>().ToSingleton();
        injectionBinder.Bind<TowerChosenSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<UpgradeChosenSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<ShowTowerDataSignal>().ToSingleton().CrossContext();
    }
}
