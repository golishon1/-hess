using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CheesCells", menuName = "Cheese/CheesCells", order = 0)]
public class CheesCells : ScriptableObject
{
    [SerializeField] private CheesConfig _white;
    [SerializeField] private CheesConfig _black;

    [SerializeField] private List<Cell> _cells = new List<Cell>();

    public Cell[,] Cells2DArray { get; set; } = new Cell[8, 8];

    public List<Cell> Cells
    {
        get => _cells;
        set => _cells = value;
    }

    public void AddedCheesToList()
    {
        if (_cells == null) return;

        AddCheesFromCoinfig(_black);
        AddCheesFromCoinfig(_white);
    }

    private void AddCheesFromCoinfig(CheesConfig config)
    {
        foreach (var cell in _cells)
        foreach (var b in config.Figures)
        foreach (var coord in b.SpawnCoordinates)
            if (coord.X == cell.X && coord.Z == cell.Z)
                cell._figure = b;
    }
}