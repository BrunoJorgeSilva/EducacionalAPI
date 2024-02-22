using System.ComponentModel.DataAnnotations;

namespace EmailHub.ViewModel
{
    public class EmailModel
    {
        public string CorpoEmail { get; set; }
        [EmailAddress]
        public string EnderecoEmail { get; set; }
    }
}
