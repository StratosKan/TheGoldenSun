using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {
    public Transform[] patrolTargets; //Εδώ μπορούμε να χρησιμοποιήσουμε και Vector3. Προτίμησα Transform για να μην
                                      // μπλέξω με διανύσματα.
    private int currentTarget; // Βάζω private γιατί χρησιμοποιείται μόνο εδώ η μεταβλητή.
    public float moveSpeed;
    
    void Start ()
    {    
        transform.position = patrolTargets[0].position; /*Αποθηκεύουμε τη θέση του αντικειμένου που έχει αυτό το script
        στην πρώτη θέση του array*/

        currentTarget = 0; //πρώτο σημείο του enemy είναι το patrolTarget/Point και τελευταίο το αρχικό του Position.       
	}
		
	void Update ()
    {        /*Κλασσικό Boolean που κοιτάζει αν η θέση του Object μας είναι ίδια με του στόχου μας στο χώρο
         Μπορούσαμε να κάνουμε διάφορα κόλπα άμα χρησιμοποιούσαμε Vector3.Distance()<0.5f εδώ, αλλά προτίμησα Transform.*/
        if (transform.position == patrolTargets[currentTarget].position) 
        {
            currentTarget ++;
            
            if (currentTarget >= patrolTargets.Length) //Ήθελε φιξ για error: array is out of index. note:(array=arrayLength+1 )
            {
                currentTarget = 0; // #Logic-Bugfix2k18
            }
        }
        // To Vector3.MoveTowards είναι ένα πολύ ωραίο command για μετακίνηση στο χώρο
        transform.position = 
          Vector3.MoveTowards
              (
              transform.position, patrolTargets[currentTarget].position, moveSpeed * Time.deltaTime
              );
                
    }
}
