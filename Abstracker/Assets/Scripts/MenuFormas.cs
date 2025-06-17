using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class MenuFormas : MonoBehaviour
{
    public float startXPosition = 38; // Initial X position (what it moves to on Start)
    public float clickedXPosition = 15; // X position after button click

    void Start()
    {
        // Set the initial position when the game starts
        Vector3 currentPosition = transform.position;
        currentPosition.x = startXPosition;
        transform.position = currentPosition;
    }

    // This method will be called when the button is clicked
    public void Click()
    {
        Vector3 currentPosition = transform.position; // Get current position
        currentPosition.x = clickedXPosition;      // Set the X component to the desired clicked position
        transform.position = currentPosition;        // Apply the new position
    }
}