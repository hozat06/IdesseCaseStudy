using IdesseCaseStudy.Models;
using IdesseCaseStudy.Models.RequestModels;
using IdesseCaseStudy.Services.CardServices;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace IdesseCaseStudy.ModelViews
{
    public class CardViewModel : BaseViewModel
    {
        private readonly ICardService cardService;
        private int totalRowCount;
        private int activeIndex = 1;
        private int limit = 10;
        private bool searchListActive = false;

        private List<Person> _serviceAllList;
        private List<Person> _searchPersonList;

        private ObservableCollection<Person> persons;
        public ObservableCollection<Person> Persons
        {
            get => persons;
            set
            {
                if (persons == value)
                {
                    persons = value;
                    OnPropertyChanged();
                }
            }
        }

        private string search;
        public string Search
        {
            get => search;
            set
            {
                if (search != value)
                {
                    search = value;
                    OnPropertyChanged();
                }
            }
        }


        /// <summary>
        /// Servisten dataları çekmek için.
        /// </summary>
        /// <returns></returns>
        private async Task GetListMobile()
        {
            IsBusy = true;

            var request = new CardGetListMobileRequestModel
            {
                IncludeVisitStats = true,
                Limit = limit,
                Start = activeIndex
            };
            var result = await cardService.GetListMobile(request);
            if (result != null && result.Success)
            {
                _serviceAllList = result.Data;
                totalRowCount = result.TotalRowCount == -1 ? result.Data.Count / limit + 1 : result.TotalRowCount;
                PersonAll();
            }

            IsBusy = false;
        }

        private void PersonAll()
        {
            IsBusy = true;

            searchListActive = false;
            activeIndex = 1;
            Persons.Clear();
            foreach (var item in _serviceAllList.Take(limit))
                Persons.Add(item);

            IsBusy = false;
        }
        private void PersonSearch()
        {
            IsBusy = true;

            if (String.IsNullOrEmpty(Search))
            {
                PersonAll();
            }
            else if (Search.Length >= 4)
            {

                _searchPersonList = _serviceAllList.Where(x => x.CardName.ToLower().Contains(Search.ToLower())
                                //|| x.CardProfessionCode.ToLower().Contains(Search.ToLower())
                                //|| x.LocationName.ToLower().Contains(Search.ToLower())
                                ).ToList();


                searchListActive = true;
                activeIndex = 1;
                Persons.Clear();
                foreach (var item in _searchPersonList.Take(limit))
                    Persons.Add(item);
            }

            IsBusy = false;
        }

        public async void LoadList(bool clear = false)
        {
            if (activeIndex == totalRowCount)
                return;

            if (IsBusy) return;

            IsBusy = true;
            await Task.Delay(2000);

            var list = searchListActive ? _searchPersonList : _serviceAllList;

            foreach (var item in list.Skip(limit * (activeIndex - 1)).Take(limit))
                Persons.Add(item);

            if (activeIndex < totalRowCount)
                activeIndex++;

            IsBusy = false;
        }

        public ICommand SearchCommand { get; set; }

        public CardViewModel()
        {
            cardService = new CardService();
            _serviceAllList = new List<Person>();
            _searchPersonList = new List<Person>();

            SearchCommand = new Command(() => PersonSearch());

            persons = new ObservableCollection<Person>();
            OnPropertyChanged(nameof(Persons));

            Device.BeginInvokeOnMainThread(async () => await GetListMobile());
        }
    }
}
