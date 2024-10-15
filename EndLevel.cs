using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public string nextLevel;
    private LevelText levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelText>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Player")){
            Debug.Log("Level Complete");
            // Checks to see if this level if the highest level the player has reached so far
            if(levelManager.GetLevel() >= PlayerPrefs.GetInt("levelReached", 1)){
                PlayerPrefs.SetInt("levelReached", levelManager.GetLevel() + 1);
            }
            
            ChangeLevel();

            
        }
    }

    void ChangeLevel(){
        SceneManager.LoadScene(nextLevel);
    }
}
