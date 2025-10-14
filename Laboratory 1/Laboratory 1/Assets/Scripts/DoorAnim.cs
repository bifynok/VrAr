using UnityEngine;

public class DoorAnim : MonoBehaviour
{
    private float rotationAngle = 90f;
    public float rotationSpeed = 3f;

    private bool isOpen = false;
    private float currentAngle = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isOpen = !isOpen;
        }

        float targetAngle = isOpen ? rotationAngle : 0f;

        currentAngle = Mathf.Lerp(currentAngle, targetAngle, Time.deltaTime * rotationSpeed);

        transform.eulerAngles = new Vector3(0, currentAngle, 0);
    }
}
