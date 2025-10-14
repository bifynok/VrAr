using UnityEngine;

public class DoorAnim : MonoBehaviour
{
    public float rotationSpeed = 3f;
    private GameObject door;
    private Collider doorCollider;
    public bool isOpen = false;

    private Quaternion closedRotation;
    private Quaternion openedRotation;

    void Start()
    {
        closedRotation = transform.rotation;
        openedRotation = closedRotation * Quaternion.Euler(0f, 90f, 0f);

        door = transform.GetChild(0).gameObject;
        doorCollider = door.GetComponent<Collider>();
    }

    void Update()
    {
        Quaternion targetRotation = isOpen ? openedRotation : closedRotation;

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

        float angleDifference = Quaternion.Angle(transform.rotation, targetRotation);
        doorCollider.isTrigger = angleDifference > 0.1f;
    }
}
