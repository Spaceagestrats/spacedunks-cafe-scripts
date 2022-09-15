using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsAGridTile;
    GamePiece[] gamePiece = null;
    private Renderer renderer;
    InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        gamePiece = FindObjectsOfType<GamePiece>();
        inputManager = FindObjectOfType<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
