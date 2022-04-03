using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractClass : MonoBehaviour
{
    [SerializeField]
    protected TileMapVisualizer tileMapVisualizer = null;
    [SerializeField]
    protected Vector2Int startPosition = Vector2Int.zero;
    public void GenerateDungeon()
    {
        tileMapVisualizer.Clear();
        RunProceduralGeneration();
    }

    protected abstract void RunProceduralGeneration();
    //By declaring an abstract method here and overriding the corresponding RunProceduralGeneration() method in the child class CorridorFirstGeneration, essentially, the parent class is calling a method in its child class.
}

