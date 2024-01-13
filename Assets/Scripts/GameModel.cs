using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameModel", menuName = "Crembo Factory / Game Model")]
public class GameModel : ScriptableObject
{
    public Action ChangedWrapped;
    public Action ChangedMissed;
    
    private int _wrappedCrembo;
    private int _missedCrembo;

    public void IncreaseWrappedCrembo()
    {
        _wrappedCrembo++;
        ChangedWrapped?.Invoke();
        PlayerPrefs.SetInt("_wrappedCrembo", _wrappedCrembo);
    }

    public void IncreaseMissedCrembo()
    {
        _missedCrembo++;
        ChangedMissed?.Invoke();
        PlayerPrefs.SetInt("_missedCrembo", _missedCrembo);

    }

    public void ResetCount()
    {
        _missedCrembo = 0;
        _wrappedCrembo = 0;
    }

    public int WrappedCrembos => _wrappedCrembo;
    public int MissedCrembo => _missedCrembo;
}
