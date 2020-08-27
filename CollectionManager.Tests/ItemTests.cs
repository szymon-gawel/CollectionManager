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
    }
}
