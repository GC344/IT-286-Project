using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RollTheBall : MonoBehaviour {
    private Rigidbody hamsterBall;
    public float bumpForce, maxAngVelocity, boost, currentSpeed;
    [SerializeField]
    public static float topSpeed;
    public static int seedMoney;
    public int  resetDepth;
    public static Vector3 spawnPoint;
    
    // Use this for initialization
    private Vector3 playerInput;
    public Text currencyText, velocityText,topSpeedText;

	void Start () {
        hamsterBall = GetComponent<Rigidbody>();
        hamsterBall.maxAngularVelocity = maxAngVelocity;
        topSpeed = 10;
        seedMoney = 0;
        spawnPoint = new Vector3(0, 2, 0);
        //level 1: 15,2,0
        hamsterBall.transform.position = spawnPoint;
        
	}
	
	// Update is called once per frame
	void Update () {
        // hamsterBall.velocity = new Vector3(2f, hamsterBall.velocity.y, 2f);
       // playerInput = new Vector3(Input.GetAxisRaw("Horizontal") * 5f, hamsterBall.velocity.y, Input.GetAxisRaw("Vertical")*5f);
        
        //consider changing off of GetAxisRaw to just GetAxis
        if(hamsterBall.transform.position.y < - resetDepth)
        {
            hamsterBall.transform.position = new Vector3(0, 2f, 0);
            hamsterBall.velocity = new Vector3(0f, 0f, 0f);
            Debug.Log("Out of bounds, player position reset");
        }

        currencyText.text = "Seeds: " + seedMoney;
        topSpeedText.text = "Top Speed: " + topSpeed + "m/s";

        if (Input.GetKeyDown(KeyCode.Space))
        {
            hamsterBall.velocity = Vector3.zero;
            hamsterBall.angularVelocity = Vector3.zero;
        }


    }
    private void FixedUpdate()
    {
        if (hamsterBall.velocity.magnitude <= topSpeed)
        {
            playerInput = new Vector3(Input.GetAxis("Horizontal") * boost, 0, Input.GetAxisRaw("Vertical") * boost);
            //hamsterBall.velocity = playerInput;
            //add tourqe for more realistic ball rolling
            hamsterBall.AddForce(playerInput);
        }
        currentSpeed = GetComponent<Rigidbody>().velocity.magnitude;
        velocityText.text = "Velocity: " + string.Format("{0:0.00}", currentSpeed);
        //string.Format("{0:0.00}", currentSpeed);

    }
    void OnCollisionEnter(Collision collision)
    {//try adddforce
        
        if (collision.gameObject.tag == "Bumper")
        {
            // Calculate Angle Between the collision point and the player
            Vector3 direction = collision.contacts[0].point - transform.position;
            // normalize the negative vector
            direction = -direction.normalized;
            //multiply direction and force and add that to the rigidbody 
            GetComponent<Rigidbody>().AddForce(direction * bumpForce);
            Debug.Log("You have been bumped");
        }
        if (collision.gameObject.tag == "KillZone")
        {
            hamsterBall.transform.position = new Vector3(0, 2f, 0);
            hamsterBall.velocity = new Vector3(0f,0f,0f);
            Debug.Log("Killzone collision, player position reset");
        }
        if (collision.gameObject.tag =="Collectible")
        {
            Destroy(collision.gameObject);
            Debug.Log("Collided with " + collision.gameObject);
            seedMoney += 1;
        }
        if (collision.gameObject.tag == "Seed")
        {
            Destroy(collision.gameObject);
            Debug.Log("Collided with " + collision.gameObject);
            seedMoney += 1;
           
        }
        if (gameObject.tag == "Drink")
        {
            //Destroy(collision.gameObject);
            topSpeed += 0.5f;
            Debug.Log("Collided with " + collision.gameObject + " Top Speed: " + topSpeed);
            

        }
        if (collision.gameObject.tag == "Platform")
        {
           
            Debug.Log("Entered The " + collision.gameObject);
            this.transform.parent = collision.transform;
            

        }
        if (collision.gameObject.tag == "SpinPlate")
        {

            Debug.Log("Entered The " + collision.gameObject);
            this.transform.parent = collision.transform;


        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Platform")
        {

            Debug.Log("Left The " + collision.gameObject);
            this.transform.parent = null;


        }
        if (collision.gameObject.tag == "SpinPlate")
        {

            Debug.Log("Left The " + collision.gameObject);
            this.transform.parent = null;


        }
    }
}

