using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillText : MonoBehaviour
{
    [SerializeField] private Image killText;
    Color32 imageColor;

    private float fadeSpeed = 0.001f;
    private bool mayFade = false;
    // Start is called before the first frame update
    void Start()
    {
        imageColor = killText.color;
        imageColor = new Color32(imageColor.r, imageColor.g, imageColor.b, 255);
        killText.color = imageColor;
        StartCoroutine(fadeOutTimer());
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    private void FixedUpdate()
    {
        if (mayFade)
        {
            fadeOut();
        }
    }

    private void fadeOut()
    {
        if (imageColor.a > 3)
        {
            imageColor = new Color32(imageColor.r, imageColor.g, imageColor.b, (byte)(imageColor.a - fadeSpeed));
            killText.color = imageColor;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    IEnumerator fadeOutTimer()
    {
        yield return new WaitForSeconds(3f);
        mayFade = true;
    }
}
