using UnityEngine;

public class DoorController : Interactable
{
    private Animator animator;
    private bool isOpen = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        promptMessage = "Press to open/close the door";
    }

    protected override void Interact()
    {
        // Toggle the door open/close state
        isOpen = !isOpen;
        animator.SetBool("isOpen", isOpen);
    }
}
