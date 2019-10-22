using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    // Start is called before the first frame update
    
        //speed variable of 8

        [SerializeField]
        
        private float _speed = 8f;
        
    

    // Update is called once per frame
    void Update()
    {
        // translate laser upwards

        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        //if the laser position on Y is greater than 7
        // Destory the object
        
        if (transform.position.y > 7)

        { 
            //this means the object connected with the script
            Destroy(this.gameObject);
        }

    }
}
