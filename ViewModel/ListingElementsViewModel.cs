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

        private int _primaryPartNumber;

        public int PrimaryPartNumber
        {
            get { return _primaryPartNumber; }
            set 
            {
                if (_primaryPartNumber != value) 
                { 
                    _primaryPartNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<string> _primaryPartList;

		public IEnumerable<string> PrimaryPartList => _primaryPartList;

        public ListingElementsViewModel()
        {
			_primaryPartList = new ObservableCollection<string>();

            _primaryPartList.Add("TEST");
            _primaryPartList.Add("TEST");
            _primaryPartList.Add("TEST");
            _primaryPartList.Add("TEST");
            _primaryPartList.Add("TEST");

            addingListElements();

        }

        private void addingListElements()
        {
            for(int a=0;a<100;a++)
            { 
                _primaryPartList.Add(a.ToString());
            }

            PrimaryPartNumber = _primaryPartList.Count;
        }

    }
}
