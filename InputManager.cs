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
            Color defaultColor = Color.blue;
            string originalColor = cellMouseIsOver.name[^14..].Trim(' ', ')').Substring(0,5);
            if (originalColor == "White"){
                defaultColor = Color.white;
            }
            else
            {
                defaultColor = Color.black;
            }
            Color currentColor = cellMouseIsOver.GetComponentInChildren<MeshRenderer>().material.color;
            if (Input.GetMouseButtonDown(0) && defaultColor == currentColor)
            {
                defaultColor = cellMouseIsOver.GetComponentInChildren<MeshRenderer>().material.color;
                cellMouseIsOver.GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                currentColor = cellMouseIsOver.GetComponentInChildren<MeshRenderer>().material.color;
            }
            else if (Input.GetMouseButtonDown(0) && defaultColor != currentColor)
            {
                cellMouseIsOver.GetComponentInChildren<MeshRenderer>().material.color = defaultColor;
                currentColor = cellMouseIsOver.GetComponentInChildren<MeshRenderer>().material.color;
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
