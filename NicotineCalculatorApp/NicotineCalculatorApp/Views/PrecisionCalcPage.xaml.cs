using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NicotineCalculatorApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrecisionCalcPage : ContentPage
    {
        public PrecisionCalcPage()
        {
            InitializeComponent();
            AddButton.IsEnabled = false;

            BaseMlInputField.TextChanged += new EventHandler<TextChangedEventArgs>(OnTextChange);
            NicShotMgInputField.TextChanged += new EventHandler<TextChangedEventArgs>(OnTextChange);
            TargetMgInputField.TextChanged += new EventHandler<TextChangedEventArgs>(OnTextChange);
            AddButton.Clicked += new EventHandler(OnButtonClicked);
        }  

        void OnTextChange(object sender, TextChangedEventArgs e)
        {
            float bottleml = -1, nicmg = -1, targetmg = -1;

            if (float.TryParse(BaseMlInputField.Text, out var bml))
                bottleml = float.Parse(BaseMlInputField.Text);
            if (float.TryParse(NicShotMgInputField.Text, out var nmg))
                nicmg = float.Parse(NicShotMgInputField.Text);
            if (float.TryParse(TargetMgInputField.Text, out var tmg))
                targetmg = float.Parse(TargetMgInputField.Text);

            if (bottleml > 0 && nicmg > 0 && targetmg > 0) AddButton.IsEnabled = true;
            else AddButton.IsEnabled = false;
        }

        void OnButtonClicked(object sender, EventArgs e)
        {
            if(float.Parse(TargetMgInputField.Text) >= float.Parse(NicShotMgInputField.Text))
            {
                DisplayAlert("Error", "Target mg/ml cannot be greater than or equal to NicShot mg/ml", "OK");
                NicShotMgInputField.Text = String.Empty;
                TargetMgInputField.Text = String.Empty;
            }
            else
            {
                BaseMlInputField.Text = String.Empty;
                NicShotMgInputField.Text = String.Empty;
                TargetMgInputField.Text = String.Empty;
            }
        }
    }
}