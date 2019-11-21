using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSlider : MonoBehaviour
{
    AudioSource myAudioSource;
    public Slider mySliderValue;
    
    void Start()
    {
        //Ξεκινάει τη μπάρα του ήχου από τη μέση
        mySliderValue.value = 0.5f;
        //Βάζουμε τα στοιχεία της πηγής του ήχου μας από το αντικείμενο με όνομα BackgroundMusic.
        myAudioSource = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        //Βάζουμε την μουσική μας να παίζει για να μπορεί ο χρήστης να αντιληφθεί την αλλαγή.
        //myAudioSource.Play();
    }

    void Update()
    {
        //Ρυθμίζουμε την ένταση του ήχου να είναι ίδια με την μπάρα μας.
        myAudioSource.volume = mySliderValue.value;
    }
}
