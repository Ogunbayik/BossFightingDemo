using UnityEngine;

public enum EnemyStates
{
    Idle,
    Chasing,
    Attacking
}


public abstract class EnemyBase : MonoBehaviour
{
    private EnemyStates currentState;
    private PlayerController player;
    protected EnemyAnimationController animationController;

    [Header("Enemy Settings")]
    [SerializeField] protected EnemySO enemySO;

    private int currentHP;

    public virtual void Awake()
    {
        player = GameObject.FindObjectOfType<PlayerController>();
        animationController = GetComponentInChildren<EnemyAnimationController>();
    }
    public virtual void Start()
    {
        currentHP = enemySO.GetEnemyMaxHP();
        currentState = EnemyStates.Idle;
    }
    public virtual void Update()
    {
        switch(currentState)
        {
            case EnemyStates.Idle:
                HandleIdleState();
                break;
            case EnemyStates.Chasing:
                HandleChaseState();
                break;
            case EnemyStates.Attacking:
                HandleAttackState();
                break;
        }
    }
    protected virtual void HandleIdleState()
    {
        //Enemy is waiting or doing idle mode.
        if (GetPlayerDistance() <= enemySO.GetChaseDistance())
            SetEnemyState(EnemyStates.Chasing);

    }
    protected virtual void HandleChaseState()
    {
        //Enemy is chasing player
        this.transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, enemySO.GetMovementSpeed() * Time.deltaTime);
        animationController.SetMoveAnimation(true);

        if (GetPlayerDistance() <= enemySO.GetAttackDistance())
            SetEnemyState(EnemyStates.Attacking);
    }
    protected virtual float GetPlayerDistance()
    {
        var playerDistance = Vector3.Distance(this.transform.position, player.transform.position);
        return playerDistance;
    }
    protected virtual void SetEnemyState(EnemyStates newState)
    {
        if (currentState == newState)
            return;

        currentState = newState;
    }
    public abstract void HandleAttackState();

    public virtual void TakeDamage(int amount)
    {
        currentHP -= amount;

        if (currentHP <= 0)
            EnemyDie();
    }
    public virtual void EnemyDie()
    {
        Debug.Log($"{this.gameObject.name} is die..");
    }
}
