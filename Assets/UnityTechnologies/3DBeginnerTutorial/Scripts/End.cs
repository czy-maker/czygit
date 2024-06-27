using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    bool m_IsPlayerAtExit;
    public GameObject player;

    public float fadeDuration = 1.0f;
    float m_Timer;
    public float displayImageDuration = 1.0f;
    public CanvasGroup exitBackgroundimageCanvasGroup;

    public CanvasGroup CaughtgroundimageCanvasGroup;
    bool m_IsCaughtPlayer;
    public void CaughtPlayer()
    {
        m_IsCaughtPlayer = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsPlayerAtExit)
        {
            EndLevel(exitBackgroundimageCanvasGroup,false);
        }
        else if(m_IsCaughtPlayer)
        {
            EndLevel(CaughtgroundimageCanvasGroup,true);
        }
    }
    void EndLevel(CanvasGroup imageCanvasGroup,bool doRestart)
    {
        m_Timer += Time.deltaTime;
       imageCanvasGroup.alpha = m_Timer / fadeDuration;
        if (m_Timer > fadeDuration + displayImageDuration)
        {
            /*        Application.Quit();*/
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
