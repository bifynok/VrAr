using UnityEngine;

public class DoorColision : MonoBehaviour
{
    GameObject parentObject;
    DoorAnim doorAnim;

    void Start()
    {
        parentObject = transform.parent.gameObject;
        doorAnim = parentObject.GetComponent<DoorAnim>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            doorAnim.isOpen = !doorAnim.isOpen;   
        }
    }
}
