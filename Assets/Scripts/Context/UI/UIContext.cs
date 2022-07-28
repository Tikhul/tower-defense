using context;
using context.main;
using context.ui;
using strange.extensions.signal.impl;
using UnityEngine;

public class UIContext : CoreContext
{
    public UIContext(MonoBehaviour view)
        : base(view)
    {

    }

    protected override Signal GetStartSignalInstance()
    {
        return injectionBinder.GetInstance<context.ui.StartSignal>();
    }

    protected override void MapSignals()
    {
        base.MapSignals();

        injectionBinder.Bind<NextLevelChosenSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<RestartLevelChosenSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<ShowEndPanelSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<ShowRestartPanelSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<PassLevelDataSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<PassTowersDictionarySignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<CellButtonViewCreatedSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<BlockBoardSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<UnblockBoardSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<ChangePlayerDataSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<TowerMenuCreatedSignal>().ToSingleton();
        injectionBinder.Bind<UpgradeMenuCreatedSignal>().ToSingleton();
        injectionBinder.Bind<HideMenuSignal>().ToSingleton();
        injectionBinder.Bind<TowerChosenSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<UpgradeChosenSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<ShowTowerDataSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<NoMoneySignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<TowerBoughtSignal>().ToSingleton().CrossContext();
        injectionBinder.Bind<PrepareForShootSignal>().ToSingleton().CrossContext();
        
        commandBinder.Bind<CreateTowerMenuSignal>().To<CreateTowerMenuCommand>();
        commandBinder.Bind<CreateUpgradeMenuSignal>().To<CreateUpgradeMenuCommand>();
        commandBinder.Bind<LoadContextsSignal>()
            .To<LoadGameContextCommand>()
            .To<LoadLevelContextCommand>()
            .InSequence();
    }

    protected override void MapMediators()
    {
        base.MapMediators();

        mediationBinder.BindView<TowerButtonView>().ToMediator<TowerButtonMediator>();
        mediationBinder.BindView<StartPanelView>().ToMediator<StartPanelMediator>();
        mediationBinder.BindView<EndPanelView>().ToMediator<EndPanelMediator>();
        mediationBinder.BindView<LevelRestartView>().ToMediator<LevelRestartMediator>();
        mediationBinder.BindView<LevelNameView>().ToMediator<LevelNameMediator>();
        mediationBinder.BindView<MenuView>().ToMediator<MenuMediator>();
        mediationBinder.BindView<TowerMenuView>().ToMediator<TowerMenuMediator>();
        mediationBinder.BindView<UserDataView>().ToMediator<UserDataMediator>();
        mediationBinder.BindView<UpgradeMenuView>().ToMediator<UpgradeMenuMediator>();
        mediationBinder.BindView<UpgradeButtonView>().ToMediator<UpgradeButtonMediator>();
        mediationBinder.BindView<WarningsView>().ToMediator<WarningsMediator>();
    }

    protected override void MapAsIndependentContext()
    {
        commandBinder.Bind<context.ui.StartSignal>()
            .InSequence()
            .Once();
    }

    protected override void MapAsModuleContext()
    {
        commandBinder.Bind<context.ui.StartSignal>()
            .InSequence()
            .Once();
    }
}
