using strange.extensions.command.impl;

public class FillCellListCommand : Command
{
    public override void Execute()
    {
        var gameModel = injectionBinder.GetInstance<GameModel>();
        int rowNumber = gameModel.Board.Settings.RowNumber;

        for (int row = 0; row < rowNumber; row++)
        {
            for (int line = 0; line < rowNumber; line++)
            {
                var cellData = new CellData(StaticName.Alphabet[line], row);
                gameModel.Board.CellList.Add(cellData);
            }
        }
    }
}
