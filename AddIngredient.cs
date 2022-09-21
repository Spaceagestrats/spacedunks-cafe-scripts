using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddIngredient : MonoBehaviour
{

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "GamePiece")
        {
            gameObject.name = gameObject.name + " : " + collision.gameObject.name;
            Destroy(collision.gameObject);
        }
    }
}
