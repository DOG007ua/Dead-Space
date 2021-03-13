using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private ControllerInput controllerInput;
    [SerializeField]private SettingsGameData settings;

    void Start()
    {
        SettingsGame.Instance.settingsGameData = settings;
        controllerInput = gameObject.AddComponent<ControllerInput>();
        controllerInput.Initialize(new InputInGame());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
