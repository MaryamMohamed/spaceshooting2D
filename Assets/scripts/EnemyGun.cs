using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBulletGo;
    
    // Start is called before the first frame update
    void Start()
    {
        //fire enemy bullet after 0.5 sec
        Invoke("FireEnemyBullet", 1f);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireEnemyBullet()
    {
        //refer to player ship
        GameObject playerShip = GameObject.Find("PlayerGo");

        if (playerShip != null)
        {
            //Instantiate enemy bullet
            GameObject bullet = (GameObject)Instantiate(EnemyBulletGo);

            //set bullet initial position
            bullet.transform.position = transform.position;

            //compute bullet towards player
            Vector2 direction = playerShip.transform.position - bullet.transform.position;

            //set bullet dir.
            bullet.GetComponent<EnemyBullet>().SetDirection(direction);

        }
    }
}
