using CollectionManager.App.Managers;
using CollectionManager.Domain.Entity;
using System;
using System.Reflection.Metadata;
using Xunit;
using Moq;
using CollectionManager.App.Abstract;
using CollectionManager.App.Concrete;
using FluentAssertions;
using System.Collections.Generic;

namespace CollectionManager.Tests
{
    public class ItemTests
    {
        [Fact]
        public void CanAddItem()
        {
            //Arrange
            Item item = new Item(1, "Gold coin", 1);
            var mock = new Mock<IService<Item>>();

            var manager = new ItemManager(new MenuActionService(), mock.Object);

            //Act
            var itemId = manager.AddItem(item);

            //Assert
            itemId.Should().NotBe(null);
            itemId.Should().Equals(item.Id);
        }

        [Fact]
        public void CanRemoveItem()
        {
            //Arrange
            Item item = new Item(1, "Gold coin", 1);
            var mock = new Mock<IService<Item>>();

            var manager = new ItemManager(new MenuActionService(), mock.Object);
            var itemId = manager.AddItem(item);

            //Act
            var removedId = manager.RemoveItem(item);

            //Assert
            removedId.Should().Equals(itemId);
            mock.Object.Items.Should().BeNull();
        }

        [Fact]
        public void CanListItemsOfSameType()
        {
            //Arange
            Item item1 = new Item(1, "Gold1", 1);
            Item item2 = new Item(2, "Gold2", 1);
            Item item3 = new Item(3, "Post1", 2);

            List<Item> items = new List<Item>();
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);

            var mock = new Mock<IService<Item>>();
            mock.Setup(s => s.Items).Returns(items);
            var manager = new ItemManager(new MenuActionService(), mock.Object);

            //Act
            var toShow = manager.GetItemsOfTheSameType(1);

            //Assert
            toShow.Should().NotBeEmpty();
            toShow.Should().HaveCount(2);
            toShow.Should().Contain(item1);
            toShow.Should().Contain(item2);
        }
    }
}
