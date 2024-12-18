using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask mask;
    private PlayerUI playerUI;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        playerUI = GetComponent<PlayerUI>();
    }

    // Update is called once per frame
    void Update()
    {
        playerUI.UpdateText(string.Empty);  // Clear prompt each frame

        // Set up ray for detecting interactable objects in front of the player
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);

        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            // Check if the object hit by the ray is interactable
            Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                // Display the prompt message
                playerUI.UpdateText(interactable.promptMessage);

                // Check for left mouse click to interact
                if (Input.GetMouseButtonDown(0))
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
