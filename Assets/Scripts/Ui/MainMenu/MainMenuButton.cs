using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    public MainMenuButtonType buttonType;


    public void OnClick()
    {
        switch (buttonType)
        {
            case MainMenuButtonType.Start: StartGame(); break;
            case MainMenuButtonType.Options: OpenOptions(); break;
            case MainMenuButtonType.Exit: ExitGame(); break;

            default: break;
        }
    }

    private void StartGame()
    {
        Debug.Log("start");
        SceneLoader.Load(SceneType.Level_1);
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
