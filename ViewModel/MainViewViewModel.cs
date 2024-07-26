using PrepareSubmittalTool.DB.Data;
using PrepareSubmittalTool.Model;
using PrepareSubmittalTool.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PrepareSubmittalTool.ViewModel
{
    public class MainViewViewModel : BaseViewModel
    {
		private UserControl _currentUserControl;

		public UserControl CurrentUserControll	
		{
			get 
			{
				return _currentUserControl;
			}
			set 
			{
				if (_currentUserControl != value) 
				{
					_currentUserControl = value;
					OnPropertyChanged();
                }
            }
		}

		private int iteration = 1;
		public ICommand ShowStartView { get; set; }

        public MainViewViewModel()
        {
			CurrentUserControll = new StartView();
			ShowStartView = new RelayCommand(nextView);
        }

		private void nextView(object parameter) 
		{ 
			if (iteration == 1)
			{
                CurrentUserControll = new InformationAboutModelView();
            }
			if(iteration == 2) 
			{ 
				CurrentUserControll = new ListingElementsView();
            }
			if(iteration == 3) 
			{
                TemporaryFields.readSelectedDrawigs();
                CurrentUserControll = new ListingDrawingsRevisonView();
            }
            iteration++;
        }

    }
}
