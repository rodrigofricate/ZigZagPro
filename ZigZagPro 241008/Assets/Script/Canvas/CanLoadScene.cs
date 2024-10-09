using System.Collections;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanLoadScene : MonoBehaviour
{
    [SerializeField] Text txtLoadPercentage;
    public int sceneBuilderRef;
    [SerializeField] Image imgLoadProgressBar;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
    }


    public void LoadScene()
    {
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneBuilderRef, LoadSceneMode.Single);

        gameObject.GetComponent<Canvas>().enabled = true;

        while (!asyncLoad.isDone)
        {
            txtLoadPercentage.text = (asyncLoad.progress * 100.0f).ToString("00") + "%";
            imgLoadProgressBar.fillAmount = asyncLoad.progress;
            yield return null;
        }

    }
}
