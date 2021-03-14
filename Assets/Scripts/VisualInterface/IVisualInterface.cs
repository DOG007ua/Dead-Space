using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVisualInterface
{
    bool IsVisible { get; set; }
    void Execute();
}
