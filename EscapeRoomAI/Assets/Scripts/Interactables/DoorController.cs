using UnityEngine;

public class DoorController : Interactable
{
    private Animator animator;
    private bool isOpen = false;
    private bool isUnlocked = false;

    public PuzzleButton[] buttonSequence; // Array to hold the buttons in the correct order
    private int currentButtonIndex = 0; // Tracks which button in the sequence should be pressed next

    void Start()
    {
        animator = GetComponent<Animator>();
        promptMessage = "Solve the puzzle to open the door";
    }

    protected override void Interact()
    {
        if (isUnlocked)
        {
            isOpen = !isOpen;
            animator.SetBool("isOpen", isOpen);
        }
        else
        {
            Debug.Log("The door is locked. Solve the puzzle to unlock it.");
        }
    }

    public void VerifyButtonOrder(PuzzleButton button)
    {
        // Check if the button pressed is the correct one in the sequence
        if (buttonSequence[currentButtonIndex] == button)
        {
            currentButtonIndex++; // Move to the next button in the sequence

            // If we've reached the end of the sequence, unlock the door
            if (currentButtonIndex >= buttonSequence.Length)
            {
                isUnlocked = true;
                Debug.Log("Puzzle solved! The door is now unlocked.");
            }
        }
        else
        {
            // Reset the sequence if the wrong button is pressed
            Debug.Log("Wrong button! Resetting the puzzle.");
            currentButtonIndex = 0;
            ResetButtons();
        }
    }

    private void ResetButtons()
    {
        // Reset each button's pressed state
        foreach (var button in buttonSequence)
        {
            button.ResetButton();
        }
    }
}
