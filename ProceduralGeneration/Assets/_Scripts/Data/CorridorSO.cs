using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CorridorParameters_", menuName = "PCG/CorridorData")]

public class CorridorSO : ScriptableObject
{
    public int corridorLength = 14;
    public int corridorCount = 5;
    [Range(0.1f, 1)] public float roomPercent = 0.8f;
}
