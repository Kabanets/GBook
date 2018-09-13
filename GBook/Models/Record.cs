using System;
using System.ComponentModel.DataAnnotations;

namespace GBook.Models
{
    public class Record
    {
        [Key]
        public int RecordId { get; set; }

        //User Name (цифры и буквы латинского алфавита) – обязательное поле
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\ ]*$", ErrorMessage = "Characters are not allowed.")]
        [Display(Name = "User Name")]
        public string UserName {get; set;}

        //E-mail (формат email) — обязательное поле
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string EMail { get; set; }

        //Homepage (формат url) – необязательное поле
        [Url]
        public string Homepage { get; set; }
        
        //Text (непосредственно сам текст сообщения, HTML тэги недопустимы) – обязательное поле
        [Required]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }

        //так же в базе данных сохраняются данные о IP пользователя и его браузере
        public string IP { get; set; }
        public string Browser { get; set; }

        //с возможностью сортировки по следующим полям: User Name, e-mail, и дата добавления        
        public DateTime Created { get; set; }
    }
}