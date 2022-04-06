using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapVisualizer : MonoBehaviour
{
    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private Tilemap wallTilemap;
    [SerializeField]
    private TileBase floorTile;
    [SerializeField]
    private TileBase transparentTile;
    [SerializeField]
    private TileBase wallTop;

    //All of these fields are serialized so that they can be edited directly in the Unity Editor

    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions) //similar to the other procedures where this was done - this is the one public method used to call the other private methods in this class to enforce information hiding
    {
        PaintTiles(floorPositions, tilemap, floorTile);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions) //paints a single tile at every position passed in
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position) //paints a single floor tile at the position passed in as a parameter
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position); //worldtocell converts the three dimensional world position in the Unity scene to a 2D coordinate on the tilemap
        tilemap.SetTile(tilePosition, tile); //this actually paints the tile
    }
    
    internal void PaintSingleWall(Vector2Int position)
    {
        PaintSingleTile(tilemap, wallTop, position); //paints a wall at every wall position passed in
    }
    internal void PaintTransparentWall(Vector2Int position)
    {
        PaintSingleTile(wallTilemap, transparentTile, position); //paints a wall at every wall position passed in
    }

    //Clear tiles so that generated levels are unique and are not generated previous versions of themselves
    public void Clear()
    {
        tilemap.ClearAllTiles();
        wallTilemap.ClearAllTiles();
    }
}
