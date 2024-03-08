using Microsoft.Maui.Controls;
using System;
using System.Windows.Input;
using ControlGallery.Views.XAML;

namespace ControlGallery
{
    public partial class MainPage : ContentPage
    {
        public ICommand NavigateCommand { get; private set; }
        public ICommand NavigateBorderCommand { get; private set; }

        public MainPage()
        {
            InitializeComponent();

            NavigateCommand = new Command<Type>(
                async (Type pageType) =>
                {
                    Page page = (Page)Activator.CreateInstance(pageType);
                    await Navigation.PushAsync(page);
                });

            NavigateBorderCommand = new Command(async () => await Navigation.PushAsync(new BorderDemoPage()));

            BindingContext = this;
        }
    }
}
