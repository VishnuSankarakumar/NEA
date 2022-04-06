using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator //class will not be instantiated so it is declared static
{
    private static HashSet<Vector2Int> FindWalls(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList)
    //this function identifies wall positions by checking if neighbours of every floor position generated are also in the gnerated floor positions Hashset. 
    //if a neighbour is not in the Hashset, then that means that a wall can be placed there.
    {
        HashSet<Vector2Int> wallPositions = new HashSet<Vector2Int>();
        foreach (var position in floorPositions)
        {
            foreach (var direction in directionList)
            {
                var neighbourPosition = position + direction;
                if (floorPositions.Contains(neighbourPosition) == false)
                    wallPositions.Add(neighbourPosition);
            }
        }
        return wallPositions;
    }

    //Places walls in the wall positions identified
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TileMapVisualizer tileMapVisualizer) //declared void as it is a procedure not a function
    {
        var basicWallPositions = FindWalls(floorPositions, Direction2D.DirectionsList); //calls the function that finds walls to identify all of the wall positions in this specific generated map
        foreach (var position in basicWallPositions) //after the walls are identified, a wall sprite is painted at every identified position
        {
            tileMapVisualizer.PaintSingleWall(position); //this is a function from the TileMapVisualizer script. it will paint a wall tile in every position that is passed into it
            tileMapVisualizer.PaintTransparentWall(position);
        }
    }    
}
