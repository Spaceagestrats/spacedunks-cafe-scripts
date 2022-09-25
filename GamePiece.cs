using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    [SerializeField] private GameObject PiecePrefab;
    Transform target;
    GameGrid gameGrid;
    private GameObject[] gamePieces;
    float placementHeight = 3;
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
    public bool CheckForCollision()
    {
        target = FindObjectOfType<CheckForWin>().transform.GetChild(0);
        if ((gameObject.transform.GetChild(0).position.x == target.position.x)&& (gameObject.transform.GetChild(0).position.z == target.position.z))
        {
            target.GetChild(0).GetComponent<ParticleSystem>().Play();
            
            Destroy(gameObject);
            return true;
        }
        else { return false; }
    }
    void placePiece(float x, float y)
    {
        GameObject newpiece = Instantiate(PiecePrefab, new Vector3(x, placementHeight, y), Quaternion.identity);
        newpiece.transform.parent = transform;
    }
    
}
