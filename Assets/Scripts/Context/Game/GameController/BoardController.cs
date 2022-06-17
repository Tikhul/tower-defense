using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardController
{
    //public void DrawBoard()
    //{
    //    BoardPartsPrototype prototype = new StandardPartPrototype();

    //    GameObject boardPanel = prototype.Clone(prototype.ParentPanel, prototype.BoardParent,
    //        prototype.ParentPanelSide, prototype.ParentPanelSide);

    //    GameObject row = prototype.Clone(prototype.Rows, boardPanel, prototype.ParentPanelSide, prototype.ParentPanelSide);

    //    for (int r = 0; r < prototype.RowNumber; r++)
    //    {
    //        GameObject column = prototype.Clone(prototype.Columns, row, prototype.ButtonWidth, prototype.ParentPanelSide);

    //        for (int b = 0; b < prototype.RowNumber; b++)
    //        {
    //            GameObject button = prototype.Clone(prototype.ButtonExample, column, prototype.ButtonWidth, prototype.ButtonWidth);
    //            FillCellist(button, b, r);
    //        }
    //    }
    //}

    private void FillCellist(GameObject button, int b, int r)
    // «аполн€ю список €чеек в борде
    {
        CellButton buttonSettings = button.GetComponent<CellButton>();
        //buttonSettings.CellChar = StaticName.Alphabet[b];
        //buttonSettings.CellInt = r;
        //Game.TicTacToeModel.BoardModel.CurrentCellList.Add(buttonSettings);
        //Game.TicTacToeModel.BoardModel.AllCellList.Add(buttonSettings);
    }
}
