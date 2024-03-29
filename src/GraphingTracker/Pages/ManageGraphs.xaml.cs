﻿//****************************************************
//ITU project 2021 - Graphing Tracker

//@authors - Tadeas Kachyna, xkachy00@fit.vutbr.cz
//@date - 5.12.2021
//****************************************************
using GraphingTracker.Models;
using GraphingTracker.Pages;
using Xamarin.Forms;


namespace GraphingTracker
{

    public partial class ManageGraphs : ContentPage
    {
        public ManageGraphs()
        {
            InitializeComponent();

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            graph_list.ItemsSource = await App.Database.GetGraphs();

        }

        Models.Graph item;



        async void catlist_ItemSelected(System.Object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            item = e.SelectedItem as Graph;
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new GraphInfo(item) { BindingContext = e.SelectedItem });
            }
        }


        async void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new AddGraph());

        }

       
        async void TapGestureRecognizer_Tapped_Remove(System.Object sender, System.EventArgs e)
        {
            var button = sender as Image;
            var plane = button?.BindingContext as Graph;

            await App.Database.RemoveGraph(plane);
            graph_list.ItemsSource = await App.Database.GetGraphs();

        }
    }
}