using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    [SerializeField]
    private Image load;
    [SerializeField]
    private TextMeshProUGUI label;
    public AsyncOperation asyncOperation;
    [SerializeField]
    private GameObject loadImage, labelText;

    private void OnEnable()
    {
        ButtonManager.SceneLoad += StartLoad;
    }

    private void OnDisable()
    {
        ButtonManager.SceneLoad -= StartLoad;
    }

    void Start()
    {
        loadImage.SetActive(false);
        labelText.SetActive(false);
    }

    void Update()
    {
        if (asyncOperation != null)
        {
            load.fillAmount = asyncOperation.progress * 0.9f;
            label.text = Mathf.Round((asyncOperation.progress * 0.9f * 100)) + "%";
        }
    }

    public void StartLoad(Scenes scene)
    {
        loadImage.SetActive(true);
        labelText.SetActive(true);
        asyncOperation = SceneManager.LoadSceneAsync(scene.ToString());
    }
}
