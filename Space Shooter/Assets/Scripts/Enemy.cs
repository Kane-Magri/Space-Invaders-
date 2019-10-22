using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]

    private float _enemySpeed = 4.0f;
 

    // Update is called once per frame
    void Update()
    {
      // move down at 4m/s
      // if the position on Y is less than -6
      // Y position = 8 
      // X position = random between -8 and 8 
        transform.Translate(Vector3.down * _enemySpeed *Time.deltaTime);

        if(transform.position.y < -6f)
        {
            // generate a random number between -8.5 and 8.5
            float x = Random.Range(-8f,8f);
            transform.position = new Vector3(x,8,0);

        }
    }

    void OnTriggerEnter(Collider other)
    {

        //Damage the player 
        //Destroy us
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                 player.Damage();
            }

             Destroy(this.gameObject);
        }

        //if the "other" object's tag is laser
        //Destroy the laser
        //Destroy us
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
        

    }
}
