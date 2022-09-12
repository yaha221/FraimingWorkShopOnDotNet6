using System.Windows.Documents;
using FraimingWorkShop.ViewModels;

namespace FraimingWorkShop.Models
{
    // Сущность "Подвесы"
    public class Hanger :ViewModel
    {

        public int Id { get; set; }

        #region Название подвеса

        private string title;
        /// <summary>Название подвеса</summary>
        public string Title
        {
            get { return title; }
            set => Set(ref title, value);
        }
        #endregion

        #region Цена подвеса

        private float price;
        /// <summary>Цена подвеса</summary>
        public float Price
        {
            get { return price; }
            set => Set(ref price, value);
        }
        #endregion

        #region Кол-во шурупов на подвес

        private int screws;
        /// <summary>Кол-во шурупов на подвес</summary>
        public int Screws
        {
            get { return screws; }
            set => Set(ref screws, value);
        }        
        #endregion
    }
}
