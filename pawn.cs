using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pawn : MonoBehaviour
{
    GameGrid gameGrid;

    private List<Vector2> validMovesList = new List<Vector2>();
    public List<Vector2> validMoves(float startPosX, float startPosY)
    {
        if (validMovesList.Count > 0)
        {
            validMovesList.Clear();
        }
        int i = 0;
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                //find valid moves for pawn
                //rules for moving pawns are as follows:
                //if ONLY y increases by one, that is a valid move; except in cases where y exceeds the size of the board
                float changeInX = x-startPosX;
                float changeInY = y-startPosY;
                if (changeInX == 0 && changeInY == 1)
                {
                    Vector2 validMove = new Vector2(x, y);
                    validMovesList.Add(validMove);
                    i++;
                }
            }
        }
        if (validMovesList.Count > 0)
        {
            return validMovesList;
        }
        else
        {
            return null;
        }
    }
}
