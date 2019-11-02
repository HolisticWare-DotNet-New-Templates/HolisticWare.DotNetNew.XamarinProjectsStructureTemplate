using System;
using System.Collections.Generic;

namespace XamarinProjectsStructureTemplate.Sample.XamarinForms.Tabbed.Models
{
    public interface IItemRepository
    {
        void Add(Item item);
        void Update(Item item);
        Item Remove(string key);
        Item Get(string id);
        IEnumerable<Item> GetAll();
    }
}
