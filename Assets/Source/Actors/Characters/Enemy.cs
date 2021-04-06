using System;
using DungeonCrawl;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using Source.Core.EnemyStateMachine;
using UnityEngine;

[RequireComponent(typeof(EnemyStateMachine))]
public class Enemy : Character, ISelectable 
{
    public CharacterState CurrentState = CharacterState.Idle;
    public GameObject[] PatrolPoints;

    public override string DefaultName { get; }
    protected override void OnDeath()
    {
        Debug.Log($"Enemy - {name} is dead.");
        Destroy(gameObject);
    }

    public void Activate(GameObject owner)
    {
        Character character = owner.GetComponent<Character>();
        
        if (character.Equipment.Weapon != null)
        {
            Debug.Log("Attack");
            CurrentHealth -= character.Attack;
            if (CurrentHealth <= 0)
            {
                OnDeath();
            }    
        }
    }
}
