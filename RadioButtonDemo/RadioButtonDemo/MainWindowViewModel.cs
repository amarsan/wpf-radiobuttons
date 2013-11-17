using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioButtonDemo
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            VegetableDishes = new Collection<string> { "Butternut Squash Soufle", "Roasted Celery Root", "Sauteed Brussel Sprouts", "Glazed Carrots"};
            SelectedVegetableDish = VegetableDishes.Last();
        }

        private ICollection<string> vegetableDishes; 
        public ICollection<string> VegetableDishes 
        {
            get { return vegetableDishes; }
            set 
            { 
                vegetableDishes = value;
                onNotifyPropertyChanged("VegetableDishes");
            }
        }

        private string selectedVegetableDish;
        public string SelectedVegetableDish
        {
            get { return selectedVegetableDish; }
            set 
            { 
                selectedVegetableDish = value;
                onNotifyPropertyChanged("SelectedVegetableDish");
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void onNotifyPropertyChanged(string propertyName)
        {
            var eventToFire = PropertyChanged;
            if (eventToFire != null)
                eventToFire(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
