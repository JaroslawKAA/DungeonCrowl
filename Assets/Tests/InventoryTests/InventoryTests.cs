using System.Collections;
using System.Collections.Generic;
using DungeonCrawl.Actors.Items;
using NUnit.Framework;
using Source.Actors.Characters;
using UnityEngine;
using UnityEngine.TestTools;

public class InventoryTests
{
    // Arrange
    public Player _player;
    public Item _item;

    [SetUp]
    public void SetUp()
    {
        GameObject player = new GameObject("Player",
            typeof(Player),
            typeof(SpriteRenderer));
        _player = player.GetComponent<Player>();

        GameObject item = new GameObject("Item",
            typeof(Item),
            typeof(SpriteRenderer));
        _item = item.GetComponent<Item>();
    }

    // A Test behaves as an ordinary method
    [Test]
    public void TestAddingItemToPlayerInventory()
    {
        // Act
        _player.Inventory.AddItem(_item);

        // Assert
        Assert.AreEqual(_item.Id, _player.Inventory.GetItem(_item.Id).Id);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NewTestScriptWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Act
        _player.Inventory.AddItem(_item);

        // Assert
        Assert.AreEqual(_item.Id, _player.Inventory.GetItem(_item.Id).Id);
        // Use yield to skip a frame.
        yield return null;
    }
}