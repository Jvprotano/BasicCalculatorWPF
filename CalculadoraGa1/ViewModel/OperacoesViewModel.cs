using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private ListItem _listItem;

        #endregion

        #region Propriedades
        public ListItem ListItem
        {
            get { return _listItem; }
            set
            {
                _listItem = value;
                RaisePropertyChange();
            }
        }
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
                return _getKeyboard ?? (_getKeyboard = new RelayCommand<string>(_GetKeyboardCommand));
            }
        }

        public ICommand ResultCommand 
        { 
            get 
            { 
                return _resultCommand ?? (_resultCommand = new RelayCommand(_ResultCommand)); 
            }
        }

        public ICommand CleanResult
        {
            get
            {
                return _cleanResult ?? (_cleanResult = new RelayCommand(_CleanResultCommand));
            }
        }

        #region CommandMethods
        public void _GetKeyboardCommand(string param)
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

        private void _ResultCommand()
        {
            try
            {
                RecebeValores(Operacao);
                var stringHistorico = new ListItem(Operacao, Resultado.ToString());
                ListItem = stringHistorico;
                Operacao = Resultado.ToString();
            }
            catch (Exception ex)
            {
                Operacao = ex.Message;
            }
        }

        public void _CleanResultCommand()
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
}
