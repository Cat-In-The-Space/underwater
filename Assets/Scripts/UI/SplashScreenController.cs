using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_CLOUD_SERVICES_ANALYTICS
using UnityEngine.Analytics;
#endif
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SplashScreenController : MonoBehaviour
{
    public AudioSource[] waitAudio;
    public Image splashScreen;
    public bool showSplashAtStart = false;
    public float t;
    public float speed;

    Color visible;
    Color invisible;
    bool sceneReady;
    bool newSceneReady;

    AsyncOperation loadSceneResult = null;
    public void LoadScene(string sceneName)
    {
        if (loadSceneResult != null)
        {
            return;
        }

        #if ENABLE_CLOUD_SERVICES_ANALYTICS
        Analytics.CustomEvent("loadScene", new Dictionary<string, object> { 
            { "name",sceneName } 
        });
        #endif

        splashScreen.color = invisible;
        splashScreen.gameObject.SetActive(true);
        t = 0.0f;
        newSceneReady = false;

        loadSceneResult = SceneManager.LoadSceneAsync(sceneName);
        loadSceneResult.allowSceneActivation = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        visible = splashScreen.color;
        visible.a = 1.0f;
        invisible = splashScreen.color;
        invisible.a = 0.0f;

        if (showSplashAtStart)
        {
            splashScreen.color = visible;
            splashScreen.gameObject.SetActive(true);
            t = 0.0f;
            sceneReady = false;
        }
        else
        {
            splashScreen.color = invisible;
            splashScreen.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (showSplashAtStart && !sceneReady)
        {
            splashScreen.color = Color.Lerp(visible, invisible, t * speed);
            t += Time.deltaTime;
            if (splashScreen.color == invisible)
            {
                splashScreen.gameObject.SetActive(false);
                sceneReady = true;
            }
        }
        if (loadSceneResult != null && !newSceneReady)
        {
            splashScreen.color = Color.Lerp(invisible, visible, t * speed);
            t += Time.deltaTime;

            bool audioDone = true;
            foreach (AudioSource audio in waitAudio)
            {
                if (audio.isPlaying)
                {
                    audioDone = false;
                    break;
                }
            }
            if (splashScreen.color == visible && audioDone)
            {
                newSceneReady = true;
                loadSceneResult.allowSceneActivation = true;
            }
        }
    }
}
