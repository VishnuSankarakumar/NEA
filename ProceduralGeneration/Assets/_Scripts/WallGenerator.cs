using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
    //Places walls in the wall positions identified
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TileMapVisualizer tileMapVisualizer)
    {
        var basicWallPositions = FindWallsInDirections(floorPositions, Direction2D.cardinalDirectionsList);
        foreach (var position in basicWallPositions)
        {
            tileMapVisualizer.PaintSingleBasicWall(position);
        }
    }
    //Identifies wall positions
    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach (var position in floorPositions)
        {
            foreach (var direction in directionList)
            {
                var neighbourPosition = position + direction;
                if(floorPositions.Contains(neighbourPosition) == false)
                    wallPositions.Add(neighbourPosition);
            }
        }
        return wallPositions;
    }
}
