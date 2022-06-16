using strange.extensions.signal.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSignal : Signal { }
public class CreatePlayerLibrarySignal : Signal { }
public class PlayerLibraryCreatedSignal : Signal<PlayerSO> { }
public class CreateBoardLibrarySignal : Signal { }
public class BoardLibraryCreatedSignal : Signal<BoardSO> { }
public class UIContextLoadedSignal : Signal { }

