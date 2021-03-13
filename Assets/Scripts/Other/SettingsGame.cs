using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsGame
{
    private static SettingsGame settingsGame;
    public static SettingsGame Instance
    {
        get
        {
            if (settingsGame == null) settingsGame = new SettingsGame();
            return settingsGame;
        }
    }

    private SettingsGame() { }
    public SettingsGameData settingsGameData;
}
