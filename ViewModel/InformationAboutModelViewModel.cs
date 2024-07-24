using PrepareSubmittalTool.DB.Data;
using PrepareSubmittalTool.Extensions.Tekla;
using PrepareSubmittalTool.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tekla.Structures.Model;


namespace PrepareSubmittalTool.ViewModel
{
    public class InformationAboutModelViewModel : BaseViewModel
    {
		private string _modelName;

		public string ModelName
		{
			get {  return _modelName; }
			set 
			{ 
				if(_modelName != value) 
				{
					_modelName = value;
					OnPropertyChanged();
                }
            }
		}
		private string _submittalNumber;

		public string SubmittalNumber
		{
			get { return _submittalNumber; }
			set 
			{ 
				if(_submittalNumber != value) 
				{
                    _submittalNumber = value;
					OnPropertyChanged();
                }
            }
		}

		private string _submittalTitle;

		public string SubmittalTitle
		{
			get { return _submittalTitle; }
			set 
			{
				if (_submittalTitle != value)
				{
                    _submittalTitle = value;
					OnPropertyChanged();
                }
            }
		}

		private string _currentDate;

		public string CurrentDate
		{
			get { return _currentDate; }
			set 
			{
				if (_currentDate != value) 
				{
					_currentDate = value;
					OnPropertyChanged();
                }
            }
		}

		private string _whoPreparedSubmittal;

		public string WhoPreparedSubmittal
		{
			get { return _whoPreparedSubmittal; }
			set 
			{
				if (_whoPreparedSubmittal != value)
				{
                    _whoPreparedSubmittal = value;
					OnPropertyChanged();
                }
            }
		}

		public ICommand SaveElementsCommand { get;set; }

		public InformationAboutModelViewModel()
        {
			TeklaModelInfo teklaModelInfo = new TeklaModelInfo();
			ModelName = teklaModelInfo.GetModelName();
			CurrentDate = teklaModelInfo.Data;
			SaveElementsCommand = new RelayCommand(saveElements);
			SubmittalNumber = teklaModelInfo.GetSubmittalNumber();

        }

		private void saveElements(object element)
		{

			Submittal submittal = new Submittal()
			{ 
				Name = SubmittalTitle,
				Number = SubmittalNumber
			};

			SubmittalData.AddSubmittal(submittal);


		}

	}
}
