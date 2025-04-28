using UnityEngine;
using TMPro;
using System.IO;

public class BestTimeDisplay : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public string[] levelNames = { "Level1", "Level2", "Level3" };

    private string folderPath = @"C:\Users\Win10\Documents\GitHub\Cube-s-Dungeon-atestat-\Cube's Dungeon\LevelTimes";

    public void LoadTimes()
    {
        string result = "";

        foreach (string level in levelNames)
        {
            string path = Path.Combine(folderPath, level + "_time.txt");

            if (File.Exists(path))
            {
                string content = File.ReadAllText(path).Trim();
                result += $"{level}: {content}\n";
            }
            else
            {
                result += $"{level}: Not completed\n";
            }
        }

        displayText.text = result;
    }
}