using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Lives;
    public int startLives = 5;

    public static int Waves;

    // Start is called before the first frame update
    void Start()
    {
        Lives = startLives;
        
        Waves = 0;
    }
    
    

}
