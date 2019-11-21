using UnityEngine;

//Προτείνεται zoom level 130% για καλύτερο διάβασμα των comments.
public class PlayerMovement : MonoBehaviour
{
    /* Η κίνηση του παίκτη μας που είναι παιδί της κλάσης Monobehaviour(ατομική συμπεριφορά σημαίνει και είναι
     * η Βασική κλάση από την οποία αντλείται κάθε script της Unity όταν προγραμματίζουνε σε C#.) */
    
    public float speed = 8f; // Η ταχύτητα που κινείται ο παίκτης.
    Vector3 movement;        //Το διάνυσμα μου αποθηκεύει την κατεύθυνση της κίνησης του παίκτη.

    Rigidbody playerRigidbody;
    public Vector3 jump;
    public float jumpForce = 6.0f;
    public bool isGrounded;       //Έλεγχος με collider αν το σώμα του παίκτη μας είναι στο έδαφος.

    AudioSource pickUpAudio; // Λόγω "τεχνικών δυσκολιών" φορτώνω το pickUpAudio στον παίκτη και το
                             // playerHurt στους Enemy. Αλλιώς θα ήταν playerHurt εδώ. 

    private int scoreValue = 100; //Δηλώνω πόσους πόντους πέρνει ο παίκτης κάνοντας συγκεκριμένες ενέργειες
                                  //σε Private γιατί χρησιμοποιέιται μόνο από αυτό το script.

    float h;         //Δηλώνω από την αρχή τις μεταβλητές κίνησης για καλύτερο optimization του παιχνιδιού.
    float v;

    // Η μέθοδος Awake συμβαίνει μία φορά μόνο στην αρχή του script μας. Επίσης, χρησιμοποιείται για να φορτώσει
    // όλες τις μεταβλητές πριν ξεκινήσει το παιχνίδι.
    void Awake()
    {
        Debug.Log("There has been an Awakening. Have you felt it?"); /* Στέλνουμε μήνυμα στην κονσόλα ότι ξεκίνησε το script και 
        είμαστε στη φάση του Awake. Star Wars reference.
        Για να δούμε την κονσόλα στη Unity, πατάμε CTRL+SHIFT+C ή πάμε
        Window->Console και κάνουμε drag'n'drop το παράθυρο της κονσόλας δίπλα στο #scene.*/

        pickUpAudio = GetComponent<AudioSource>(); //Βάζω εδώ το AudioSource component.

        playerRigidbody = GetComponent<Rigidbody>(); /* Ψάχνει τα properties του GameObject μας για ένα rigidBody
            και βάζει τα στοιχεία του στο playerRigidbody που έχουμε δημιουργήσει πιο πριν. */

        jump = new Vector3(0.0f, 3.0f, 0.0f);  // Ρυθμίζω τις παραμέτρους του Jump.
    }

    /* Η μέθοδος FixedUpdate γίνεται 50 φορές το δευτερόλεπτο και την χρησιμοποιούμε 
     * σε αντικείμενα που έχουν rigidBody component(δηλαδή μεταβάλονται με φυσική στο χώρο). */
    void FixedUpdate()
    {
        /* Διαβάζει αν ο χρήστης δίνει εντολή μέσω keyboard/controller για
        οριζόντια ή κάθετη κίνηση και το αποθηκεύει στις αντίστοιχες μεταβλητές τις οποίες χρησιμοποιεί 
        για να κινείται με την μέθοδο Move.*/
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical"); 

        Move(h, v);  //Η κίνηση του παίκτη μας

        //Για να γίνει το jump πρέπει να έχουμε τουλάχιστον 1 energy και να είμαστε προσγειωμένοι.
        if (Input.GetKeyDown(KeyCode.Space)&& isGrounded && EnergyManager.energyCounter>=1)
        {
            playerRigidbody.AddForce(jump * jumpForce, ForceMode.Impulse);
            EnergyManager.energyCounter--; //Αφαιρούμε 1 energy μετά από κάθε Jump.
        }

        if(Input.GetKey(KeyCode.LeftShift)) //TODO: Controller mapping && energyConsumption/s
        {                                   //                           (note:energy=int, Time=float)
            speed = 12f;  //Όσο είναι πατημένο το LeftShift τόσο επιταγχύνει ο παίκτης μας.
        }
        else
        {
            speed = 8f;  //...Αλλιώς είναι πάντα σταθερή.
        }
    }
    // Αυτή η μέθοδος αντιλαμβάνεται πότε ο παίκτης μας έρχεται σε επαφή με ένα άλλο Object.
    // Γίνεται από το trigger του capsule collider.
    void OnCollisionEnter(Collision hit)
    {
        //Για βελτιστοποίηση του κώδικα ίσως είναι καλύτερο να γίνει με switch/case construct
        if (hit.gameObject.name == "Floor")
        {
            isGrounded = true; //Δηλώνει ότι υπάρχει επαφή με το πάτωμα
                               //Debug.Log("Player has landed");
        }
        if(hit.gameObject.name=="PickUp")
        {
            Destroy(hit.gameObject);       //To καταστρέφει.Θα μπορούσαμε να το κάνουμε και deactivate.
            EnergyManager.energyCounter++; //Ανεβάζει την ενέργεια του παίκτη μας κάθε φορά που πέρνουμε ένα PickUp.
            ScoreManager.scoreCount+=scoreValue; //Aνεβάζει το Score μας.
            pickUpAudio.Play();                 //Παίζει τον ήχο του PickUp.
        }
        if (hit.gameObject.name == "GoldenSun")  //Golden Sun λέω το finish της πίστας.
        {
            Destroy(hit.gameObject);
            GameOverManager.goldenSunPicked = true; //Το κάνω true για να παίξει το animation της νίκης.
            ScoreManager.scoreCount += 3000;        //Είμαι large. Το γνωρίζω.
        }
        
    }

    // Αντίστοιχα με το που σταματήσει η επαφή του παίκτη.gameobject με το πάτωμα αλλάζει το isGrounded για να
    // μην μπορεί να κάνει διπλό jump ο παίκτης.
    void OnCollisionExit(Collision hit)
    {
        if (hit.gameObject.name == "Floor")
        {
            isGrounded = false;            //Το βάζω false από εδώ για να γίνεται σίγουρα μόνο μία φορά. 
        }
      //Note: Έπρεπε να βάλω και ="Wall" ώστε να πηδάει και όταν είναι πάνω στους τοίχους αλλά "τεχνικές δυσκολίες".
    }
    /* Δεν γνωρίζω αν είναι καλύτερα να έχω το isGrounded σε OnCollisionStay, το αφήνω σαν comment όπως και να έχει.
     * 
     * void OnCollisionStay()
    {
        if (hit.gameObject.name == "Floor")
        {
            isGrounded = true;            //Όσο έχει επαφή με το πάτωμα ο παίκτης είναι grounded. 
        }
    }
    */

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v); //Θέτουμε τις παραμέτρους κίνησης σε vector3 με τρόπο ιδανικό για την ισομετρική Camera.

        movement = movement.normalized * speed * Time.deltaTime; /*Όλες αυτές οι παράμετροι είναι για να ομαλοποιηθεί
        * η κίνηση του παίκτη. To .normalized κάνει ακέραιο τα h,v. To speed μας δείχνει την ταχύτητα και το
        * Time.deltaTime μας σιγουρεύει ότι η κίνηση θα γίνεται βάση του χρόνου και όχι βάση του frame.*/

        playerRigidbody.MovePosition(transform.position + movement); /*Εδώ γίνεται η κίνηση του παίκτη μας. Αν
        * θέλαμε π.χ. να μην κινείται όταν πηδάει θα το βάζαμε σε συνθήση if(isGrounded)*/
    }
}
