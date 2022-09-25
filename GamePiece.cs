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


    public enum Type
    {
        Knight, King, Pawn
    };
    public Type typePiece;

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

    private List<Vector2> validMovesList = new List<Vector2>();
    public List<Vector2> validMoves(float startPosX, float startPosY)
    {

        if (validMovesList.Count > 0)
        {
            validMovesList.Clear();
        }


        int i = 0;
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (typePiece.ToString().ToLower() == "knight")
                {
                    //find valid moves for knight
                    //rules for moving knights are as follows:
                    //if the absolute value of the sum of the difference (where the difference of x and y are > 0) of the
                    //new position vector and the original position vector are equal to three, that is a valid move.
                    float changeInX = Mathf.Abs(startPosX - x);
                    float changeInY = Mathf.Abs(startPosY - y);
                    if (changeInX + changeInY == 3)
                    {
                        if (changeInX > 0 && changeInY > 0)
                        {
                            Vector2 validMove = new Vector2(x, y);
                            validMovesList.Add(validMove);
                            i++;
                        }
                    }
                }
                else if (typePiece.ToString().ToLower() == "king")
                {
                    //find valid moves for king(variant)
                    //rules for moving kings(variant) are as follows:
                    float changeInX = Mathf.Abs(startPosX - x);
                    float changeInY = Mathf.Abs(startPosY - y);
                    if (changeInX + changeInY == 3)
                    {
                        Vector2 validMove = new Vector2(x, y);
                        validMovesList.Add(validMove);
                        i++;
                    }
                }
                else if (typePiece.ToString().ToLower() == "pawn")
                {
                    //find valid moves for pawn
                    //rules for moving pawns are as follows:
                    //if ONLY y increases by one, that is a valid move; except in cases where y exceeds the size of the board
                    float changeInX = x - startPosX;
                    float changeInY = y - startPosY;
                    if (changeInX == 0 && changeInY == 1)
                    {
                        Vector2 validMove = new Vector2(x, y);
                        validMovesList.Add(validMove);
                        i++;
                    }
                }
            }
        }
        if (validMovesList.Count > 0)
        {
            return validMovesList;
        }
        else return null;

    }


}
