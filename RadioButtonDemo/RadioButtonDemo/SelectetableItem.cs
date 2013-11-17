using System.ComponentModel;

namespace RadioButtonDemo
{
    public class SelectetableItem : INotifyPropertyChanged
    {
        public string ItemDescription { get; set; }

        public bool IsSelected { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}