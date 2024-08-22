using PrepareSubmittalTool.DB.Data;
using PrepareSubmittalTool.Extensions.TeklaExtensions;
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
        #region Properties
        private string _projectName;

		public string ProjectName
		{
			get {  return _projectName; }
			set 
			{ 
				if(_projectName != value) 
				{
					_projectName = value;
					OnPropertyChanged();
                }
            }
		}
		private int _submittalNumber;

		public int SubmittalNumber
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

        #endregion

        public InformationAboutModelViewModel()
        {
            GetInfoAboutModel teklaModelInfo = new GetInfoAboutModel();
			ProjectName = teklaModelInfo.GetModelName();
			CurrentDate = DateTime.Now.ToString("MMM_dd_yy", (IFormatProvider)new CultureInfo("en-us")).ToUpper().ToString();

		    SaveElementsCommand = new RelayCommand(saveSubmittalInfo);
			//getSubmittalNumber();
			//saveSubmittal();
			//var existing = ClientData.ClientExist(_modelName);
		}

		private void saveSubmittal()
		{
			SubmittalData.AddSubmittal(new Submittal()
			{
				Submittal_Number = SubmittalNumber,
				Project_ID = ProjectData.GetProjectId(_projectName)
			});
		}
		private void getSubmittalNumber()
		{
            var ifAnySubmittal = SubmittalData.AnySubmittalForProject(_projectName);
            if (!ifAnySubmittal)
                SubmittalNumber = 1;
            else
                SubmittalNumber = SubmittalData.GetLastSubmittalNumber(_projectName) + 1;
        }

		private void saveSubmittalInfo(object element)
		{
			SubmittalInfoData.AddSubmittalInfo(new SubmittalInfo
			{
				Who_Prepared = WhoPreparedSubmittal,
				Date = CurrentDate,
				Filter = "#00" + SubmittalNumber.ToString(),
				Submittal_Title = SubmittalTitle,
				Submittal_ID = SubmittalData.GetLastSubmittalId(_projectName)
			});

		}

	}
}
