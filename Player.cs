using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    //step 1. define my event
    public delegate void PlayerFloorChange(string floorname);
    public static event PlayerFloorChange OnPlayerFloorChange;

    public float Movespeed = 3.5f;
    public float Jumpforce = 8.0f;
    private Rigidbody rb = null;
    private GameObject currentFloor = null;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }
    private void Update()
    {
        //move control
        float xval = Input.GetAxis("Horizontal");
        float zval = Input.GetAxis("Vertical");
        this.transform.Translate(Vector3.right * xval * Movespeed * Time.deltaTime);
        this.transform.Translate(Vector3.forward * zval * Movespeed * Time.deltaTime);

        //jump control
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            rb.AddRelativeForce(Vector3.up * Jumpforce, ForceMode.VelocityChange);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor") == true)
        {
            if (currentFloor == null || currentFloor.name != collision.gameObject.name)
            {
                // step 2. fire off my event
                if (OnPlayerFloorChange != null)
                {
                    OnPlayerFloorChange(collision.gameObject.name);
                } 
            }
        }
    }
}
