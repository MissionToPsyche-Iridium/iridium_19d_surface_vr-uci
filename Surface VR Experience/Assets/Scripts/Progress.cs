using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Progress : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI progressText;
    private string curScene;

    // Start is called before the first frame update
    void Start()
    {
        progressText.text = string.Format("0%");
        curScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.Instance != null)
        {
            int progress = GameState.Instance.get_progress(curScene);
            progressText.text = $"{progress}%";
        }
    }
}
