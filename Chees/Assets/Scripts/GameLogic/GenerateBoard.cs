using System.Collections.Generic;
using UnityEngine;

public class GenerateBoard : MonoBehaviour
{
    private const int X = 8;
    private const int Z = 8;

    [SerializeField] private CheesCells _cells;

    [SerializeField] private Vector3 _currentCellPos = new Vector3(7, 0, 7);
    [SerializeField] private GameObject _pref;
    [SerializeField] private Transform _root;

    private Vector3 _startCellPoss;

    private readonly List<GameObject> _trash = new List<GameObject>();

    private readonly float _xOffset = -1f;
    private readonly float _zOffset = -1f;

    public void ClearBoards()
    {
        _cells.Cells.Clear();
        foreach (var t in _trash) DestroyImmediate(t);
    }

    public void GenerateCells()
    {
        ClearBoards();
        _startCellPoss = _currentCellPos;
        for (var i = 0; i < Z; i++)
        {
            if (i != 0)
                _currentCellPos = new Vector3(_startCellPoss.x, _currentCellPos.y, _currentCellPos.z + _zOffset);

            for (var j = 0; j < X; j++)
            {
                var tempCell = new Cell();
                var c = Instantiate(_pref, _currentCellPos, Quaternion.identity, _root);
                c.name = $"Cell {i} {j}";
                _trash.Add(c);
                tempCell._pos = _currentCellPos;
                _currentCellPos = new Vector3(_currentCellPos.x + _xOffset, _currentCellPos.y, _currentCellPos.z);
                tempCell.X = j;
                tempCell.Z = i;
                _cells.Cells2DArray[i, j] = tempCell;
                _cells.Cells.Add(tempCell);
                _cells.AddedCheesToList();
            }
        }

        _currentCellPos = _startCellPoss;

        SpawnChees();
    }

    private void SpawnChees()
    {
        foreach (var cell in _cells.Cells)
            if (cell._figure != null)
            {
                var obj = Instantiate(cell._figure.Prefab, cell._pos, Quaternion.identity, _root);
                _trash.Add(obj);
            }
    }
}