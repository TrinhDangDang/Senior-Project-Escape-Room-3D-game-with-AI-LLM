using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public ArrayList gameState; 
    public int currentRoom;
    public string[] puzzleStates;
    public string[] puzzles;
    public string contextCache;

    // Start is called before the first frame update
    void Start()
    {
        gameState = new ArrayList();
        currentRoom = 0;
      //  PuzzleStates = {"puzzle 1","puzzle 2","puzzle 3"};
        contextCache = "The player is in the Starting room and no puzzles have been solved";

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateGameContext() 
    {
    
    
    
    }


    void UpdateGameState(int puzzleCode)
    {
        gameState.Add(puzzles[puzzleCode]);

    }



}
