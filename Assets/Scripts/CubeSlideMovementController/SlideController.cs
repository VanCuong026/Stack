using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlideController : MonoBehaviour
{
    public static SlideController instance;
    public float _RightSpeed;
    public float _Speed = 2f;
    public float _LeftSpeed;
    [SerializeField]
    public Text _ScoreText;
    public int _Score = 0;
    public bool _DownSwitch = false, _ScoreCal = false;
    [SerializeField]
    private GameObject _FirstSlideCube;

    


    // Start is called before the first frame update
    void Start()
    {
        _FirstSlideCube.SetActive(true);
        instance = this;
        if (_Score % 2 == 0)
        {
            _RightSpeed = _Speed;
            _LeftSpeed = 0;
        }
        if (_Score % 2 == 1)
        {
            _RightSpeed = 0f;
            _LeftSpeed = _Speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && CubeCut.instance._GameOver == false)
        {
            _DownSwitch = true;
            _Score++;

            if (_Score % 2 == 0)
            {
                _RightSpeed = _Speed;
                _LeftSpeed = 0;
            }
            if (_Score % 2 == 1)
            {
                _RightSpeed = 0f;
                _LeftSpeed = _Speed;
            }
        }
        if (CubeCut.instance._GameOver == true && _ScoreCal == false)
        {
            _Score--;
            _ScoreCal = true;
        }
    }
    
    
}
