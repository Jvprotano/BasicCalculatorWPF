using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CalculadoraGa1.Model;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;

namespace CalculadoraGa1.ViewModel
{
    internal class OperacoesViewModel : INotifyPropertyChanged
    {

        #region CamposPrivados
        private decimal? _resultado;
        private ICommand _resultCommand;
        private string _operacao;
        private ICommand _getKeyboard;
        private ICommand _cleanResult;

        #endregion

        #region Propriedades
        public string Operacao
        {
            get { return _operacao; }
            set 
            {
                _operacao = value;
                RaisePropertyChange();
            }
        }

        public decimal? Resultado
        {
            get { return _resultado; }
            set 
            {
                _resultado = value;
                RaisePropertyChange();
            }
        }

        #endregion

        #region Eventos
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChange([CallerMemberName] string propertyname = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        #endregion

        #region Construtores
        public OperacoesViewModel()
        {
        }
        #endregion

        #region Métodos
        public void RecebeValores(string valores)
        {
            string corte1, corte2;
            decimal valor1 = 0, valor2 = 0;
            string[] operadores = {"+", "-", "*", "/"};
            
            for(int cont = 0; cont<operadores.Length;cont++)
            {
                if(valores.Contains(operadores[cont]))
                {
                    corte1 = valores[..valores.IndexOf(operadores[cont])];
                    corte2 = valores.Substring(valores.IndexOf(operadores[cont]) + 1, (valores.Length - corte1.Length - 1));
                    valor1 = decimal.Parse(corte1);
                    valor2 = decimal.Parse(corte2);
                }
            }

            if (valores.Contains("+"))
            {
                RealizaSoma(valor1,valor2);
            }
            else if (valores.Contains("-"))
            {
                RealizaSubtracao(valor1, valor2);
            }
            else if (valores.Contains("*"))
            {
                RealizaMultiplicacao(valor1, valor2);
            }
            else if (valores.Contains("/"))
            {
                RealizaDivisao(valor1, valor2);
            }
        }

        #region MétodosOperações
        private void RealizaDivisao(decimal valor1, decimal valor2)
        {
            Resultado = valor1 / valor2;
        }

        private void RealizaMultiplicacao(decimal valor1, decimal valor2)
        {
            Resultado = valor1 * valor2;
        }

        public void RealizaSoma(decimal valor1, decimal valor2)
        {
            Resultado = valor1 + valor2;
        }

        public void RealizaSubtracao(decimal valor1, decimal valor2)
        {
            Resultado = valor1 - valor2;

        }
        #endregion
        #endregion

        #region ICommands
        public ICommand GetKeyboard
        {
            get
            {
                return _getKeyboard ?? (_getKeyboard = new RelayCommand<string>(_GetKeyboard));
            }
        }

        public ICommand ResultCommand 
        { 
            get 
            { 
                return _resultCommand ?? (_resultCommand = new RelayCommand(_Result)); 
            }
        }

        public ICommand CleanResult
        {
            get
            {
                return _cleanResult ?? (_cleanResult = new RelayCommand(_CleanResult));
            }
        }

        #region CommandMethods
        public void _GetKeyboard(string param)
        {
            try
            {
                    Operacao += param;

            }
            catch
            {
                throw new NotImplementedException();

            }
        }

        private void _Result()
        {
            try
            {
                RecebeValores(Operacao);
                Operacao = Resultado.ToString();
            }
            catch(Exception ex)
            {
                Operacao = ex.Message;
            }
        }

        public void _CleanResult()
        {
            try
            {
                Operacao = "";
            }
            catch
            {
            }
        }
        #endregion

        #endregion

        

    }

    #region Converter
    public class ColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush cor1 = new SolidColorBrush();
            SolidColorBrush cor2 = new SolidColorBrush();
            switch (parameter)
            {
                case "TextBox":
                    cor1 = Brushes.Purple;
                    cor2 = Brushes.Transparent;
                    break;

                case "Igual":
                    cor1 = Brushes.Green;
                    cor2 = Brushes.White;
                    break;
            }
            if (value != "")
            {
                return cor1;
            }
            else
            {
                return cor2;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

}
