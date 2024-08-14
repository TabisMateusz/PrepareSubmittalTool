using PrepareSubmittalTool.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrepareSubmittalTool.ViewModel
{
    public class ListingElementsViewModel : BaseViewModel
    {

        private string _mainPartInfoNumber;

        public string MainPartInfoNumber
        {
            get { return _mainPartInfoNumber; }
            set 
            {
                if (_mainPartInfoNumber != value) 
                { 
                    _mainPartInfoNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _seconderyPartInfoNumber;

        public string SecondaryPartInfoNumber
        {
            get { return _seconderyPartInfoNumber; }
            set 
            {
                if( _seconderyPartInfoNumber != value) 
                {
                    _seconderyPartInfoNumber = value;
                    OnPropertyChanged();
                }
            }
        }
                
        private Dictionary<string, int> _seconderyPartInfo = new Dictionary<string, int>();

        public Dictionary<string, int> SecondaryPartInfo
        {
            get { return _seconderyPartInfo; }
            set
            {
                if (_seconderyPartInfo != value)
                {
                    _seconderyPartInfo = value;
                    OnPropertyChanged();
                }
            }
        }

        private Dictionary<string,int> _mainPartInfo = new Dictionary<string,int>();

        public Dictionary<string,int> MainPartInfo
        {
            get { return _mainPartInfo; }
            set 
            { 
                if (_mainPartInfo != value)
                {
                    _mainPartInfo = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _changeVisibility;

        public string ChangerVisibility
        {
            get { return _changeVisibility; }
            set 
            {
                if (value != _changeVisibility)
                {
                    _changeVisibility = value;
                    OnPropertyChanged();
                }
            }
        }


        public ListingElementsViewModel()
        {
            ReadSelectedElements();
        }

        private void ReadSelectedElements()
        {
            MainPartInfo = TemporaryFields.SelectedElementsInfo
                .Where(x => x.Key == "MAINPART")
                .Select(x => x.Value)
                .SelectMany(x => x)
                .GroupBy(s => s.PartNumber)
                .ToDictionary(g => g.Key, g => g.Count());

            SecondaryPartInfo = TemporaryFields.SelectedElementsInfo
                .Where(x => x.Key == "SECONDARYPART")
                .Select(x => x.Value)
                .SelectMany(x => x)
                .GroupBy(s => s.PartNumber)
                .ToDictionary(g => g.Key, g => g.Count());

            MainPartInfoNumber = MainPartInfo.Values.Sum().ToString();
            SecondaryPartInfoNumber = SecondaryPartInfo.Values.Sum().ToString();


        }
    }
}
