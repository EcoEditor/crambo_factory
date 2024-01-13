using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Ending_score_set : MonoBehaviour
{
    [SerializeField] private int _wrappedCrembo = 0;
    [SerializeField] private int _missedCrembo = 0;
    [SerializeField] private TMP_Text wrappedCount;
    [SerializeField] private TMP_Text missedCount;
    // Start is called before the first frame update
    void Start()
    {
        _wrappedCrembo = PlayerPrefs.GetInt("_wrappedCrembo");
        _missedCrembo = PlayerPrefs.GetInt("_missedCrembo");
        wrappedCount.text = _wrappedCrembo.ToString();
        missedCount.text = _missedCrembo.ToString();

    }

}
