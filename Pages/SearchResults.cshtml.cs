using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test_4._0.Data;
using Test_4._0.Data.Model;
using Dapper;
using System.Data.SqlClient;

namespace TrainDEv.Pages
{
    public class SearchResultsModel : PageModel
    {
        [TempData]

        public string Message { get; set; }

        public string UserType { get; set; }

        //private readonly IDapperRepository<PrivacyUser> _userDapperRepository;
        private readonly IDapperRepository<Trainee> _traineeDapperRepository;
        private readonly IDapperRepository<Trainer> _trainerDapperRepository;
        private object FiddleHelper;

        /*  public SearchResultsModel(IDapperRepository<PrivacyUser> userDapperRepository, IDapperRepository<Trainee> traineeDapperRepository, IDapperRepository<Trainer> trainerDapperRepository)
          {
             // _userDapperRepository = userDapperRepository;
              _traineeDapperRepository = traineeDapperRepository;
              _trainerDapperRepository = trainerDapperRepository;
          }*/

        public SearchResultsModel(IDapperRepository<Trainer> trainerDapperRepository)
        {
            _trainerDapperRepository = trainerDapperRepository;
        }

        [BindProperty]

        public IList<Trainer> trainer { get; set; }
        public Trainer trainers { get; set; }



        public async Task OnGet()
        {
            string query = "Select * from Trainer ";

            var myConnString = "Data Source=DESKTOP-SOFAUS2\\SQLEXPRESS;Initial Catalog=db;Integrated Security=True; Connection Timeout=180";

            using var connection = new SqlConnection(myConnString);

            return connection.Query<string>("Select * from Trainer").FirstOrDefault(

        }

        public async Task<IActionResult> OnPostAsync()
        {
            




        }
    }
}


       

    

