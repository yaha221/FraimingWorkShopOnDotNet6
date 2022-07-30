using FramingWorkshop.Controller;

namespace FramingWorkshop.Models
{
    // Сущность "Подвесы"
    internal class Hanger :ViewModel
    {

        internal int Id { get; set; }

        #region Название подвеса

        private string title;
        /// <summary>Название подвеса</summary>
        internal string Title
        {
            get { return title; }
            set => Set(ref title, value);
        }
        #endregion

        #region Цена подвеса

        private float price;
        /// <summary>Цена подвеса</summary>
        internal float Price
        {
            get { return price; }
            set => Set(ref price, value);
        }
        #endregion

        #region Кол-во шурупов на подвес

        private int screws;
        /// <summary>Кол-во шурупов на подвес</summary>
        internal int Screws
        {
            get { return screws; }
            set => Set(ref screws, value);
        }        
        #endregion
    }
}
