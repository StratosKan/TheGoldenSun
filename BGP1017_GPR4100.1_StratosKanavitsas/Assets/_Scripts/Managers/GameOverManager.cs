using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{

    PlayerHealth playerHealth;                      //Αναφορά στο PlayerHealth class.
    PlayerMovement playerMovement;                  //Αναφορά στο PlayerMovement class.
    GameObject player;

    Animator anim;                                   //Δημιουργία animator class.
    
    public static bool goldenSunPicked;              //Static ώστε να έχουμε πρόσβαση μέσω της κλάσης.

    private float menuTimer;                         //Χρονόμετρο που ξεκινάει αφότου κερδίσει/χάσει ο παίκτης.
    private float menuDelay = 5f;                    //Το χρονικό όριο για να τελειώσει η πίστα.

    void Awake()
    {
        anim = GetComponent<Animator>();                     //Δίνουμε στο animator class πρόσβαση στον animator.

        player = GameObject.FindGameObjectWithTag("Player");  //Ορίζουμε τον παίκτη.

        playerMovement = player.GetComponent<PlayerMovement>(); //...δίνουμε πρόσβαση στο PlayerMovement script
        
        playerHealth = player.GetComponent<PlayerHealth>();     //...και στο PlayerHealth script
        
        goldenSunPicked = false;  //Ορίζω εξ αρχής το boolean false αν και είναι περιττό.
    }
    
    void LateUpdate()  
    {
        if (goldenSunPicked)            //Όταν φτάσει ο παίκτης μας στο φινάλε
        {
            anim.SetTrigger("GameWon");  //...παίζει το animation για το GameWon
            MenuCountDown();              //...και ξεκινάει η αντίστροφη μέτρηση για να πάμε στο μενού
        }
        if (TimeManager.timeLeft <= 0)  //Αντίστοιχα όταν τελειώσει ο χρόνος
        {
            anim.SetTrigger("GameOver");
            MenuCountDown();
        }
        if (playerHealth.currentHealth <= 0) //...και όταν η ζωή του μηδενιστεί.
        {
            anim.SetTrigger("GameOver");
            MenuCountDown();
        }
        
    }
    private void MenuCountDown()
    {
        playerMovement.enabled = false; //Παγώνει τo script που δίνει κίνηση στον παίκτη μας.

        menuTimer += Time.deltaTime; //Με το που γίνει το animation του GameOver/Won ξεκινάει
                                     // το χρονόμετρο
        if (menuTimer >= menuDelay)  //...και όταν ξεπεράσει το delay που έχω ορίσει
        {
            SceneManager.LoadScene("MenuScene"); //...φορτώνει το μενού.
        }
    }
}
