using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    [SerializeField]
    private Color availableColor;
    private Color usedColor = Color.red;
    private int shotsRemaining = 3;
    [SerializeField]
    private Image shot1;
    [SerializeField]
    private Image shot2;
    [SerializeField]
    private Image shot3;
    private Ammo instance;


    void Awake(){
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(shotsRemaining){
            case 3:
                shot1.color = availableColor;
                shot2.color = availableColor;
                shot3.color = availableColor;
                break;
            case 2:
                shot1.color = usedColor;
                shot2.color = availableColor;
                shot3.color = availableColor;
                break;
            case 1:
                shot1.color = usedColor;
                shot2.color = usedColor;
                shot3.color = availableColor;
                break;
            case 0:
                shot1.color = usedColor;
                shot2.color = usedColor;
                shot3.color = usedColor;
                break;
        }
    }

    public Ammo GetInstance(){
        return instance;
    }

    public int GetRemainingShots(){
        return shotsRemaining;
    }

    public void UseShot(){
        shotsRemaining--;
    }
}
