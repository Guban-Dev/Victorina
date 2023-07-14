using UnityEngine;
using UnityEngine.UI;
using TMPro;
using YG;
using Assets.Scripts;

public class Saver : MonoBehaviour
{
    private GameManager _gameManager;
    private SoundManager _soundManager;

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Start() {
        _gameManager =  GetComponent<GameManager>();
        _soundManager = GetComponent<SoundManager>();
    }

    private void Awake()
    {
        if (YandexGame.SDKEnabled)
            GetLoad();
    }

    public void Save()
    {
        for(int i = 0; i < PointManager.points.Length; i++)
        {
            YandexGame.savesData.points[i] = PointManager.points[i];
            YandexGame.savesData.SpeedPoints[i] = PointManager.SpeedPoints[i];
        }

        YandexGame.savesData.MusicOn = _soundManager.MusicOn;

        YandexGame.savesData.RangID = _gameManager._numberRunk;

        YandexGame.SaveProgress();
    }

    public void Load() => YandexGame.LoadProgress();

    public void GetLoad()
    {
        for (int i = 0; i < PointManager.points.Length; i++)
        {
            PointManager.points[i] = YandexGame.savesData.points[i];
            PointManager.SpeedPoints[i] = YandexGame.savesData.SpeedPoints[i];
        }

        for(int i = 0; i < _gameManager.Categories.Length; i++)
        {
            _gameManager.QuestGuessedTxt[i].text = YandexGame.savesData.points[i].ToString() + "/" + _gameManager.QuestionsCount[i].ToString();
        }
        _gameManager._numberRunk = YandexGame.savesData.RangID;
        _gameManager.CheckRank();
        _gameManager.LevelManager();
        PointManager.instance.SetScoreSpeedTxt();
        PointManager.instance.SetTotalPoints();
        PointManager.instance.SetPoitsTxt();
        ExpTrace.instance.SetMaxValue(PointManager.totalPoints);
        ExpTrace.instance.ExpBarUpdate(PointManager.TotalPoints());

        _soundManager.MusicOn = YandexGame.savesData.MusicOn;

        if(_soundManager.MusicOn)
        {
           _soundManager.MusicButton.GetComponent<Image>().sprite = _soundManager.onMusic;
        }
        else if (!_soundManager.MusicOn)
        {
            _soundManager.MusicButton.GetComponent<Image>().sprite = _soundManager.offMusic;
        }
    }
}