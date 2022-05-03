using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using NicotineCalculatorApp.Views;

namespace NicotineCalculatorApp
{
    public partial class MainPage : ContentPage
    {
		public MainPage()
		{
			InitializeComponent();
			CalculateBtn.IsEnabled = false;

			BaseMlPicker.SelectedIndexChanged += new EventHandler(Picker_SelectIndexChanged);
			NicMgPicker.SelectedIndexChanged += new EventHandler(Picker_SelectIndexChanged);
			TargetMgPicker.SelectedIndexChanged += new EventHandler(Picker_SelectIndexChanged);

			void Picker_SelectIndexChanged(object sender, EventArgs e)
			{
				if (BaseMlPicker.SelectedIndex > -1 &&
					NicMgPicker.SelectedIndex > -1 &&
					TargetMgPicker.SelectedIndex > -1 )
				{
					baseMl = BaseMlPicker.Items[BaseMlPicker.SelectedIndex];
					nicMg = NicMgPicker.Items[NicMgPicker.SelectedIndex];
					targetMg = TargetMgPicker.Items[TargetMgPicker.SelectedIndex];

					CalculateBtn.IsEnabled = true;
				}
			}
		}

		string baseMl;
		string targetMg;
		string nicMg;

		private void CalculateBtn_Clicked(object sender, EventArgs e)
		{
			float nicMl = (float.Parse(targetMg) * (float.Parse(baseMl)-10)) / (float.Parse(nicMg) - float.Parse(targetMg));
			DisplayAlert("Nic shot ml to be added", "Add " + nicMl.ToString("0.00") + " ml To base", "OK");
		}

		private void NavBtn_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new PrecisionCalcPage());
		}
	}
}

