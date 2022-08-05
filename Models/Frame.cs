using FraimingWorkShop.ViewModels;

namespace FraimingWorkShop.Models
{
    // Сущность "Багет"
    public class Frame : ViewModel
    {

        public int Id { get; set; }

        #region Название багета

        private string? title;
        /// <summary> Название багета </summary>
        public string Title
        {
            get => title;
            set => Set(ref title, value);

        }
        #endregion

        #region Отступ багета

        private float correction;
        /// <summary> Отступ багета </summary>
        public float Correction
        {
            get { return correction; }
            set => Set(ref correction, value);      
        }
        #endregion

        #region Цена багета

        private float price;
        /// <summary>Цена багета</summary>
        public float Price
        {
            get { return price; }
            set => Set(ref price, value);

        }
        #endregion

        #region Кол-во скоб на угол скрепления

        private int amountClip;
        /// <summary>Кол-во скоб на угол скрепления</summary>
        public int AmountClip
        {
            get { return amountClip; }
            set => Set(ref amountClip, value);

        }
        #endregion
    }
}
