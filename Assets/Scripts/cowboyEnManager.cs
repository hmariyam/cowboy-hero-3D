using UnityEngine;
using UnityEngine.UI;
using TMPro;
//Leen Al Harash

public class cowboyEnManager : MonoBehaviour {
    public static int cowboyEnemyCount;
    [SerializeField] private TMP_Text cowboyEnemyText;

    private void Start() {
        cowboyEnemyCount = GameObject.FindGameObjectsWithTag("cowboyEnemie").Length;
        UpdateCounterText();
    }

    public static void DecreaseEnemyCount() {
        cowboyEnemyCount--;
        Debug.Log("Enemies left:" + cowboyEnemyCount);

        cowboyEnManager instance = FindObjectOfType<cowboyEnManager>();
        if (instance != null) {
            instance.UpdateCounterText();
        }
    }

    //Affichage
    private void UpdateCounterText() {
        if (cowboyEnemyText != null) {
            cowboyEnemyText.text = ":" + cowboyEnemyCount;
        }
    }
}