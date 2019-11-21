using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    Text timerText;
    public static float timeLeft = 240f; //Static ώστε να καλείται από την ίδια την κλάση σε άλλα script.

    void Awake()
    {
        timerText = GetComponent<Text>(); //Του λέμε να διαβάσει το component Text.       
    }

    void Update()
    {
        timeLeft -= Time.deltaTime; //Μειώνει το χρόνο που έχει απομείνει για να τελειώσει το παιχνίδι.

        if (timeLeft >= 0)
        {
            timerText.text = "Time:" + (int)timeLeft; // Κάνει Update τον χρόνο με int cast
                                                      // στο text και επομένως στην οθόνη μας.
        }
    }
}