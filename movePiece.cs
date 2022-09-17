using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePiece : MonoBehaviour
{
    public bool isSelected = false;
    private GameGrid gameGrid;
    public GameObject selectedPiece = null;
    float gridScale;
    [SerializeField] private LayerMask whatIsAGridLayer;
    [SerializeField] private LayerMask whatIsAGamePiece;
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
                selectedPiece = hitInfo.collider.gameObject;
        }
        else if (Physics.Raycast(ray, out RaycastHit gridHitInfo, 100f, whatIsAGridLayer))
        {
            if (Input.GetMouseButtonDown(0) && isMoveValid())
            {
                Vector2Int targetTile = gridHitInfo.collider.gameObject.GetComponent<GridCell>().GetPosition();
                
                moveSelectedPiece(targetTile.x, targetTile.y,gridScale);
            }
        }
        
    }
    void moveSelectedPiece(int x, int y, float gridScale)
    {
        selectedPiece.transform.position = new Vector3(x*gridScale, 2, y*gridScale);
    }
    bool isMoveValid()
    {
        return true;
    }
}
