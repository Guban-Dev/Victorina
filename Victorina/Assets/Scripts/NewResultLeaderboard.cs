using UnityEngine;
using UnityEngine.UI;
using YG;

public class NewResultLeaderboard : MonoBehaviour
{
    [Header("Set in Inspector")]
    [SerializeField] LeaderboardYG leaderboardYG;

    private void OnEnable() => PlayerEventManager.onUpdatedSpeedPoints += NewScore;
    private void OnDisable() => PlayerEventManager.onUpdatedSpeedPoints -= NewScore;

    public void NewScore(string record)
    {
        // Статический метод добавление нового рекорда
        YandexGame.NewLeaderboardScores(leaderboardYG.nameLB, int.Parse(record));
        // Метод добавление нового рекорда обращением к компоненту LeaderboardYG
        // leaderboardYG.NewScore(int.Parse(scoreLbInputField.text));
        print($"new score {record}");
    }
}
