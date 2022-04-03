using System.Collections;
using System.Collections.Generic;
using UnityEngine; //three generic unity libraries that any project would benefit from using, or in the case of UnityEngine, and game would HAVE to use

public static class ProceduralGenerationAlgorithms
{
    public static HashSet<Vector2Int> RandomWalkLevel(Vector2Int startPosition, int walkLength)
    {
        //Generate each iteration of the floor positions
        HashSet<Vector2Int> path = new HashSet<Vector2Int>(); //Create Hashset to stored generated floor positions

        path.Add(startPosition); //add (0, 0) to floor positions. Since startPosition is a constant, it means that it will always be a floor position
        var previousposition = startPosition;

        for (int i = 0; i < walkLength; i++)
        {
            var newPosition = previousposition + Direction2D.GetRandomDirection(); //add random coordinate move to previous position each time, starting with (0, 0)
            path.Add(newPosition); //add new position to Hashset
            previousposition = newPosition; //update previous position to be the most recently generated floor position, so that the next iteration starts from there.
        } //the for loop repeats the process as many times as specified by walkLength in the SimplieRandomWalkSO scriptable object
        return path; //returns the generated floor positions
    }

    public static List<Vector2Int> RandomWalkCorridor(Vector2Int startPosition, int corridorLength)
    {
        List<Vector2Int> corridor = new List<Vector2Int>(); //create Hashset to stored generated floor positions
        var direction = Direction2D.GetRandomDirection(); //GetRandomDirection() returns a random coordinate move and it is stored in a variable
        var currentPosition = startPosition; //the start position is stored in a currentPosition variable so that the correct start position can be used,
                                             //and so that the startPosition constant is not changed during runtime
        corridor.Add(currentPosition); //the start position will always be the first floor position, therefore it is added to the Hashset.

        for (int i = 0; i < corridorLength; i++) //This loops for the number specified by the corridorLength variable in the CorridorSO scriptable object
        {
            currentPosition += direction; //Add the same coordinate move to currentPosition every time it loops to create the straight corridor line required
            corridor.Add(currentPosition); //add the generated floor position to the Hashset

        }
        return corridor; //returns generated corridor positions
    }
}

public static class Direction2D
{
    public static List<Vector2Int> DirectionsList = new List<Vector2Int> //declare list that will stored four compass direction moves
    {
        new Vector2Int(0, 1), //UP
        new Vector2Int(1, 0), //RIGHT
        new Vector2Int(0, -1), //DOWN
        new Vector2Int(-1, 0), //LEFT
    };

    public static Vector2Int GetRandomDirection() //function to return a random compass direction that is called during procedural generation
    {
        return DirectionsList[Random.Range(0, DirectionsList.Count)]; //returns the element in the list at a random index between 0 and 3
    }   
}