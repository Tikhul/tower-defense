using strange.extensions.signal.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelContextSignal : Signal { }
public class LevelContextLoadedSignal : Signal { }
public class PlayerCreatedSignal : Signal<PlayerModel> { }
public class BoardCreatedSignal : Signal<BoardModel> { }
public class GameCreatedSignal : Signal<GameModel> { }
