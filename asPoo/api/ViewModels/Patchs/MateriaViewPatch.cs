using Domain.Entities;

namespace api.ViewModels.Patchs
{
    public class MateriaViewPatch
    {
        public string Nome {get; set;}
        public Professor Professor{get; set;}
         public DateTime Duracao {get; set;}
       
    }
}