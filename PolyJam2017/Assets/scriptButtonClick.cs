using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scriptButtonClick : MonoBehaviour {

    private Button button;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() => actionToMaterial());
    }

    void actionToMaterial()
    {
        Application.LoadLevel("GameScene");
    }
}
