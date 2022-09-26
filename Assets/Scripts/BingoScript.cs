using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BingoScript : MonoBehaviour
{

    private List<int> _bingoBowl;
    [SerializeField]
    private int _bowlSize;
    private List<int> _outNumbers;
    [SerializeField]
    private Text _displayText;
    [SerializeField]
    private Text _displayText2;
    [SerializeField]
    private Text _lastNumber;
    [SerializeField]
    private Image _raptor;
    [SerializeField]
    private Sprite _smirk;
    [SerializeField]
    private Sprite _smile;
    [SerializeField]
    private float _raptorTimeGap;
    [SerializeField]
    private InputField _inputBowlSize;
    [SerializeField]
    private List<AudioSource> _raptorSounds = new List<AudioSource>();
    private bool isMuted = false;
   // private AudioSource _raptorSound;

    private void Start()
    {
        FullfullBowl();
        _lastNumber.text = " ";
       
    }

    private void FullfullBowl()
    {
        _bingoBowl = new List<int>() { };
        _outNumbers = new List<int>() { };
        for (int i = 1; i <= _bowlSize; i++)
        {
            _bingoBowl.Add(i);
        }

        DisplayUpdate();
    }

    private string DisplayList(List<int> list)
    {
        string display = "";

        for (int i = 0; i < list.Count; i++)
        {
            display = display + " " + list[i];
        }

        Debug.Log(display);
        return display;
    }

    public void TakeRandom()
    {
        if (_bingoBowl.Count>0)
        {
            int a = Random.Range(0, _bingoBowl.Count);
            _lastNumber.text = _bingoBowl[a].ToString();
            _outNumbers.Add(_bingoBowl[a]);
            _outNumbers.Sort();
            _bingoBowl.RemoveAt(a);
            DisplayUpdate();
            Smirk();
            
        }

    }

    void DisplayUpdate()
    {
        _displayText.text = DisplayList(_bingoBowl);
        _displayText2.text = DisplayList(_outNumbers);
    }

    public void Reload()
    {
        _bowlSize = int.Parse(_inputBowlSize.text);
        FullfullBowl();
        _lastNumber.text = " ";

        //SceneManager.LoadScene(0);
    }

    public void Mute()
    {
        if (isMuted)
        {
            isMuted = false;
        }
        else
        {
            isMuted = true;
        }
    }

    public void Smirk()
    {
        //_raptorSound.Play(0);
        if (!isMuted) {
            int soundVar = Random.Range(0, _raptorSounds.Count);
            _raptorSounds[soundVar].Play(0);
        }

        StartCoroutine(imageChanger());
    }

    IEnumerator imageChanger()
    {
        _raptor.sprite = _smirk;
        yield return new WaitForSeconds(_raptorTimeGap);
        _raptor.sprite = _smile;
    }

}
