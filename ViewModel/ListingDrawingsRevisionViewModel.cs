using PrepareSubmittalTool.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace PrepareSubmittalTool.ViewModel
{
    public class ListingDrawingsRevisionViewModel : BaseViewModel
    {

        private ObservableCollection<DrawingAndRevisionInfo> _shopDrawingAndRevisionInfos;

        public ObservableCollection<DrawingAndRevisionInfo> ShopDrawingAndRevisionInfos
        {
            get { return _shopDrawingAndRevisionInfos; }
            set 
            {
                if (value == null)
                {
                    _shopDrawingAndRevisionInfos = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand ReadElements {  get; set; }

        public ListingDrawingsRevisionViewModel()
        {
            _shopDrawingAndRevisionInfos = new ObservableCollection<DrawingAndRevisionInfo>();

            ReadElements = new RelayCommand(readElement);
        }

        private async void readElement(object obj)
        {
            for (int a = 0; a <= 100; a++)
            {
                ShopDrawingAndRevisionInfos.Add(new DrawingAndRevisionInfo{ Description = "TEST", DrawingNumber="TEST", RevisionNumber="1"});
                await Task.Delay(10);
            }
        }
    }
}
