using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //ship speed
    public float speed;
    public GameObject PlayerBulletGo;
    public GameObject BulletPosition01;
    public GameObject BulletPosition02;
    public GameObject ExplosionGo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //fire when spacebar press
        if (Input.GetKeyDown("space"))
        {
            //instentiate 1st bullet
            GameObject bullet01 = (GameObject)Instantiate(PlayerBulletGo);
            bullet01.transform.position = BulletPosition01.transform.position;

            GameObject bullet02 = (GameObject)Instantiate(PlayerBulletGo);
            bullet02.transform.position = BulletPosition02.transform.position;

        }
        // values will be -1 for left, 0 for no input and 1 for right
        float x = Input.GetAxisRaw("Horizontal");
        // values will be -1 for down, 0 for no input and 1 for up
        float y = Input.GetAxisRaw("Vertical");

        Vector2 direction = new Vector2(x, y).normalized;

        Move(direction);

    }
    void Move(Vector2 direction)
    {
        //find screen limits to player movement
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //bottom left corner
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //bottom right corner

        max.x = max.x - 0.5f;
        min.x = min.x + 0.5f;

        max.y = max.y - 0.6f;
        min.y = min.y + 0.6f;


        //get player pos.
        Vector2 pos = transform.position;

        //calc new pos.
        pos += direction * speed * Time.deltaTime;

        //position not outside camra
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        //update pos
        transform.position = pos;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //destroy player when collies with enemy ship or bullet
        if ((col.tag == "EnemyShipTag") || (col.tag == "EnemyBulletTag"))
        {
            PlayerExplosion();
            //Destroy(gameObject);
        }
    }

    //instantiate explo
    void PlayerExplosion()
    {
        GameObject explosion = (GameObject)Instantiate(ExplosionGo);
        explosion.transform.position = transform.position;

    }

}
