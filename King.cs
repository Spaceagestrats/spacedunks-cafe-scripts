using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : MonoBehaviour
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
                //find valid moves for knight
                //rules for moving knights are as follows:
                //if the absolute value of the sum of the difference (where the difference of x and y are > 0) of the
                //new position vector and the original position vector are equal to three, that is a valid move.
                float changeInX = Mathf.Abs(startPosX - x);
                float changeInY = Mathf.Abs(startPosY - y);
                if (changeInX + changeInY == 2 || (changeInX == 1 && changeInY == 2))
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
