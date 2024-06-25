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
		private int _iteration = 1;

		public ICommand ShowStartView { get; set; }

        public MainViewViewModel()
        {
			CurrentUserControll = new StartView();
			ShowStartView = new RelayCommand(nextView);

        }

		private void nextView(object parameter) 
		{ 
			CurrentUserControll = new InformationAboutModelView();
		
		}

    }
}
