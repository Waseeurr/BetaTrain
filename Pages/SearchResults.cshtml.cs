using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test_4._0.Data;
using Test_4._0.Data.Model;
using Dapper;
namespace TrainDEv.Pages
{
    public class SearchResultsModel : PageModel
    {
        [TempData]

        public string Message { get; set; }

        public string UserType { get; set; }

        private readonly IDapperRepository<PrivacyUser> _userDapperRepository;
        private readonly IDapperRepository<Trainee> _traineeDapperRepository;
        private readonly IDapperRepository<Trainer> _trainerDapperRepository;

        public SearchResultsModel(IDapperRepository<PrivacyUser> userDapperRepository, IDapperRepository<Trainee> traineeDapperRepository, IDapperRepository<Trainer> trainerDapperRepository)
        {
            _userDapperRepository = userDapperRepository;
            _traineeDapperRepository = traineeDapperRepository;
            _trainerDapperRepository = trainerDapperRepository;
        }

        [BindProperty]

        public IList<Trainer> trainer { get; set; }
        public Trainer trainers { get; set; }



        public IActionResult OnGet()
        {
            return Page();

        }

        public IActionResult OnPostSave()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            string query = "Select * from Trainer where KindOfTrainer=''" + trainers.KindOfTrainer ;
            var list = _userDapperRepository.GetList(query, null);


            return Page();
        }
    }
}
