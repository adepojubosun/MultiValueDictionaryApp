using System;
using Xunit;
using MultiValueDictionaryApp;
using System.Collections.Generic;

namespace MultiValueDictionaryApp.Tests
{
    public class StorageTest
    {

        [Fact]
        public void Keys_ShouldReturnAllKeysInDictionary()
        {
            // Act
            Storage.Add("foo", "bar");
            Storage.Add("baz", "bang");

            // Assert
            Assert.Equal(Storage.Keys().Count, 2);

            // CleanUp
            Storage.Clear();

        }

        [Fact]
        public void Members_ShouldReturnMembersForSpecificKey()
        {
            //Act
            Storage.Add("foo", "bar");
            Storage.Add("foo", "baz");

            // Assert
            Assert.Equal(Storage.Members("foo").Count, 2);

            // CleanUp
            Storage.Clear();

        }

        [Fact]
        public void Members_ShouldReturnErrorIfKeyDoesNotExist()
        {
            //Act
            Storage.Add("foo", "bar");
            Storage.Add("foo", "baz");

            // Assert
            Assert.Throws<KeyNotFoundException>(() => Storage.Members("bad"));

            // CleanUp
            Storage.Clear();
        }

        public void Add_ShouldAddMembersToAGivenKeyAndGiveError()
        {
            //Act
            Storage.Add("foo", "bar");
            Storage.Add("foo", "baz");

            // Assert
            Assert.Throws<CustomException>(() => Storage.Add("foo", "bar"));

            // CleanUp
            Storage.Clear();
        }
    }
}
