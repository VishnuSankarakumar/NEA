using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq; //LINQ statements allow me to iterate through Hashsets temporarily. Importing System/Linq is easier than converting the entire Hashset to a List just for a single line.
using UnityEngine;
using Random = UnityEngine.Random;

public class CompleteDungeonGenerator : AbstractClass
{
    [SerializeField] protected CorridorSO CorridorParameters;
    [SerializeField] protected LevelSO randomWalkParameters;
    //these two are the two scriptable objects holding all the parameters for generation of both corridors and levels. They are called instead of the parameter variables themselves.

    protected override void RunProceduralGeneration() //only this procedure is public so that information hiding principles are maintained
    {
        MapGeneration();
    }

    private void MapGeneration()
    {
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>();
        HashSet<Vector2Int> potentialRoomPositions = new HashSet<Vector2Int>();

        CreateCorridors(floorPositions, potentialRoomPositions, CorridorParameters); //a network of corridors is created. no rooms exist at this point in the code, but potential room positions have been identified

        HashSet<Vector2Int> roomPositions = CreateRooms(potentialRoomPositions, CorridorParameters); //floor positions are created at a percentage of identified potential room positions AKA corridor junctions

        List<Vector2Int> deadEnds = FindAllDeadEnds(floorPositions); //identifies and returns all dead ends that remain in the map

        CreateRoomsAtDeadEnds(deadEnds, roomPositions); //generates floor coordinates for rooms at every identified dead end

        floorPositions.UnionWith(roomPositions); //generated floor positions are appended to the main floor positions Hashset

        tileMapVisualizer.PaintFloorTiles(floorPositions); //calls Visualizer functions to place rule tiles at all generated floor positions

        WallGenerator.CreateWalls(floorPositions, tileMapVisualizer); //calls function to identify every wall position in the map created
    }

    private void CreateRoomsAtDeadEnds(List<Vector2Int> deadEnds, HashSet<Vector2Int> roomFloors) //generates room floor positions at every identified floor position
    {
        foreach (var position in deadEnds)
        {
            if (roomFloors.Contains(position) == false) //this if statement is to make sure rooms arent created at positions where rooms have already been created
            {
                var room = RunRandomWalk(randomWalkParameters, position); // coordinates for a room is created at the start position
                roomFloors.UnionWith(room);
            }
        }
    }

    private List<Vector2Int> FindAllDeadEnds(HashSet<Vector2Int> floorPositions)
    {
        List<Vector2Int> deadEnds = new List<Vector2Int>(); //this Hashset will contain all identified dead ends
        foreach (var position in floorPositions)
        {
            int neighboursCount = 0; //this counter is initialised to be 0 every time this loops, so that every position initially has 0 neighbours
            foreach (var direction in Direction2D.DirectionsList) //the random direction function is called from the Direction2D class.
            {
                if (floorPositions.Contains(position + direction))
                    neighboursCount++; //if the floor position has a neighbour in this direction then neighboursCount is incremented
            }
            if (neighboursCount == 1) //if a floor position has only one neighbour, it means that it is at the end of a corridor. Therefore it has been identified as a dead end
                deadEnds.Add(position);
        }
        return deadEnds;
    }

    private HashSet<Vector2Int> CreateRooms(HashSet<Vector2Int> potentialRoomPositions, CorridorSO corridorParameters) //generates floor coordinates for rooms at a set percentage of identified corridor junctions
    {
        HashSet<Vector2Int> roomPositions = new HashSet<Vector2Int>(); //new Hashset that will contain the start position of every room
        int roomsToCreateCount = Mathf.RoundToInt(potentialRoomPositions.Count * corridorParameters.roomPercent); //this calculates the number of corridor junctions at which rooms will be created

        List<Vector2Int> roomsToCreate = potentialRoomPositions.OrderBy(x => Guid.NewGuid()).Take(roomsToCreateCount).ToList(); //takes roomsToCreateCount number of random positions from the potential start positions list

        foreach (var roomPosition in roomsToCreate) //this runs the generation algorithm to generate a room at every start position identified
        {
            var roomFloor = RunRandomWalk(randomWalkParameters, roomPosition); //roomFloor is a Hashset containing the floor positions generated at each start position
            roomPositions.UnionWith(roomFloor); //the generated floor positions in the roomFloor Hashset is appended to the main list of floor position every time this loops
        }
        return roomPositions;
    }

    private void CreateCorridors(HashSet<Vector2Int> floorPositions, HashSet<Vector2Int> potentialRoomPositions, CorridorSO corridorParameters)
    {
        var currentPosition = startPosition;
        potentialRoomPositions.Add(currentPosition); //adds the starting position to the Hashset of floor positions, since it will always be a floor position

        for (int i = 0; i < corridorParameters.corridorCount; i++)
        {
            var path = ProceduralGenerationAlgorithms.RandomWalkCorridor(currentPosition, corridorParameters.corridorLength); //calls RandomWalkCorridor function from the ProceduralGenerationAlgorithms script
            currentPosition = path[path.Count - 1]; //the starting position for each consecutive new position wil be the end of the last generated corridor
            potentialRoomPositions.Add(currentPosition);
            floorPositions.UnionWith(path); //appends generated floor positions to the main floor positions Hashset

        }
    }

    protected HashSet<Vector2Int> RunRandomWalk(LevelSO parameters, Vector2Int position) //iterates the random walk algorithm repeatedly to create the level shape required
    {
        var currentPosition = position;
        HashSet<Vector2Int> floorPositions = new HashSet<Vector2Int>(); //the floor positions generated by each iteration is added to this Hashset.
        for (int i = 0; i < parameters.iterations; i++)
        {
            var path = ProceduralGenerationAlgorithms.RandomWalkLevel(currentPosition, parameters.walkLength);
            floorPositions.UnionWith(path); //the new floor positions created by each iterations are then appended to the main floor positions Hashset
            if (parameters.startRandomlyEachIteration) //if this boolean value is true then the starting position of each iteration will be random.
                currentPosition = floorPositions.ElementAt(Random.Range(0, floorPositions.Count)); //this chooses a random position from the Hashset of floor positions
        }
        return floorPositions;
    }
}
