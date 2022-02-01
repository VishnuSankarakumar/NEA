//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;
//using Random = UnityEngine.Random;

//public class SimpleRandomWalkDungeonGenerator: CorridorFirstDungeonGenerator
//{
//    //[SerializeField]
//    //protected SimpleRandomWalkSO randomWalkParameters;    

//    //protected override void RunProceduralGeneration()
//    //{
//    //    //runs generation function, runs procedures to paint floor tiles, runs function to identify wall positions and procedure to paint wall positions
//    //    HashSet<Vector2Int> floorPositions = RunRandomWalk(randomWalkParameters, startPosition);
//    //    tileMapVisualizer.Clear();
//    //    tileMapVisualizer.PaintFloorTiles(floorPositions);
//    //    WallGenerator.CreateWalls(floorPositions, tileMapVisualizer);
//    //}

//    protected HashSet<Vector2Int> RunRandomWalk(SimpleRandomWalkSO parameters, Vector2Int position)
//    {
//        //Generate iterations of floor positions 
//        var currentPosition = position;
//        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
//        for (int i = 0; i < parameters.iterations; i++)
//        {
//            var path = ProceduralGenerationAlgorithms.SimpleRandomWalk(currentPosition, parameters.walkLength);
//            floorPositions.UnionWith(path);
//            if (parameters.startRandomlyEachIteration)
//                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count));
//        }
//        return floorPositions;
//    }

//}

