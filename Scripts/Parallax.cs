using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour{
   
    public float distance = 32f;

    private void OnBecameVisible(){

        Vector2 newPositon = new Vector2(transform.position.x + distance, transform.position.y);
        Instantiate(gameObject, newPositon, Quaternion.identity);
    }

    private void OnBecameInvisible(){

        Destroy(gameObject);
    }

    
}
