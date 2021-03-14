using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    private ControllerInput controllerInput;
    private SelectUnitController selectUnitController;
    public SettingsGameData settings;
    [SerializeField]private VisualInterfaceController visualInterfaceController;


    void Start()
    {
        SettingsGame.Instance.settingsGameData = settings;
        selectUnitController = new SelectUnitController();

        controllerInput = gameObject.AddComponent<ControllerInput>();
        controllerInput.Initialize(new InputInGame(selectUnitController));

        visualInterfaceController.Initialize();

        Subscription();
    }

    private void Subscription()
    {
        selectUnitController.eventSelectNewUnit += visualInterfaceController.SetSelectUnit;
    }

    private void SetTypeInput()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
