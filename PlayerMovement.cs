using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 4f;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] float jumpForce = 30f;

    // Start is called before the first frame update
    void Start()
    {
        Score.score = 0;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotation
        float horizontalInput = Input.GetAxis("Horizontal");
                transform.Rotate(Vector3.up * horizontalInput * rotationSpeed * Time.deltaTime);

        // Movement
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * verticalInput * movementSpeed;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
    }

    bool IsGrounded()
    {
        // Raycast to check if there is ground beneath the player
        RaycastHit hit;
        float raycastDistance = 1.1f; // Adjust this value depending on your player's height
        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
            return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Yarn")
        {
            Score.score += 1;
            Destroy(other.gameObject);
        }
    }
}
