using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;

public class CluesCollectible : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI UItext;
    
    public void TextPopUp()
    {
        UItext.text = "Press E to pick up!";

        if (Input.GetKeyDown(KeyCode.E))
        {
            Clues.clues += 1;
            Destroy(gameObject); 
        }
    }
    
}
