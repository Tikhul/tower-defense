using System.Collections.Generic;

public class BoardModel
{
    private List<CellData> _cellList = new List<CellData>();
    public BoardConfig Settings { get; set; }

    public void Initialize (BoardConfig settings)
    {
        Settings = settings;
    }
    
    public List<CellData> CellList
    {
        get => _cellList;
        set => _cellList = value;
    }
}

public class CellData
{
    public char Char { get; set; }
    public int Int { get; set; }

    public CellData(char c, int i)
    {
        Char = c;
        Int = i;
    }
}