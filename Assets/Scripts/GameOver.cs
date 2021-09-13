using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject warningText;
    [SerializeField] private GameObject objectiveText;
    private void Update()
    {
        if (Clues.clues == 4)
        {
            objectiveText.SetActive(true);
        }
    }

    /// <summary>
    /// This code is by Unity
    /// </summary>
    /// <param name="collider">This parameter allows collider2D to be called and grabs its accessors.</param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player" && Clues.clues == 4)
        {
            SceneManager.LoadScene("Win");
        }
        else
        {
            StartCoroutine(WarningTextUI());
        }
    }

    /// <summary>
    /// Just a routine to allow text to appear and disapear
    /// </summary>
    /// <returns> No returns just a return when time reaches in real time.</returns>
    IEnumerator WarningTextUI()
    {
        warningText.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        {
            warningText.SetActive(false);
        }
    }
}
