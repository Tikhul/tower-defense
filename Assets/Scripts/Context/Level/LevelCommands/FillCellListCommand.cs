using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillCellListCommand : Command
{
    [Inject] public GameModel GameModel { get; set; }
    [Inject] public FillCellListSignal FillCellListSignal { get; set; }
    [Inject] public GameObject Button { get; set; }
    [Inject] public char Char { get; set; }
    [Inject] public int Int { get; set; }
    public override void Execute()
    {
        CellButton buttonSettings = Button.GetComponent<CellButton>();
        buttonSettings.CellChar = Char;
        buttonSettings.CellInt = Int;
        GameModel.Board.CurrentCellList.Add(buttonSettings);
        GameModel.Board.AllCellList.Add(buttonSettings);
        Debug.Log(Char.ToString() + Int.ToString());
    }
}
