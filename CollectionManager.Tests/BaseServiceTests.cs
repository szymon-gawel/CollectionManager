using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using FluentAssertions;
using CollectionManager.Domain.Entity;
using CollectionManager.App.Common;
using CollectionManager.App.Managers;
using CollectionManager.App.Concrete;

namespace CollectionManager.Tests
{
    public class BaseServiceTests
    {
        [Fact]
        public void CanGetLastId()
        {
            //Arrange
            Item item1 = new Item(1, "Gold1", 1);
            Item item2 = new Item(2, "Gold2", 1);

            var service = new BaseService<Item>();
            var firstId = service.AddItem(item1);
            var secondId = service.AddItem(item2);

            //Act
            var lastId = service.GetLastId();

            //Assert
            lastId.Should().NotBe(null);
            lastId.Should().Equals(secondId);
        }

        [Fact]
        public void CanAddItem()
        {
            //Arrange
            Item item = new Item(1, "Gold1", 1);

            var service = new BaseService<Item>();

            //Act
            var id = service.AddItem(item);

            //Assert
            service.Items.Should().NotBeEmpty();
            service.Items.Should().Contain(item);
        }

        [Fact]
        public void CanRemoveItem()
        {
            //Arrange
            Item item1 = new Item(1, "Coin1", 1);
            Item item2 = new Item(2, "Coin2", 1);

            var service = new BaseService<Item>();

            service.AddItem(item1);
            service.AddItem(item2);

            //Act
            service.RemoveItem(item2);

            //Assert
            service.Items.Should().HaveCount(1);
            service.Items.Should().Contain(item1);
            service.Items.Should().NotContain(item2);
        }

        [Fact]
        public void CanGetItems()
        {
            //Arrange
            Item item1 = new Item(1, "Coin1", 1);
            Item item2 = new Item(2, "Post1", 2);

            var service = new BaseService<Item>();

            service.AddItem(item1);
            service.AddItem(item2);

            //Act
            var items = service.GetItems();

            //Assert
            items.Should().HaveCount(2);
            items.Should().Contain(item1);
            items.Should().Contain(item2);
        }

    }
}
