using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;                            // Η αρχική ζωή του παίκτη μας.
    public int currentHealth;                                   // Η τωρινή ζωή του παίκτη μας.
    
    bool damaged;                                   //Boolean για να ξέρουμε αν ο παίκτης μας παθαίνει ζημιά.

    public Slider healthSlider;                                 // Αναφορά στο UI health bar.
    public Image damageImage;                                   // Αναφορά στην εικόνα που παίζει όταν χάνει ζωή ο παίκτης.

    public float flashSpeed = 5f;                               // Η ταχύτητα με την οποία αναβοσβήνει η εικόνα του damage.
    public Color flashColour;
    
    
    void Awake()
    {
        currentHealth = startingHealth;  
        flashColour = new Color(1f, 0f, 0f, 0.4f);  //Ορίζω το alpha που θέλω να έχει η εικόνα μου στο 0.4 του αρχικού.
    }

    void Update()
    {
        if (damaged)
        {        
            damageImage.color = flashColour;                         //Ορίζουμε το χρώμα της οθόνης για να φωτίσει
        }
        else
        {
            damageImage.color =                                      //...και πάντα καθαρίζουμε το χρώμα της οθόνης
                Color.Lerp
                (
                    damageImage.color, Color.clear, flashSpeed * Time.deltaTime
                );
        }

        damaged = false;             //Επαναφέρουμε το χρώμα της εικόνας μας.
    }


    public void TakeDamage(int amount)
    {
        damaged = true;                   //Δηλώνουμε τον παίκτη χτυπημένο ώστε να αναβοσβήσει η οθόνη.

        currentHealth -= amount;          // Η ζωή του παίκτη μειώνεται.

        healthSlider.value -= amount;     //...και η μπάρα της ζωής μειώνεται ανάλογα.
    }
}
