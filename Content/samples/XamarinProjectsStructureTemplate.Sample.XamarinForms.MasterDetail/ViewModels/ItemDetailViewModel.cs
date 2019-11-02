using System;

using XamarinProjectsStructureTemplate.Sample.XamarinForms.MasterDetail.Models;

namespace XamarinProjectsStructureTemplate.Sample.XamarinForms.MasterDetail.ViewModels
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
