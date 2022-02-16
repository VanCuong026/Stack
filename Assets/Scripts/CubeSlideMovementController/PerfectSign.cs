using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectSign : MonoBehaviour
{
    public static PerfectSign instance;
    public bool _Perfect=false,_StartPerfect = false;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (_StartPerfect == true&& _Perfect == false)
        {
            _DoPerfect();
        }
    }

    void _DoPerfect()
    {
        _Perfect = true;
    }
}
