using strange.extensions.signal.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameContextSignal : Signal { }
public class GameContextLoadedSignal : Signal { }
public class ShowRestartPanelSignal : Signal { }
public class NextLevelChosenSignal : Signal { }
public class RestartLevelChosenSignal : Signal { }
public class ShowEndPanelSignal : Signal { }
public class PassLevelDataSignal : Signal<ILevelModel> { }
public class CellButtonCreatedSignal : Signal<CellButton> { }
public class BlockBoardSignal : Signal { }
public class UnblockBoardSignal : Signal { }
public class ChangePlayerDataSignal : Signal<PlayerModel> { }