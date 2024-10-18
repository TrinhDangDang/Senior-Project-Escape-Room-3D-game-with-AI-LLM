using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinstonAnywhere : Interactable, Dialoguer

{
    private GameObject player; // reference to the player object
    public Sprite dialogueIcon;
    private InputManager playerIM; // reference to the player object
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerIM = player.GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        // set playerCanMove to false, complete talking interaction, then set it back to true 
        if (playerIM.playerCanMove){
            playerIM.playerCanMove = false;
            Dialogue.OpenDialogue(this);
        }
    }
    private void Talk(string str)
    {
        Debug.Log(str);
    }

    public List<DialogueItem> getDialogue()
    {
        return new List<DialogueItem>(){
                new DialogueItem(){name="Prof. Winston", picture=dialogueIcon},
                new DialogueItem(){text="Hello! My name is professor Winston"},
                new DialogueItem(){text="What can I help you with today?"},
                new DialogueItem(){text="ABRAKADABRA!", action=()=>{Talk(player.name+ " performed action talking with: "+ gameObject.name);}},
                new DialogueItem(){text="I just did magic to write to your Console Log"},
                new DialogueItem(){text="To solve the puzzles, you must use your own intelligence... mine is artificial!"},
                new DialogueItem(){action=()=>{playerIM.playerCanMove = true;}}
                };
    }
}
