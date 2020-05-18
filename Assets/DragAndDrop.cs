using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool moveAllowed;
    Collider2D col;
    public GameObject selectionEffect;
    private GameMaster gm;
    public GameObject deathEffect;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
            
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            if(touch.phase == TouchPhase.Began)
            {
                Collider2D touchCollider = Physics2D.OverlapPoint(touchPosition);
                if(col == touchCollider)
                {
                    Instantiate(selectionEffect, transform.position, Quaternion.identity);
                    audioSource.Play();
                    
                    moveAllowed = true;
                }
            }
            if(touch.phase == TouchPhase.Moved)
            {
                if(moveAllowed == true)
                {
                    transform.position = new Vector2(touchPosition.x, touchPosition.y);
                }
            }
            if(touch.phase == TouchPhase.Ended)
            {
                moveAllowed = false;
            }
        }
       

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Planet")
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //RestartPanel.SetActive(true);
            //Debug.Log("this is it");
            gm.GameOver();
        }
    }
}
