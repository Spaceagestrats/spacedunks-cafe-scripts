using System.Collections.Generic;
using UnityEngine;

public class movePiece : MonoBehaviour
{
    private GameGrid gameGrid;
    public GameObject selectedPiece = null;
    float gridScale;
    [SerializeField] private LayerMask whatIsAGridLayer;
    [SerializeField] private LayerMask whatIsAGamePiece;
    Vector2Int startPos = new Vector2Int(0, 0);
    GridCell[] gridCells;
    // Start is called before the first frame update
    void Start()
    {
        gameGrid = FindObjectOfType<GameGrid>();
        gridScale = gameGrid.gridSpaceSize;
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, whatIsAGamePiece))
        {
            if (Input.GetMouseButtonDown(0))
            {

                selectedPiece = hitInfo.collider.gameObject;
                startPos = gameGrid.GetComponent<GameGrid>().GetGridPosFromWorld(selectedPiece.transform.position);
                HighlightValidMoves(startPos.x, startPos.y);
            }
        }
        else if (Physics.Raycast(ray, out RaycastHit gridHitInfo, 100f, whatIsAGridLayer))
        {
            if (Input.GetMouseButtonDown(0) && selectedPiece != null)
            {
                Vector2Int targetTile = gridHitInfo.collider.gameObject.GetComponent<GridCell>().GetPosition();
                if (IsMoveValid(startPos.x,startPos.y , targetTile.x, targetTile.y))
                {

                    MoveSelectedPiece(targetTile.x, targetTile.y, gridScale);
                    selectedPiece = null;
                    
                }
                else
                {
                    selectedPiece = null;
                }
                ClearHighlights();
            }
            
        }
    }
    
    private void ClearHighlights()
    {
        foreach (GridCell cell in gridCells)
        {
            cell.GetComponentInParent<MeshRenderer>().material.color = cell.oldColor;
        }
        
    }
    private void HighlightValidMoves(int startx, int starty)
    {
        gridCells = FindObjectsOfType<GridCell>();
        if (selectedPiece.GetComponentInParent<knight>())
        {
            List<Vector2> validKnightMoves = selectedPiece.GetComponentInParent<knight>().validMoves(startx, starty);
            

            foreach (Vector2 validMove in validKnightMoves)
            {

                foreach (GridCell cell in gridCells)
                {
                    if (cell.GetPosition() == new Vector2Int((int)validMove.x, (int)validMove.y))
                    {
                        cell.ChangeOwnColor();
                    }
                }
            }
        }
        else if (selectedPiece.GetComponentInParent<King>())
        {
            List<Vector2> validKingMoves = selectedPiece.GetComponentInParent<King>().validMoves(startx, starty);

            foreach (Vector2 validMove in validKingMoves)
            {
                foreach (GridCell cell in gridCells)
                {
                    if (cell.GetPosition() == new Vector2Int((int)validMove.x, (int)validMove.y))
                    {
                        cell.ChangeOwnColor();
                    }
                }
            }
        }
        else if (selectedPiece.GetComponentInParent<pawn>())
        {
            List<Vector2> validPawnMoves = selectedPiece.GetComponentInParent<pawn>().validMoves(startx, starty);
            if (validPawnMoves != null)
            {
                foreach (Vector2 validMove in validPawnMoves)
                {
                    foreach (GridCell cell in gridCells)
                    {
                        if (cell.GetPosition() == new Vector2Int((int)validMove.x, (int)validMove.y))
                        {
                            cell.ChangeOwnColor();
                        }
                    }
                }
            }
        }
    }

    void MoveSelectedPiece(int x, int y, float gridScale)
    {
        
        selectedPiece.transform.position = new Vector3(x * gridScale, 2, y * gridScale);
        selectedPiece.GetComponentInParent<GamePiece>().CheckForCollision();
    }
    bool IsMoveValid(float startx, float starty, int destx, int desty)
    {
        Vector2 attemptedMove = new Vector2(destx, desty);
        if (selectedPiece.GetComponentInParent<knight>())
        {

            List<Vector2> validKnightMoves = selectedPiece.GetComponentInParent<knight>().validMoves(startx, starty);
            if (validKnightMoves != null)
            {
                for (int i = 0; i < validKnightMoves.Count; i++)
                {
                    if (attemptedMove == validKnightMoves[i])
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }
        }
        else if (selectedPiece.GetComponentInParent<King>()) 
        {
            List<Vector2> validKingMoves = selectedPiece.GetComponentInParent<King>().validMoves(startx, starty);
            gridCells = FindObjectsOfType<GridCell>();

            foreach (Vector2 validMove in validKingMoves)
            {
                if (validMove == attemptedMove)
                {
                    return true;
                }
            }
            return false;
        }
        else if (selectedPiece.GetComponentInParent<pawn>())
        {
            List<Vector2> validPawnMoves = selectedPiece.GetComponentInParent<pawn>().validMoves(startx, starty);
            gridCells = FindObjectsOfType<GridCell>();

            foreach (Vector2 validMove in validPawnMoves)
            {
                if (validMove == attemptedMove)
                {
                    return true;
                }
                    
            }
            return false;
        }
        else return false;
    }

    
}
