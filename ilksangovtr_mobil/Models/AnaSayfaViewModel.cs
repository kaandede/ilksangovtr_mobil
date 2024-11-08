using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ilksangovtr_mobil.Models
{

    public partial class AnaSayfaViewModel : ObservableObject
    {
        public ObservableCollection<CarouselItem> CarouselItems { get; set; } = new();
        public AnaSayfaViewModel() 
        {
            CarouselItems.Add(new CarouselItem()
            {
                Title = "Başlık 1",
                Description= "Açıklama 2",
                Image = "back4.png"
            });
            CarouselItems.Add(new CarouselItem()
            {
                Title = "Başlık 2",
                Description = "Açıklama 2",
                Image = "back2.png"
            });
        }
    }
}
