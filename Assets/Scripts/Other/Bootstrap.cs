using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private ControllerInput controllerInput;
    private SelectUnitController selectUnitController;
    public SettingsGameData settings;


    void Start()
    {
        SettingsGame.Instance.settingsGameData = settings;
        selectUnitController = new SelectUnitController();
        controllerInput = gameObject.AddComponent<ControllerInput>();
        controllerInput.Initialize(new InputInGame(selectUnitController));        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
