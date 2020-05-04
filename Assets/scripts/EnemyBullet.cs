using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed; //bullet speed
    Vector2 _direction; //direction of bullet
    bool isReady; //to know when bullet direction is set

    void Awake()
    {
        speed = 5f;
        isReady = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //function to set bullet direction
    public void SetDirection(Vector2 direction)
    {
        //set direction normalized
        _direction = direction.normalized;

        isReady = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            //get bullet current position
            Vector2 position = transform.position;

            //compute bullet new position
            position += _direction * speed * Time.deltaTime;

            //update bullet position
            transform.position = position;

            //remove bullet if it goes outside seen
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

            if ((transform.position.x < min.x) || (transform.position.x > max.x) || (transform.position.y < min.y) || (transform.position.y > max.y))
            {
                Destroy(gameObject);
            }

        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //destroy enemy bullet when collies with player ship
        if (col.tag == "PlayerShipTag")
        {
            Destroy(gameObject);
        }
    }
}
