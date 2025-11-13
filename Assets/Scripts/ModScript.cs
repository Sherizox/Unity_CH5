using System;
using UnityEngine;

public class ModScript : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveX = 1f;     
    public float moveY = 1f;     
    public float xLimit = 5f;     
    public float yLimit = 5f;     

    [Header("Scaling Settings")]
    public float minScale = 1f;
    public float maxScale = 3f;
    public float scaleInterval = 0.5f; 

    [Header("Color Settings")]
    public float colorInterval = 0.5f; 

    [Header("Rotation (not used currently)")]
    public float rotate = 50f;

    private bool movingRight = true;
    private bool movingUp = true;

    public Renderer modCube;

    // Timers for color and scale changes
    private float scaleTimer = 0f;
    private float colorTimer = 0f;

    private void Start()
    {
        if (modCube == null)
            modCube = GetComponent<Renderer>();
    }

    private void Update()
    {
        MoveObject();

        // Update scale timer
        scaleTimer += Time.deltaTime;
        if (scaleTimer >= scaleInterval)
        {
            ChangeScale();
            scaleTimer = 0f;
        }

        // Update color timer
        colorTimer += Time.deltaTime;
        if (colorTimer >= colorInterval)
        {
            ChangeColor();
            colorTimer = 0f;
        }
    }

    // Move the object back and forth within boundaries
    private void MoveObject()
    {
        // Horizontal movement
        if (movingRight)
        {
            transform.Translate(moveX * Time.deltaTime, 0, 0);
            if (transform.position.x > xLimit)
                movingRight = false;
        }
        else
        {
            transform.Translate(-moveX * Time.deltaTime, 0, 0);
            if (transform.position.x < -xLimit)
                movingRight = true;
        }

        // Vertical movement
        if (movingUp)
        {
            transform.Translate(0, moveY * Time.deltaTime, 0);
            if (transform.position.y > yLimit)
                movingUp = false;
        }
        else
        {
            transform.Translate(0, -moveY * Time.deltaTime, 0);
            if (transform.position.y < -yLimit)
                movingUp = true;
        }
    }

    // Change object color randomly
    private void ChangeColor()
    {
        modCube.material.color = new Color(
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f),
            UnityEngine.Random.Range(0f, 1f)
        );
    }

    // Change object scale randomly
    private void ChangeScale()
    {
        transform.localScale = new Vector3(
            UnityEngine.Random.Range(minScale, maxScale),
            UnityEngine.Random.Range(minScale, maxScale),
            UnityEngine.Random.Range(minScale, maxScale)
        );
    }
}
