using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class ClueUI : MonoBehaviour
    {
        public GameObject collectibleCluesCount;
        private void Update()
        {
            collectibleCluesCount.GetComponent<TextMeshProUGUI>().text = Clues.clues + "/4 Clues remain";
        }
        
        
    }
}