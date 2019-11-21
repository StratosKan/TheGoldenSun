using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour {
    //Iδιο script με ScoreManager με διαφορετικό Pivot/Position.
    //Θα μπορούσαμε επίσης να την κάνουμε Generic Class για χρήση και στα δύο script.

    public static int energyCounter; //Static ώστε να καλείται από την ίδια την κλάση σε άλλα script.
    Text text;

    void Awake()
    {
        text = GetComponent<Text>(); //Του λέμε να διαβάσει το component Text.
        energyCounter = 0;
    }
    
    void Update ()
    {
        text.text = "Energy " + energyCounter; // Κάνει Update το Score στο text και επομένως στην οθόνη μας.
    }
}
