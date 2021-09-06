using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject warningText;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && Clues.clues == 4)
        {
            
        }
        else
        {
            StartCoroutine(WarningTextUI());
        }
    }

    IEnumerator WarningTextUI()
    {
        warningText.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        {
            warningText.SetActive(false);
        }
    }
}
