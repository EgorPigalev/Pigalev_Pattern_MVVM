using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Паттерн_MVVM
{
    public static class Model
    {
        // блок с данными
        public static string firstField; // Переменная для хранения значения первого поля ввода
        public static string secondlyField; // Переменная для хранения значения второго поля ввода
        public static string result = ""; // Переменная для хранения результата
        public static List<string> dataListDisplay = new List<string>() { "Сложение", "Вычитание", "Умножение", "Деление" }; // Список для выбора из comboBox
        public static List<string> dataListValue = new List<string>() { "+", "-", "*", "/" }; // Список для вывода в textBox
    }
}
