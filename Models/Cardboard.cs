using FramingWorkshop.Controller;

namespace FramingWorkshop.Models
{
    // Сущность "Картон"
    internal class Cardboard:ViewModel
    {
        internal int Id { get; set; }

        #region Толщина багета

        private float dense;
        /// <summary> Толщина картона </summary>
        internal float Dense
        {
            get { return dense; }
            set => Set(ref dense, value);

        }
        #endregion

        #region Цена картона

        private float price;
        /// <summary> Цена картона </summary>
        internal float Price
        {
            get { return price; }
            set => Set(ref price, value);
        }
        #endregion
    }
}
