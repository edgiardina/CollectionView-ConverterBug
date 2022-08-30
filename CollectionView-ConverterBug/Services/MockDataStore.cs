using CollectionView_BugRepro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollectionView_BugRepro.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        readonly List<Item> items;
        readonly List<Item> moreItems;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Distance=1337, UnitOfMeasurement="Yards" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Distance=42, UnitOfMeasurement="yds" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Distance=1024, UnitOfMeasurement="yds" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Distance=3.141592654, UnitOfMeasurement="Yards" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Distance=186282, UnitOfMeasurement="Yards" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Distance=123, UnitOfMeasurement="yds" }
            };

            moreItems = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Distance=1337, UnitOfMeasurement="Yards" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Distance=42, UnitOfMeasurement="yds" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Distance=1024, UnitOfMeasurement="yds" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Distance=3.141592654, UnitOfMeasurement="Yards" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Distance=186282, UnitOfMeasurement="Yards" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Distance=123, UnitOfMeasurement="yds" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "etc!", Distance=101, UnitOfMeasurement="Yards" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "etc", Distance=404, UnitOfMeasurement="yds" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "etc", Distance=32, UnitOfMeasurement="yds" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Etc", Distance=3.14, UnitOfMeasurement="Yards" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "etc etc", Distance=19, UnitOfMeasurement="Yards" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "etc etc", Distance=222, UnitOfMeasurement="yds" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Still etc", Distance=777, UnitOfMeasurement="Yards" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "", Distance=55, UnitOfMeasurement="yds" },
                new Item { Id = Guid.NewGuid().ToString(), Text = " ", Distance=321, UnitOfMeasurement="yds" },
                new Item { Id = Guid.NewGuid().ToString(), Text = " ", Distance=432, UnitOfMeasurement="Yards" },
                new Item { Id = Guid.NewGuid().ToString(), Text = " ", Distance=543, UnitOfMeasurement="Yards" },
                new Item { Id = Guid.NewGuid().ToString(), Text = " ", Distance=654, UnitOfMeasurement="yds" },
                new Item { Id = Guid.NewGuid().ToString(), Text = " ", Distance=765, UnitOfMeasurement="Yards" },
                new Item { Id = Guid.NewGuid().ToString(), Text = " ", Distance=876, UnitOfMeasurement="yds" },
                new Item { Id = Guid.NewGuid().ToString(), Text = " ", Distance=987, UnitOfMeasurement="yds" },
                new Item { Id = Guid.NewGuid().ToString(), Text = " ", Distance=7, UnitOfMeasurement="Yards" },
                new Item { Id = Guid.NewGuid().ToString(), Text = " ", Distance=9, UnitOfMeasurement="Yards" },
                new Item { Id = Guid.NewGuid().ToString(), Text = " ", Distance=99, UnitOfMeasurement="yds" },
                new Item { Id = Guid.NewGuid().ToString(), Text = " ", Distance=887, UnitOfMeasurement="Yards" },
                new Item { Id = Guid.NewGuid().ToString(), Text = " ", Distance=2833, UnitOfMeasurement="yds" },
                new Item { Id = Guid.NewGuid().ToString(), Text = " ", Distance=7.5, UnitOfMeasurement="yds" },
                new Item { Id = Guid.NewGuid().ToString(), Text = " ", Distance=1.16, UnitOfMeasurement="Yards" },
                new Item { Id = Guid.NewGuid().ToString(), Text = " ", Distance=2253, UnitOfMeasurement="Yards" },
                new Item { Id = Guid.NewGuid().ToString(), Text = " ", Distance=7358, UnitOfMeasurement="yds" }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<IEnumerable<Item>> GetMoreItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(moreItems);
        }
    }
}