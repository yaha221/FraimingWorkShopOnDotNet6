using System;
using FraimingWorkShop.Models;
using FraimingWorkShop.Infrastructure.Commands;
using FraimingWorkShop.Views.Windows;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

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

        private void OnDataViewCommandExecuted(object p)
        {
            if (FrameIsSelected)
            {
              db.Frames.Load();   
              Frames = db.Frames.Local.ToObservableCollection();
              PriceData = Frames;

            }
            else if (CardboardIsSelected)
            {
                db.Cardboards.Load();
                Cardboards = db.Cardboards.Local.ToObservableCollection();
                PriceData = Cardboards;

            }
            else if (HangerIsSelected)
            {
                db.Hangers.Load();
                Hangers = db.Hangers.Local.ToObservableCollection();
                PriceData = Hangers;

            }
            else if (PeripheryIsSelected)
            {
                db.Peripheries.Load();
                Peripheries = db.Peripheries.Local.ToObservableCollection();
                PriceData = Peripheries;

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

        #region Команда поиска нужного элеемента в БД

        public ICommand DataFindCommand { get; }

        private static bool CanDataFindCommandExecuted(object p) => true;

        private void OnDataFindCommandExecuted(object p)
        {
            if (FrameIsSelected)
            {
                var filtred = Frames.Where(Frames => Frames.Title.StartsWith(FindItemOnPrice));
                PriceData = filtred;
            }
            else if (CardboardIsSelected)
            {
                db.Cardboards.Find(FindItemOnPrice);
            }
            else if (HangerIsSelected)
            {
                db.Hangers.Find(FindItemOnPrice);
            }
            else if (PeripheryIsSelected)
            {
                db.Peripheries.Find(FindItemOnPrice);
            }
        }

        #endregion

        public FraimingWorkShopVM()
        {
            DataViewCommand = new LambdaCommand(OnDataViewCommandExecuted, CanDataViewCommandExecuted);
            DataSaveCommand = new LambdaCommand(OnDataSaveCommandExecuted, CanDataSaveCommandExecuted);
            DataFindCommand = new LambdaCommand(OnDataFindCommandExecuted, CanDataFindCommandExecuted);
        }

        #region Свойства

        #region FindItemOnPrice - Свойство поиска данных в таблицах

        private string _findItemOnPrice;

        public string FindItemOnPrice
        {
            get => _findItemOnPrice;
            set => Set(ref _findItemOnPrice, value);
        }

        #endregion

        #region PriceData - Свойство для передачи данных в DataGrid;
        private IEnumerable _priceData;

        public IEnumerable PriceData
        {
            get=> _priceData;
            set => Set(ref _priceData, value);
        }
        #endregion

        #region PeripheryIsSelected - Свойство для проверки выбора элемента списка;
        private bool _peripheryIsSelected;

        public bool PeripheryIsSelected
        {
            get=> _peripheryIsSelected;
            set => Set(ref _peripheryIsSelected, value);
        }
        #endregion

        #region HangerIsSelected - Свойство для проверки выбора элемента списка;
        private bool _hangerIsSelected;

        public bool HangerIsSelected
        {
            get => _hangerIsSelected;
            set => Set(ref _hangerIsSelected, value);
        }
        #endregion

        #region CardboardIsSelected - Свойство для проверки выбора элемента списка;
        private bool _cardboardIsSelected;

        public bool CardboardIsSelected
        {
            get=> _cardboardIsSelected;
            set => Set(ref _cardboardIsSelected, value);
        }
        #endregion

        #region FrameIsSelected - Свойство для проверки выбора элемента списка;
        private bool _frameIsSelected;

        public bool FrameIsSelected
        {
            get => _frameIsSelected;
            set => Set(ref _frameIsSelected, value);
        }
        #endregion


        private Visibility _groupboxVisibility;

        public Visibility GroupBoxVisibility
        {
            get => _groupboxVisibility;
            set => Set(ref _groupboxVisibility, value);
        }

        #region Status - логика отображения статуса события;
        
        private string _status="Готово!";
        /// <summary> Status - логика отображения статуса </summary>
        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }
        #endregion
        #endregion
    }
}
