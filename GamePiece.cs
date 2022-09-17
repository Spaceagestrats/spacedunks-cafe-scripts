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
    // Start is called before the first frame update
    void Start()
    {
        
        gameGrid = FindObjectOfType<GameGrid>( );
        Vector3 tileSpot = gameGrid.GetWorldPosFromGridPos(new Vector2Int(piecex, piecey));
        placePiece(tileSpot.x, tileSpot.z);
        
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
