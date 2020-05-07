using ApiLibary;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WebAPIFetcherClientTest.Models;

namespace WebAPIFetcherClientTest.ViewModel
{

    public class MainViewModel : ViewModelBase
    {

        //-------------------------------------------------- Model
        private MainModel mainModel = new MainModel();
        //-------------------------------------------------- Interfaces
        //-------------------------------------------------- ICommands
        public ICommand FetchUserCommand => new RelayCommand(async () => await SetPersonlist(IdInput));
        public ICommand FetchAllUsersCommand => new RelayCommand(async () => await SetPersonlist());

        public ICommand ResetCommand => new RelayCommand(ResetList);
        //-------------------------------------------------- Constructor

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {

        }

        //-------------------------------------------------- Properties

        /// <summary>
        /// The list containing the user
        /// </summary>
        public ObservableCollection<string> PersonList
        {
            get => mainModel._personList;
            set => Set(ref mainModel._personList, value);
        }

        /// <summary>
        /// An ID from the WebApi List
        /// </summary>
        public int IdInput
        {
            get => mainModel._IdInput;
            set
            {
                Set(ref mainModel._IdInput, value);
            }
        }
        //-------------------------------------------------- Methods

        /// <summary>
        /// Async task to fetch a person
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task SetPersonlist(int value)
        {
            var person = await new DataProcessor().GetPerson(value);

            if(person != null)
            {
                if(!PersonList.Contains(person.Name))
                {
                    PersonList.Add(person.Name);
                }
            }
            else
            {
                MessageBox.Show("Invalid user ID, please enter an valid ID for a user.",
                               "Company Broker - User ID error",
                               MessageBoxButton.OK,
                               MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Async task to fetch all persons
        /// </summary>
        /// <returns></returns>
        public async Task SetPersonlist()
        {
            var allPersonList = await new DataProcessor().GetAllPersons();

            foreach (var person in allPersonList)
            {
                if (!PersonList.Contains(person.Name))
                {
                    PersonList.Add(person.Name);
                }
            }
        }

        /// <summary>
        /// Resets the list
        /// </summary>
        public void ResetList()
        {
            PersonList = new ObservableCollection<string>();
        }
    }
}