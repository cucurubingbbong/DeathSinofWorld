using UnityEngine;
using System;
using Unity.VisualScripting;

[Serializable]
public class UnitBase : MonoBehaviour
{
    [Header("유닛의 기본 정보")]
    public string unitName {get; private set;}

    public int unitId {get; private set;}

    public int health {get; private set;}

    public int attackLevel {get; private set;}

    public int defenseLevel {get; private set;}
    /// <summary>
    /// 유닛의 이동 속도 범위
    /// </summary>
    public Vector2 speedRange {get; private set;}

    /// <summary>
    /// 유닛의 기본 정보를 설정하는 생성자
    /// </summary>
    /// <param name="unitName"></param>
    /// <param name="health"></param>
    /// <param name="attackLevel"></param>
    /// <param name="defenseLevel"></param>
    /// <param name="speedRange"></param>
    public UnitBase(string unitName, int health, int attackLevel, int defenseLevel, Vector2 speedRange)
    {
        this.unitName = unitName;
        this.health = health;
        this.attackLevel = attackLevel;
        this.defenseLevel = defenseLevel;
        this.speedRange = speedRange;
    }

    public void TakeDamage(int damage)
    {
        health -= Mathf.Max(0, damage - defenseLevel);
        Debug.Log($"{unitName}이(가) {damage}의 피해를 입었습니다. 남은 체력: {health}");
    }

    public void Attack(UnitBase target)
    {
        target.TakeDamage(attackLevel);
        Debug.Log($"{unitName}이(가) {target.unitName}을(를) 공격했습니다. 공격력: {attackLevel}");
    }
}
