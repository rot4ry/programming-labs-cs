using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11._2
{
    public class TextBoxContent : INotifyPropertyChanged
    {
		private string _content;

		public string Content
		{
			get { return _content; }
			set
			{
				if (_content != value)
				{
					_content = value;
					PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Content"));
				}
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
    }
}
