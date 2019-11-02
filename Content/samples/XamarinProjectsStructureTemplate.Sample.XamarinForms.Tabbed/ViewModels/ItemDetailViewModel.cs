using System;

using XamarinProjectsStructureTemplate.Sample.XamarinForms.Tabbed.Models;

namespace XamarinProjectsStructureTemplate.Sample.XamarinForms.Tabbed.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
        }
    }
}
