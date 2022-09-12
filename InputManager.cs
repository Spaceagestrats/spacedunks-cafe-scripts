using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameGrid gameGrid;
    [SerializeField] private LayerMask whatIsAGridLayer;
    [SerializeField] private LayerMask whatIsAGamePiece;
    // Start is called before the first frame update
    void Start()
    {
        gameGrid = FindObjectOfType<GameGrid>();
    }

    // Update is called once per frame
    void Update()
    {
        GridCell cellMouseIsOver = IsMouseOverAGridSpace();
        //piece_movement pieceMouseIsOver = IsMouseOverAGamePiece();
        if (cellMouseIsOver != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                cellMouseIsOver.GetComponentInChildren<SpriteRenderer>().material.color = Color.red;
            }
        }
        /*
        if (pieceMouseIsOver != null)
        {
            pieceMouseIsOver.GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            pieceMouseIsOver.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        */
    }

    // Returns the grid cell if mouse is over a grid cell and returns null if it is not
    private GridCell IsMouseOverAGridSpace()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, whatIsAGridLayer))
        {
            return hitInfo.transform.GetComponent<GridCell>();

        }
        else
        {
            return null;
        }
    }
    //returns the piece if mouse over a piece and null if not
    
    /*
    private piece_movement IsMouseOverAGamePiece()
    {
        Ray pieceRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(pieceRay, out RaycastHit hitInfo, 100f, whatIsAGamePiece))
        {
            return hitInfo.transform.GetComponent<piece_movement>();

        }
        else
        {
            return null;
        }
    }
    */
}
