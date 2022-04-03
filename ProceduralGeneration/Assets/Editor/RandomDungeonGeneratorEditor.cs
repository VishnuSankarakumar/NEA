using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AbstractClass), true)]

public class RandomDungeonGeneratorEditor : Editor
{
    AbstractClass generator;

    private void Awake() //awake() initialises variables on startup
    {
        generator = (AbstractClass)target; //this allows the button to call CompleteDungeonGenerator
    }

    public override void OnInspectorGUI() //standard base class method used to create cutom editors
    {
        base.OnInspectorGUI(); //calls the method from unity's base class
        if(GUILayout.Button("Create Dungeon")) 
        {
            generator.GenerateDungeon(); //specifies what method is called when the butotn is clicked
        }
    }
}

