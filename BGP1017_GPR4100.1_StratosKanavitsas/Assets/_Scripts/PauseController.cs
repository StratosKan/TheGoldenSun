using UnityEngine;

public class PauseController : MonoBehaviour
{
    //Το PauseController μπορούσα να το κάνω με διάφορους τρόπους αλλά επέλεξα τον πιο ανορθόδοξο
    // αλλά και πιο σίγουρο ότι θα μου λειτουργήσει σωστά όταν το χρειαστώ.

    public GameObject PauseArea; //Δημιουργώ νέο GameObject

	void Awake ()
    {
        PauseArea = GameObject.Find("PauseArea"); //Το ορίζω απευθείας από το script
        PauseArea.SetActive(false);               //Το απενεργοποιώ για σιγουριά (αλλιώς το βάζω inactive από την αρχή)
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //TODO: GetButtonDown("Cancel") για χρήση controller
        {
            if (Time.timeScale == 1) // timeScale για έλεγχο του pause μιας και δεν αλλάζει κατά τη 
            {                         //  διάρκεια του παιχνίδιου, εκτός από το ίδιο το pause.
                PauseArea.SetActive(true);
                Time.timeScale = 0;
            }
            else if (Time.timeScale == 0) //Και επαναφορά του παιχνιδιού αν πατηθεί ξανά.
            {
                PauseArea.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }
    public void ResumeOnClick () //Click functionality για το pauseMenu.
    {
       Time.timeScale = 1;
       PauseArea.SetActive(false);
    }
}
