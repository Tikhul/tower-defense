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
    public class PassTowersDictionarySignal : Signal<Dictionary<TowerView, TowerModel>> { }
    public class CellButtonViewCreatedSignal : Signal<CellButtonView> { }
    public class BlockBoardSignal : Signal { }
    public class UnblockBoardSignal : Signal { }
    public class ChangePlayerDataSignal : Signal<PlayerModel> { }
    public class CreateTowerMenuSignal : Signal<CellButtonView> { }
    public class TowerMenuCreatedSignal : Signal<List<TowerView>> { }
    public class CreateUpgradeMenuSignal : Signal<CellButtonView> { }
    public class UpgradeMenuCreatedSignal : Signal<List<UpgradeConfig>, TowerView> { }
    public class HideMenuSignal : Signal { }
    public class HideSubMenuSignal : Signal { }
    public class TowerChosenSignal : Signal<TowerButtonView> { }
    public class TowerBoughtSignal : Signal { }
    public class UpgradeChosenSignal : Signal<UpgradeButtonView> { }
    public class ShowTowerDataSignal : Signal<TowerModel> { }
    public class NoMoneySignal : Signal { }
    public class PrepareForShootSignal : Signal<TowerModel> { }
    public class BlockShootButtonSignal : Signal { }
    public class UnBlockShootButtonSignal : Signal { }
}
