using UnityEngine;
using System.IO;
using TMPro;

public class LevelTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public string levelName = "Level1";

    private float timer = 0f;
    private bool isRunning = true;

    private string customFolderPath = @"C:\Users\Win10\Documents\GitHub\Cube-s-Dungeon-atestat-\Cube's Dungeon\LevelTimes";

    string filePath => Path.Combine(customFolderPath, levelName + "_time.txt");

    void Start()
    {
        timer = 0f;
        isRunning = true;

        Directory.CreateDirectory(customFolderPath);
    }

    void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;
            timerText.text = "Time: " + timer.ToString("F2") + "s";
        }
    }

    public void StopTimer()
    {
        if (!isRunning) return;
        isRunning = false;

        float finalTime = timer;
        Debug.Log("Final time: " + finalTime.ToString("F2"));

        SaveIfBestTime(finalTime);
    }

    void SaveIfBestTime(float newTime)
    {
        float bestTime = float.MaxValue;

        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath).Replace(" seconds", "").Trim();

            if (!string.IsNullOrEmpty(content) && float.TryParse(content, out float savedTime))
            {
                bestTime = savedTime;
            }
            else
            {
                Debug.LogWarning("Existing file is empty or invalid. Will overwrite.");
            }
        }

        if (newTime < bestTime)
        {
            File.WriteAllText(filePath, newTime.ToString("F2") + " seconds");
            Debug.Log("New best time saved to: " + filePath);
        }
        else
        {
            Debug.Log("Slower than best time. Not saved.");
        }
    }
}