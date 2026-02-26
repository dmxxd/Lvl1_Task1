using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lvl1_Task1
{
    public partial class Form1 : Form
    {
        int[] numbers = new int[10]; // массив для 10 чисел
        int currentIndex = 0; // счетчик введенных чисел

        public Form1()
        {
            InitializeComponent();
        }

        // добавление числа в массив
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (currentIndex < 10)
            {
                if (int.TryParse(txtInput.Text, out int value))
                {
                    numbers[currentIndex] = value;
                    listBoxNumbers.Items.Add($"Элемент {currentIndex + 1}: {value}");
                    currentIndex++;
                    txtInput.Clear();
                    txtInput.Focus();

                    if (currentIndex == 10)
                    {
                        btnAdd.Enabled = false;
                        txtInput.Enabled = false;
                        btnCalculate.Enabled = true;
                        lblStatus.Text = "Введены все 10 чисел. Можно вычислить сумму.";
                    }
                }
                else
                {
                    MessageBox.Show("Введите корректное целое число!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // вычисление суммы элементов массива
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }

            lblResult.Text = $"Сумма всех элементов: {sum}";
            btnReset.Enabled = true;
        }

        // сброс программы
        private void btnReset_Click(object sender, EventArgs e)
        {
            numbers = new int[10];
            currentIndex = 0;
            listBoxNumbers.Items.Clear();
            txtInput.Clear();
            txtInput.Enabled = true;
            btnAdd.Enabled = true;
            btnCalculate.Enabled = false;
            btnReset.Enabled = false;
            lblResult.Text = "";
            lblStatus.Text = "Введите 10 чисел:";
            txtInput.Focus();
        }
    }
}