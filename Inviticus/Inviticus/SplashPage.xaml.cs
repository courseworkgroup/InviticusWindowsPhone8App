using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO;
using System.Threading.Tasks;

namespace Inviticus
{
    public partial class SplashPage : PhoneApplicationPage
    {
       
        public SplashPage()
        {
            InitializeComponent();
            Loaded += SplashPage_Loaded;
        }

         async void SplashPage_Loaded(object sender, RoutedEventArgs e)
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
              NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
         
        }
       
                      
                   
                
            
        
    }
}