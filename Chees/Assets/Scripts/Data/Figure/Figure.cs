using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Figure",menuName = "Cheese/Figure")]
public class Figure : ScriptableObject
{
   
   [SerializeField] private GameObject _prefab;
   [SerializeField] private CheesType _type;
   [SerializeField] private SpawnCoordinate[] _spawnCoordinates;
   public GameObject Prefab => _prefab;
   public CheesType Type => _type;

   public SpawnCoordinate[] SpawnCoordinates => _spawnCoordinates;
}
[Serializable]
public struct SpawnCoordinate
{
   public int X;
   public int Z;
   
}