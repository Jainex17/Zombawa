using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    public float Yincrement;
    public float speed;
    public float minheight;
    public float maxheight;
    public float health = 3;
    public GameObject effect;
    public Animator camAnim;
    public Text healthDisplay;

    public GameObject gameOver;


    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = "HP: " + health.ToString();
        if(health <= 0){
            gameOver.SetActive(true);
            Destroy(gameObject);
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxheight) {
            
            Instantiate(effect, transform.position, Quaternion.identity);
            
            camAnim.SetTrigger("Shake");
            targetPos = new Vector2(transform.position.x, transform.position.y + Yincrement);
            
        }else if(Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minheight){
            
            Instantiate(effect, transform.position, Quaternion.identity);
            
            camAnim.SetTrigger("Shake");
            targetPos = new Vector2(transform.position.x, transform.position.y - Yincrement);
            
        }
    }
}
