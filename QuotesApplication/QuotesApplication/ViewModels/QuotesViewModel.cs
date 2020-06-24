using Newtonsoft.Json;
using QuotesApplication.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;

namespace QuotesApplication.ViewModels
{
    public class QuotesViewModel : BaseViewModel
    {
        public ObservableCollection<Quote> Quotes { get; set; }
        public QuotesViewModel()
        {
            Quotes = new ObservableCollection<Quote>();
            LoadQuotes();
        }

        public async void LoadQuotes()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://quotessamplerestfulwebapi.azurewebsites.net/api/quotes");
            var quotes = JsonConvert.DeserializeObject<List<Quote>>(response);
            //LvQuotes.ItemsSource = quotes;
            foreach(var quote in quotes)
            {
                Quotes.Add(quote);
            }

        }
    }

}
