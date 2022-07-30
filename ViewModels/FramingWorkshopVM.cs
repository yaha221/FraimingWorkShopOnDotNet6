using FramingWorkshop.Models;
using FramingWorkshop.View;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Windows.Input;

namespace FramingWorkshop.Controller
{
    internal class FramingWorkshopVM : ViewModel
    {
        //IEnumerable<Cardboard> cardboards;
        //IEnumerable<Hanger> hangers;
        //IEnumerable<Periphery> peripheries;


        //public IEnumerable<Cardboard> Cardboards
        //{
        //    get { return cardboards; }
        //}

        //public IEnumerable<Hanger> Hangers
        //{
        //    get { return hangers; }
        //}

        //public IEnumerable<Periphery> Peripheries
        //{
        //    get { return peripheries; }
        //}
        #region Сущность "Багет"

        //internal IEnumerable<Frame> frames;
        ///// <summary>Сущность "Багет"</summary>
        //internal IEnumerable<Frame> Frames
        //{
        //    get { return frames; }
        //    set => Set(ref frames, value);
        //}

        #endregion

        #region Команда загрузки сущности "Багет" из БД

        //private readonly FramingWorkshopContext db;
        //internal FramingWorkshopVM()
        //{
        //    db = new FramingWorkshopContext();
        //    //db.Frames.Load();
        //    //db.Hangers.Load();
        //    //db.Cardboards.Load();
        //    //db.Peripheries.Load();

        //}
        #endregion

        #region Команда вызова окна редактирования сущности "Багет"

        public ICommand FrameEditorCommand { get; }

        private bool CanFrameEditorCommandExecuted(object p) => true;
        private void OnFrameEditorCommandExecuted(object p) 
        {
            FrameWindow frameWindow = new FrameWindow();
            frameWindow.ShowDialog();
        }
        #endregion

        public FramingWorkshopVM()
        {
            FrameEditorCommand = new LambdaCommand(OnFrameEditorCommandExecuted, CanFrameEditorCommandExecuted);
        }
    }
}
