using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Converter : MonoBehaviour
{
    public int x;
    public int y;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void placeObstacle(int x, int y)
    {

        gameObject.transform.position = new Vector3(x, 1, y);

    }
    Vector2Int GetPosition()
    {
        return new Vector2Int(x, y);
    }
    public void ConvertPiece(GameObject pieceOnConverter)
    {
        if (pieceOnConverter.GetComponent<knight>())
        {
            Destroy(pieceOnConverter.GetComponent<knight>());
        }
    }
}
