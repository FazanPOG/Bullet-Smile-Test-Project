//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/BulletSmileTestProject/Prefabs/Characters/MainCharacter/InputActions/MainCharacterInputAction.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @MainCharacterInputAction: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @MainCharacterInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MainCharacterInputAction"",
    ""maps"": [
        {
            ""name"": ""MainCharacter"",
            ""id"": ""722e09ae-92ee-4249-a494-9e31b75a04f3"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""f8ba7b2b-ecc1-4759-bf8d-0853b25e6ee4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""b322180d-27d6-441c-93b1-86c4df51d1bf"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""36cbd56a-4fe0-4f31-8f74-10bdb1bcb111"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": ""NormalizeVector2"",
                    ""groups"": ""Mouse"",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""efc9872d-c4cb-45eb-a4fb-32dff25818b5"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Mouse"",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Mouse"",
            ""bindingGroup"": ""Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // MainCharacter
        m_MainCharacter = asset.FindActionMap("MainCharacter", throwIfNotFound: true);
        m_MainCharacter_Click = m_MainCharacter.FindAction("Click", throwIfNotFound: true);
        m_MainCharacter_MousePosition = m_MainCharacter.FindAction("MousePosition", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // MainCharacter
    private readonly InputActionMap m_MainCharacter;
    private List<IMainCharacterActions> m_MainCharacterActionsCallbackInterfaces = new List<IMainCharacterActions>();
    private readonly InputAction m_MainCharacter_Click;
    private readonly InputAction m_MainCharacter_MousePosition;
    public struct MainCharacterActions
    {
        private @MainCharacterInputAction m_Wrapper;
        public MainCharacterActions(@MainCharacterInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_MainCharacter_Click;
        public InputAction @MousePosition => m_Wrapper.m_MainCharacter_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_MainCharacter; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainCharacterActions set) { return set.Get(); }
        public void AddCallbacks(IMainCharacterActions instance)
        {
            if (instance == null || m_Wrapper.m_MainCharacterActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_MainCharacterActionsCallbackInterfaces.Add(instance);
            @Click.started += instance.OnClick;
            @Click.performed += instance.OnClick;
            @Click.canceled += instance.OnClick;
            @MousePosition.started += instance.OnMousePosition;
            @MousePosition.performed += instance.OnMousePosition;
            @MousePosition.canceled += instance.OnMousePosition;
        }

        private void UnregisterCallbacks(IMainCharacterActions instance)
        {
            @Click.started -= instance.OnClick;
            @Click.performed -= instance.OnClick;
            @Click.canceled -= instance.OnClick;
            @MousePosition.started -= instance.OnMousePosition;
            @MousePosition.performed -= instance.OnMousePosition;
            @MousePosition.canceled -= instance.OnMousePosition;
        }

        public void RemoveCallbacks(IMainCharacterActions instance)
        {
            if (m_Wrapper.m_MainCharacterActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IMainCharacterActions instance)
        {
            foreach (var item in m_Wrapper.m_MainCharacterActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_MainCharacterActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public MainCharacterActions @MainCharacter => new MainCharacterActions(this);
    private int m_MouseSchemeIndex = -1;
    public InputControlScheme MouseScheme
    {
        get
        {
            if (m_MouseSchemeIndex == -1) m_MouseSchemeIndex = asset.FindControlSchemeIndex("Mouse");
            return asset.controlSchemes[m_MouseSchemeIndex];
        }
    }
    public interface IMainCharacterActions
    {
        void OnClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}