using context.ui;
using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��������, ���������� �� ����� �� ������� ��������
/// </summary>
public class CheckMoneyForUpgradeCommand : Command
{
    [Inject] public UpgradeButtonView UpgradeButtonView { get; set; }
    private GameModel GameModel => injectionBinder.GetInstance<GameModel>();

    public override void Execute()
    {
        if (UpgradeButtonView.UpgradeConfig.Cost > GameModel.Player.ActualCoins)
        {
            Debug.Log("������������ �����");
            injectionBinder.GetInstance<NoMoneySignal>().Dispatch();
            Fail();
        }
        else
        {
            GameModel.Player.ActualCoins -= UpgradeButtonView.UpgradeConfig.Cost;
            injectionBinder.GetInstance<ChangePlayerDataSignal>().Dispatch(GameModel.Player);
            injectionBinder.GetInstance<TowerBoughtSignal>().Dispatch();
        }
    }
}
