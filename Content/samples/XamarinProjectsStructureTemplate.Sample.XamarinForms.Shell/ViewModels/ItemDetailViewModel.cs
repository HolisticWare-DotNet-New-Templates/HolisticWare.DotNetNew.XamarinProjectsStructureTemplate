using System;

using XamarinProjectsStructureTemplate.Sample.XamarinForms.Shell.Models;

namespace XamarinProjectsStructureTemplate.Sample.XamarinForms.Shell.ViewModels
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
