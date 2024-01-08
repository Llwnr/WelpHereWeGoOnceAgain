using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class CommonFuncExecutor : MonoBehaviour
{
    //This class will execute the function based on the function type.
    public enum FunctionType{
        OnAwake, OnStart, OnEnable, OnDisable, OnDestroy, OnUpdate
    }

    [SerializeField]private FunctionType functionType;

    private void Awake() {
        if(functionType == FunctionType.OnAwake) FuncToRun();
    }

    private void Start() {
        if(functionType == FunctionType.OnStart) FuncToRun();
    }

    private void OnEnable() {
        if(functionType == FunctionType.OnEnable) FuncToRun();
    }

    private void OnDisable() {
        if(functionType == FunctionType.OnDisable) FuncToRun();
    }

    private void OnDestroy() {
        if(functionType == FunctionType.OnDestroy) FuncToRun();
    }

    private void Update() {
        if(functionType == FunctionType.OnUpdate) FuncToRun();
    }

    public abstract void FuncToRun();

}
