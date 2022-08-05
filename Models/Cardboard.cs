using FraimingWorkShop.ViewModels;

namespace FraimingWorkShop.Models
{
    // Сущность "Картон"
    public class Cardboard:ViewModel
    {
        public int Id { get; set; }

        #region Толщина багета

        private float dense;
        /// <summary> Толщина картона </summary>
        public float Dense
        {
            get { return dense; }
            set => Set(ref dense, value);

        }
        #endregion

        #region Цена картона

        private float price;
        /// <summary> Цена картона </summary>
        public float Price
        {
            get { return price; }
            set => Set(ref price, value);
        }
        #endregion
    }
}
