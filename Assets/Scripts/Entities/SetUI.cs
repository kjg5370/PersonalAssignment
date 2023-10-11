using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetUI : MonoBehaviour
{
    public static SetUI Instance { get; private set; }
    private GameObject canvas;

    [SerializeField] private Text labelTxt;
    private void Awake()
    {
        Instance = this;  
        canvas = gameObject;
    }
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            canvas.SetActive(false);
        }
    }
    
    public void LoadTargetScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void SetLabelText(string text)
    {
        if (labelTxt != null)
        {
            labelTxt.text = text;
        }
    }
    public void SetGameObjectActive(bool isActive)
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        canvas.SetActive(isActive);
    }
}
