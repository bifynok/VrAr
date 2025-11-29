using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class UIKeyboardActivator : MonoBehaviour
{
    public GameObject uiKeyboard, leftInt, rightInt, tagName;

    public TMP_Text interactableTag;

    private Transform xrOriginCamera;
    
    private UIKeyboardManager uiKeyboardManager;

    void Start()
    {
        xrOriginCamera = Camera.main.transform;

        uiKeyboardManager = uiKeyboard.GetComponent<UIKeyboardManager>();

        uiKeyboard.SetActive(false);
    }

    public void ShowUIKeyboard(SelectEnterEventArgs args)
    {
        Vector3 spawnPosition = xrOriginCamera.position + xrOriginCamera.forward * 1.2f;
        uiKeyboard.transform.position = spawnPosition;

        Quaternion lookRotation = Quaternion.LookRotation(xrOriginCamera.forward);
        lookRotation.eulerAngles = new Vector3(0, lookRotation.eulerAngles.y, 0);
        uiKeyboard.transform.rotation = lookRotation;

        uiKeyboard.SetActive(true);
        tagName.SetActive(true);
        leftInt.SetActive(false);
        rightInt.SetActive(false);

        uiKeyboardManager.uiKeyboardActivator = this;
        uiKeyboardManager.textField.text = interactableTag.text;
    }

    public void HideUIKeyboard()
    {
        uiKeyboard.SetActive(false);
        tagName.SetActive(false);
        leftInt.SetActive(true);
        rightInt.SetActive(true);
    }
}
