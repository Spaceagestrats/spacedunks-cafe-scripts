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
        gridCells = FindObjectsOfType<GridCell>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, whatIsAGamePiece))
        {
            if (Input.GetMouseButtonDown(0))
            {
                ClearHighlights();
                gameObject.transform.GetChild(0).GetComponent<AudioSource>().Play();
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
        if (selectedPiece.GetComponentInParent<GamePiece>())
        {
            List<Vector2> validMoves = selectedPiece.GetComponentInParent<GamePiece>().validMoves(startx, starty);
            

            foreach (Vector2 validMove in validMoves)
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

    void MoveSelectedPiece(int x, int y, float gridScale)
    {
        
        selectedPiece.transform.position = new Vector3(x * gridScale, 3, y * gridScale);
        if(selectedPiece.GetComponentInParent<GamePiece>().CheckForCollision())
        {
            gameObject.transform.GetChild(1).GetComponent<AudioSource>().Play();
        }
    }
    bool IsMoveValid(float startx, float starty, int destx, int desty)
    {
        Vector2 attemptedMove = new Vector2(destx, desty);
        if (selectedPiece.GetComponentInParent<GamePiece>())
        {

            List<Vector2> validMoves = selectedPiece.GetComponentInParent<GamePiece>().validMoves(startx, starty);
            foreach (Vector2 validMove in validMoves)
            {
                if (attemptedMove == validMove)
                {
                    return true;
                }
            }
            return false;
        }
        else return false;
    }

    
}
