using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Microsoft.Extensions.DependencyInjection;
using ThreePageApp.ViewModels;

namespace ThreePageApp.Views
{	
	public partial class FirstPage : ContentPage
	{	
		public FirstPage ()
		{
			InitializeComponent ();
            BindingContext = App.ServiceProvider.GetService<FirstPageVM>();
        }
	}
}

