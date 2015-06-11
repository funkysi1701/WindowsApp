using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.ApplicationSettings;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace FSiCalc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            SettingsPane.GetForCurrentView().CommandsRequested += onCommandsRequested;
            Calc.CreateResult();

        }
        void onCommandsRequested(SettingsPane settingsPane, SettingsPaneCommandsRequestedEventArgs e)
        {
            SettingsCommand generalCommand = new SettingsCommand("about", "About",
                (handler) =>
                {
                    SettingsFlyout1 sf = new SettingsFlyout1();
                    sf.Show();
                });
            e.Request.ApplicationCommands.Add(generalCommand);

        }

        public void numberpad(int number)
        {
            if (answers.Text == "0") { answers.Text = number.ToString(); }
            else answers.Text += number;
        }
        private void quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();

        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            numberpad(7);
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            numberpad(8);
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            numberpad(9);
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            numberpad(4);
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            numberpad(5);
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            numberpad(6);
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            numberpad(1);
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            numberpad(2);
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            numberpad(3);
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            numberpad(0);
        }

        private void point_Click(object sender, RoutedEventArgs e)
        {
            answers.Text += ".";
            point.IsEnabled = false;
        }

        private void signchange_Click(object sender, RoutedEventArgs e)
        {
            answers.Text = Calc.ChangeSign(Convert.ToDouble(answers.Text)).ToString();
        }

        private void equals_Click(object sender, RoutedEventArgs e)
        {
            point.IsEnabled = true;
            Calc.Result.Add(Convert.ToDouble(answers.Text));
            Calc.Evaluate(Convert.ToDouble(Calc.Result[Calc.Result.Count - 1]), Convert.ToDouble(Calc.Result[Calc.Result.Count - 2]));
            answers.Text = Calc.ReturnResult();
        }

        private void plus_Click(object sender, RoutedEventArgs e)
        {
            point.IsEnabled = true;
            Calc.SetOperation("+");
            Calc.Result.Add(Convert.ToDouble(answers.Text));
            answers.Text = Calc.ClearResult();
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            point.IsEnabled = true;
            Calc.SetOperation("-");
            Calc.Result.Add(Convert.ToDouble(answers.Text));
            answers.Text = Calc.ClearResult();
        }

        private void multiply_Click(object sender, RoutedEventArgs e)
        {
            point.IsEnabled = true;
            Calc.SetOperation("*");
            Calc.Result.Add(Convert.ToDouble(answers.Text));
            answers.Text = Calc.ClearResult();
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            point.IsEnabled = true;
            Calc.SetOperation("/");
            Calc.Result.Add(Convert.ToDouble(answers.Text));
            answers.Text = Calc.ClearResult();
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            point.IsEnabled = true;
            Calc.Result.Add(Convert.ToDouble(answers.Text));
            answers.Text = Calc.ClearResult();
        }

        private void sqrt_Click(object sender, RoutedEventArgs e)
        {
            point.IsEnabled = true;

            Calc.Result.Add(Calc.SquareRoot(Convert.ToDouble(answers.Text)));
            answers.Text = Calc.ReturnResult();

        }
    }
}
