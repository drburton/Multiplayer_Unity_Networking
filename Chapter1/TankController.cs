using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankController : MonoBehaviour {
   
    public CharacterController controller; 
    public float moveSpeed = 5f; // Speed of player movement
    public float sensitivity = 20f; // Mouse sensitivity for rotation
    Vector3 velocity; // Current velocity of the player

    InputAction movement; // InputAction for player movement
    InputAction mouseLook; // InputAction for mouse look

    void Start()
    {
        // Create the movement InputAction and define its bindings
        movement = new InputAction("PlayerMovement", binding: "<Gamepad>/leftStick");
        // Add composite bindings for WASD/Arrow keys and D-pad on gamepad
        movement.AddCompositeBinding("Dpad")
            .With("Up", "<Keyboard>/w")
            .With("Up", "<Keyboard>/upArrow")
            .With("Down", "<Keyboard>/s")
            .With("Down", "<Keyboard>/downArrow")
            .With("Left", "<Keyboard>/a")
            .With("Left", "<Keyboard>/leftArrow")
            .With("Right", "<Keyboard>/d")
            .With("Right", "<Keyboard>/rightArrow");
        movement.Enable(); // Enable the movement InputAction
        
        // Create the mouse look InputAction
        mouseLook = new InputAction("MouseLook", binding: "mouse/delta");
        mouseLook.Enable(); // Enable the mouse look InputAction
    }

    private void FixedUpdate()
    {
        float x;
        float y;

        // Read the movement input value as a Vector2
        var delta = movement.ReadValue<Vector2>();
        x = delta.x;
        y = delta.y;

        // Calculate the movement direction based on player's local space
        Vector3 move = transform.right * x + transform.forward * y;

        // Check if there is movement input
        if (move != Vector3.zero)
        {
            // Move the character using CharacterController
            controller.Move(move * moveSpeed * Time.deltaTime);
        }

        // Read the mouse look input value as a Vector2
        var mouseDelta = mouseLook.ReadValue<Vector2>();
        float mouseX = mouseDelta.x * sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * mouseX); // Apply horizontal rotation

        // Move the controller using the stored velocity to simulate gravity, etc.
        controller.Move(velocity * Time.deltaTime);
    }
}


