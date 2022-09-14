using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private LayerMask whatIsAGridTile;
    GamePiece gamePiece = null;
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        gamePiece = FindObjectOfType<GamePiece>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (gamePiece.isSelected)
        {
            renderer.material.color = Color.green;
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f, whatIsAGridTile))
            {
                transform.position = new Vector3(hitInfo.transform.position.x, gamePiece.placementHeight, hitInfo.transform.position.z);
            }
            
        }
        else
        {
            renderer.material.color = Color.cyan;
        }
    }

    private void OnMouseEnter()
    {
        renderer.material.color = Color.green;
        
    }
    private void OnMouseExit()
    {
        renderer.material.color = Color.cyan;
    }
}
