﻿//****************************************************
//ITU project 2021 - Graphing Tracker

//@authors - Lukas Hais, xhaisl00@fit.vutbr.cz
//         - Tadeas Kachyna, xkachy00@fit.vutbr.cz
//@date - 5.12.2021
//****************************************************
using Xamarin.Forms;
using GraphingTracker.Models;

namespace GraphingTracker
{
    public partial class AddItem : ContentPage
    {
        private ItemCategory _itemCategory;

        public AddItem(ItemCategory itemCategory)
        {
            InitializeComponent();
            _itemCategory = itemCategory;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            picker_unit.ItemsSource = await App.Database.GetUnitsForCategory(_itemCategory.UnitCategoryId);
            picker_unit.SelectedIndex = 0;
        }

        async void Button_Clicked_2(System.Object sender, System.EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(entry_name.Text) && !string.IsNullOrWhiteSpace(unit_value.Text))
            {
                await App.Database.SaveItem(new Models.Item
                {
                    Value = float.Parse(unit_value.Text),
                    Name = entry_name.Text,
                    UnitId = ((Models.Unit) picker_unit.SelectedItem).Id,
                    ItemCategoryId = _itemCategory.Id,
                    UnitCategoryId = _itemCategory.UnitCategoryId
                });

                name.Text = string.Empty;
                await Navigation.PopAsync();

            };
        }

        void Button_Clicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }

    }
}
