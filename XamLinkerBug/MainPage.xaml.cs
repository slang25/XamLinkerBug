using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace XamLinkerBug
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var list = new List<string> { "hello hello" };
            foreach (var item in list.AsQueryable().GroupBy(x => new { A = 1, B = 2 }))
            {
                output.Text = item.FirstOrDefault();
                break;
            }
        }
    }
}
