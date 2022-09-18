using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForWin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameWon())
        {
            Debug.Log("CONGRATS YOU DID IT KING/QUEEN/MONARCH LUV U");
        }   
    }
    bool isGameWon()
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
}
