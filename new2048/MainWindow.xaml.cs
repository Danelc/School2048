using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace the2048
{
    /// <summary>
    /// all the logic for my game
    /// </summary>
    public partial class MainWindow : Window
    {
        int[,] arr = new int[4, 4];
        int[,] undo = new int[4, 4];
        double score = 0, hightscore = 0;
        int timer = 0, editing = 0, sumOfBoard = 0;
        bool lose = false, win = false, isUndone = false, isMenuOpen = false, isFirstTurn = true, editorMode = false;
        public MainWindow()
        {
            InitializeComponent();
            this.setRandom();
            this.setRandom();
            //arr[0, 0] = 4;
            //arr[2, 0] = 4;
            //arr[3, 0] = 8;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    undo[i, j] = arr[i, j];
                }
            }
            this.PrintBoard();
        }
        private void PrintBoard()
        {
            sumOfBoard = 0;
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    sumOfBoard += arr[i, j];
            progressBar1.Value = sumOfBoard;
            if (isFirstTurn == true || checkBox2.IsChecked == false || isUndone == true)
                buttonUndo.IsEnabled = false;
            else
                buttonUndo.IsEnabled = true;
            if (lose == false)
            {
                rectangle2.Opacity = 0;
                textBlock2.Opacity = 0;
            }
            if (lose == true)
            {
                buttonUndo.IsEnabled = false;
                rectangle2.Opacity = 0.7;
                textBlock2.Opacity = 1;
                textBlock2.Text = "You Lose !";
            }
            if (win == true)
            {
                rectangle2.Opacity = 0.7;
                textBlock2.Opacity = 1;
                textBlock2.Text = "You Win !";
            }
            if (checkBox1.IsChecked == true)
                textBlock4.Foreground = new SolidColorBrush(Color.FromRgb(119, 110, 101));
            if (checkBox1.IsChecked == false)
                timer = 5;
            if (timer == 20)
                textBlock4.Text = "WARNING! Button failure imimnent!";
            else if (checkBox1.IsChecked == false)
            {
                textBlock4.Foreground = Brushes.Green;
                textBlock4.Text = "Safe";
            }
            else
                textBlock4.Text = "Button falilure is expected in " + (20 - timer);
            textBlock1.Text = score.ToString();
            if (score > hightscore)
                hightscore = score;
            textBlock3.Text = hightscore.ToString();
            label1.Foreground = new SolidColorBrush(Color.FromRgb(247, 245, 240));
            label2.Foreground = new SolidColorBrush(Color.FromRgb(247, 245, 240));
            label3.Foreground = new SolidColorBrush(Color.FromRgb(247, 245, 240));
            label4.Foreground = new SolidColorBrush(Color.FromRgb(247, 245, 240));
            label4.Foreground = new SolidColorBrush(Color.FromRgb(247, 245, 240));
            label5.Foreground = new SolidColorBrush(Color.FromRgb(247, 245, 240));
            label6.Foreground = new SolidColorBrush(Color.FromRgb(247, 245, 240));
            label7.Foreground = new SolidColorBrush(Color.FromRgb(247, 245, 240));
            label8.Foreground = new SolidColorBrush(Color.FromRgb(247, 245, 240));
            label9.Foreground = new SolidColorBrush(Color.FromRgb(247, 245, 240));
            label10.Foreground = new SolidColorBrush(Color.FromRgb(247, 245, 240));
            label11.Foreground = new SolidColorBrush(Color.FromRgb(247, 245, 240));
            label12.Foreground = new SolidColorBrush(Color.FromRgb(247, 245, 240));
            label13.Foreground = new SolidColorBrush(Color.FromRgb(247, 245, 240));
            label14.Foreground = new SolidColorBrush(Color.FromRgb(247, 245, 240));
            label15.Foreground = new SolidColorBrush(Color.FromRgb(247, 245, 240));
            label16.Foreground = new SolidColorBrush(Color.FromRgb(247, 245, 240));
            if (arr[0, 0] != 0)//0,0
                label1.Content = arr[0, 0];

            else
            {
                label1.Content = " ";
                label1.Background = new SolidColorBrush(Color.FromRgb(199, 191, 175));
            }
            if (arr[0, 0] == 2)
            {
                label1.Background = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                label1.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[0, 0] == 4)
            {
                label1.Background = new SolidColorBrush(Color.FromRgb(231, 222, 198));
                label1.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[0, 0] == 8)
                label1.Background = new SolidColorBrush(Color.FromRgb(231, 176, 119));
            else if (arr[0, 0] == 16)
                label1.Background = new SolidColorBrush(Color.FromRgb(233, 147, 95));
            else if (arr[0, 0] == 32)
                label1.Background = new SolidColorBrush(Color.FromRgb(233, 125, 92));
            else if (arr[0, 0] == 64)
                label1.Background = new SolidColorBrush(Color.FromRgb(232, 91, 65));
            else if (arr[0, 0] == 128)
                label1.Background = new SolidColorBrush(Color.FromRgb(227, 208, 110));
            else if (arr[0, 0] == 256)
                label1.Background = new SolidColorBrush(Color.FromRgb(237, 204, 97));
            else if (arr[0, 0] == 512)
                label1.Background = new SolidColorBrush(Color.FromRgb(236, 200, 80));
            else if (arr[0, 0] == 1024)
                label1.Background = new SolidColorBrush(Color.FromRgb(237, 197, 63));
            else if (arr[0, 0] == 2048)
                label1.Background = new SolidColorBrush(Color.FromRgb(223, 181, 47));
            else if (arr[0, 0] != 0)
                label1.Background = new SolidColorBrush(Color.FromRgb(48, 43, 37));
            if (arr[1, 0] != 0)//1,0
                label2.Content = arr[1, 0];
            else
            {
                label2.Content = " ";
                label2.Background = new SolidColorBrush(Color.FromRgb(199, 191, 175));
            }
            if (arr[1, 0] == 2)
            {
                label2.Background = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                label2.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[1, 0] == 4)
            {
                label2.Background = new SolidColorBrush(Color.FromRgb(231, 222, 198));
                label2.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[1, 0] == 8)
                label2.Background = new SolidColorBrush(Color.FromRgb(231, 176, 119));
            else if (arr[1, 0] == 16)
                label2.Background = new SolidColorBrush(Color.FromRgb(233, 147, 95));
            else if (arr[1, 0] == 32)
                label2.Background = new SolidColorBrush(Color.FromRgb(233, 125, 92));
            else if (arr[1, 0] == 64)
                label2.Background = new SolidColorBrush(Color.FromRgb(232, 91, 65));
            else if (arr[1, 0] == 128)
                label2.Background = new SolidColorBrush(Color.FromRgb(227, 208, 110));
            else if (arr[1, 0] == 256)
                label2.Background = new SolidColorBrush(Color.FromRgb(237, 204, 97));
            else if (arr[1, 0] == 512)
                label2.Background = new SolidColorBrush(Color.FromRgb(236, 200, 80));
            else if (arr[1, 0] == 1024)
                label2.Background = new SolidColorBrush(Color.FromRgb(237, 197, 63));
            else if (arr[1, 0] == 2048)
                label2.Background = new SolidColorBrush(Color.FromRgb(223, 181, 47));
            else if (arr[1, 0] != 0)
                label2.Background = new SolidColorBrush(Color.FromRgb(48, 43, 37));
            if (arr[2, 0] != 0)//2,0
                label3.Content = arr[2, 0];
            else
            {
                label3.Content = " ";
                label3.Background = new SolidColorBrush(Color.FromRgb(199, 191, 175));
            }
            if (arr[2, 0] == 2)
            {
                label3.Background = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                label3.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[2, 0] == 4)
            {
                label3.Background = new SolidColorBrush(Color.FromRgb(231, 222, 198));
                label3.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[2, 0] == 8)
                label3.Background = new SolidColorBrush(Color.FromRgb(231, 176, 119));
            else if (arr[2, 0] == 16)
                label3.Background = new SolidColorBrush(Color.FromRgb(233, 147, 95));
            else if (arr[2, 0] == 32)
                label3.Background = new SolidColorBrush(Color.FromRgb(233, 125, 92));
            else if (arr[2, 0] == 64)
                label3.Background = new SolidColorBrush(Color.FromRgb(232, 91, 65));
            else if (arr[2, 0] == 128)
                label3.Background = new SolidColorBrush(Color.FromRgb(227, 208, 110));
            else if (arr[2, 0] == 256)
                label3.Background = new SolidColorBrush(Color.FromRgb(237, 204, 97));
            else if (arr[2, 0] == 512)
                label3.Background = new SolidColorBrush(Color.FromRgb(236, 200, 80));
            else if (arr[2, 0] == 1024)
                label3.Background = new SolidColorBrush(Color.FromRgb(237, 197, 63));
            else if (arr[2, 0] == 2048)
                label3.Background = new SolidColorBrush(Color.FromRgb(223, 181, 47));
            else if (arr[2, 0] != 0)
                label3.Background = new SolidColorBrush(Color.FromRgb(48, 43, 37));
            if (arr[3, 0] != 0)//3,0
                label4.Content = arr[3, 0];
            else
            {
                label4.Content = " ";
                label4.Background = new SolidColorBrush(Color.FromRgb(199, 191, 175));
            }
            if (arr[3, 0] == 2)
            {
                label4.Background = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                label4.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[3, 0] == 4)
            {
                label4.Background = new SolidColorBrush(Color.FromRgb(231, 222, 198));
                label4.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[3, 0] == 8)
                label4.Background = new SolidColorBrush(Color.FromRgb(231, 176, 119));
            else if (arr[3, 0] == 16)
                label4.Background = new SolidColorBrush(Color.FromRgb(233, 147, 95));
            else if (arr[3, 0] == 32)
                label4.Background = new SolidColorBrush(Color.FromRgb(233, 125, 92));
            else if (arr[3, 0] == 64)
                label4.Background = new SolidColorBrush(Color.FromRgb(232, 91, 65));
            else if (arr[3, 0] == 128)
                label4.Background = new SolidColorBrush(Color.FromRgb(227, 208, 110));
            else if (arr[3, 0] == 256)
                label4.Background = new SolidColorBrush(Color.FromRgb(237, 204, 97));
            else if (arr[3, 0] == 512)
                label4.Background = new SolidColorBrush(Color.FromRgb(236, 200, 80));
            else if (arr[3, 0] == 1024)
                label4.Background = new SolidColorBrush(Color.FromRgb(237, 197, 63));
            else if (arr[3, 0] == 2048)
                label4.Background = new SolidColorBrush(Color.FromRgb(223, 181, 47));
            else if (arr[3, 0] != 0)
                label4.Background = new SolidColorBrush(Color.FromRgb(48, 43, 37));
            if (arr[0, 1] != 0)//0,1
                label5.Content = arr[0, 1];
            else
            {
                label5.Content = " ";
                label5.Background = new SolidColorBrush(Color.FromRgb(199, 191, 175));
            }
            if (arr[0, 1] == 2)
            {
                label5.Background = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                label5.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[0, 1] == 4)
            {
                label5.Background = new SolidColorBrush(Color.FromRgb(231, 222, 198));
                label5.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[0, 1] == 8)
                label5.Background = new SolidColorBrush(Color.FromRgb(231, 176, 119));
            else if (arr[0, 1] == 16)
                label5.Background = new SolidColorBrush(Color.FromRgb(233, 147, 95));
            else if (arr[0, 1] == 32)
                label5.Background = new SolidColorBrush(Color.FromRgb(233, 125, 92));
            else if (arr[0, 1] == 64)
                label5.Background = new SolidColorBrush(Color.FromRgb(232, 91, 65));
            else if (arr[0, 1] == 128)
                label5.Background = new SolidColorBrush(Color.FromRgb(227, 208, 110));
            else if (arr[0, 1] == 256)
                label5.Background = new SolidColorBrush(Color.FromRgb(237, 204, 97));
            else if (arr[0, 1] == 512)
                label5.Background = new SolidColorBrush(Color.FromRgb(236, 200, 80));
            else if (arr[0, 1] == 1024)
                label5.Background = new SolidColorBrush(Color.FromRgb(237, 197, 63));
            else if (arr[0, 1] == 2048)
                label5.Background = new SolidColorBrush(Color.FromRgb(223, 181, 47));
            else if (arr[0, 1] != 0)
                label5.Background = new SolidColorBrush(Color.FromRgb(48, 43, 37));
            if (arr[1, 1] != 0)//1,1
                label6.Content = arr[1, 1];
            else
            {
                label6.Content = " ";
                label6.Background = new SolidColorBrush(Color.FromRgb(199, 191, 175));
            }
            if (arr[1, 1] == 2)
            {
                label6.Background = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                label6.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[1, 1] == 4)
            {
                label6.Background = new SolidColorBrush(Color.FromRgb(231, 222, 198));
                label6.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[1, 1] == 8)
                label6.Background = new SolidColorBrush(Color.FromRgb(231, 176, 119));
            else if (arr[1, 1] == 16)
                label6.Background = new SolidColorBrush(Color.FromRgb(233, 147, 95));
            else if (arr[1, 1] == 32)
                label6.Background = new SolidColorBrush(Color.FromRgb(233, 125, 92));
            else if (arr[1, 1] == 64)
                label6.Background = new SolidColorBrush(Color.FromRgb(232, 91, 65));
            else if (arr[1, 1] == 128)
                label6.Background = new SolidColorBrush(Color.FromRgb(227, 208, 110));
            else if (arr[1, 1] == 256)
                label6.Background = new SolidColorBrush(Color.FromRgb(237, 204, 97));
            else if (arr[1, 1] == 512)
                label6.Background = new SolidColorBrush(Color.FromRgb(236, 200, 80));
            else if (arr[1, 1] == 1024)
                label6.Background = new SolidColorBrush(Color.FromRgb(237, 197, 63));
            else if (arr[1, 1] == 2048)
                label6.Background = new SolidColorBrush(Color.FromRgb(223, 181, 47));
            else if (arr[1, 1] != 0)
                label6.Background = new SolidColorBrush(Color.FromRgb(48, 43, 37));
            if (arr[2, 1] != 0)//2,1
                label7.Content = arr[2, 1];
            else
            {
                label7.Content = " ";
                label7.Background = new SolidColorBrush(Color.FromRgb(199, 191, 175));
            }
            if (arr[2, 1] == 2)
            {
                label7.Background = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                label7.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[2, 1] == 4)
            {
                label7.Background = new SolidColorBrush(Color.FromRgb(231, 222, 198));
                label7.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[2, 1] == 8)
                label7.Background = new SolidColorBrush(Color.FromRgb(231, 176, 119));
            else if (arr[2, 1] == 16)
                label7.Background = new SolidColorBrush(Color.FromRgb(233, 147, 95));
            else if (arr[2, 1] == 32)
                label7.Background = new SolidColorBrush(Color.FromRgb(233, 125, 92));
            else if (arr[2, 1] == 64)
                label7.Background = new SolidColorBrush(Color.FromRgb(232, 91, 65));
            else if (arr[2, 1] == 128)
                label7.Background = new SolidColorBrush(Color.FromRgb(227, 208, 110));
            else if (arr[2, 1] == 256)
                label7.Background = new SolidColorBrush(Color.FromRgb(237, 204, 97));
            else if (arr[2, 1] == 512)
                label7.Background = new SolidColorBrush(Color.FromRgb(236, 200, 80));
            else if (arr[2, 1] == 1024)
                label7.Background = new SolidColorBrush(Color.FromRgb(237, 197, 63));
            else if (arr[2, 1] == 2048)
                label7.Background = new SolidColorBrush(Color.FromRgb(223, 181, 47));
            else if (arr[2, 1] != 0)
                label7.Background = new SolidColorBrush(Color.FromRgb(48, 43, 37));
            if (arr[3, 1] != 0)//3,1
                label8.Content = arr[3, 1];
            else
            {
                label8.Content = " ";
                label8.Background = new SolidColorBrush(Color.FromRgb(199, 191, 175));
            }
            if (arr[3, 1] == 2)
            {
                label8.Background = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                label8.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[3, 1] == 4)
            {
                label8.Background = new SolidColorBrush(Color.FromRgb(231, 222, 198));
                label8.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[3, 1] == 8)
                label8.Background = new SolidColorBrush(Color.FromRgb(231, 176, 119));
            else if (arr[3, 1] == 16)
                label8.Background = new SolidColorBrush(Color.FromRgb(233, 147, 95));
            else if (arr[3, 1] == 32)
                label8.Background = new SolidColorBrush(Color.FromRgb(233, 125, 92));
            else if (arr[3, 1] == 64)
                label8.Background = new SolidColorBrush(Color.FromRgb(232, 91, 65));
            else if (arr[3, 1] == 128)
                label8.Background = new SolidColorBrush(Color.FromRgb(227, 208, 110));
            else if (arr[3, 1] == 256)
                label8.Background = new SolidColorBrush(Color.FromRgb(237, 204, 97));
            else if (arr[3, 1] == 512)
                label8.Background = new SolidColorBrush(Color.FromRgb(236, 200, 80));
            else if (arr[3, 1] == 1024)
                label8.Background = new SolidColorBrush(Color.FromRgb(237, 197, 63));
            else if (arr[3, 1] == 2048)
                label8.Background = new SolidColorBrush(Color.FromRgb(223, 181, 47));
            else if (arr[3, 1] != 0)
                label8.Background = new SolidColorBrush(Color.FromRgb(48, 43, 37));
            if (arr[0, 2] != 0)//0,2
                label9.Content = arr[0, 2];
            else
            {
                label9.Content = " ";
                label9.Background = new SolidColorBrush(Color.FromRgb(199, 191, 175));
            }
            if (arr[0, 2] == 2)
            {
                label9.Background = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                label9.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[0, 2] == 4)
            {
                label9.Background = new SolidColorBrush(Color.FromRgb(231, 222, 198));
                label9.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[0, 2] == 8)
                label9.Background = new SolidColorBrush(Color.FromRgb(231, 176, 119));
            else if (arr[0, 2] == 16)
                label9.Background = new SolidColorBrush(Color.FromRgb(233, 147, 95));
            else if (arr[0, 2] == 32)
                label9.Background = new SolidColorBrush(Color.FromRgb(233, 125, 92));
            else if (arr[0, 2] == 64)
                label9.Background = new SolidColorBrush(Color.FromRgb(232, 91, 65));
            else if (arr[0, 2] == 128)
                label9.Background = new SolidColorBrush(Color.FromRgb(227, 208, 110));
            else if (arr[0, 2] == 256)
                label9.Background = new SolidColorBrush(Color.FromRgb(237, 204, 97));
            else if (arr[0, 2] == 512)
                label9.Background = new SolidColorBrush(Color.FromRgb(236, 200, 80));
            else if (arr[0, 2] == 1024)
                label9.Background = new SolidColorBrush(Color.FromRgb(237, 197, 63));
            else if (arr[0, 2] == 2048)
                label9.Background = new SolidColorBrush(Color.FromRgb(223, 181, 47));
            else if (arr[0, 2] != 0)
                label9.Background = new SolidColorBrush(Color.FromRgb(48, 43, 37));
            if (arr[1, 2] != 0)//1,2
                label10.Content = arr[1, 2];
            else
            {
                label10.Content = " ";
                label10.Background = new SolidColorBrush(Color.FromRgb(199, 191, 175));
            }
            if (arr[1, 2] == 2)
            {
                label10.Background = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                label10.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[1, 2] == 4)
            {
                label10.Background = new SolidColorBrush(Color.FromRgb(231, 222, 198));
                label10.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[1, 2] == 8)
                label10.Background = new SolidColorBrush(Color.FromRgb(231, 176, 119));
            else if (arr[1, 2] == 16)
                label10.Background = new SolidColorBrush(Color.FromRgb(233, 147, 95));
            else if (arr[1, 2] == 32)
                label10.Background = new SolidColorBrush(Color.FromRgb(233, 125, 92));
            else if (arr[1, 2] == 64)
                label10.Background = new SolidColorBrush(Color.FromRgb(232, 91, 65));
            else if (arr[1, 2] == 128)
                label10.Background = new SolidColorBrush(Color.FromRgb(227, 208, 110));
            else if (arr[1, 2] == 256)
                label10.Background = new SolidColorBrush(Color.FromRgb(237, 204, 97));
            else if (arr[1, 2] == 512)
                label10.Background = new SolidColorBrush(Color.FromRgb(236, 200, 80));
            else if (arr[1, 2] == 1024)
                label10.Background = new SolidColorBrush(Color.FromRgb(237, 197, 63));
            else if (arr[1, 2] == 2048)
                label10.Background = new SolidColorBrush(Color.FromRgb(223, 181, 47));
            else if (arr[1, 2] != 0)
                label10.Background = new SolidColorBrush(Color.FromRgb(48, 43, 37));
            if (arr[2, 2] != 0)//2,2
                label11.Content = arr[2, 2];
            else
            {
                label11.Content = " ";
                label11.Background = new SolidColorBrush(Color.FromRgb(199, 191, 175));
            }
            if (arr[2, 2] == 2)
            {
                label11.Background = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                label11.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[2, 2] == 4)
            {
                label11.Background = new SolidColorBrush(Color.FromRgb(231, 222, 198));
                label11.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[2, 2] == 8)
                label11.Background = new SolidColorBrush(Color.FromRgb(231, 176, 119));
            else if (arr[2, 2] == 16)
                label11.Background = new SolidColorBrush(Color.FromRgb(233, 147, 95));
            else if (arr[2, 2] == 32)
                label11.Background = new SolidColorBrush(Color.FromRgb(233, 125, 92));
            else if (arr[2, 2] == 64)
                label11.Background = new SolidColorBrush(Color.FromRgb(232, 91, 65));
            else if (arr[2, 2] == 128)
                label11.Background = new SolidColorBrush(Color.FromRgb(227, 208, 110));
            else if (arr[2, 2] == 256)
                label11.Background = new SolidColorBrush(Color.FromRgb(237, 204, 97));
            else if (arr[2, 2] == 512)
                label11.Background = new SolidColorBrush(Color.FromRgb(236, 200, 80));
            else if (arr[2, 2] == 1024)
                label11.Background = new SolidColorBrush(Color.FromRgb(237, 197, 63));
            else if (arr[2, 2] == 2048)
                label11.Background = new SolidColorBrush(Color.FromRgb(223, 181, 47));
            else if (arr[2, 2] != 0)
                label11.Background = new SolidColorBrush(Color.FromRgb(48, 43, 37));
            if (arr[3, 2] != 0)//3,2
                label12.Content = arr[3, 2];
            else
            {
                label12.Content = " ";
                label12.Background = new SolidColorBrush(Color.FromRgb(199, 191, 175));
            }
            if (arr[3, 2] == 2)
            {
                label12.Background = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                label12.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[3, 2] == 4)
            {
                label12.Background = new SolidColorBrush(Color.FromRgb(231, 222, 198));
                label12.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[3, 2] == 8)
                label12.Background = new SolidColorBrush(Color.FromRgb(231, 176, 119));
            else if (arr[3, 2] == 16)
                label12.Background = new SolidColorBrush(Color.FromRgb(233, 147, 95));
            else if (arr[3, 2] == 32)
                label12.Background = new SolidColorBrush(Color.FromRgb(233, 125, 92));
            else if (arr[3, 2] == 64)
                label12.Background = new SolidColorBrush(Color.FromRgb(232, 91, 65));
            else if (arr[3, 2] == 128)
                label12.Background = new SolidColorBrush(Color.FromRgb(227, 208, 110));
            else if (arr[3, 2] == 256)
                label12.Background = new SolidColorBrush(Color.FromRgb(237, 204, 97));
            else if (arr[3, 2] == 512)
                label12.Background = new SolidColorBrush(Color.FromRgb(236, 200, 80));
            else if (arr[3, 2] == 1024)
                label12.Background = new SolidColorBrush(Color.FromRgb(237, 197, 63));
            else if (arr[3, 2] == 2048)
                label12.Background = new SolidColorBrush(Color.FromRgb(223, 181, 47));
            else if (arr[3, 2] != 0)
                label12.Background = new SolidColorBrush(Color.FromRgb(48, 43, 37));
            if (arr[0, 3] != 0)//0,3
                label13.Content = arr[0, 3];
            else
            {
                label13.Content = " ";
                label13.Background = new SolidColorBrush(Color.FromRgb(199, 191, 175));
            }
            if (arr[0, 3] == 2)
            {
                label13.Background = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                label13.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[0, 3] == 4)
            {
                label13.Background = new SolidColorBrush(Color.FromRgb(231, 222, 198));
                label13.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[0, 3] == 8)
                label13.Background = new SolidColorBrush(Color.FromRgb(231, 176, 119));
            else if (arr[0, 3] == 16)
                label13.Background = new SolidColorBrush(Color.FromRgb(233, 147, 95));
            else if (arr[0, 3] == 32)
                label13.Background = new SolidColorBrush(Color.FromRgb(233, 125, 92));
            else if (arr[0, 3] == 64)
                label13.Background = new SolidColorBrush(Color.FromRgb(232, 91, 65));
            else if (arr[0, 3] == 128)
                label13.Background = new SolidColorBrush(Color.FromRgb(227, 208, 110));
            else if (arr[0, 3] == 256)
                label13.Background = new SolidColorBrush(Color.FromRgb(237, 204, 97));
            else if (arr[0, 3] == 512)
                label13.Background = new SolidColorBrush(Color.FromRgb(236, 200, 80));
            else if (arr[0, 3] == 1024)
                label13.Background = new SolidColorBrush(Color.FromRgb(237, 197, 63));
            else if (arr[0, 3] == 2048)
                label13.Background = new SolidColorBrush(Color.FromRgb(223, 181, 47));
            else if (arr[0, 3] != 0)
                label13.Background = new SolidColorBrush(Color.FromRgb(48, 43, 37));
            if (arr[1, 3] != 0)//1,3
                label14.Content = arr[1, 3];
            else
            {
                label14.Content = " ";
                label14.Background = new SolidColorBrush(Color.FromRgb(199, 191, 175));
            }
            if (arr[1, 3] == 2)
            {
                label14.Background = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                label14.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[1, 3] == 4)
            {
                label14.Background = new SolidColorBrush(Color.FromRgb(231, 222, 198));
                label14.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[1, 3] == 8)
                label14.Background = new SolidColorBrush(Color.FromRgb(231, 176, 119));
            else if (arr[1, 3] == 16)
                label14.Background = new SolidColorBrush(Color.FromRgb(233, 147, 95));
            else if (arr[1, 3] == 32)
                label14.Background = new SolidColorBrush(Color.FromRgb(233, 125, 92));
            else if (arr[1, 3] == 64)
                label14.Background = new SolidColorBrush(Color.FromRgb(232, 91, 65));
            else if (arr[1, 3] == 128)
                label14.Background = new SolidColorBrush(Color.FromRgb(227, 208, 110));
            else if (arr[1, 3] == 256)
                label14.Background = new SolidColorBrush(Color.FromRgb(237, 204, 97));
            else if (arr[1, 3] == 512)
                label14.Background = new SolidColorBrush(Color.FromRgb(236, 200, 80));
            else if (arr[1, 3] == 1024)
                label14.Background = new SolidColorBrush(Color.FromRgb(237, 197, 63));
            else if (arr[1, 3] == 2048)
                label14.Background = new SolidColorBrush(Color.FromRgb(223, 181, 47));
            else if (arr[1, 3] != 0)
                label14.Background = new SolidColorBrush(Color.FromRgb(48, 43, 37));
            if (arr[2, 3] != 0)//2,3
                label15.Content = arr[2, 3];
            else
            {
                label15.Content = " ";
                label15.Background = new SolidColorBrush(Color.FromRgb(199, 191, 175));
            }
            if (arr[2, 3] == 2)
            {
                label15.Background = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                label15.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[2, 3] == 4)
            {
                label15.Background = new SolidColorBrush(Color.FromRgb(231, 222, 198));
                label15.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[2, 3] == 8)
                label15.Background = new SolidColorBrush(Color.FromRgb(231, 176, 119));
            else if (arr[2, 3] == 16)
                label15.Background = new SolidColorBrush(Color.FromRgb(233, 147, 95));
            else if (arr[2, 3] == 32)
                label15.Background = new SolidColorBrush(Color.FromRgb(233, 125, 92));
            else if (arr[2, 3] == 64)
                label15.Background = new SolidColorBrush(Color.FromRgb(232, 91, 65));
            else if (arr[2, 3] == 128)
                label15.Background = new SolidColorBrush(Color.FromRgb(227, 208, 110));
            else if (arr[2, 3] == 256)
                label15.Background = new SolidColorBrush(Color.FromRgb(237, 204, 97));
            else if (arr[2, 3] == 512)
                label15.Background = new SolidColorBrush(Color.FromRgb(236, 200, 80));
            else if (arr[2, 3] == 1024)
                label15.Background = new SolidColorBrush(Color.FromRgb(237, 197, 63));
            else if (arr[2, 3] == 2048)
                label15.Background = new SolidColorBrush(Color.FromRgb(223, 181, 47));
            else if (arr[2, 3] != 0)
                label15.Background = new SolidColorBrush(Color.FromRgb(48, 43, 37));
            if (arr[3, 3] != 0)//3,3
                label16.Content = arr[3, 3];
            else
            {
                label16.Content = " ";
                label16.Background = new SolidColorBrush(Color.FromRgb(199, 191, 175));
            }
            if (arr[3, 3] == 2)
            {
                label16.Background = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                label16.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[3, 3] == 4)
            {
                label16.Background = new SolidColorBrush(Color.FromRgb(231, 222, 198));
                label16.Foreground = new SolidColorBrush(Color.FromRgb(113, 105, 95));
            }
            else if (arr[3, 3] == 8)
                label16.Background = new SolidColorBrush(Color.FromRgb(231, 176, 119));
            else if (arr[3, 3] == 16)
                label16.Background = new SolidColorBrush(Color.FromRgb(233, 147, 95));
            else if (arr[3, 3] == 32)
                label16.Background = new SolidColorBrush(Color.FromRgb(233, 125, 92));
            else if (arr[3, 3] == 64)
                label16.Background = new SolidColorBrush(Color.FromRgb(232, 91, 65));
            else if (arr[3, 3] == 128)
                label16.Background = new SolidColorBrush(Color.FromRgb(227, 208, 110));
            else if (arr[3, 3] == 256)
                label16.Background = new SolidColorBrush(Color.FromRgb(237, 204, 97));
            else if (arr[3, 3] == 512)
                label16.Background = new SolidColorBrush(Color.FromRgb(236, 200, 80));
            else if (arr[3, 3] == 1024)
                label16.Background = new SolidColorBrush(Color.FromRgb(237, 197, 63));
            else if (arr[3, 3] == 2048)
                label16.Background = new SolidColorBrush(Color.FromRgb(223, 181, 47));
            else if (arr[3, 3] != 0)
                label16.Background = new SolidColorBrush(Color.FromRgb(48, 43, 37));
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.Up) && button1.IsEnabled == true)
                doUp();
            if (Keyboard.IsKeyDown(Key.Down) && button3.IsEnabled == true)
                doDown();
            if (Keyboard.IsKeyDown(Key.Right) && button4.IsEnabled == true)
                doRight();
            if (Keyboard.IsKeyDown(Key.Left) && button2.IsEnabled == true)
                doLeft();
        }
        private void buttonU_Click(object sender, RoutedEventArgs e)
        {
            doUp();
        }
        private void setRandom()
        {
            Random rnd = new Random();
            int r = rnd.Next(0, 4), t = rnd.Next(0, 4);
            while (arr[r, t] != 0)
            {
                r = rnd.Next(0, 4);
                t = rnd.Next(0, 4);
            }
            arr[r, t] = rnd.Next(1, 3) * 2;
        }
        private void buttonL_Click(object sender, RoutedEventArgs e)
        {
            doLeft();
        }
        private void buttonD_Click(object sender, RoutedEventArgs e)
        {
            doDown();
        }
        private void buttonR_click(object sender, RoutedEventArgs e)
        {
            doRight();
        }
        private bool isBoardFull()
        {
            int q = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (arr[i, j] == 0)
                        q++;
                }
            }
            if (q == 0)
                return (true);
            return (false);
        }
        private bool is2048()
        {

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (arr[i, j] == 2048)
                        return (true);
                }
            }
            return (false);
        }
        private void buttonRestart_click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("your previus game will be descarded \nare you sure you want to start a new game ?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                isFirstTurn = true;
                Array.Clear(arr, 0, 16);
                Array.Clear(undo, 0, 16);
                setRandom();
                PrintBoard();
                score = 0;
                timer = 5;
                lose = false;
                win = false;
                textBlock2.Opacity = 0;
                rectangle2.Opacity = 0;
                buttonUndo.IsEnabled = true;
                checkBox2.IsEnabled = true;
                PrintBoard();
            }
        }
        private double scoreCal(int x)
        {
            int i = 0;
            for (int t = x; t != 1; t = t / 2)
            {
                i++;
            }
            return ((i - 1) * Math.Pow(2, i));
        }
        private int buttonFailure()
        {
            Random rnd = new Random();
            if (timer == 5)
            {
                button1.IsEnabled = true;
                button2.IsEnabled = true;
                button3.IsEnabled = true;
                button4.IsEnabled = true;
                button1.Foreground = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                button2.Foreground = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                button3.Foreground = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                button4.Foreground = new SolidColorBrush(Color.FromRgb(248, 247, 236));
                button1.Content = "^";
                button2.Content = "<";
                button3.Content = "v";
                button4.Content = ">";
                PrintBoard();
            }
            if (button1.IsEnabled == false)
            {
                button1.Foreground = Brushes.Green;
                button1.Content = 5 - timer;
            }
            if (button2.IsEnabled == false)
            {
                button2.Foreground = Brushes.Green;
                button2.Content = 5 - timer;
            }
            if (button3.IsEnabled == false)
            {
                button3.Foreground = Brushes.Green;
                button3.Content = 5 - timer;
            }
            if (button4.IsEnabled == false)
            {
                button4.Foreground = Brushes.Green;
                button4.Content = 5 - timer;
            }
            if (timer == 20)
            {
                int r = rnd.Next(1, 4);
                if (r == 1)
                {
                    button1.IsEnabled = false;
                    button1.Foreground = Brushes.Red;
                    button1.Content = "Fail";
                }
                else if (r == 2)
                {
                    button2.IsEnabled = false;
                    button2.Foreground = Brushes.Red;
                    button2.Content = "Fail";
                }
                else if (r == 3)
                {
                    button3.IsEnabled = false;
                    button3.Foreground = Brushes.Red;
                    button3.Content = "Fail";
                }
                else
                {
                    button4.IsEnabled = false;
                    button4.Foreground = Brushes.Red;
                    button4.Content = "Fail";
                }
                return (0);
            }

            return (timer + 1);

        }
        private void moveUp()
        {
            if (this.lose == false)
            {
                checkBox2.IsEnabled = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        undo[i, j] = arr[i, j];
                    }
                }
                int Temp = 0, q = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 1; j < 4; j++)
                    {
                        if ((arr[i, j - 1] == 0 || arr[i, j - 1] == arr[i, j]) && arr[i, j] != 0)
                        {
                            q++;
                            if (arr[i, j - 1] == arr[i, j])
                            {
                                Temp = (arr[i, j] * 2);
                                arr[i, j] = 0;
                                arr[i, j - 1] = Temp;
                                score += scoreCal(Temp);
                            }
                            else
                            {
                                Temp = arr[i, j];
                                arr[i, j] = 0;
                                arr[i, j - 1] = Temp;
                                if (j != 1)
                                    j = j - 2;
                            }
                        }
                    }
                }
                if (is2048() == true)
                {
                    PrintBoard();
                    MessageBox.Show("NOOOOO,this is imposible!\nyou have defeated my game!", "Winner! Winner! Winner!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    win = true;
                }
                if (isBoardFull() == true && checkMove() == false)
                {
                    MessageBox.Show("Looks like you have lost to my game!", ">:)", MessageBoxButton.OK, MessageBoxImage.Stop);
                    lose = true;
                }
                if (q != 0 && isBoardFull() == false)
                {
                    this.setRandom();
                    timer = buttonFailure();
                }
                this.PrintBoard();
            }
        }
        private void moveDown()
        {
            if (this.lose == false)
            {
                checkBox2.IsEnabled = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        undo[i, j] = arr[i, j];
                    }
                }
                int Temp = 0, q = 0;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 2; j >= 0; j--)
                    {
                        if ((arr[i, j + 1] == 0 || arr[i, j + 1] == arr[i, j]) && arr[i, j] != 0)
                        {
                            q++;
                            if (arr[i, j + 1] == arr[i, j])
                            {
                                Temp = (arr[i, j] * 2);
                                arr[i, j] = 0;
                                arr[i, j + 1] = Temp;
                                score += scoreCal(Temp);
                            }
                            else
                            {
                                Temp = arr[i, j];
                                arr[i, j] = 0;
                                arr[i, j + 1] = Temp;
                                if (j < 2)
                                    j = j + 2;
                            }
                        }
                    }
                }
                if (is2048() == true)
                {
                    PrintBoard();
                    MessageBox.Show("NOOOOO,this is imposible!\nyou have defeated my game!", "Winner! Winner! Winner!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    win = true;
                }
                if (isBoardFull() == true && checkMove() == false)
                {
                    MessageBox.Show("Looks like you have lost to my game!", ">:)", MessageBoxButton.OK, MessageBoxImage.Stop);
                    lose = true;
                }
                if (q != 0 && isBoardFull() == false)
                {
                    this.setRandom();
                    timer = buttonFailure();
                }
                this.PrintBoard();
            }
        }
        private void moveRight()
        {
            if (this.lose == false)
            {
                checkBox2.IsEnabled = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        undo[i, j] = arr[i, j];
                    }
                }
                int Temp = 0, q = 0;
                for (int i = 2; i >= 0; i--)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if ((arr[i + 1, j] == 0 || arr[i + 1, j] == arr[i, j]) && arr[i, j] != 0)
                        {
                            q++;
                            if (arr[i + 1, j] == arr[i, j])
                            {
                                Temp = (arr[i, j] * 2);
                                arr[i, j] = 0;
                                arr[i + 1, j] = Temp;
                                score += scoreCal(Temp);
                            }
                            else
                            {
                                Temp = arr[i, j];
                                arr[i, j] = 0;
                                arr[i + 1, j] = Temp;
                                if (i != 2)
                                    i++;
                                j--;
                            }
                        }
                    }
                }
                if (is2048() == true)
                {
                    PrintBoard();
                    MessageBox.Show("NOOOOO,this is imposible!\nyou have defeated my game!", "Winner! Winner! Winner!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    win = true;
                }
                if (isBoardFull() == true && checkMove() == false)
                {
                    MessageBox.Show("Looks like you have lost to my game!", ">:)", MessageBoxButton.OK, MessageBoxImage.Stop);
                    lose = true;
                }
                if (q != 0 && isBoardFull() == false)
                {
                    this.setRandom();
                    timer = buttonFailure();
                }
                this.PrintBoard();
            }
        }
        private void moveLeft()
        {
            if (this.lose == false)
            {
                checkBox2.IsEnabled = false;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        undo[i, j] = arr[i, j];
                    }
                }
                int Temp = 0, q = 0;
                for (int i = 1; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if ((arr[i - 1, j] == 0 || arr[i - 1, j] == arr[i, j]) && arr[i, j] != 0)
                        {
                            q++;
                            if (arr[i - 1, j] == arr[i, j])
                            {
                                Temp = (arr[i, j] * 2);
                                arr[i, j] = 0;
                                arr[i - 1, j] = Temp;
                                score += scoreCal(Temp);
                            }
                            else
                            {
                                Temp = arr[i, j];
                                arr[i, j] = 0;
                                arr[i - 1, j] = Temp;
                                if (i != 1)
                                    i--;
                                j--;
                            }


                        }
                    }
                }
                if (is2048() == true)
                {
                    PrintBoard();
                    MessageBox.Show("NOOOOO,this is imposible!\nyou have defeated my game!", "Winner! Winner! Winner!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    win = true;
                }
                if (isBoardFull() == true && checkMove() == false)
                {
                    MessageBox.Show("Looks like you have lost to my game!", ">:)", MessageBoxButton.OK, MessageBoxImage.Stop);
                    lose = true;
                }
                if (q != 0 && isBoardFull() == false)
                {
                    this.setRandom();
                    timer = buttonFailure();
                }
                this.PrintBoard();
            }
        }
        private bool checkMove()
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 1; j < 4; j++)
                {
                    if ((arr[i, j - 1] == 0 || arr[i, j - 1] == arr[i, j]) && arr[i, j] != 0)
                        return (true);
                }
            }
            for (int i = 0; i < 4; i++)
            {
                for (int j = 2; j >= 0; j--)
                {
                    if ((arr[i, j + 1] == 0 || arr[i, j + 1] == arr[i, j]) && arr[i, j] != 0)
                        return (true);
                }
            }
            for (int i = 2; i >= 0; i--)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((arr[i + 1, j] == 0 || arr[i + 1, j] == arr[i, j]) && arr[i, j] != 0)
                        return (true);
                }
            }
            for (int i = 1; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if ((arr[i - 1, j] == 0 || arr[i - 1, j] == arr[i, j]) && arr[i, j] != 0)
                        return (true);
                }
            }
            return (false);
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("are you sure you want to leave the game ?", "Exit", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.Cancel)
                e.Cancel = true;
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Thank you for playing and see you next time ! :D", "Good Bye!", MessageBoxButton.OK);

        }
        private void buttonUndo_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    arr[i, j] = undo[i, j];

                }
            }
            isUndone = true;
            PrintBoard();
        }
        private void doUp()
        {
            isFirstTurn = false;
            if (this.lose == false)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        undo[i, j] = arr[i, j];
                    }
                }
                int q = 0, temp = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        for (int t = j + 1; t < 4; t++)
                        {
                            if (arr[i, j] != 0)
                            {
                                if (arr[i, t] == arr[i, j])
                                {
                                    arr[i, t] = 0;
                                    arr[i, j] = arr[i, j] * 2;
                                    q++;
                                    score += scoreCal(arr[i, j]);
                                    break;
                                }
                                else if (arr[i, t] != 0)
                                {
                                    temp = arr[i, t];
                                    arr[i, t] = 0;
                                    arr[i, j + 1] = temp;
                                    if (t != j + 1)
                                        q++;
                                    break;
                                }
                            }
                            else
                            {
                                if (arr[i, t] != 0)
                                {
                                    arr[i, j] = arr[i, t];
                                    arr[i, t] = 0;
                                    j++;
                                    q++;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (q != 0)
                    checkBox2.IsEnabled = false;
                if (is2048() == true)
                {
                    PrintBoard();
                    MessageBox.Show("NOOOOO,this is imposible!\nyou have defeated my game!", "Winner! Winner! Winner!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    win = true;
                }
                if (isBoardFull() == true && checkMove() == false)
                {
                    MessageBox.Show("Looks like you have lost to my game!", ">:)", MessageBoxButton.OK, MessageBoxImage.Stop);
                    lose = true;
                }
                if (q != 0 && isBoardFull() == false)
                {
                    this.setRandom();
                    timer = buttonFailure();
                }
                this.PrintBoard();
            }
        }
        private void doDown()
        {
            isFirstTurn = false;
            if (this.lose == false)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        undo[i, j] = arr[i, j];
                    }
                }
                int temp = 0, q = 0;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 3; j >= 0; j--)
                    {
                        for (int t = j - 1; t >= 0; t--)
                        {
                            if (arr[i, j] != 0)
                            {
                                if (arr[i, t] == arr[i, j])
                                {
                                    arr[i, t] = 0;
                                    arr[i, j] = arr[i, j] * 2;
                                    q++;
                                    score += scoreCal(arr[i, j]);
                                    break;
                                }
                                else if (arr[i, t] != 0)
                                {
                                    temp = arr[i, t];
                                    arr[i, t] = 0;
                                    arr[i, j - 1] = temp;
                                    if (t != j - 1)
                                        q++;
                                    break;
                                }
                            }
                            else
                            {
                                if (arr[i, t] != 0)
                                {
                                    arr[i, j] = arr[i, t];
                                    arr[i, t] = 0;
                                    j++;
                                    q++;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (q != 0)
                    checkBox2.IsEnabled = false;
                if (is2048() == true)
                {
                    PrintBoard();
                    MessageBox.Show("NOOOOO,this is imposible!\nyou have defeated my game!", "Winner! Winner! Winner!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    win = true;
                }
                if (isBoardFull() == true && checkMove() == false)
                {
                    MessageBox.Show("Looks like you have lost to my game!", ">:)", MessageBoxButton.OK, MessageBoxImage.Stop);
                    lose = true;
                }
                if (q != 0 && isBoardFull() == false)
                {
                    this.setRandom();
                    timer = buttonFailure();
                }
                this.PrintBoard();
            }
        }
        private void doRight()
        {
            isFirstTurn = false;
            if (this.lose == false)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        undo[i, j] = arr[i, j];
                    }
                }
                int temp = 0, q = 0;
                for (int i = 3; i >= 0; i--)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        for (int t = i - 1; t >= 0; t--)
                        {
                            if (arr[i, j] != 0)
                            {
                                if (arr[t, j] == arr[i, j])
                                {
                                    arr[t, j] = 0;
                                    arr[i, j] = arr[i, j] * 2;
                                    q++;
                                    score += scoreCal(arr[i, j]);
                                    break;
                                }
                                else if (arr[t, j] != 0)
                                {
                                    temp = arr[t, j];
                                    arr[t, j] = 0;
                                    arr[i - 1, j] = temp;
                                    if (t != i - 1)
                                        q++;
                                    break;
                                }
                            }
                            else
                            {
                                if (arr[t, j] != 0)
                                {
                                    arr[i, j] = arr[t, j];
                                    arr[t, j] = 0;
                                    q++;
                                    j--;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (q != 0)
                    checkBox2.IsEnabled = false;
                if (is2048() == true)
                {
                    PrintBoard();
                    MessageBox.Show("NOOOOO,this is imposible!\nyou have defeated my game!", "Winner! Winner! Winner!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    win = true;
                }
                if (isBoardFull() == true && checkMove() == false)
                {
                    MessageBox.Show("Looks like you have lost to my game!", ">:)", MessageBoxButton.OK, MessageBoxImage.Stop);
                    lose = true;
                }
                if (q != 0 && isBoardFull() == false)
                {
                    this.setRandom();
                    timer = buttonFailure();
                }
                this.PrintBoard();
            }
        }
        private void doLeft()
        {
            isFirstTurn = false;
            if (this.lose == false)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        undo[i, j] = arr[i, j];
                    }
                }
                int temp = 0, q = 0;
                for (int i = 0; i < arr.GetLength(0); i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        for (int t = i + 1; t < 4; t++)
                        {
                            if (arr[i, j] != 0)
                            {
                                if (arr[t, j] == arr[i, j])
                                {
                                    arr[t, j] = 0;
                                    arr[i, j] = arr[i, j] * 2;
                                    q++;
                                    score += scoreCal(arr[i, j]);
                                    break;
                                }
                                else if (arr[t, j] != 0)
                                {
                                    temp = arr[t, j];
                                    arr[t, j] = 0;
                                    arr[i + 1, j] = temp;
                                    if (t != i + 1)
                                        q++;
                                    break;
                                }
                            }
                            else
                            {
                                if (arr[t, j] != 0)
                                {
                                    arr[i, j] = arr[t, j];
                                    arr[t, j] = 0;
                                    q++;
                                    j--;
                                    break;
                                }
                            }
                        }
                    }
                }
                if (q != 0)
                    checkBox2.IsEnabled = false;
                if (is2048() == true)
                {
                    PrintBoard();
                    MessageBox.Show("NOOOOO,this is imposible!\nyou have defeated my game!", "Winner! Winner! Winner!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    win = true;
                }
                if (isBoardFull() == true && checkMove() == false)
                {
                    MessageBox.Show("Looks like you have lost to my game!", ">:)", MessageBoxButton.OK, MessageBoxImage.Stop);
                    lose = true;
                }
                if (q != 0 && isBoardFull() == false)
                {
                    this.setRandom();
                    timer = buttonFailure();
                }
                this.PrintBoard();
            }
        }
        private void button7_Click(object sender, RoutedEventArgs e)
        {
            if (isMenuOpen == false)
            {
                isMenuOpen = true;
                checkBox1.Opacity = 1;
                checkBox1.IsEnabled = true;
                checkBox2.Opacity = 1;
            }
            else
            {
                isMenuOpen = false;
                checkBox1.Opacity = 0;
                checkBox1.IsEnabled = false;
                checkBox2.Opacity = 0;
            }

        }
        private void edit_button_Click(object sender, RoutedEventArgs e)
        {
            if (editorMode == false)
            {
                editorMode = true;
                edit_1.IsEnabled = true;
                edit_2.IsEnabled = true;
                edit_3.IsEnabled = true;
                edit_4.IsEnabled = true;
                edit_5.IsEnabled = true;
                edit_6.IsEnabled = true;
                edit_7.IsEnabled = true;
                edit_8.IsEnabled = true;
                edit_9.IsEnabled = true;
                edit_10.IsEnabled = true;
                edit_11.IsEnabled = true;
                edit_12.IsEnabled = true;
                edit_13.IsEnabled = true;
                edit_14.IsEnabled = true;
                edit_15.IsEnabled = true;
                edit_16.IsEnabled = true;
                editing_0.Opacity = 1;
                editing_2.Opacity = 1;
                editing_4.Opacity = 1;
                editing_8.Opacity = 1;
                editing_16.Opacity = 1;
                editing_32.Opacity = 1;
                editing_64.Opacity = 1;
                editing_128.Opacity = 1;
                editing_256.Opacity = 1;
                editing_512.Opacity = 1;
                editing_1024.Opacity = 1;
                editing_1024.Height = 35;
                editing_512.Height = 35;
            }
            else
            {
                editorMode = false;
                edit_1.IsEnabled = false;
                edit_2.IsEnabled = false;
                edit_3.IsEnabled = false;
                edit_4.IsEnabled = false;
                edit_5.IsEnabled = false;
                edit_6.IsEnabled = false;
                edit_7.IsEnabled = false;
                edit_8.IsEnabled = false;
                edit_9.IsEnabled = false;
                edit_10.IsEnabled = false;
                edit_11.IsEnabled = false;
                edit_12.IsEnabled = false;
                edit_13.IsEnabled = false;
                edit_14.IsEnabled = false;
                edit_15.IsEnabled = false;
                edit_16.IsEnabled = false;
                editing_0.Opacity = 0;
                editing_2.Opacity = 0;
                editing_4.Opacity = 0;
                editing_8.Opacity = 0;
                editing_16.Opacity = 0;
                editing_32.Opacity = 0;
                editing_64.Opacity = 0;
                editing_128.Opacity = 0;
                editing_256.Opacity = 0;
                editing_512.Opacity = 0;
                editing_1024.Opacity = 0;
                editing_1024.Height = 0;
                editing_512.Height = 0;
            }
        }
        private void editing_0_Click(object sender, RoutedEventArgs e)
        {
            editing = 0;
        }
        private void editing_2_Click(object sender, RoutedEventArgs e)
        {
            editing = 2;
        }
        private void editing_4_Click(object sender, RoutedEventArgs e)
        {
            editing = 4;
        }
        private void editing_8_Click(object sender, RoutedEventArgs e)
        {
            editing = 8;
        }
        private void editing_16_Click(object sender, RoutedEventArgs e)
        {
            editing = 16;
        }
        private void editing_32_Click(object sender, RoutedEventArgs e)
        {
            editing = 32;
        }
        private void editing_64_Click(object sender, RoutedEventArgs e)
        {
            editing = 64;
        }
        private void editing_128_Click(object sender, RoutedEventArgs e)
        {
            editing = 128;
        }
        private void editing_256_Click(object sender, RoutedEventArgs e)
        {
            editing = 256;
        }
        private void editing_512_Click(object sender, RoutedEventArgs e)
        {
            editing = 512;
        }
        private void editing_1024_Click(object sender, RoutedEventArgs e)
        {
            editing = 1024;
        }
        private void edit_1_Click(object sender, RoutedEventArgs e)
        {
            if (win == false && lose == false)
                arr[0, 0] = editing;
            PrintBoard();
        }
        private void edit_2_Click(object sender, RoutedEventArgs e)
        {
            if (win == false && lose == false)
                arr[1, 0] = editing;
            PrintBoard();
        }
        private void edit_3_Click(object sender, RoutedEventArgs e)
        {
            if (win == false && lose == false)
                arr[2, 0] = editing;
            PrintBoard();
        }
        private void edit_4_Click(object sender, RoutedEventArgs e)
        {
            if (win == false && lose == false)
                arr[3, 0] = editing;
            PrintBoard();
        }
        private void edit_5_Click(object sender, RoutedEventArgs e)
        {
            if (win == false && lose == false)
                arr[0, 1] = editing;
            PrintBoard();
        }
        private void edit_6_Click(object sender, RoutedEventArgs e)
        {
            if (win == false && lose == false)
                arr[1, 1] = editing;
            PrintBoard();
        }
        private void edit_7_Click(object sender, RoutedEventArgs e)
        {
            if (win == false && lose == false)
                arr[2, 1] = editing;
            PrintBoard();
        }
        private void edit_8_Click(object sender, RoutedEventArgs e)
        {
            if (win == false && lose == false)
                arr[3, 1] = editing;
            PrintBoard();
        }
        private void edit_9_Click(object sender, RoutedEventArgs e)
        {
            if (win == false && lose == false)
                arr[0, 2] = editing;
            PrintBoard();
        }
        private void edit_10_Click(object sender, RoutedEventArgs e)
        {
            if (win == false && lose == false)
                arr[1, 2] = editing;
            PrintBoard();
        }
        private void edit_11_Click(object sender, RoutedEventArgs e)
        {
            if (win == false && lose == false)
                arr[2, 2] = editing;
            PrintBoard();
        }
        private void edit_12_Click(object sender, RoutedEventArgs e)
        {
            if (win == false && lose == false)
                arr[3, 2] = editing;
            PrintBoard();
        }
        private void edit_13_Click(object sender, RoutedEventArgs e)
        {
            if (win == false && lose == false)
                arr[0, 3] = editing;
            PrintBoard();
        }
        private void edit_14_Click(object sender, RoutedEventArgs e)
        {
            if (win == false && lose == false)
                arr[1, 3] = editing;
            PrintBoard();
        }
        private void edit_15_Click(object sender, RoutedEventArgs e)
        {
            if (win == false && lose == false)
                arr[2, 3] = editing;
            PrintBoard();
        }
        private void edit_16_Click(object sender, RoutedEventArgs e)
        {
            if (win == false && lose == false)
                arr[3, 3] = editing;
            PrintBoard();
        }
        private void editing_2_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            editing = 2048;
        }


    }
}
