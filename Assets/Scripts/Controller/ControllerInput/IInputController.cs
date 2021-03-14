using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputController
{
    bool isEnable { get; set; }

    void FirstTypeClick();
    void SecondTypeClick();
    void Execute();

    void Initialize();
}
