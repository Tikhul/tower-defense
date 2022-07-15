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
    public class DefineEnemyWaySignal : Signal { }
    public class OnEnemyWayDefinedSignal : Signal { }
    public class ActivateEnemySignal : Signal<string, EnemyModel> { }
    public class EnemyActivatedSignal : Signal { }
}
