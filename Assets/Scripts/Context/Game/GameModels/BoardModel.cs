using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardModel
{
    public int RowNumber { get; } 
    public BoardModel (BoardSO settings)
    {
        RowNumber = settings.RowNumber;
    }
}
