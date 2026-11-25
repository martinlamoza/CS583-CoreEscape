
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalCores = 3;

    private int collectedCores = 0;
    private bool gameWon = false;

    public void CollectCore()
    {
        collectedCores++;
    }

    public bool AllCoresCollected()
    {
        return collectedCores >= totalCores;
    }

    public void WinGame()
    {
        gameWon = true;
    }

    // Display the player's current progress
    void OnGUI()
    {
        GUIStyle style = new GUIStyle(GUI.skin.label);
        style.fontSize = 24;
        style.normal.textColor = Color.white;

        GUI.Box(new Rect(15, 15, 260, 90), "");

        GUI.Label(new Rect(30, 25, 240, 35),
            "Energy Cores: " + collectedCores + " / " + totalCores,
            style);

        GUI.Label(new Rect(30, 60, 240, 30),
            AllCoresCollected() ? "Find the exit!" : "Collect all energy cores");

        // Display the victory screen
        if (gameWon)
        {
            GUIStyle winStyle = new GUIStyle(GUI.skin.label);
            winStyle.fontSize = 36;
            winStyle.alignment = TextAnchor.MiddleCenter;
            winStyle.normal.textColor = Color.green;

            GUI.Box(new Rect(
                Screen.width / 2f - 180,
                Screen.height / 2f - 60,
                360, 120), "");

            GUI.Label(new Rect(
                Screen.width / 2f - 180,
                Screen.height / 2f - 50,
                360, 70), "YOU ESCAPED!", winStyle);
        }
    }
}
