using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public static CubeSpawner instance;
    [SerializeField]
    private GameObject _SlideCube;
    public int _CountTo3;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;
        temp.y = SlideController.instance._Score * 0.1f;
        if (CubeCut.instance._StartSpawner==true && Time.timeScale != 0&&CubeCut.instance._GameOver == false&& Time.timeScale == 1)
        {
            GameObject _gob = Instantiate(_SlideCube, transform.position, Quaternion.identity);
            CubeCut.instance._StartSpawner = false;
            if (SlideController.instance._Score == 0)
                SlideController.instance._ScoreText.text = "";
            else
                SlideController.instance._ScoreText.text = "" + SlideController.instance._Score;
        }
    }
}
