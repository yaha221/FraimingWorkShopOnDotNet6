using System;
using FramingWorkshop.Models;
using FramingWorkshop.Controller;
using FramingWorkshop.View;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FramingWorkshop
{
    internal class FrameVM : ViewModel
    {
        #region Багет

        IEnumerable<Frame> frames;
        /// <summary> Багет </summary>
        public IEnumerable<Frame> Frames
        {
            get { return frames; }
            set => Set(ref frames, value);

        }
        #endregion

        #region Загрузка сущности "Багет" из БД

        private readonly FramingWorkshopContext db;
        public FrameVM()
        {
            AddFrameCommand = new LambdaCommand(OnAddFrameCommandexecuted, CanAddFrameCommandExecuted);
            //db = new FramingWorkshopContext();
            //db.Frames.Load();
            //Frames = db.Frames.Local.ToBindingList();
        }
        #endregion

        #region Команда добавления багета в БД

        public ICommand AddFrameCommand { get; }

        private bool CanAddFrameCommandExecuted(object p) => true;

        private void OnAddFrameCommandexecuted(object p)
        {
            AddFrameWindow addFrameWindow = new AddFrameWindow(new Frame());
            if (addFrameWindow.ShowDialog() == true)
            {
                Frame frame = addFrameWindow.Frame;
                db.Frames.Add(frame);
                db.SaveChanges();
            }
        }
        #endregion

        #region Команда редактирования багета

        public ICommand EditFrameCommand { get; }

        private bool CanEditFrameCommandExecuted(object p) => true;

        private void OnEditFrameCommandExecuted(object p)
        {

            if (selectedItem == null) return;
            Frame frame = selectedItem as Frame;
            Frame fr = new Frame()
            {
                Id = frame.Id,
                Title = frame.Title,
                Correction = frame.Correction,
                Price = frame.Price,
                AmountClip = frame.AmountClip
            };
            AddFrameWindow frameWindow = new AddFrameWindow(fr);
            if (frameWindow.ShowDialog() == true)
            {
                frame = db.Frames.Find(frameWindow.Frame.Id);
                if (frame != null)
                {
                    frame.Title = frameWindow.Frame.Title;
                    frame.Price = frameWindow.Frame.Price;
                    frame.Correction = frameWindow.Frame.Correction;
                    frame.AmountClip = frameWindow.Frame.AmountClip;
                    db.Entry(frame).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }
        }

        //{
        //    get
        //    {
        //        return editCommand ??
        //            (editCommand = new RelayCommand((selectedItem) =>
        //            {if (selectedItem == null) return;
        //                Frame frame = selectedItem as Frame;
        //                Frame fr = new Frame()
        //                {
        //                    Id = frame.Id,
        //                    Title = frame.Title,
        //                    Correction = frame.Correction,
        //                    Price = frame.Price,
        //                    AmountClip = frame.AmountClip
        //                };
        //                FrameWindow frameWindow = new FrameWindow(fr);
        //                if(frameWindow.ShowDialog() == true)
        //                {
        //                    frame = db.Frames.Find(frameWindow.Frame.Id);
        //                    if(frame != null)
        //                    {
        //                        frame.Title = frameWindow.Frame.Title;
        //                        frame.Price = frameWindow.Frame.Price;
        //                        frame.Correction = frameWindow.Frame.Correction;
        //                        frame.AmountClip = frameWindow.Frame.AmountClip;
        //                        db.Entry(frame).State = EntityState.Modified;
        //                        db.SaveChanges();
        //                    }
        //                }
        //            }));
        //    }
        //}
        #endregion

        //#region Команда удаления багета из БД

        //RelayCommand deletCommand;
        //public RelayCommand DeleteCommand
        //{
        //    get
        //    {
        //        return deletCommand ??
        //            (deletCommand = new RelayCommand((selectedItem) =>
        //            {
        //                if (selectedItem == null) return;
        //                Frame frame = selectedItem as Frame;
        //                db.Frames.Remove(frame);
        //                db.SaveChanges();
        //            }));
        //    }
        //}
        //#endregion

    }
}
