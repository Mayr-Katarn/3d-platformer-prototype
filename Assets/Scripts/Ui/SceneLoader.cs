using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Image _progressBar;
    [SerializeField] private TMP_Text _percentText;

    private static SceneLoader instance;

    private AsyncOperation _sceneLoadingOperation;

    public static void Load(SceneType sceneName)
    {
        instance._sceneLoadingOperation = SceneManager.LoadSceneAsync((int)sceneName);
        //instance._sceneLoadingOperation.allowSceneActivation = false;
        instance.gameObject.SetActive(true);
    }

    private void Start()
    {
        Debug.Log("SSSSS");
        instance = this;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_sceneLoadingOperation != null)
        {
            _percentText.text = Mathf.RoundToInt(_sceneLoadingOperation.progress * 100).ToString();
            _progressBar.fillAmount = _sceneLoadingOperation.progress;
            //Debug.Log(_sceneLoadingOperation.isDone);
        }

        //if (_sceneLoadingOperation.isDone && !_sceneLoadingOperation.allowSceneActivation)
        //{
        //    StartScene();
        //}
    }

    private void StartScene()
    {
        Debug.Log("Start scene");
        gameObject.SetActive(false);
        _sceneLoadingOperation.allowSceneActivation = true;
    }
}
