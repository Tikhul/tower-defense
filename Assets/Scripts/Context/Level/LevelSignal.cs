using strange.extensions.signal.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawBoardSignal : Signal<GameObject> { }
public class FillCellListSignal : Signal<GameObject, char, int> { }