using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace JokesWebApp_MVC.Models
{
    public class Joke
    {
        
        public int Id { get; set; }
        public string JokeQuestion { get; set; }
        public string JokeAnswer { get; set; }
        public string User { get; set; }
        

        public Joke()
        {
            
        }

    }
}
