// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/InputMaster.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputMaster : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputMaster()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputMaster"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""bbc69e31-0bae-48af-aacd-c58c65c90d4d"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a45544b1-6567-4615-b48d-11cb339149d1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""3a6bde1a-8e4a-464c-89dc-b74e488588c3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ControllerUse"",
                    ""type"": ""Button"",
                    ""id"": ""1c730fdf-87a8-44e9-bb31-8a0e5bf0e4d2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Use"",
                    ""type"": ""Button"",
                    ""id"": ""ea1f2572-d3de-4625-8b3b-5d8fa8fa62c7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ControllerAim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""6ae7644c-e8b0-4e7e-8581-a0b0a88a6a72"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""67ea40f7-9633-435a-85f2-17d3d4ca0fc3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HotbarSel"",
                    ""type"": ""Button"",
                    ""id"": ""9128a746-0cc1-43a8-b708-11722b7cd072"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrevHotbar"",
                    ""type"": ""Button"",
                    ""id"": ""1d4c27db-b74c-4678-b003-909af04d5dd7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextHotbar"",
                    ""type"": ""Button"",
                    ""id"": ""274ca66d-eae5-4f37-bc18-79a6f5a58622"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ToggleInv"",
                    ""type"": ""Button"",
                    ""id"": ""4d90c988-09f0-41c7-b880-b75e0e150791"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""50a0df85-fa60-4a9e-a126-c67841fdc4e1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Moving"",
                    ""id"": ""2a89fa22-9d5b-4944-8956-c5a969c47162"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3e392923-9346-456a-81a0-b4c8002e3b25"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""ec8a0d16-8949-41ce-8172-42d8a4f616d9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c22c7e48-3bb7-40dc-bf72-70ee53d803d8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1f7c5308-16ed-43a9-b326-90445a400205"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d209cbad-387e-4401-a82b-6667dd572b91"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""41deca71-dade-4d5c-83b1-49b432331023"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""706f75d6-9e74-405b-a085-7f6afc336c3c"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d3f4862c-8a67-4a22-bbf2-8aff1d2bc431"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Use"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""779cb7e3-be6e-4c67-8430-db795f5b464a"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ControllerUse"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""510c6eb0-6b1d-4da8-8393-debfa41e725d"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone"",
                    ""groups"": """",
                    ""action"": ""ControllerAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0afdf319-02e7-48a8-8102-0c91f7b1c459"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""77f1ad5b-66c3-4c4d-b289-c8524774ae58"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotbarSel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""467945b0-31e6-499a-b4d1-9236be21b434"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotbarSel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""53cf53bb-9c00-4994-b8df-259a67420a7e"",
                    ""path"": ""<Keyboard>/3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotbarSel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29aee377-b950-46e3-8468-d508239a9edf"",
                    ""path"": ""<Keyboard>/4"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotbarSel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6311b561-0573-4abb-9e87-d9b0f99082b0"",
                    ""path"": ""<Keyboard>/5"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotbarSel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dba01b47-a601-4dda-921b-06239806ccdd"",
                    ""path"": ""<Keyboard>/6"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotbarSel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""400c64ac-687d-4b43-8d6a-7890bae4c10d"",
                    ""path"": ""<Keyboard>/7"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotbarSel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10636f51-6426-446d-930c-a21cacb66db7"",
                    ""path"": ""<Keyboard>/8"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotbarSel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9db8ca2d-1619-4a72-90e2-c39c52394b43"",
                    ""path"": ""<Keyboard>/9"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HotbarSel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e0437f5-d28d-480b-8496-fad6cdff5fd1"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrevHotbar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""08580635-164a-419a-8346-dd92bb8bd8e6"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextHotbar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""35ec3f3b-3892-4205-9482-b3a440c9f720"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleInv"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""def57816-56b3-4acc-b374-75303078a091"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ToggleInv"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7aff3dda-aa36-4c91-8a63-2b94d154dc84"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62ca250d-1979-4938-9564-d1ec87212ba0"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_ControllerUse = m_Player.FindAction("ControllerUse", throwIfNotFound: true);
        m_Player_Use = m_Player.FindAction("Use", throwIfNotFound: true);
        m_Player_ControllerAim = m_Player.FindAction("ControllerAim", throwIfNotFound: true);
        m_Player_Aim = m_Player.FindAction("Aim", throwIfNotFound: true);
        m_Player_HotbarSel = m_Player.FindAction("HotbarSel", throwIfNotFound: true);
        m_Player_PrevHotbar = m_Player.FindAction("PrevHotbar", throwIfNotFound: true);
        m_Player_NextHotbar = m_Player.FindAction("NextHotbar", throwIfNotFound: true);
        m_Player_ToggleInv = m_Player.FindAction("ToggleInv", throwIfNotFound: true);
        m_Player_Reload = m_Player.FindAction("Reload", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_ControllerUse;
    private readonly InputAction m_Player_Use;
    private readonly InputAction m_Player_ControllerAim;
    private readonly InputAction m_Player_Aim;
    private readonly InputAction m_Player_HotbarSel;
    private readonly InputAction m_Player_PrevHotbar;
    private readonly InputAction m_Player_NextHotbar;
    private readonly InputAction m_Player_ToggleInv;
    private readonly InputAction m_Player_Reload;
    public struct PlayerActions
    {
        private @InputMaster m_Wrapper;
        public PlayerActions(@InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @ControllerUse => m_Wrapper.m_Player_ControllerUse;
        public InputAction @Use => m_Wrapper.m_Player_Use;
        public InputAction @ControllerAim => m_Wrapper.m_Player_ControllerAim;
        public InputAction @Aim => m_Wrapper.m_Player_Aim;
        public InputAction @HotbarSel => m_Wrapper.m_Player_HotbarSel;
        public InputAction @PrevHotbar => m_Wrapper.m_Player_PrevHotbar;
        public InputAction @NextHotbar => m_Wrapper.m_Player_NextHotbar;
        public InputAction @ToggleInv => m_Wrapper.m_Player_ToggleInv;
        public InputAction @Reload => m_Wrapper.m_Player_Reload;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @ControllerUse.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnControllerUse;
                @ControllerUse.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnControllerUse;
                @ControllerUse.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnControllerUse;
                @Use.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @Use.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @Use.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnUse;
                @ControllerAim.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnControllerAim;
                @ControllerAim.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnControllerAim;
                @ControllerAim.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnControllerAim;
                @Aim.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @HotbarSel.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHotbarSel;
                @HotbarSel.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHotbarSel;
                @HotbarSel.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHotbarSel;
                @PrevHotbar.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrevHotbar;
                @PrevHotbar.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrevHotbar;
                @PrevHotbar.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPrevHotbar;
                @NextHotbar.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextHotbar;
                @NextHotbar.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextHotbar;
                @NextHotbar.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnNextHotbar;
                @ToggleInv.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleInv;
                @ToggleInv.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleInv;
                @ToggleInv.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnToggleInv;
                @Reload.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @ControllerUse.started += instance.OnControllerUse;
                @ControllerUse.performed += instance.OnControllerUse;
                @ControllerUse.canceled += instance.OnControllerUse;
                @Use.started += instance.OnUse;
                @Use.performed += instance.OnUse;
                @Use.canceled += instance.OnUse;
                @ControllerAim.started += instance.OnControllerAim;
                @ControllerAim.performed += instance.OnControllerAim;
                @ControllerAim.canceled += instance.OnControllerAim;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @HotbarSel.started += instance.OnHotbarSel;
                @HotbarSel.performed += instance.OnHotbarSel;
                @HotbarSel.canceled += instance.OnHotbarSel;
                @PrevHotbar.started += instance.OnPrevHotbar;
                @PrevHotbar.performed += instance.OnPrevHotbar;
                @PrevHotbar.canceled += instance.OnPrevHotbar;
                @NextHotbar.started += instance.OnNextHotbar;
                @NextHotbar.performed += instance.OnNextHotbar;
                @NextHotbar.canceled += instance.OnNextHotbar;
                @ToggleInv.started += instance.OnToggleInv;
                @ToggleInv.performed += instance.OnToggleInv;
                @ToggleInv.canceled += instance.OnToggleInv;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnControllerUse(InputAction.CallbackContext context);
        void OnUse(InputAction.CallbackContext context);
        void OnControllerAim(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnHotbarSel(InputAction.CallbackContext context);
        void OnPrevHotbar(InputAction.CallbackContext context);
        void OnNextHotbar(InputAction.CallbackContext context);
        void OnToggleInv(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
    }
}
