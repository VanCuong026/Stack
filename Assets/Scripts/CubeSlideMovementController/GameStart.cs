using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    [SerializeField]
    public Text _StartText;
    [SerializeField]
    public Text _StackText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick()
    {
        _StartText.gameObject.SetActive(false);
        _StackText.gameObject.SetActive(false);
        Application.LoadLevel("PlayScene");
    }
}
