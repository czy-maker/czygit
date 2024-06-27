using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class myEnd : MonoBehaviour


{
    bool m_IsPlayerAtExit;
    public GameObject player;
    public float fadeDuration = 1.0f;
    float m_Timer;

    public float displayImageDuration = 1.0f;
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public Image image;


    bool m_IsPlayercaught;
    Sprite spriteCaught;
    Sprite spriteWon;
    public AudioSource exitAudio;
    public AudioSource caughtAudio;
    bool m_HasAudioPlayed;
    // Start is called before the first frame update
    void Start()
    {
        spriteCaught = Resources.Load<Sprite>("Caught");
        spriteWon = Resources.Load<Sprite>("Won");
    }
    public void CaughtPlayer()
    {
        m_IsPlayercaught = true;

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject== player){
            m_IsPlayerAtExit = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(spriteWon, false,exitAudio);
        }
        else if (m_IsPlayercaught)
        {
            EndLevel(spriteCaught, true,caughtAudio);
        }
    }
     void EndLevel(Sprite sprite, bool doRestart,AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        
            m_Timer += Time.deltaTime;
            image.sprite = sprite;
            exitBackgroundImageCanvasGroup.alpha = m_Timer / fadeDuration;
            if (m_Timer > displayImageDuration + fadeDuration)
            {
                if (doRestart)
                {
                    SceneManager.LoadScene(0);

                }
                else
                {
                    Application.Quit();
                }
            }

        
    }
}
