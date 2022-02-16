using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapVisualizer : MonoBehaviour
{
    //[SerializeField]
    //private Tilemap tilemap;
    [SerializeField]
    private Tilemap tilemap;
    [SerializeField]
    private TileBase floorTile;
    [SerializeField]
    private TileBase wallTop;

    //Paint correct tiles onto identified positions
    public void PaintFloorTiles(IEnumerable<Vector2Int> floorPositions)
    {
        PaintTiles(floorPositions, tilemap, floorTile);
    }

    private void PaintTiles(IEnumerable<Vector2Int> positions, Tilemap tilemap, TileBase tile)
    {
        foreach (var position in positions)
        {
            PaintSingleTile(tilemap, tile, position);
        }
    }

    internal void PaintSingleBasicWall(Vector2Int position)
    {
        PaintSingleTile(tilemap, wallTop, position);
    }

    private void PaintSingleTile(Tilemap tilemap, TileBase tile, Vector2Int position)
    {
        var tilePosition = tilemap.WorldToCell((Vector3Int)position);
        tilemap.SetTile(tilePosition, tile);
    }

    //Clear tiles so that generated levels are unique and are not generated on itself
    public void Clear()
    {
        tilemap.ClearAllTiles();
        //tilemap.ClearAllTiles();
    }
}
