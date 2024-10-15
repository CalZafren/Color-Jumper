using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(){
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame(){
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
