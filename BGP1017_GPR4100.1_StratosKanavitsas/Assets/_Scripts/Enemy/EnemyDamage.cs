using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int attackDamage = 20;          // Η ζημιά ανά επίθεση.
    public float timeToDamage = 1f;        // Ο χρόνος ανάμεσα στις επιθέσεις
    bool playerInRange;                       // Η ακτίνα δράσης του Enemy. Boolean κλασσικά.
    float timer;                              // Χρονόμετρο ανάμεσα στις επιθέσεις

    AudioSource playerHurt;                //To AudioSource μου βλέπε PlayerMovement.pickUpAudio για πληροφορίες                           

    GameObject player;                          
    PlayerHealth playerHealth;                

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Ορίζω τον παίκτη

        playerHealth = player.GetComponent<PlayerHealth>();  //... και την ζωή του

        playerHurt = GetComponent<AudioSource>();            //... και τον ήχο όταν τον χτυπά ο Enemy.

    }

    void OnTriggerEnter(Collider other)   
    {
        if (other.gameObject == player) //Ελέγχουμε αν ο παίκτης έχει μπει στο Trigger Collider του Enemy
        {
            playerInRange = true;       //...Και το ορίζουμε true.
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player) //Ελέγχουμε αν ο παίκτης βγήκε από το Trigger Collider του Enemy
        {
            playerInRange = false;      //...και το ορίζουμε false.
        }
    }

    void Update()
    {
        timer += Time.deltaTime; //Ξεκινάει το χρονόμετρο για να ελέγχουμε τον χρόνο των επιθέσεων
                                 // με αποτέλεσμα στην πρώτη επαφή να πέσει και η πρώτη φάπα. :D
        if (timer >= timeToDamage && playerInRange)
        {
            Attack();            //Κάθε φορά που γίνεται η επίθεση καλέιται η μέθοδος attack.
        }
    }


    void Attack()
    { 
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage); //Κάνει όσο damage έχουμε ρυθμίσει στον παίκτη.
            playerHurt.Play();                     //Παίζει τον ήχο όταν χτυπάει τον παίκτη.
        }

        timer = 0f;                               //Μηδενίζουμε το timer μετά από κάθε attack
    }
}