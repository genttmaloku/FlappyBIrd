using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    [Header("Parameters")]
    public float jumpVelocity = 5f;
    public float moveVelocity = 5f;

    private bool hasLost = false;

    private Rigidbody2D rigidbody;
    private Camera mainCamera;

    [Header("Menus")]
    public GameObject loseMenu;
    public GameObject gameMenu;
  
    private AudioSource audioSource;

    [Header("Audio")]
    public AudioClip jumpClip;
    public AudioClip scoreClip;
    public AudioClip loseClip;


    private void Start(){

        Debug.Log("Highscore: " + GameManager.Instance.Highscore);
        GameManager.Instance.Score = 0;
        rigidbody = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        mainCamera = Camera.main;

    }

    private void Update(){
        if(hasLost){
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space)){
            Jump();
        }

        CameraFollow();
        Move();
    }

    private void Move(){
        Vector2 currentVelocity = rigidbody.velocity;
        currentVelocity.x = moveVelocity;
        rigidbody.velocity = currentVelocity;
    }

    private void Jump(){

        Vector2  currentVelocity = rigidbody.velocity;
        currentVelocity.y = jumpVelocity;
        rigidbody.velocity = currentVelocity;
        audioSource.PlayOneShot(jumpClip);
    }


    private void CameraFollow(){
        Vector3 newCameraPosition = new Vector3(transform.position.x, 0f, -10f);
        mainCamera.transform.position = newCameraPosition;
    }

    private void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.CompareTag("Wall")){
            LoseGame();
        }
    }

    private void LoseGame(){
        hasLost = true;
        GameManager.Instance.Highscore = GameManager.Instance.Score;
        Debug.Log("Score: " + GameManager.Instance.Score + " / Highscore " + GameManager.Instance.Highscore);
      
        Invoke("ActivateLoseMenu", 2f);
        audioSource.PlayOneShot(loseClip);
    }

    private void ActivateLoseMenu(){
        loseMenu.SetActive(true);
        gameMenu.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other){

        if(other.gameObject.CompareTag("Score")){
            GameManager.Instance.Score++;

            audioSource.PlayOneShot(scoreClip);

            Debug.Log("Score: " + GameManager.Instance.Score);
        }
    }
}
