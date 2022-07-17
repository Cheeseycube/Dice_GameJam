using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScore : MonoBehaviour
{
    TextMeshProUGUI TextPro;
    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        TextPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
       TextPro.text = score.ToString();
    }
}
