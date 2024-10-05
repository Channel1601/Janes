using UnityEngine;
using UnityEngine.UI;

public class LevelDoneButton : MonoBehaviour
{
    public Sprite levelCompletedSprite;  // Sprite to show when the level is completed
    public Sprite defaultSprite;         // Default sprite for uncompleted levels
    public Image levelButtonImage;       // Reference to the button's Image component

    void Start()
    {
        CheckLevelCompletion();
    }

    void CheckLevelCompletion()
    {
        int currentLevel = 1; // Example: replace with the actual level number
        bool isCompleted = PlayerPrefs.GetInt("Level" + currentLevel + "Completed", 0) == 1;

        // Change the sprite based on level completion status
        if (isCompleted)
        {
            levelButtonImage.sprite = levelCompletedSprite;
        }
        else
        {
            levelButtonImage.sprite = defaultSprite;
        }
    }
}

