using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI pointsText;

    void Start()
    {
        pointsText.text = "Points: 0";
    }


    void Update()
    {
        
    }
}
