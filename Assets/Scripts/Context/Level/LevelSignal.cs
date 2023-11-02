using strange.extensions.signal.impl;
using UnityEngine;

namespace context.level
{
    public class StartSignal : Signal { }
    public class PipelineStartSignal : Signal { }
    public class PipelineEndedSignal : Signal { }
    public class LevelEndedSignal : Signal { }
    public class DefineEnemyWaySignal : Signal { }
    public class WaveEndedSignal : Signal { }
    public class ActivateWaveSignal : Signal { }
    public class EnemyWayCompletedSignal : Signal<EnemyView> { }
    public class BulletHitEnemySignal : Signal<int, EnemyView> { }
    public class StartShootingSignal : Signal { }
    public class RenewTowerDataSignal : Signal { }
    public class EnemyDestroyedSignal : Signal<EnemyView> { }
}
