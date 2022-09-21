using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForWin : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] private LayerMask whatIsAGamePiece;
    [SerializeField] private GameObject coffeeCup;
    public float placementHeight;
    public float x;
    public float y;
    public float spacing;
    

    private void Start()
    {
        
        placePiece(x*spacing, y*spacing);
    }
    void Update()
    {
        
        if (IsGameWon())
        {
            
            Debug.Log("CONGRATS YOU DID IT KING/QUEEN/MONARCH LUV U");
            Time.timeScale = 0.2f;
        }   
    }
    bool IsGameWon()
    {
        GamePiece[] piecesOnBoard = FindObjectsOfType<GamePiece>();
        if (piecesOnBoard.Length == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
   
    void placePiece(float x, float y)
    {
        GameObject newpiece = Instantiate(coffeeCup, new Vector3(x, placementHeight, y), Quaternion.identity);
        newpiece.transform.parent = transform;
    }
}
