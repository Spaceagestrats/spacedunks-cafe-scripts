using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{

    public int height = 10;
    public int width = 10;


    public float gridSpaceSize = 5f;

    [SerializeField] private GameObject gridCellPrefab;
    private GameObject[,] gameGrid;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CreateGrid());
    }

    private IEnumerator CreateGrid()
    {
        gameGrid = new GameObject[height, width];

        if (gridCellPrefab == null)
        {
            Debug.LogError("Error: Grid Cell Prefab Not Assigned on the Game Grid");
            yield return null;
        }
        //Make Grid
        int tileTracker = 0;
        for (int y = 0; y < height; y++)
        {
            for(int x = 0; x < width; x++)
            {
                gameGrid[x, y] = Instantiate(gridCellPrefab, new Vector3(x * gridSpaceSize,0, y * gridSpaceSize), Quaternion.identity);
                gameGrid[x, y].GetComponent<GridCell>().SetPosition(x, y);
                gameGrid[x, y].transform.parent = transform;
                
                if (y % 2 == 0)
                {
                    if (tileTracker % 2 == 1)
                    {
                        gameGrid[x, y].gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
                        Color defaultColor = gameGrid[x, y].gameObject.GetComponent<MeshRenderer>().material.color;
                        gameGrid[x, y].gameObject.name = "Grid space ( X: " + x.ToString() + " , Y: " + y.ToString() + ", Color: White Square)";
                    }
                    else
                    {
                        gameGrid[x, y].gameObject.name = "Grid space ( X: " + x.ToString() + " , Y: " + y.ToString() + ", Color: Black Square)";
                    }
                }
                else
                {
                    if (tileTracker % 2 == 0)
                    {
                        gameGrid[x, y].gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
                        Color defaultColor = gameGrid[x, y].gameObject.GetComponent<MeshRenderer>().material.color;
                        gameGrid[x, y].gameObject.name = "Grid space ( X: " + x.ToString() + " , Y: " + y.ToString() + ", Color: White Square)";
                    }
                    else
                    {
                        gameGrid[x, y].gameObject.name = "Grid space ( X: " + x.ToString() + " , Y: " + y.ToString() + ", Color: Black Square)";
                    }

                }
                tileTracker++;
                yield return new WaitForSeconds(0.02f);
            }
        }
    }
    //Gets the grid position from world position
    public Vector2Int GetGridPosFromWorld(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt(worldPosition.x / gridSpaceSize);
        int y = Mathf.FloorToInt(worldPosition.z / gridSpaceSize);

        x = Mathf.Clamp(x, 0, width);
        y = Mathf.Clamp(y, 0, height);

        return new Vector2Int(x, y);

    }
    public Vector3 GetWorldPosFromGridPos(Vector2Int gridPos)
    {
        float x = gridPos.x * gridSpaceSize;
        float y = gridPos.y * gridSpaceSize;

        return new Vector3(x, 0, y);
    }
    public Color GetColor(int x, int y)
    {
        Color color = gameGrid[x, y].GetComponent<MeshRenderer>().material.color;
        return color;
    }
}


