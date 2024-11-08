using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks; 

public class WinstonAnywhere : Interactable, Dialoguer

{
    private GameObject player; // Reference to the player object
    public Sprite dialogueIcon;
    private InputManager playerIM; // Reference to the player's input manager
    private GameObject ChatObject;
    private GameObject GameMasterObject;  
    private LLMHandler LLM;
    private GameMaster GM;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerIM = player.GetComponent<InputManager>();

        ChatObject = GameObject.FindGameObjectWithTag("LLMObj");
        LLM = ChatObject.GetComponent<LLMHandler>();
        
        GameMasterObject = GameObject.FindGameObjectWithTag("GameMasterObj");
        GM = GameMasterObject.GetComponent<GameMaster>();
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
    return GetDialogueAsync().Result;
}

public async Task<List<DialogueItem>> GetDialogueAsync()
{
    string GameContext = GM.GenerateGameContext(); //Get Game context from GM
 
    var WinstonMessage = await LLM.SendMessageToWinston(GameContext);
    string Message = WinstonMessage;
    UnityEngine.Debug.Log(Message);

    return new List<DialogueItem>()
    {
        new DialogueItem() { name = "Prof. Winston", picture = dialogueIcon },
        new DialogueItem() { text = "Hello! My name is professor Winston" },
        new DialogueItem() { text = "What can I help you with today?" },
        new DialogueItem() { text = Message},
        new DialogueItem() { action = () => { playerIM.playerCanMove = true; } }
    };
}

}
