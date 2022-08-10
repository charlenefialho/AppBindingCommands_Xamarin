using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppBindingCommands
{
    public class MainPageViewModel : INotifyPropertyChanged  // : -> herança ou implementação de uma interface
    {
        public void ShowMessage()
        {
            string dataProperty = Application.Current.Properties["dtAtual"].ToString();
        }


        public MainPageViewModel()
        {
            ShowMessageCommand = new Command(ShowMessage);
        }



        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ICommand ShowMessageCommand;//declaração de como se fosse um "botão"  futuramente definindo sua função

        private string name = string.Empty; //CTRL, R + E

        string displayName = string.Empty;

        //public string DisplayMessage { get => displayMessage; set => displayMessage = value; }
        //ou 
        public string DisplayMessage
        {
            get => DisplayMessage;
            set
            {
                if (DisplayMessage == null)
                    return;
                DisplayMessage = value;
                OnPropertyChanged(nameof(DisplayMessage));
            }
        }

        //identação Ctrl, K + D
        public string Name
        {
            get { return name; }   //get { return name;} = get => name;
            //set => name = value; 
            set
            {
                if (name == null)
                    return;
                name = value;
                OnPropertyChanged(nameof(name));//nameof -> sinatxe para indicar qual propiedade vai modificar
                OnPropertyChanged(nameof(DisplayName));//OnPropertyChanged -> Para exibir/indicar a alteração do valor do atrbuto para exibir na tela
            }
        }


        public string DisplayName => $"Nome digitado: {Name}"; // Atalho: prop [TAB] + [TAB]

        
    }
}
