using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCubeMovementController : MonoBehaviour
{
    // Start is called before the first frame update
    private float _Speed=0;
    bool _SlideSwitch = false;
    Vector3 temp;
    private bool _Stop = false;
    public bool _AllDone = false;
    int _Counting = 0;
    private void Start()
    {
        temp = transform.position;
        temp.z = -1.8f;
        temp.x = CubeCut.instance._LastCubeCenter.x;
        transform.position = temp;
        if (SlideController.instance._Score % 2 == 0)//Only RIGHT run
        {
            gameObject.SetActive(false);
            SlideDown.instance._Switch = "Left";//LEFT stop
        }

        Vector3 tempScale = CubeCut.instance._CubeScale;
        tempScale.y = 0.1f;
        transform.localScale = tempScale;
    }
    // Update is called once per frame
    void Update()
    {
        
        _Speed = SlideController.instance._LeftSpeed;
        if (_Stop == false)
        {
            if (_SlideSwitch == false)
            {
                _SlideToFront();
            }
            else if (_SlideSwitch == true)
            {
                _SlideToBack();
            }
        }
        
        if (Input.GetMouseButtonDown(0)&& _Stop == false)
        {
            CubeCut.instance._CurrentCubeCenter.z = transform.position.z;
            //DropCubeSpawner.instance._CurrentCenter.z = transform.position.z;
            CubeCut.instance._StartZCut = true;
            _Stop = true;
        }

        if (_Stop == true && CubeCut.instance._StartZCut == false && _AllDone == false&&CubeCut.instance._GameOver == false)
        {
            Vector3 tempPosition = CubeCut.instance._LastCubeCenter;
            tempPosition.y = 0.54f;
            transform.position = tempPosition;

            CubeCut.instance._CubeScale.y = 0.1f;
            transform.localScale = CubeCut.instance._CubeScale;
            _AllDone = true;

            SlideDown.instance._Down = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            _Counting++;
        }
        if (_Counting == 1 && CubeCut.instance._GameOver == true)
        {
            gameObject.SetActive(false);
        }
    }

    void _SlideToFront()
    {
        temp = transform.position;
        if (temp.z - 1.2f < -0.01f)
        {
            temp.z += _Speed * Time.deltaTime;
            transform.position = temp;
        }else if(temp.z - 1.2f > -0.05f)
        {
            temp.z = 1.2f;
            transform.position = temp;
            _SlideSwitch = true;
        }
        
    }

    void _SlideToBack()
    {
        temp = transform.position;
        if (temp.z + 1.2f > 0.01f)
        {
            temp.z -= _Speed * Time.deltaTime;
            transform.position = temp;
        }
        else if (temp.z + 1.2f < 0.05f)
        {
            temp.z = -1.2f;
            transform.position = temp;
            _SlideSwitch = false;
        }
    }
}
