using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour{

    public GameObject wallPrefab;
    public float wallDistance = 4f;
    public float verticaleRange = 3f;

    private void OnBecameVisible(){

        float randomVerticalePosition = Random.Range(-verticaleRange, verticaleRange);
        Vector2 newPositon = new Vector2(transform.position.x + wallDistance, randomVerticalePosition);
        Instantiate(wallPrefab, newPositon, Quaternion.identity);

    }

    private void OnBecameInvisible(){
        
        Destroy(gameObject);
    }

}
    
