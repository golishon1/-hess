using UnityEngine;

public class CellGame : MonoBehaviour
{
    [SerializeField] private CellGameInfo _cellGameInfo;
}

public class CellGameInfo
{
    public int idX = 1;
    public int idZ = 1;
    public bool isLocked = false;
}