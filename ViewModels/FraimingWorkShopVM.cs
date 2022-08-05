using FraimingWorkShop.Models;
using FraimingWorkShop.Infrastructure.Commands;
using FraimingWorkShop.Views.Windows;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace FraimingWorkShop.ViewModels
{
    internal class FraimingWorkShopVM : ViewModel
    {
        private readonly FraimingWorkShopContext db = new();
        public ObservableCollection<Frame> Frames { get; set; }
        public ObservableCollection<Cardboard> Cardboards { get; set; }
        public ObservableCollection<Hanger> Hangers{ get; set; }
        public ObservableCollection<Periphery> Peripheries { get; set; }


        #region Команда загрузки таблиц из БД

        public ICommand DataViewCommand { get; }

        private static bool CanDataViewCommandExecuted(object p) => true;
        //{
        //    if (FrameList)
        //    {
        //        return true;
        //    }
        //}

        private void OnDataViewCommandExecuted(object p)
        {
            if (((MainWindow)System.Windows.Application.Current.MainWindow).Frame.IsSelected)
            {
              db.Frames.Load();   
              Frames = db.Frames.Local.ToObservableCollection();
              ((MainWindow)System.Windows.Application.Current.MainWindow).PriceDataGrid.ItemsSource = Frames;

            }
            else if (((MainWindow)System.Windows.Application.Current.MainWindow).Cardboard.IsSelected)
            {
                db.Cardboards.Load();
                Cardboards = db.Cardboards.Local.ToObservableCollection();
                ((MainWindow)System.Windows.Application.Current.MainWindow).PriceDataGrid.ItemsSource = Cardboards;

            }
            else if (((MainWindow)System.Windows.Application.Current.MainWindow).Hanger.IsSelected)
            {
                db.Hangers.Load();
                Hangers = db.Hangers.Local.ToObservableCollection();
                ((MainWindow)System.Windows.Application.Current.MainWindow).PriceDataGrid.ItemsSource = Hangers;

            }
            else if (((MainWindow)System.Windows.Application.Current.MainWindow).Periphery.IsSelected)
            {
                db.Peripheries.Load();
                Peripheries = db.Peripheries.Local.ToObservableCollection();
                ((MainWindow)System.Windows.Application.Current.MainWindow).PriceDataGrid.ItemsSource = Peripheries;

            }
        }

        #endregion

        #region Команда сохранения изменений в БД

        public ICommand DataSaveCommand { get; }

        private static bool CanDataSaveCommandExecuted(object p) => true;
        private void OnDataSaveCommandExecuted(object p)
        {
            db.SaveChanges();
        }
        #endregion

        public FraimingWorkShopVM()
        {
            DataViewCommand = new LambdaCommand(OnDataViewCommandExecuted, CanDataViewCommandExecuted);
            DataSaveCommand = new LambdaCommand(OnDataSaveCommandExecuted, CanDataSaveCommandExecuted);

        }

        #region ListStatus - определяет выбран объект листа или нет

        private bool _liststatus;

        public bool ListStatus
        {
            get => _liststatus;
            set => Set(ref _liststatus, value);
        }
        #endregion

        #region Status - логика отображения статуса события;
        
        private string _status="Готово!";
        /// <summary> Status - логика отображения статуса </summary>
        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }
        #endregion
    }
}
