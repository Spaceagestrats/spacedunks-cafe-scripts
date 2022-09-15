using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    [SerializeField] private GameObject PiecePrefab;
    GameGrid gameGrid;
    private GameObject[] gamePieces;
    public float placementHeight = 0;
    public int piecex, piecey = 0;
    public bool isSelected = false;
    // Start is called before the first frame update
    void Start()
    {
        
        gameGrid = FindObjectOfType<GameGrid>( );
        float spacing = gameGrid.gridSpaceSize;
        transform.position = new Vector3(piecex*spacing, placementHeight, piecey*spacing);
        placePiece(spacing*piecex, spacing*piecey);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void placePiece(float x, float y)
    {
        GameObject newpiece = Instantiate(PiecePrefab, new Vector3(x, placementHeight, y), Quaternion.identity);
        newpiece.transform.parent = transform;
    }
    
}
