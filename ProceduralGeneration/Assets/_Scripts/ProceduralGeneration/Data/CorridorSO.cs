using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CorridorParameters_", menuName = "GenerationParameters/CorridorData")]
//this creates a custom menu folder called GenerationParameters, and makes it so that the only objects that can be created in the folder are instantiations of this class.
public class CorridorSO : ScriptableObject ////inherits from Unity's standard ScriptableObject class so that it can behave like one
{
    public int corridorLength;
    public int corridorCount;
    [Range(0.1f, 1)] public float roomPercent;
    //attributes are declared here. they can be defined to be unique values in every instantiation of the class.

}
