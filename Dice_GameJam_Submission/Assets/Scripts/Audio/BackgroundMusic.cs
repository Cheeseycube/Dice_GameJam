using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] AudioClip MainMenuMusic;
    [SerializeField] AudioClip MainTheme;

    AudioSource myAudio;
    private int level1 = 2;
    // Start is called before the first frame update
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void AudioToggle()
    {
        AudioListener.pause = !AudioListener.pause;
    }
    private void Awake()
    {
        int numMusic = FindObjectsOfType<BackgroundMusic>().Length;
        if (numMusic > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        // you can check the index and change the audio to whatever you want, this is just an example
        if ((SceneManager.GetActiveScene().buildIndex == 2))
        {
            // should play boss music
            myAudio.clip = MainTheme;
            myAudio.Play();
        }
    }
}
