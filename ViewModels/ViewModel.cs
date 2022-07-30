using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace FramingWorkshop.Controller
{
    /// <summary> Класс реализующий интерфейс INotifyPropertyChanged </summary>
    internal abstract class ViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged ([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field,T value, [CallerMemberName]string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
