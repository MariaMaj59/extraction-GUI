using System;
using System.Windows.Forms;
using System.Numerics;
using System.Collections.Generic;

namespace SquareRoot
{
    
    public partial class MainForm : Form
    {
        public int Lang = 1; // Язык 1 - Ру 2 - En
        public MainForm()
        {
            InitializeComponent();

            SetLang.SelectedItem = "Русский";

            // Только для чтения
            ResultBox.ReadOnly = true;          // Поле вывода результата
        }

        // Извлечение кореня
        private void ExtractionButton_Click(object sender, EventArgs e)
        {
            int Decimal;            // количество знаков после запятой

            // Проверка ввода
            if (!int.TryParse(DecimalPlBox.Text, out Decimal) || Decimal < 0)
            {
                if (Lang == 1)
                    MessageBox.Show("Проверьте ввод количества знаков!");
                else if (Lang == 2)
                    MessageBox.Show("Check the input of the number of decimal places!");
            }

            // Иррациональное число
            else 
            {
                double numReal;     // действительная часть числа
                double numCom;      // иррациональная часть числа

                // Проверка ввода 
                if (!double.TryParse(RealExtBox.Text, out numReal))
                {
                    if (Lang == 1)
                        MessageBox.Show("Проверьте ввод действительного числа! ");
                    else if (Lang == 2)
                        MessageBox.Show("Check the input of a real number! ");
                }
                else if (!double.TryParse(ComplexExtBox.Text, out numCom))
                {
                    if (Lang == 1)
                        MessageBox.Show("Проверьте ввод иррационального числа! ");
                    else if (Lang == 2)
                        MessageBox.Show("Check the input of an irrational number! ");
                }
                // Рассчет
                else
                {
                    Complex minusOne = new Complex(numReal, numCom);
                    Complex result = Complex.Sqrt(minusOne);
                    // действительная часть
                    ResultBox.Text = "" + Math.Round(result.Real, Decimal);
                    // иррациональная часть
                    if (result.Imaginary > 0)
                        ResultBox.Text += " + " + Math.Round(result.Imaginary, Decimal) + " i";
                    else if (result.Imaginary < 0)
                        ResultBox.Text += " - " + Math.Round(Math.Abs(result.Imaginary), Decimal) + " i";
                }
            }
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
        }

        private void LanguageButton_Click(object sender, EventArgs e)
        {
        }

        // Закрывает все окна
        private void ExitButton_Click_1(object sender, EventArgs e)
        {
            DialogResult ExitAnswer;
            if (Lang == 1)
            {
                ExitAnswer = MessageBox.Show("Вы действительно хотите завершить работу?",
                "Завершение работы", MessageBoxButtons.YesNo);
            }
            else 
            {
                
                ExitAnswer = MessageBox.Show("Are you sure you want to quit? ",
                "Exit", MessageBoxButtons.YesNo);
            }

            if (ExitAnswer == DialogResult.Yes) //Если нажата “Да”
                Application.Exit(); // Закрыть приложение
            else if (Lang == 1)
                MessageBox.Show("Мы благодарны Вам, за то, что Вы выбрали работу с нашим приложением.");
            else if (Lang == 2)
                MessageBox.Show("We are grateful to you for choosing to work with our application.");


        }

        private void SetLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SetLang.SelectedItem.Equals("Русский"))
            {
                Lang = 1;

                Language.Text = "Язык интерфейса";
                ExitButton.Text = "Выход";
                //LengthNum.Text = "Тип числа";
                //IntLenRadio.Text = "Комплексное";
                //LongLenRadio.Text = "Длинное";
                SupportLabel.Text = "Служба поддержки:";
                Extraction.Text = "Извлечение";
                NumLabel.Text = "Число:";
                DecimalPlLabel.Text = "Необходимое количество знаков в результате:";
                ExtractionButton.Text = "Извлечь";
                ResultLabel.Text = "Результат:";
                CleanButton.Text = "Очистить поля:";
                //LongLengthLeb.Text = "Длина числа:";
            }
            else if (SetLang.SelectedItem.Equals("English"))
            {
                Lang = 2;

                Language.Text = "Interface language";
                ExitButton.Text = "Exit";
                //LengthNum.Text = "Form number";
                //IntLenRadio.Text = "Complex ";
                //LongLenRadio.Text = "Bignum";
                SupportLabel.Text = "Support:";
                Extraction.Text = "Extraction";
                NumLabel.Text = "Number:";
                DecimalPlLabel.Text = "Required number of decimal places:";
                ExtractionButton.Text = "Extract";
                ResultLabel.Text = "Result:";
                CleanButton.Text = "Clear fields";
                //LongLengthLeb.Text = "Number length :";
            }
        }

        private void RealExtBox_TextChanged(object sender, EventArgs e)
        {
            ResultBox.Text = "";
        }

        private void ComplexExtBox_TextChanged(object sender, EventArgs e)
        {
            ResultBox.Text = "";
        }

        private void DecimalPlBox_TextChanged(object sender, EventArgs e)
        {
            ResultBox.Text = "";
        }

        //Стерает информацию с полей
        private void CleanButton_Click(object sender, EventArgs e)
        {
            DialogResult ExitAnswer;
            if (Lang == 1)
            {
                ExitAnswer = MessageBox.Show("Поля будут очищены",
                "Очистка полей", MessageBoxButtons.YesNo);
            }
            else
            {

                ExitAnswer = MessageBox.Show("The fields will be cleared",
                "Cleaning the fields ", MessageBoxButtons.YesNo);
            }

            if (ExitAnswer == DialogResult.Yes) //Если нажата “Да”
            {
                ResultBox.Text = "";
                RealExtBox.Text = "";
                ComplexExtBox.Text = "";
                ResultBox.Text = "";
                DecimalPlBox.Text = "";
            }
        }
    }
}
