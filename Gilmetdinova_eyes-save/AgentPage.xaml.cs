using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gilmetdinova_eyes_save
{
    /// <summary>
    /// Логика взаимодействия для AgentPage.xaml
    /// </summary>
    public partial class AgentPage : Page
    {
        public AgentPage()
        {
            InitializeComponent();

            var currentAgent = Gilmetdinova_eyesEntities.GetContext().Agent.ToList();
            AgentListView.ItemsSource = currentAgent;


            ComboType2.SelectedIndex = 0;
            ComboType.SelectedIndex = 0;
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            UpdateAgent();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAgent();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgent();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            UpdateAgent();
        }

        private void RButtonUp_Checked(object sender, RoutedEventArgs e)
        {
            UpdateAgent();
        }

        private void RButtonDown_Checked(object sender, RoutedEventArgs e)
        {
            UpdateAgent();
        }

        private void UpdateAgent()
        {
            var currentAgent = Gilmetdinova_eyesEntities.GetContext().Agent.ToList();

            if(ComboType.SelectedIndex == 0)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeID >= 1 && p.AgentTypeID <= 6)).ToList();
            }

            if (ComboType.SelectedIndex == 1)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeID==1)).ToList();
            }

            if (ComboType.SelectedIndex == 2)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeID == 2)).ToList();
            }

            if (ComboType.SelectedIndex == 3)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeID == 3)).ToList();
            }

            if (ComboType.SelectedIndex == 4)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeID ==4)).ToList();
            }

            if (ComboType.SelectedIndex == 5)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeID ==5)).ToList();
            }

            if (ComboType.SelectedIndex == 6)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeID ==6)).ToList();
            }

   
          

            if (ComboType2.SelectedIndex == 0)
            {
                currentAgent = currentAgent.Where(p => (p.AgentTypeID >= 1 && p.AgentTypeID <= 6)).ToList();
            }

            if (ComboType2.SelectedIndex == 1)
            {
                currentAgent = currentAgent.OrderByDescending(p => p.Priority).ToList();
            }

            if (ComboType2.SelectedIndex == 2)
            {
                currentAgent = currentAgent.OrderBy(p => p.Priority).ToList();
            }

            if (ComboType2.SelectedIndex == 3)
            {
                currentAgent = currentAgent.OrderByDescending(p => p.Title).ToList();
            }

            if (ComboType2.SelectedIndex == 4)
            {
                currentAgent = currentAgent.OrderBy(p => p.Title).ToList();
            }

            if (ComboType2.SelectedIndex == 5)
            {
              //  currentAgent = currentAgent.OrderByDescending(p => p.Скидка).ToList();
            }

            if (ComboType2.SelectedIndex == 6)
            {
             //   currentAgent = currentAgent.OrderBy(p => p.Скидка).ToList();
            }
           

            currentAgent = currentAgent.Where(p =>
            p.Title.ToLower().Contains(TBoxSearch.Text.ToLower()) || p.Phone.Replace("+7", "7").Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "").Contains(TBoxSearch.Text.Replace("+7", "8").Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "")) || p.Email.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            AgentListView.ItemsSource = currentAgent;
        }

        private void ComboType2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgent();
        }
    }
}
