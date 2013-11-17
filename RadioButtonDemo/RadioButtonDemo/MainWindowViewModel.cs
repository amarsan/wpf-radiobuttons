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

            Salads = new Collection<SelectetableItem>
                {
                    new SelectetableItem { ItemDescription = "Kale Avocado"},
                    new SelectetableItem { ItemDescription = "Caesar"},
                    new SelectetableItem { ItemDescription = "Arugula with Goat Cheese", IsSelected = true},
                    new SelectetableItem { ItemDescription = "Garden"}
                };
        }

        // Vegetables
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

        // Salads
        // Note: If you need to know when the selection has changed immediatly, e.g. for storing to DB, need to handle click event or do something in SelectableItem
        public Collection<SelectetableItem> Salads { get; set; }
 
        public SelectetableItem SelectedSalad
        {
            get { return Salads.FirstOrDefault(s => s.IsSelected); }
        }

        // Dessert
        public string[] Desserts
        {
            get { return Enum.GetNames(typeof (DessertEnumeration)); }
        }


        // Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        private void onNotifyPropertyChanged(string propertyName)
        {
            var eventToFire = PropertyChanged;
            if (eventToFire != null)
                eventToFire(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
