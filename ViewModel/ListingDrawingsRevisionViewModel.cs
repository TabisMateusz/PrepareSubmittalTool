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

        public ListingDrawingsRevisionViewModel()
        {
            _shopDrawingAndRevisionInfos = new ObservableCollection<DrawingAndRevisionInfo>();
                
            ReadSelectedDrawings();
        }

        private async void ReadSelectedDrawings()
        {
            foreach (var element in TemporaryFields.ShopDrawingAndRevisionInfos)
            {
                ShopDrawingAndRevisionInfos.Add(element);
                await Task.Delay(10);
            }
        }

        
    }
}
