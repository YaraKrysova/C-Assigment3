using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAssigment3
{
    public partial class ViewRequestsPage : ContentPage
    {
        public ViewRequestsPage()
        {
            InitializeComponent();
            RequestsListView.ItemsSource = App.ReservationRequestManager.ReservationRequests;
        }
    }
}
