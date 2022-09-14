using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCell : MonoBehaviour
{
    private int posX;
    private int posY;

    //Saves a reference to the gameobject that gets placed on this cell
    public GameObject objectInThisGridSpace = null;

    //Saves if the grid space is occupied or not.
    public bool isOccupied = false;

    // set the position of this grid cell on the grid

    public void SetPosition(int x, int y)
    {
        posX = x;
        posY = y;
    }

    //Get the position of this space on the grid
    public Vector2Int GetPosition()
    {
        return new Vector2Int(posX, posY);
    }
    
}