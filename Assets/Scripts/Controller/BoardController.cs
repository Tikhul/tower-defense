using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BoardController : BoardLibraryModel
{
    /// <summary>
    /// Забрать настройки борда со сцены
    /// </summary>
    /// <param name="board"></param>
    private void GetBoardSettings(BoardScriptableObject board)
    {
        BoardSettings = board;
    }

    /// <summary>
    /// Создание борда для игры
    /// </summary>
    public void CreateBoard()
    {
        BoardPartsPrototype prototype = new StandardPartPrototype();

        GameObject boardPanel = prototype.Clone(prototype.ParentPanel, prototype.BoardParent, 
            prototype.ParentPanelSide, prototype.ParentPanelSide);

        GameObject row = prototype.Clone(prototype.Rows, boardPanel, prototype.ParentPanelSide, prototype.ParentPanelSide);

        for (int r = 0; r < prototype.RowNumber; r++)
        {
            GameObject column = prototype.Clone(prototype.Columns, row, prototype.ButtonWidth, prototype.ParentPanelSide);

            for (int b = 0; b < prototype.RowNumber; b++)
            {
                GameObject button = prototype.Clone(prototype.ButtonExample, column, prototype.ButtonWidth, prototype.ButtonWidth);
                FillCellist(button, b, r);
            }
        }
    }

    /// <summary>
    /// Заполняю список ячеек в борде
    /// </summary>
    /// <param name="button"></param>
    /// <param name="charIndex"></param>
    /// <param name="intIndex"></param>
    public void FillCellist(GameObject button, int charIndex, int intIndex)
    {
        CellView buttonSettings = button.GetComponent<CellView>();
        buttonSettings.CellChar = Alphabet[charIndex];
        buttonSettings.CellInt = intIndex;
        CurrentCellList.Add(buttonSettings);
        AllCellList.Add(buttonSettings);
    }
}
