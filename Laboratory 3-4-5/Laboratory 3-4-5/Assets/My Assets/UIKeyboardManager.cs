using UnityEngine;
using TMPro;

public class UIKeyboardManager : MonoBehaviour
{
    public TMP_Text textField;

    public UIKeyboardActivator uiKeyboardActivator; 

    public void AppendCharacter(string character)
    {        
        textField.text += character;
        uiKeyboardActivator.interactableTag.text = textField.text;
    }

    public void Delete()
    {
        if (textField.text.Length > 0)
        {
            textField.text = textField.text.Substring(0, textField.text.Length - 1);
            uiKeyboardActivator.interactableTag.text = textField.text;
        }
    }

    public void Close()
    {
        uiKeyboardActivator.HideUIKeyboard();
    }
}
