using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace WpfNavigable.Front.ViewModels.Base
{
    public class ViewModelBase: INotifyPropertyChanged
    {
        public bool ThrowOnInvalidPropertyName { get; }
        public ViewModelBase(bool throwOnInvalidPropertyName = false)
        {
            ThrowOnInvalidPropertyName = throwOnInvalidPropertyName;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            this.VerifyPropertyName(propertyName);
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
        [Conditional("DEBUG")]
        [DebuggerStepThrough]
        public void VerifyPropertyName(string propertyName)
        {
            // Verify that the property name matches a real, 
            // public, instance property on this object. 
            if (TypeDescriptor.GetProperties(this)[propertyName] == null)
            {
                string msg = "Invalid property name: " + propertyName;
                if (this.ThrowOnInvalidPropertyName)
                    throw new Exception(msg);
                else
                    Debug.Fail(msg);
            }
        }
    }
}
