//Methods of Mathematical Modeling - Project by Krzysztof Włódarczak & Filip Wojtasik

using System;
using System.Collections.Generic;
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
using System.Windows.Threading;
using System.IO;

namespace KWFWMMMProject
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        class Pendulum
        {
            private const double g = 9.81;          //gravity                   [m/s^2]
            private double w = 0;                   //yaw angle                 [degree]
            private double w1 = 0;                  //yaw angle prim            [rad/s]
            private double m;                       //mass                      [kg]
            private double L;                       //length of the pendulum    [m]
            private double b;                       //coefficient of sticky friction
            private double j;                       //moment of inertion
            public void Set_parameters(double w, double w1, double m, double L, double b)
            {
                this.w  = w;
                this.w1 = w1;
                this.m  = m;
                this.L  = L;
                this.b  = b;
                this.j  = m * L * L / 3;
            }
            public double Get_w_deg()
            {
                return (w % (2 * Math.PI)) * 180 / Math.PI;
                //return Math.Round((((w % (2 * Math.PI)) + 2 * Math.PI) % (2 * Math.PI)) * 180 / Math.PI, 4);
            }
            public double Get_w1_deg()
            {
                return w1 * 180 / Math.PI;
            }
            public void Moving(double t, double delta_t)
            {
                //Euler method
                double w10 = w1;
                w1 = w1 + delta_t * (-t - (b * w1) + (m * g * L * Math.Sin(w)) / 2) / j;
                w = w + delta_t * w10;
                /*
                w1 = w1 + delta_t * (-t - (b * w1) + (m * g * L * Math.Sin(w)) / 2) / j;
                w = w + delta_t * w1;
                */
            }
            public void Drawing(Grid Main, SolidColorBrush color, int thickness, int r)
            {
                Line line = new Line
                {
                    Stroke = color,
                    Fill = System.Windows.Media.Brushes.White,
                    StrokeThickness = thickness,
                    X1 = 496,
                    Y1 = 151,
                    X2 = 496 + r * System.Math.Sin(w),
                    Y2 = 151 - r * System.Math.Cos(w)
                };
                Main.Children.Add(line);
            }
        }
        class Signal
        {
            private double A;                       //amplitude
            private double T;                       //period                [s]
            private double fi;                      //phase shift           [degree]
            private double Ct;                      //constant engine drive torque
            private double fill;                    //fill factor           [%]
            private double duration;                //duration of signal    [s]     
            public void Set_parameters(double A, double T, double fi, double Ct, double fill, double duration)
            {
                this.A        = A;
                this.T        = T;
                this.fi       = fi;
                this.Ct       = Ct;
                this.fill     = fill;
                this.duration = duration;
            }
            public double Get_value_of_signal(double moment_of_time, int controller)
            {
                if (moment_of_time <= duration)
                {
                    switch (controller)
                    {
                        case 0: { return Square_signal  (moment_of_time); }
                        case 1: { return Triangle_signal(moment_of_time); }
                        case 2: { return Harmonic_signal(moment_of_time); }
                    }
                }
                return 0;
            }

            private double Harmonic_signal(double moment_of_time)
            {
                return (Ct + A * Math.Sin((moment_of_time * 2 * Math.PI / T) + fi));
            }

            private double Triangle_signal(double moment_of_time)
            {
                if ((Math.Round(moment_of_time + fi * T / (2 * Math.PI), 8) % T >= 0) &&
                    (Math.Round(moment_of_time + fi * T / (2 * Math.PI), 8) % T < T / 4))           // 0 - 1/4 T
                    return (Ct + 4 * A * (Math.Round(moment_of_time + fi * T / (2 * Math.PI), 8) % T) / T);
                else if ((Math.Round(moment_of_time + fi * T / (2 * Math.PI), 8) % T >= T / 4) &&
                         (Math.Round(moment_of_time + fi * T / (2 * Math.PI), 8) % T < 3 * T / 4))   // 1/4 - 3/4 T
                    return (Ct + (2 * A - 4 * A * (Math.Round(moment_of_time + fi * T / (2 * Math.PI), 8) % T) / T));
                else
                    return (Ct + (-4 * A + 4 * A * (Math.Round(moment_of_time + fi * T / (2 * Math.PI), 8) % T) / T));
            }

            private double Square_signal(double moment_of_time)
            {
                if ((Math.Round(moment_of_time + fi * T / (2 * Math.PI), 8) % T >= 0) &&
                    (Math.Round(moment_of_time + fi * T / (2 * Math.PI), 8) % T < T * fill))
                    return (Ct + A);
                else return (Ct - A);
            }
        }

        double delta_t;
        double moment_of_time;
        double step;
        int n;
        int controller = 3;
        Pendulum MyPendulum   = new Pendulum();
        Signal MySignal       = new Signal();
        StringBuilder file    = new StringBuilder();
        DispatcherTimer timer = new DispatcherTimer();


        //Add lines to file
        private void Save_to_file(string text)
        {
            file.AppendLine(text);
            File.WriteAllText("D:\\Results.csv", file.ToString());
        }

        //Preparing all data input and titles for tabel in file
        private void Save_input_data(double w, double w1, double m, double L, double b, double Ct, double A, double T, double fill, double fi, double duration, double delta_t, double freq, int controller)
        {
            string signal = "signal";
            Save_to_file("Input_data:");
            Save_to_file("w_[deg] w1_[deg] m_[g] L_[m] b delta_t_[s] freq_[Hz] iterations_[n]");
            Save_to_file(((w + 360) % 360).ToString() + " " + w1.ToString() + " " + m.ToString() + " " + L.ToString() + " " + b.ToString() + " " + delta_t.ToString() + " " + freq.ToString() + " " + n.ToString());
            Save_to_file(" ");
            Save_to_file("About_signal:");
            switch (controller)
            {
                case 0: { signal = "Square_signal";   break; }
                case 1: { signal = "Triangle_signal"; break; }
                case 2: { signal = "Harmonic_signal"; break; }
            }
            Save_to_file("Type Ct A T_[s] fill_[%] fi_[deg] Duration_[s]");
            Save_to_file(signal + " " + Ct.ToString() + " " + A.ToString() + " " + T.ToString() + " " + fill.ToString() + " " + (fi % 360).ToString() + " " + duration.ToString());
            Save_to_file(" ");
            Save_to_file("Results_of_simulation:");
            Save_to_file("step_[n] moment_of_time_[s] t w_[deg] w1_[deg/s]");
        }

        //Preparing all parameters
        private void Accept(object sender, RoutedEventArgs e)
        {
            //Destroying existing data and position of pendulum
            file.Clear();
            MyPendulum.Drawing(Main, System.Windows.Media.Brushes.White, 6, 125);
            //Taking value of parameters from textboxes
            if ((bool)Square.IsChecked)
                controller = 0;
            else if ((bool)Triangle.IsChecked)
                controller = 1;
            else if ((bool)Harmonic.IsChecked)
                controller = 2;
            //Parsing of all input data
            if (double.TryParse(angle.Text, out double w))
                if ((double.TryParse(angular_speed.Text, out double w1)) && (w1 >= 0))
                    if ((double.TryParse(mass.Text, out double m)) && (m >= 0))
                        if ((double.TryParse(lenght.Text, out double L)) && (L >= 0))
                            if (double.TryParse(friction.Text, out double b))
                                if (double.TryParse(constant_t.Text, out double Ct))
                                    if (double.TryParse(amplitude.Text, out double A))
                                        if ((double.TryParse(period.Text, out double T)) && (T >= 0))
                                            if ((double.TryParse(fill_factor.Text, out double fill)) && (fill > 0) && (fill < 100))
                                                if (double.TryParse(phase_shift.Text, out double fi))
                                                    if ((double.TryParse(duration_of_signal.Text, out double duration)) && (duration>=0))
                                                        if ((double.TryParse(step_of_time.Text, out delta_t)) && (delta_t > 0))
                                                            if ((double.TryParse(freq_of_simulation.Text, out double freq)) && (freq > 0))
                                                                if ((int.TryParse(iterations.Text, out n)) && (n >= 0))
                                                                    if ((controller >= 0) && (controller <= 2))
                                                                    {
                                                                        Save_input_data(w, w1, m, L, b, Ct, A, T, fill, fi, duration, delta_t, freq, controller);
                                                                        //Zero iteracji oznacza wpisanie do pliku tylko stanu w chwili równej 0
                                                                        if (n >= 0)
                                                                        {
                                                                            moment_of_time = 0;
                                                                            step = 0;
                                                                            MyPendulum.Set_parameters((w % 360) * Math.PI / 180, w1 * Math.PI / 180, m, L, b);
                                                                            MySignal.Set_parameters(A, T, (fi % 360) * Math.PI / 180, Ct, fill / 100, duration);
                                                                            Save_to_file(step.ToString() + " " + moment_of_time.ToString() + " " + (Math.Round(MySignal.Get_value_of_signal(moment_of_time, controller), 4)).ToString() + " " + MyPendulum.Get_w_deg().ToString() + " " + MyPendulum.Get_w1_deg().ToString());
                                                                            Iteration_counter.Content = step;
                                                                            Iteration_counter.Content = moment_of_time;
                                                                            MyPendulum.Drawing(Main, System.Windows.Media.Brushes.DarkRed, 4, 120);
                                                                            timer.Interval = TimeSpan.FromSeconds(1 / freq);
                                                                            timer.Tick += Timer_function;
                                                                            timer.Start();
                                                                        }
                                                                    }
        }

        private void Timer_function(object sender, EventArgs e)
        {
            if (step == n)
                timer.Stop();
            else
            {
                step++;
                moment_of_time = Math.Round(moment_of_time + delta_t, 5);
                Iteration_counter.Content = step;
                Moment_of_time_counter.Content = moment_of_time;
                MyPendulum.Drawing(Main, System.Windows.Media.Brushes.White, 6, 125);
                MyPendulum.Moving(MySignal.Get_value_of_signal(moment_of_time, controller), delta_t);
                Save_to_file(step.ToString() + " " + moment_of_time.ToString() + " " + (Math.Round(MySignal.Get_value_of_signal(moment_of_time, controller), 4)).ToString() + " " + Math.Round(MyPendulum.Get_w_deg(), 4).ToString() + " " + Math.Round(MyPendulum.Get_w1_deg(), 4).ToString());
                MyPendulum.Drawing(Main, System.Windows.Media.Brushes.DarkRed, 4, 120);
            }
        }
        private void Stop_timer(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        //alternatywna wersja (0 iteracji oznacza dosłownie zero kroków)
        /*
        if (n > 0)
        {
            moment_of_time = 0;
            step = 0;
            MyPendulum.Set_parameters((w % 360) * Math.PI / 180, w1 * Math.PI / 180, m, L, b);
            MySignal.Set_parameters(A, T, (fi % 360) * Math.PI / 180, Ct, fill / 100);
            timer.Interval = TimeSpan.FromSeconds(1 / freq);
            timer.Tick += Timer_function;
            timer.Start()
        }
         */

        /*
        private void Timer_function(object sender, EventArgs e)
        {
            if (step == n)
                timer.Stop();
            else
            {
                MyPendulum.Drawing(Main, System.Windows.Media.Brushes.White, 6, 125);
                MySignal.Get_value_of_signal(moment_of_time, controller);
                Save_to_file(step.ToString() + " " + moment_of_time.ToString() + " " + (Math.Round(MySignal.Get_value_of_signal(moment_of_time, controller), 4)).ToString() + " " + MyPendulum.Get_w_deg().ToString() + " " + MyPendulum.Get_w1_deg().ToString());
                moment_of_time = Math.Round(moment_of_time + delta_t, 5);
                MyPendulum.Moving(MySignal.Get_value_of_signal(moment_of_time, controller), delta_t);
                MyPendulum.Drawing(Main, System.Windows.Media.Brushes.DarkRed, 4, 120);
                step++;
            }
        }
        */
    }
}
