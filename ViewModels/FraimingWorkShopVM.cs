using System;
using FraimingWorkShop.Models;
using FraimingWorkShop.Infrastructure.Commands;
using FraimingWorkShop.Views.Windows;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Frame = FraimingWorkShop.Models.Frame;

namespace FraimingWorkShop.ViewModels
{
    internal class FraimingWorkShopVM : ViewModel
    {
        #region Поля

        private readonly FraimingWorkShopContext db = new();
        public ObservableCollection<Frame> Frames { get; set; }
        public ObservableCollection<Cardboard> Cardboards { get; set; }
        public ObservableCollection<Hanger> Hangers { get; set; }
        public ObservableCollection<Periphery> Peripheries { get; set; }

        #endregion

        #region Команды

        #region Команда загрузки таблиц из БД

        public ICommand DataViewCommand { get; }

        private static bool CanDataViewCommandExecuted(object p) => true;

        private void OnDataViewCommandExecuted(object p)
        {
            if (SelectedTable != null)
            {
                Task displaySelectedTask = Task.Run(() =>
                    DisplaySelectedData(SelectedTable));
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
            if (SelectedTable != null)
            {
                Task findSelectedItemTask = Task.Run(() =>
                    FindDataInSelectedTable(SelectedTable));
            }
        }

        #endregion 

        #endregion

        public FraimingWorkShopVM()
        {
            #region Загрузка необходимых данных

            Task loadFramesTask = Task.Run(LoadDB);

            #endregion

            #region Команды

            DataViewCommand = new LambdaCommand(OnDataViewCommandExecuted, CanDataViewCommandExecuted);
            DataSaveCommand = new LambdaCommand(OnDataSaveCommandExecuted, CanDataSaveCommandExecuted);
            DataFindCommand = new LambdaCommand(OnDataFindCommandExecuted, CanDataFindCommandExecuted);

            #endregion
        }

        #region Свойства

        #region SelectedTable - Выбранная таблица

        private string _selectedTable;

        public string SelectedTable
        {
            get => _selectedTable;
            set => Set(ref _selectedTable, value);
        } 

        #endregion

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

        #region Status - логика отображения статуса события;
        
        private string _status="Готово!";
        /// <summary> Status - логика отображения статуса </summary>
        public string Status
        {
            get => _status;
            set => Set(ref _status, value);
        }
        #endregion

        #region FrameNamefromForms - название багета из формы

        private string _frameNamefromForms;

        public string FrameNamefromForms
        {
            get => _frameNamefromForms;
            set => Set(ref _frameNamefromForms, value);
        }

        #endregion

        #region FrameHeight - высота багета

        private int _frameHeight;

        public int FrameHeight
        {
            get => _frameHeight;
            set => Set(ref _frameHeight, value);
        }

        #endregion

        #region FrameWidth - Ширина багета

        private int _frameWidth;

        public int FrameWidth
        {
            get => _frameWidth;
            set => Set(ref _frameWidth, value);
        }

        #endregion

        #region CardboardSum - считать картон

        private bool _cardboardSum;

        public bool CardboardSum
        {
            get => _cardboardSum;
            set => Set(ref _cardboardSum, value);
        }

        #endregion

        #region GlassSum - считать стекло

        private bool _glassSum;

        public bool GlassSum
        {
            get => _glassSum;
            set => Set(ref _glassSum, value);
        }

        #endregion

        #region HangerSum - считать подвесы

        private bool _hangerSum;

        public bool HangerSum
        {
            get => _hangerSum;
            set => Set(ref _hangerSum, value);
        }

        #endregion

        #region HangersTitle - название подвесов

        private ObservableCollection<string> _hangerTitle;

        public ObservableCollection<string> HangerTitle
        {
            get => _hangerTitle;
            set => Set(ref _hangerTitle, value);
        }

        #endregion

        #region HangerCount - Количество подвесов

        private int _hangerCount;

        public int HangerCount
        {
            get => _hangerCount;
            set => Set(ref _hangerCount, value);
        }

        #endregion

        #region CarboardDense - толщина картона

        private double _cardboardDense;

        public double CardboardDense
        {
            get => _cardboardDense;
            set => Set(ref _cardboardDense, value);
        }

        #endregion

        #endregion

        #region Методы

        #region Подсчёт цены рамы

        private static double SummaryFrame(double frameHeigth, double frameWeidth, double frameIndent, double framePrice) 
            => (((frameHeigth + frameWeidth) * 2 + (frameIndent * 4)) / 100) * framePrice;

        #endregion

        #region Подсчёт цены стекла
        
        private static double SummaryGlass(double frameHeight, double frameWeidth, double glassPrice) 
            => ((frameHeight * frameWeidth) / 1000) * glassPrice;

        #endregion

        #region Подсчёт подвесов

        private static double SummaryHanger(int hangerCount, double hangerPrice)
            => hangerCount * hangerPrice;

        #endregion

        #region Подсчёт цены картона

        private static double SummaryCardboard(int frameHeight, int frameWidth, double cardboardPrice, double summaryHanger)
            => (frameHeight*frameWidth/1000 * cardboardPrice)+summaryHanger;

        #endregion
        
        #region Подсчёт цены рамы со стеклом

        private static double SummaryGlassAndFrame(double summaryFrame, double summaryGlass) => (summaryFrame + summaryGlass) * 2;

        #endregion

        #region Подсчёт цены рамы со стеклом и картоном

        private static double SummaryFrameGlassAndCardboard(double summaryFrame, double summaryGlass,
            double summaryCardboard) =>
            summaryFrame + summaryGlass + summaryCardboard;

        #endregion

        #region Логика просчёта из формы

        private void SummaryForm (bool cardboarSum, bool glassSum, int hangerCount)
        {
            if (cardboarSum)
            {
                //SummaryCardboard();
            }
        }

        #endregion

        #region Отображение данных в зависимости от выбранного элемента;

        private IEnumerable DisplaySelectedData(string selectedTable)
        {
            switch (selectedTable)
            {
                case "System.Windows.Controls.ListBoxItem: Багет":
                    return PriceData = Frames;
                case "System.Windows.Controls.ListBoxItem: Картон":
                    return PriceData = Cardboards;
                case "System.Windows.Controls.ListBoxItem: Подвесы":
                    return PriceData = Hangers;
                case "System.Windows.Controls.ListBoxItem: Остальное":
                   return PriceData = Peripheries;
                default:
                    return PriceData = null;
            }
        }

        #endregion

        #region Поиск данных в нужном столбце

        private IEnumerable FindDataInSelectedTable(string selectedTable)
        {
            switch (selectedTable)
            {
                case "System.Windows.Controls.ListBoxItem: Багет":
                    var filtredFrame = Frames.Where(Frames => Frames.Title.StartsWith(FindItemOnPrice));
                    return PriceData = filtredFrame;
                case "System.Windows.Controls.ListBoxItem: Картон":
                    var filtredCardboards = Cardboards.Where(Cardboards => Cardboards.Dense.Equals(FindItemOnPrice));
                    return PriceData = filtredCardboards;
                case "System.Windows.Controls.ListBoxItem: Подвесы":
                    var filtredHanger = Hangers.Where(Hangers => Hangers.Title.StartsWith(FindItemOnPrice));
                    return PriceData = filtredHanger;
                case "System.Windows.Controls.ListBoxItem: Остальное":
                    var filtredOther = Peripheries.Where(Peripheries => Peripheries.Title.StartsWith(FindItemOnPrice));
                    return PriceData = filtredOther;
                default:
                    return PriceData = null;

            }
        }

        #endregion

        #region Загрузка данных из бд

        private void LoadDB()
        {
            db.Frames.Load();
            Frames = db.Frames.Local.ToObservableCollection();

            db.Cardboards.Load();
            Cardboards = db.Cardboards.Local.ToObservableCollection();

            db.Peripheries.Load();
            Peripheries = db.Peripheries.Local.ToObservableCollection();

            db.Hangers.Load();
            Hangers = db.Hangers.Local.ToObservableCollection();

        }

        #endregion

        //#region Автогенерация столбцов для Frame

        //public void Frame_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        //{
        //    if (SelectedTable == "System.Windows.Controls.ListBoxItem: Багет")
        //    {
        //        e.Column.Header = e.Column.DisplayIndex switch
        //        {
        //            1 => "Номер",
        //            2 => "Название",
        //            3 => "Отступ",
        //            4 => "Цена",
        //            5 => "Количество скоб",
        //            _ => e.Column.Header
        //        };
        //    }
        //}

        //#endregion

        #endregion

        #region Делегаты


        #endregion
    }
}
