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
    public class DrawEnemyWaySignal : Signal { }
    public class OnEnemyWayDefinedSignal : Signal { }
    public class CreateEnemiesSignal : Signal { }
}
