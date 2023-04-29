using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace QuizApp
{
    public partial class MainPage : ContentPage
    {
        private static string[] QUESTIONS = {
            "Do you enjoy a nice cup of coffee in the morning?",
            "Are you an early riser?",
            "Are you quick to fall asleep in the evening?",
            "Do you like taking showers in evening?",
            "Do you enjoy watching the sun rise?"
        };

        private int score = 0;
        private int index = 0;

        public MainPage()
        {
            InitializeComponent();
            btn_reset.IsVisible = false;
            renderQuestion();
        }

        private void renderQuestion() {
            if (index == QUESTIONS.Length)
            {
                btn_reset.IsVisible = true;
                btn_false.IsVisible = false;
                btn_true.IsVisible = false;
                quiz_question.Text = score > 2 ? "You are a morning person!" : "You are not a morning person...";
            }

            else {
                quiz_question.Text = QUESTIONS[index];
                btn_reset.IsVisible = false;
                btn_false.IsVisible = true;
                btn_true.IsVisible = true;
            }
        }

        private void answer(bool a) {
            score += a ? 1 : 0;
            index++;
            renderQuestion();
        }

        private void btn_true_Clicked(object sender, EventArgs e) { answer(true); }

        private void btn_false_Clicked(object sender, EventArgs e) { answer(false); }

        private void btn_reset_Clicked(object sender, EventArgs e) {
            score = 0;
            index = 0;
            renderQuestion();
        }
    }
}
