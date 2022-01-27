using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test_4._0.Data;
using Test_4._0.Data.Model;

namespace TrainDEv.Pages
{
    public class SearchResultsModel : PageModel
    {
        /*(  public IList<Trainer>? Trainers { get; set; }

           IConfiguration c;
           public SearchResultsModel(IConfiguration c) => this.c = c;

           public async Task OnGetAsync()
           {
               var connectionString = c.GetConnectionString("Data Source=DESKTOP-SOFAUS2\\SQLEXPRESS;Initial Catalog=db;Integrated Security=True; Connection Timeout=180");
               var data = await Db.GetThings(connectionString);

               Trainers = data.ToList();
           }
       }

           public static class Db
           {
               public static async Task<IEnumerable<Trainer>> GetThings(string connectionString)
               {
                    using var connec = GetOpenConnection(connectionString);

               var result = await connec.QueryAsync<Trainer>(
                       @"SELECT * FROM TRAINER");

                    return result;

               }

           public static IDbConnection GetOpenConnection(string connectionString) =>
           new NpgsqlConnection(connectionString);
             */
        [TempData]

        public string KindOfInterest { get; set; }

        private readonly IDapperRepository<Trainer> _trainerDapperRepository;

        public SearchResultsModel(IDapperRepository<Trainer> trainerDapperRepository)
        {
            _trainerDapperRepository = trainerDapperRepository;
        }

        [BindProperty]
        public Trainer trainer { get; set; }
        public List<Trainer> trainers { get; set; }





        public IActionResult OnGet()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            string query = "Select * from Trainer where KindOfInterest='" + trainer.KindOfTrainer + "'";
            var list = _trainerDapperRepository.GetList(query, null);
            if (list != null)
            {
                return
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
