using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardModel
{
    public BoardSO Settings { get; } 
    public BoardModel (BoardSO settings)
    {
        Settings = settings;
    }
}
