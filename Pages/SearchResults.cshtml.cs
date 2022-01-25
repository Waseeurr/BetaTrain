using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test_4._0.Data;
using Test_4._0.Data.Model;

namespace TrainDEv.Pages
{
    public class SearchResultsModel : PageModel
    {
        private readonly IDapperRepository<Trainer> _trainerDapperRepository;

        public SearchResultsModel(IDapperRepository<Trainer> trainerDapperRepository)
        {
            _trainerDapperRepository = trainerDapperRepository;
            

        }

       
        public void OnGet()
        {
            string sql = "";
        }
    }
}
