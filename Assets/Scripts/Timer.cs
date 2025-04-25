using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLimit = 60f;
    public TextMeshProUGUI timerText;
    public GameObject[] tasks;
    private int currentTaskIndex = 0;
    private float timeRemaining;
    private bool isTimerRunning = false;

    void Start()
    {
        timeRemaining = timeLimit;
        UpdateTimerText();
        ShowTask(currentTaskIndex);
    }

    void Update()
    {
        if (isTimerRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                timeRemaining = 0;
                isTimerRunning = false;
                EndChallenge();
            }
        }
    }

    void UpdateTimerText()
    {
        timerText.text = "Temps restant : " + Mathf.Round(timeRemaining).ToString() + "s";
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void NextTask()
    {
        if (currentTaskIndex < tasks.Length - 1)
        {
            currentTaskIndex++;
            ShowTask(currentTaskIndex);
        }
        else
        {
            EndChallenge();
        }
    }

    void ShowTask(int index)
    {
        for (int i = 0; i < tasks.Length; i++)
        {
            tasks[i].SetActive(i == index);
        }
    }

    void EndChallenge()
    {
        // Logique de fin de défi (succès ou échec)
        Debug.Log("Défi terminé !");
    }
}
