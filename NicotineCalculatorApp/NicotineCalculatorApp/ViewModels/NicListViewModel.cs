using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using NicotineCalculatorApp.Models;

namespace NicotineCalculatorApp.ViewModels
{
    internal class NicListViewModel
    {
        
        public ObservableCollection<NicAmount> NicAmounts { get; set; }

        public NicListViewModel()
        {
            NicAmounts = new ObservableCollection<NicAmount>();
        }

        public string NewBaseMlValue { get; set; }
        public string NewNicMgValue { get; set; }
        public string NewTargetMgValue { get; set; }
        public bool AddButtonEnabled { get; set; }

        public ICommand AddNicCommand => new Command(AddNicItem);

        void AddNicItem()
        {
            float baseMl = float.Parse(NewBaseMlValue);
            float nicShotMg = float.Parse(NewNicMgValue);
            float targetMg = float.Parse(NewTargetMgValue);

            if(targetMg < nicShotMg)
            {
                float nicShotMl = (targetMg * baseMl) / (nicShotMg - targetMg);

                string nicShotMlPrint = nicShotMl.ToString("0.00");
                string bottleMlPrint = (baseMl + nicShotMl).ToString("0.00");

                NicAmounts.Add(new NicAmount(NewNicMgValue, bottleMlPrint, nicShotMlPrint, NewTargetMgValue));
            }
        }

        public ICommand RemoveNicCommand => new Command(RemoveNicItem);

        void RemoveNicItem(object o)
        {
            NicAmount nicAmount = (NicAmount)o;
            NicAmounts.Remove(nicAmount);
        }
    }
}
