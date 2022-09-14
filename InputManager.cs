using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InputManager : MonoBehaviour
{
    
    [SerializeField] private LayerMask whatIsAGridLayer;
    [SerializeField] private LayerMask whatIsAGamePiece;
    GamePiece gamePiece;
    // Start is called before the first frame update
    void Start()
    {
        gamePiece = FindObjectOfType<GamePiece>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gamePiece.isSelected == false)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.gameObject.GetComponent<Target>() != null)
                {
                    hitInfo.collider.gameObject.GetComponentInParent<GamePiece>().isSelected = true;

                }
            }
        }
        else if (Input.GetMouseButtonDown(0) && gamePiece.isSelected == true)
        {
            gamePiece.isSelected = false;        
        }
    }
}
