using UnityEngine;
[CreateAssetMenu(fileName = "New Enemy", menuName = "Scriptable Objects/Enemy")]
public class EnemySO : ScriptableObject
{
    public enum EnemyType { Melee, Range};

    [Header("Enemy Settings")]
    public EnemyType enemyType;
    [SerializeField] private string enemyName;
    [SerializeField] private int maxHP;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float chaseDistance;
    [SerializeField] private float attackDistance;
    [SerializeField] private float retreatingDistance;
    public string GetEnemyName()
    {
        return enemyName;
    }
    public int GetEnemyMaxHP()
    {
        return maxHP;
    }
    public float GetMovementSpeed()
    {
        return movementSpeed;
    }
    public float GetChaseDistance()
    {
        return chaseDistance;
    }
    public float GetAttackDistance()
    {
        return attackDistance;
    }
    public float GetRetreatingDistance()
    {
        return retreatingDistance;
    }
    
}


