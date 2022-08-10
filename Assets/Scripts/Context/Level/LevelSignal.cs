using strange.extensions.signal.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace context.level
{
    public class StartSignal : Signal { }
    public class DrawBoardSignal : Signal<GameObject> { }
    public class FillCellListSignal : Signal<GameObject, char, int> { }
    public class PipelineStartSignal : Signal { }
    public class PipelineEndedSignal : Signal { }
    public class LevelEndedSignal : Signal { }
    public class DefineEnemyWaySignal : Signal { }
    public class OnEnemyWayDefinedSignal : Signal { }
    public class WaveEndedSignal : Signal { }
    public class ActivateWaveSignal : Signal { }
    public class ChangePlayerHealthSignal : Signal<int> { }
    public class ChangeEnemyHealthSignal : Signal<int, EnemyView> { }
    public class PrepareForShootSignal : Signal<TowerModel, TowerView> { }
    public class ReadyToShootSignal : Signal<Vector3, TowerModel> { }
    public class RenewTowerDataSignal : Signal { }
}
