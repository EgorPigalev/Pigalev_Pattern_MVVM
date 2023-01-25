using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows;

namespace Паттерн_MVVM
{
    class ViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstField // Свойство для заполнение значения первого поля
        {
            set
            {
                Model.firstField = value;
            }
        }
        public string SecondlyField // Свойство для заполнение значения второго поля
        {
            set
            {
                Model.secondlyField = value;
            }
        }

        public string ResultChange // Свойство для отображения результата вычисления в TextBlock
        {
            get
            {
                return Model.result.ToString();
            }
        }

        public List<String> ComboChange  // Свойство для заполнения Combobox
        {
            get
            {
                return Model.dataListDisplay;
            }
        }
        int cbIndex = -1;
        public int IndexSelected // свойство для нахождения индекса выбранного в Combobox элемента
        {
            set
            {
                // индек - это необходимое значение, которое нужно получить
                cbIndex = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CBIndex"));  // событие, которое реагирует на изменение свойства
            }
        }

        public string CBIndex // Свойство для отображения выбранной арифметической операции
        {
            get
            {
                if (cbIndex == -1)
                {
                    return "";
                }
                else
                {
                    return Model.dataListValue[cbIndex];
                }
            }
        }

        public RoutedCommand Command { get; set; } = new RoutedCommand();

        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                double numberFirst = 0; // Переменная, которая хранит числовое значение первого поля
                double numberSecondly = 0; // Переменная, которая хранит числовое значение второго поля
                if (Model.firstField != "")
                {
                    numberFirst = Convert.ToDouble(Model.firstField);
                }
                if (Model.secondlyField != "")
                {
                    numberSecondly = Convert.ToDouble(Model.secondlyField);
                }
                switch (cbIndex)
                {
                    case -1:
                        MessageBox.Show("Арифметическая операция не выбрана");
                        return;
                    case 0:
                        Model.result = Convert.ToString(numberFirst + numberSecondly);
                        break;
                    case 1:
                        Model.result = Convert.ToString(numberFirst - numberSecondly);
                        break;
                    case 2:
                        Model.result = Convert.ToString(numberFirst * numberSecondly);
                        break;
                    case 3:
                        if (numberSecondly == 0)
                        {
                            Model.result = "Деление на 0 (ноль) не допустимо";
                        }
                        else
                        {
                            Model.result = Convert.ToString(numberFirst / numberSecondly);
                        }
                        break;
                    default:
                        MessageBox.Show("При расчёте возникла ошибка");
                        return;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("ResultChange"));
            }
            catch
            {
                MessageBox.Show("При вычисление арифметической операции возникла ошибка");
            }
        }
        public CommandBinding bind;
        public ViewModel()
        {
            bind = new CommandBinding(Command);
            bind.Executed += Command_Executed;
        }
    }
}
