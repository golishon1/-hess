using UnityEngine;

[CreateAssetMenu(fileName = "Config", menuName = "Cheese/Config", order = 0)]
public class CheesConfig : ScriptableObject
{
    [SerializeField] private CheesColorType _type;
    [SerializeField] private Figure[] _figures;

    public CheesColorType Type => _type;

    public Figure[] Figures => _figures;
}