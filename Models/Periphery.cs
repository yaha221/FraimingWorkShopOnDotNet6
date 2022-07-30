using FramingWorkshop.Controller;

namespace FramingWorkshop.Models
{
    // Сущность "Переферия" (стекло,лепестки,скобы)
    internal class Periphery : ViewModel
    {

        public int Id { get; set; }

        #region Названиеи переферии
        /// <summary> Названиеи переферии </summary>
        private string title;
        public string Title
        {
            get { return title; }
            set => Set(ref title, value);
        }
        #endregion

        #region Цена переферии
        /// <summary> Цена переферии </summary>
        private double price;
        public double Price
        {
            get { return price; }
            set => Set(ref price, value);            
        }       
        #endregion
    }
}
