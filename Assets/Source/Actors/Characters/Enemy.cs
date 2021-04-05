using DungeonCrawl;
using DungeonCrawl.Actors;
using DungeonCrawl.Actors.Characters;
using UnityEngine;

public class Enemy : Character, ISelectable 
{
    public CharacterState CurrentState = CharacterState.Idle;

    public override string DefaultName { get; }
    protected override void OnDeath()
    {
        Debug.Log($"Enemy - {name} is dead.");
        Destroy(gameObject);
    }

    public void Activate(GameObject owner)
    {
        Debug.Log("Attack");
        CurrentHealth -= owner.GetComponent<Character>().Attack;
        if (CurrentHealth <= 0)
        {
            OnDeath();
        }        
    }
}
