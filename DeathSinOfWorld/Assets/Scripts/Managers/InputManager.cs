using UnityEngine;
using System;
public class InputManager : ManagerBase
{
    public override void Init()
    {
        base.Init();
        GlobalEventBus.eventBus.SubScribe<InputData>(OnKeyInput);
    } 

    private void OnKeyInput(InputData inputData)
    {
        //Debug.Log($"키를 입력받았습니다: {inputData.key}");
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode key in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(key))
                {
                    GlobalEventBus.eventBus.Publish(new InputData(key));
                    break;
                }
            }
        }
    }
}
