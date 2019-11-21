using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    //Iδιο script με EnergyManager με διαφορετικό Pivot/Position.
    //Θα μπορούσαμε επίσης να την κάνουμε Generic Class για χρήση και στα δύο script.

    public static int scoreCount; //Static ώστε να καλείται από την ίδια την κλάση σε άλλα script.
    Text text;

	void Awake()
    {
        text = GetComponent<Text>(); //Του λέμε να διαβάσει το component Text.
        scoreCount = 0;              
	}

	void Update ()
    {
		text.text = "Score: "+ scoreCount; // Κάνει Update το Score στο text και επομένως στην οθόνη μας.
    }
}
