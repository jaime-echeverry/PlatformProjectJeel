using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    [HideInInspector]
    public EnemyController myController;
    public virtual  void OnEnterState(EnemyController controller) {
        myController = controller;
    }

    public abstract void OnUpdateState();
        
    public abstract void OnExitState();  
}
