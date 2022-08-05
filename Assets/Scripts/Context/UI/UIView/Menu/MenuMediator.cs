using context.ui;
using strange.extensions.mediation.impl;
using System.Collections.Generic;

public class MenuMediator : Mediator
{
 //   private List<CellView> _cells = new List<CellView>();
    
  //  private bool _subscribedToCells = false;
    
    [Inject] public MenuView View { get; set; }
    [Inject] public CellViewCreatedSignal CellViewCreatedSignal { get; set; }
    [Inject] public BlockBoardSignal BlockBoardSignal { get; set; }
    [Inject] public UnblockBoardSignal UnblockBoardSignal { get; set; }
    [Inject] public NextLevelChosenSignal NextLevelChosenSignal { get; set; }
    [Inject] public CreateTowerMenuSignal CreateTowerMenuSignal { get; set; }
    [Inject] public CreateUpgradeMenuSignal CreateUpgradeMenuSignal { get; set; }
    [Inject] public HideSubMenuSignal HideSubMenuSignal { get; set; }
    [Inject] public HideMenuSignal HideMenuSignal { get; set; }
    [Inject] public TowerChosenSignal TowerChosenSignal { get; set; }
    [Inject] public PrepareForShootSignal PrepareForShootSignal { get; set; }

    public override void OnRegister()
    {
        CellViewCreatedSignal.AddListener(SubscribeToCells);
        TowerChosenSignal.AddListener(TowerButtonClickedHandler);
        PrepareForShootSignal.AddListener(ShootButtonClickedHandler);
        HideMenuSignal.AddListener(HideMenuHandler);
    }

    public override void OnRemove()
    {
        CellViewCreatedSignal.RemoveListener(SubscribeToCells);
        TowerChosenSignal.RemoveListener(TowerButtonClickedHandler);
        PrepareForShootSignal.RemoveListener(ShootButtonClickedHandler);
        HideMenuSignal.RemoveListener(HideMenuHandler);
    }
    private void SubscribeToCells(CellView cell)
    {
     //   _cells.Add(cell);
        cell.OnTowerMenuOpen += ShowTowerMenuHandler;
        cell.OnUpgradeMenuOpen += ShowUpgradeMenuHandler;
      //  _subscribedToCells = true;
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
    private void ShootButtonClickedHandler(TowerModel tower)
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
