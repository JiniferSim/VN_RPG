using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float MaxFly;
    public float MinFly;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        bool walking = false;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
            GetComponent<SpriteRenderer>().flipX = false;
            walking = true;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0, 0);
            GetComponent<SpriteRenderer>().flipX = true;
            walking = true;
        }

        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y < MaxFly)
        {
            transform.position = transform.position + new Vector3(0, speed * Time.deltaTime, 0);
            walking = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && transform.position.y > MinFly)
        {
            transform.position = transform.position + new Vector3(0, -speed * Time.deltaTime, 0);
            walking = true;
        }
        GetComponent<Animator>().SetBool("Walk", walking);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            LevelLoader levelLoader = FindObjectOfType<LevelLoader>();
            if (levelLoader != null)
            {
                levelLoader.LoadNextLevel();
            }
            else
            {
                Debug.LogError("LevelLoader not found in the scene.");
            }
        }
    }
}
