using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputManager : MonoBehaviour
{
    
    [SerializeField] private LayerMask whatIsAGridLayer;
    [SerializeField] private LayerMask whatIsAGamePiece;
    Vector2Int nullVector = new Vector2Int(-1, -1);
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2Int tileUnderMouse = isMouseOverATile();
        GameObject pieceUnderMouse = isMouseOverAPiece();

        if (pieceUnderMouse != null)
        {
            //Debug.Log(pieceUnderMouse);
            if (Input.GetMouseButtonDown(0) && pieceUnderMouse.GetComponentInParent<GamePiece>().isSelected == false)
            {
                Debug.Log(pieceUnderMouse.name + "has been selected");
                pieceUnderMouse.GetComponentInParent<GamePiece>().isSelected = true;
            }
            while (pieceUnderMouse.GetComponentInParent<GamePiece>().isSelected && tileUnderMouse != nullVector)
            {
                pieceUnderMouse.transform.position = new Vector3(tileUnderMouse.x, 0, tileUnderMouse.y);
            }
            
        }
        
    }
    Vector2Int isMouseOverATile ()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo,100f, whatIsAGridLayer))
        {
            Vector2Int tileUnderMouse;
            tileUnderMouse = hitInfo.collider.gameObject.GetComponent<GridCell>().GetPosition();
            return tileUnderMouse;
        }
        else
        {
            Vector2Int cellPos = nullVector;
            return cellPos;
        }
    }
    GameObject isMouseOverAPiece()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, whatIsAGamePiece))
        {
            GameObject pieceUnderMouse;
            pieceUnderMouse = hitInfo.collider.gameObject;
            return pieceUnderMouse;
        }
        else
        {
            return null;
        }
    }
}
