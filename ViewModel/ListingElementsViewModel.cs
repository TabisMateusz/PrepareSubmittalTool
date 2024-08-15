using Microsoft.EntityFrameworkCore.Metadata;
using PrepareSubmittalTool.Extensions.TeklaExtensions;
using PrepareSubmittalTool.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        private bool _buttonSaveEnable;

        public bool ButtonSaveEnable
        {
            get { return _buttonSaveEnable; }
            set 
            {
                if(value != _buttonSaveEnable)
                { 
                    _buttonSaveEnable = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _buttonRefreshEnable;

        public bool ButtonRefreshEnable
        {
            get { return _buttonRefreshEnable; }
            set 
            {
                if (_buttonRefreshEnable != value)
                {
                    _buttonRefreshEnable = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand RefreshElementListCommand { get;set; }

        public ListingElementsViewModel()
        {
            WriteSelectedElements();
            RefreshElementListCommand = new RelayCommand(refreshElementList);
        }

        private void refreshElementList(object obj)
        {
            ReadInformationFromSelectedElements readInformation = new ReadInformationFromSelectedElements();
            readInformation.ReadSelectedElements();
            WriteSelectedElements();
        }

        private void WriteSelectedElements()
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

            var AnyIsNotNumbered = TemporaryFields.SelectedElementsInfo.SelectMany(x => x.Value).Select(x=>x.IsNumbering).Any(x=>x == false);

            ButtonSaveEnable = AnyIsNotNumbered ? false : true;
            ButtonRefreshEnable = AnyIsNotNumbered ? true : false;
        }
    }
}
