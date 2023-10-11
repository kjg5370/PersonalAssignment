using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [field: Header("References")]
    [field: SerializeField] public PlayerSO Data { get; private set; }

    [field: Header("Animations")]
    [field: SerializeField] public PlayerAnimationData AnimationData { get; private set; }
    [field: SerializeField] public Weapon Weapon { get; private set; }
    public CharacterHealth CharacterHealth { get; private set; }

    public Rigidbody Rigidbody { get; private set; }
    public Animator Animator { get; private set; }
    public PlayerInput Input { get; private set; }
    public CharacterController Controller { get; private set; }

    public ForceReceiver ForceReceiver { get; private set; }


    private PlayerStateMachine stateMachine;

    private const string Message = "GameOver";
    private void Awake()
    {
        AnimationData.Initialize();

        Rigidbody = GetComponent<Rigidbody>();
        Animator = GetComponentInChildren<Animator>();
        Input = GetComponent<PlayerInput>();
        Controller = GetComponent<CharacterController>();
        stateMachine = new PlayerStateMachine(this);
        ForceReceiver = GetComponent<ForceReceiver>();
        CharacterHealth = GetComponent<CharacterHealth>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        stateMachine.ChangeState(stateMachine.IdleState);
        CharacterHealth.OnDie += OnDie;
    }
    private void Update()
    {
        stateMachine.HandleInput();
        stateMachine.Update();
    }

    private void FixedUpdate()
    {
        stateMachine.PhysicsUpdate();
    }
    void OnDie()
    {
        Animator.SetTrigger("Die");
        SetUI.Instance.SetGameObjectActive(true);
        SetUI.Instance.SetLabelText(Message);
        enabled = false;
    }
}
