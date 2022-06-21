using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public ButtonType buttonType;
    
    void Start()
    {
    }

    public void OnClick()
    {
        switch (buttonType)
        {
            case ButtonType.Start: StartGame(); break;
            case ButtonType.Options: OpenOptions(); break;
            case ButtonType.Exit: ExitGame(); break;

            default: break;
        }
    }

    private void StartGame()
    {
        Debug.Log("start");
    }

    private void OpenOptions()
    {
        Debug.Log("options");
    }

    private void ExitGame()
    {
        Debug.Log("exit");
    }
}
