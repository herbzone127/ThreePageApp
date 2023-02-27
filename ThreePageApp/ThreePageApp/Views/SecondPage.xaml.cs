using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using ThreePageApp.ViewModels;

namespace ThreePageApp.Views
{	
	public partial class SecondPage : ContentPage
	{	
		public SecondPage ()
		{
			InitializeComponent ();
            BindingContext = App.ServiceProvider.GetService<SecondPageVM>();
        }
	}
}

