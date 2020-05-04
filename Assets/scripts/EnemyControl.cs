using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameObject ExplosionGo;

    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        //calc new pos.
        position = new Vector2(position.x, position.y - speed * Time.deltaTime);
        //update pos
        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //bottom left corner
        if (transform.position.y < min.y)
        {
            
            Destroy(gameObject);
        }   
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //deftroy enemy when collies with player bullet
        if (col.tag == "PlayerBulletTag" || (col.tag == "PlayerShipTag"))
        {
            PlayerExplosion();
            Destroy(gameObject);
        }
    }
    //instantiate explo
    void PlayerExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGo);
        explosion.transform.position = transform.position;

    }

}
