using UnityEngine;

public class MovementControls : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 5f;
    private Transform cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        cam = Camera.main.transform;
    }

    void FixedUpdate()
    {
        Vector3 move = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
            move += Vector3.forward;
        if (Input.GetKey(KeyCode.S))
            move += Vector3.back;
        if (Input.GetKey(KeyCode.A))
            move += Vector3.left;
        if (Input.GetKey(KeyCode.D))
            move += Vector3.right;

        if (move != Vector3.zero)
        {
            Vector3 camForward = cam.forward;
            camForward.y = 0;
            Vector3 camRight = cam.right;
            camRight.y = 0;

            Vector3 moveDir = move.z * camForward + move.x * camRight;
            moveDir.Normalize();

            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(moveDir), 0.2f);

            rb.MovePosition(rb.position + moveDir * speed * Time.fixedDeltaTime);
        }
    }
}
