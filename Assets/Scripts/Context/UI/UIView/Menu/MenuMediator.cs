using context.ui;
using strange.extensions.mediation.impl;

public class MenuMediator : Mediator
{
    [Inject] public MenuView View { get; set; }
    [Inject] public CellViewCreatedSignal CellViewCreatedSignal { get; set; }
    [Inject] public BlockBoardSignal BlockBoardSignal { get; set; }
    [Inject] public UnblockBoardSignal UnblockBoardSignal { get; set; }
    [Inject] public CreateTowerMenuSignal CreateTowerMenuSignal { get; set; }
    [Inject] public CreateUpgradeMenuSignal CreateUpgradeMenuSignal { get; set; }
    [Inject] public HideSubMenuSignal HideSubMenuSignal { get; set; }
    [Inject] public HideMenuSignal HideMenuSignal { get; set; }
    [Inject] public TowerChosenSignal TowerChosenSignal { get; set; }

    public override void OnRegister()
    {
        CellViewCreatedSignal.AddListener(SubscribeToCells);
        TowerChosenSignal.AddListener(TowerButtonClickedHandler);
        HideMenuSignal.AddListener(HideMenuHandler);
    }

    public override void OnRemove()
    {
        CellViewCreatedSignal.RemoveListener(SubscribeToCells);
        TowerChosenSignal.RemoveListener(TowerButtonClickedHandler);
        HideMenuSignal.RemoveListener(HideMenuHandler);
    }
    private void SubscribeToCells(CellView cell)
    {
        cell.OnTowerMenuOpen += ShowTowerMenuHandler;
        cell.OnUpgradeMenuOpen += ShowUpgradeMenuHandler;
        View.OnCloseMenu += HideMenuHandler;
    }

    private void ShowTowerMenuHandler(CellView receivedCell)
    {
        BlockBoardSignal.Dispatch();
        CreateTowerMenuSignal.Dispatch(receivedCell);
        View.Show();
    }
    private void ShowUpgradeMenuHandler(CellView receivedCell)
    {
        BlockBoardSignal.Dispatch();
        CreateUpgradeMenuSignal.Dispatch(receivedCell);
        View.Show();
    }
    private void TowerButtonClickedHandler(TowerButtonView button)
    {
        HideMenuHandler();
    }
    private void HideMenuHandler()
    {
        UnblockBoardSignal.Dispatch();
        HideMenu();
        HideSubMenuSignal.Dispatch();
    }

    private void HideMenu()
    {
        View.Hide();
    }
}
