using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldenSunSpawnManager : MonoBehaviour {

    public Transform[] goldenSunSpawns;
    int min = 1;
    int max = 3;                       //Θέλουμε το 3 να είναι max αλλά επειδή χρησιμοποιούμε Random.Range με int
                                       //το max value είναι πάντα exclusive.
    int LuckOfTheDraw;
    public Transform GoldenSun;
    
    void Start ()
    {
        //Χρησιμοποιώ for για να μεγαλώσω την τύχη του ζαριού.
        for (int i=0; i<3; i++)  // Το τυχερό 7άρι.
        {
            LuckOfTheDraw = Random.Range(min, max);
            Debug.Log(LuckOfTheDraw);
        }

        GoldenSun = goldenSunSpawns[LuckOfTheDraw];
        //GoldenSunPosition();
        //goldenSun.transform.position=goldenSunSpawns[LuckOfTheDraw].position;
        //Instantiate(GoldenSun, goldenSunSpawns[LuckOfTheDraw].position,Quaternion.identity);

    }
    /*private void GoldenSunPosition()
    {
        switch (LuckOfTheDraw)
        {
            case 1: Instantiate(GoldenSun, goldenSunSpawns[1], Quaternion.identity); break;

            case 2: Instantiate(GoldenSun, goldenSunSpawns[2], Quaternion.identity); break;

            case 3: Instantiate(GoldenSun, goldenSunSpawns[3], Quaternion.identity); break;

        }
    }
	*/
}
