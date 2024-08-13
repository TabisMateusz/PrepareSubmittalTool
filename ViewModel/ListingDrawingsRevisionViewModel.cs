using PrepareSubmittalTool.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace PrepareSubmittalTool.ViewModel
{
    public class ListingDrawingsRevisionViewModel : BaseViewModel
    {

        private ObservableCollection<DrawingAndRevisionInfo> _shopDrawingAndRevisionList = new ObservableCollection<DrawingAndRevisionInfo>();
        public ObservableCollection<DrawingAndRevisionInfo> ShopDrawingAndRevisionList
        {
            get { return _shopDrawingAndRevisionList; }
            set 
            {
                if (_shopDrawingAndRevisionList != value)
                {
                    _shopDrawingAndRevisionList = value;
                    OnPropertyChanged();
                }
            }
        }
        private ObservableCollection<DrawingAndRevisionInfo> _partDrawingAndRevisionList = new ObservableCollection<DrawingAndRevisionInfo>();
        public ObservableCollection<DrawingAndRevisionInfo> PartDrawingAndRevisionList
        {
            get { return _partDrawingAndRevisionList; }
            set 
            {
                if (_partDrawingAndRevisionList != value)
                {
                    _partDrawingAndRevisionList = value;
                    OnPropertyChanged();
                }
            }
        }
        private ObservableCollection<DrawingAndRevisionInfo> _ePlansDrawingAndRevisionList = new ObservableCollection<DrawingAndRevisionInfo>();

        public ObservableCollection<DrawingAndRevisionInfo> EPlansDrawingAndRevisionList
        {
            get { return _ePlansDrawingAndRevisionList; }
            set 
            {
                if (_ePlansDrawingAndRevisionList != value)
                {
                    _ePlansDrawingAndRevisionList = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _shopDrawingAndRevisionListLength;

        public int ShopDrawingAndRevisionListLength
        {
            get { return _shopDrawingAndRevisionListLength; }
            set
            {
                if (_shopDrawingAndRevisionListLength != value)
                {
                    _shopDrawingAndRevisionListLength = value;
                    OnPropertyChanged();
                }
            }                 
        }

        private int _partDrawingAndRevisionListLength;

        public int PartDrawingAndRevisionListLength
        {
            get { return _partDrawingAndRevisionListLength; }
            set 
            {
                if (_partDrawingAndRevisionListLength != value)
                {
                    _partDrawingAndRevisionListLength = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _ePlansDrawingAndRevisionListLength;

        public int EPlansDrawingsAndRevisionListLength
        {
            get { return _ePlansDrawingAndRevisionListLength; }
            set 
            { 
                if (_ePlansDrawingAndRevisionListLength != value)
                {
                    _ePlansDrawingAndRevisionListLength= value;
                    OnPropertyChanged();
                }
            }
        }

        public ListingDrawingsRevisionViewModel()
        {
                            
            ReadSelectedDrawings();
        }

        private async void ReadSelectedDrawings()
        {
            var shopDrawingsInfo = TemporaryFields.SelectedDrawingAndRevisionInfos.Where(x => x.Key == "SHOP").Select(x => x.Value);
            var partDrawingsInfo = TemporaryFields.SelectedDrawingAndRevisionInfos.Where(x => x.Key == "PART").Select(x => x.Value);
            var ePlansDrawingsInfo = TemporaryFields.SelectedDrawingAndRevisionInfos.Where(x => x.Key == "E-PLANS").Select(x => x.Value);

            foreach (var shopDrawing in shopDrawingsInfo.FirstOrDefault()) 
            {
                if(shopDrawing != null)
                    ShopDrawingAndRevisionList.Add(shopDrawing);
                await Task.Delay(10);
            }
            foreach (var partDrawing in partDrawingsInfo.FirstOrDefault())
            {
                if(partDrawing != null)
                    PartDrawingAndRevisionList.Add(partDrawing);
                await Task.Delay(10);
            }
            foreach (var ePlanDrawing in ePlansDrawingsInfo.FirstOrDefault())
            {
                if(ePlanDrawing != null)
                    EPlansDrawingAndRevisionList.Add(ePlanDrawing);
                await Task.Delay(10);
            }
            ShopDrawingAndRevisionListLength = shopDrawingsInfo.FirstOrDefault().Count();
            PartDrawingAndRevisionListLength = partDrawingsInfo.FirstOrDefault().Count();
            EPlansDrawingsAndRevisionListLength = ePlansDrawingsInfo.FirstOrDefault().Count();
        }
    }
}
