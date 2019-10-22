// Namespaces - libraries of pre-exisiting code
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehaviour is a Unity class that allows us
// to attach scripts to gameObjects
// the colon symbol means that player inherits monobehaviour's code
public class Player : MonoBehaviour
{
    // Vabriable - a box with information that can be changed.
    // step 1 - public player can change it or private player can t see or change it and must always have a _ infront the name
    // step 2 - data type (int :whole number, float :number with a point, bool :true and false, string : text)
    // step 3 - every vatiable needs a name
    // step 4 - optional value 

    // Attribute - exposes the variable inside Unity
    [SerializeField]

    private float _speed = 3.5f;

    [SerializeField]

    private GameObject _laserPrefab;

    [SerializeField]
    private int _lives = 3;
    private SpawnManager _spawnManager;

    private float _fireRate = 0.5f;

    private float _nextFire = -1.0f;


    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);

        _spawnManager = GameObject.Find("Spawn Manager"). GetComponent<SpawnManager>();
        if (_spawnManager == null)
        {
            Debug.LogError("There is no Spawn Manager in the scene!");
        }
    }

    //Update is called once per frame
   void Update()
   {
        CalculateMovement();

        //if I hit the space key and the game time is greater than next fire
        //reset next fire = current time + fire rate

        // if I hit the space key
        // spawn laser
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _nextFire)
        {
            FireLaser();       
        }

   }
    
     void CalculateMovement()
    {

        // local varriable - horizontalInput
        // read the keyboard input from the user
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Vector3.right =new Vector (1,0,0)
        transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime);
        transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        
        // all the input can  be in one like below
        //Vector3 direction = new Vector3 (
            //Input.GetAxis ("Horizontal"),
            //Input.GetAxis ("Vertical"),
            //0
        //);
        //transform.Translate(direction * _speed * Time.deltaTime)

        // if the player position on the Y axis is > 0
        // y position = 0
        //else if the Y position <-4.5
        // y position = -4.5

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);

        }
        else if (transform.position.y <-4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, 0);
        
        }
    
        // if x position is > 11
        // x position = -11.5
        // else if X position < -11.5
        // X position = 11.5
        if (transform.position.x > 11.5f)
        {
            transform.position = new Vector3(-11.5f, transform.position.y, 0);
        }
        else if (transform.position.x <-11.5f)
        {
            transform.position = new Vector3(11.5f, transform.position.y , 0);
        }

    }

    void FireLaser()
    {
        _nextFire = Time.time + _fireRate;
            
            //calculate 0.8 units vertically from the player
            Vector3 laserPos = transform.position + new Vector3(0, 0.8f, 0);


            //Quaternion.identity = default rotation (0,0,0)
            Instantiate(_laserPrefab, laserPos, Quaternion.identity); 
    }

    public void Damage()
    {
        // reduce lives by 1
        _lives = _lives -1;

        // check if dead
        // destroy us 
        if (_lives <1)
        {
            _spawnManager.OnPlayerDeath();
            Destroy(this.gameObject);
        }
    }
}
