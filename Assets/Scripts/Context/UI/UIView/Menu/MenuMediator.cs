using context.ui;
using strange.extensions.mediation.impl;
using System.Collections.Generic;

public class MenuMediator : Mediator
{
    private List<CellButtonView> _cells = new List<CellButtonView>();
    
    private bool _subscribedToCells = false;
    
    [Inject] public MenuView View { get; set; }
    [Inject] public CellButtonViewCreatedSignal CellButtonViewCreatedSignal { get; set; }
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
        CellButtonViewCreatedSignal.AddListener(SubscribeToCells);
        TowerChosenSignal.AddListener(TowerButtonClickedHandler);
        PrepareForShootSignal.AddListener(ShootButtonClickedHandler);
        HideMenuSignal.AddListener(HideMenuHandler);
    }

    public override void OnRemove()
    {
        CellButtonViewCreatedSignal.RemoveListener(SubscribeToCells);
        TowerChosenSignal.RemoveListener(TowerButtonClickedHandler);
        PrepareForShootSignal.RemoveListener(ShootButtonClickedHandler);
        HideMenuSignal.RemoveListener(HideMenuHandler);
    }
    private void SubscribeToCells(CellButtonView cell)
    {
        _cells.Add(cell);
        cell.OnCellButtonViewClick += ShowMenu;
        _subscribedToCells = true;
    }

    private void ShowMenu(CellButtonView receivedCell)
    {
        BlockBoardSignal.Dispatch();

        if (receivedCell.State.Equals(CellState.Empty))
        {
            CreateTowerMenuSignal.Dispatch(receivedCell);
        }
        else if (receivedCell.State.Equals(CellState.HasTower))
        {
            CreateUpgradeMenuSignal.Dispatch(receivedCell);
        }

        View.Show();
        View.OnCloseMenu += HideMenuHandler;

        foreach (var cell in _cells)
        {
            cell.OnCellButtonViewClick -= ShowMenu;
            _subscribedToCells = false;
        }
    }
    private void TowerButtonClickedHandler(TowerButtonView button)
    {
        HideMenuHandler();
    }
    private void ShootButtonClickedHandler(TowerModel _tower)
    {
        HideMenuHandler();
    }
    private void HideMenuHandler()
    {
        UnblockBoardSignal.Dispatch();
        HideMenu();
        View.OnCloseMenu -= HideMenuHandler;
        if (!_subscribedToCells)
        {
            foreach (var cell in _cells)
            {
                cell.OnCellButtonViewClick += ShowMenu;
                _subscribedToCells = true;
            }
        }
        HideSubMenuSignal.Dispatch();
    }

    private void HideMenu()
    {
        View.Hide();
    }
}
