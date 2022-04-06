using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelParameters_", menuName = "GenerationParameters/LevelData")]
//this creates a custom menu folder called GenerationParameters, and makes it so that the only objects that can be created in the folder are instantiations of this class.

public class LevelSO : ScriptableObject //inherits from Unity's standard ScriptableObject class so that it can behave like one
{
    public int iterations, walkLength;
    public bool startRandomlyEachIteration;
    //attributes are declared here. they can be defined to be unique values in every instantiation of the class.
}
