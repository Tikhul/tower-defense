using strange.extensions.signal.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace context.ui
{
    public class StartSignal : Signal {  }
    public class ShowRestartPanelSignal : Signal { }
    public class NextLevelChosenSignal : Signal { }
    public class RestartLevelChosenSignal : Signal { }
    public class ShowEndPanelSignal : Signal { }
    public class PassLevelDataSignal : Signal<ILevelModel> { }
    public class CellButtonCreatedSignal : Signal<CellButton> { }
    public class BlockBoardSignal : Signal { }
    public class UnblockBoardSignal : Signal { }
    public class ChangePlayerDataSignal : Signal<PlayerModel> { }
    public class CreateTowerMenuSignal : Signal<CellButton> { }
    public class TowerMenuCreatedSignal : Signal<List<TowerView>> { }
    public class CreateUpgradeMenuSignal : Signal<CellButton> { }
    public class UpgradeMenuCreatedSignal : Signal<List<UpgradeConfig>, TowerView> { }
    public class HideMenuSignal : Signal { }
    public class TowerChosenSignal : Signal<TowerButton> { }
    public class TowerBoughtSignal : Signal<TowerButton> { }
    public class UpgradeChosenSignal : Signal<UpgradeButton> { }
    public class ShowTowerDataSignal : Signal<TowerModel> { }
    public class TowerUpgradedSignal : Signal { }
    public class NoMoneySignal : Signal { }
}
